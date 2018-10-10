using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidRawTools
{
    partial class HidRawTools { 
    public ushort ConvertChinese1(char str, string code)
    {
        string str2 = Convert.ToString(str);
        byte[] data; ushort a3;
        if (code == "GBK")
        {
            return ConvertChinese2(str, code);
        }
        else if (code == "Default")
        {
            data = Encoding.Default.GetBytes(str2);
            string Data1 = data[0].ToString("x"); if (Data1.Length == 1) Data1 = "0" + Data1;
            string Data2 = data[1].ToString("x"); if (Data2.Length == 1) Data2 = "0" + Data2;
            str2 = Data1 + Data2;
            a3 = Convert.ToUInt16(str2, 16);
            return a3;
        }
        else if (code == "Unicode")
        {
            data = Encoding.Unicode.GetBytes(str2);
        }
        else if (code == "UTF8")
        {
            data = Encoding.UTF8.GetBytes(str2);
        }
        else { Print("encoding error"); return 0; }
        string data1 = data[1].ToString("x"); if (data1.Length == 1) data1 = "0" + data1;
        string data2 = data[0].ToString("x"); if (data2.Length == 1) data2 = "0" + data2;
        str2 = data1 + data2;
        a3 = Convert.ToUInt16(str2, 16);
        return a3;
    }
    public ushort ConvertChinese2(char str, string code)
    {
        string str2 = Convert.ToString(str);
        byte[] data = Encoding.GetEncoding(code).GetBytes(str2);
        string Data1 = data[0].ToString("x"); if (Data1.Length == 1) Data1 = "0" + Data1;
        string Data2 = data[1].ToString("x"); if (Data2.Length == 1) Data2 = "0" + Data2;
        str2 = Data1 + Data2;
        ushort a3 = Convert.ToUInt16(str2, 16);
        return a3;
    }
    private void Encode(string _code)
        {
            try
            {
                //Clear();
                CodeTemp = "";
                char[] ch = PrintBox.Text.ToArray();
                if (ch == null || ch.Length == 0)
                {
                    CodeTemp += "0";
                    Print("Uploading RGB parameter!Nothing for printing!");
                    return;
                }
                // Print("English 0-127 GBK > " + 0x8080);
                addr = 0;
                if (textBox4.Text != "" && textBox4.Text != null)
                {
                    addr = Convert.ToInt32(textBox4.Text);
                }
                Print("Uploading address=" + addr.ToString());
                int length = ch.Length;
                string output = "";
                int length2 = length;
                for (int j = 0; j < length; j++)
                {
                    if (ch[j] < 127 && ch[j] >= 0)
                    {
                        int code = Program.ascii_to_scan_code_table[(int)ch[j]];
                        if (code != 0)
                        {
                            output += code.ToString();
                            if (j != length - 1) output += ",";
                        }
                        else
                        {
                            length2--;
                        }
                    }
                    else if (ch[j] <= 0xFFFF)
                    {
                        //汉字                     
                        ushort a3 = ConvertChinese1(ch[j], _code);
                        output += a3.ToString();
                        //Printhex((int)a3);
                        if (j != length - 1) output += ",";
                    }
                }

                CodeTemp += length2.ToString() + ",";
                CodeTemp += output;
                Print(CodeTemp);
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
    }
    public class Hex
    {
        public Hex() {
            data = new List<ushort>();
        }
        public Hex(List<string>_data)
        {
            data = new List<ushort>();
            for(int i = 0; i < _data.Count; i++)
            {
                data.Add(Convert.ToUInt16(_data[i]));
            }
        }
        public Hex(string[] _data)
        {
            data = new List<ushort>();
            for (int i = 0; i < _data.Length; i++)
            {
                data.Add(Convert.ToUInt16(_data[i]));
            }
        }
        public List<ushort> data;
        public string Write(int address)
        {
            string output = "";            
            for (int i = 0; i < data.Count; i += 8)
            {
                string buffer1 = ":10";
                buffer1 += Convert.ToString(address, 16).PadLeft(4, '0');
                buffer1 += "00";
                for (int j = 0; j < 8; j++) {
                    int index = i  + j;
                    if (index < data.Count) {
                        buffer1 += Convert.ToString(data[index], 16).PadLeft(4, '0');                   
                    }
                    else { buffer1 += "0000"; }                                      
                    }
                buffer1 += Hex.Tail(buffer1);
                  output += buffer1 + "\r\n";
                address += 16;
            }
            output += ":00000001FF";
            return output;
        }
        public static string Tail(string input)
        {
            char[] data1 = input.ToCharArray();
            if (data1[0] != ':') return "FF";
            int regi = 0;
            for (int i = 1; i <data1.Length; i += 2)
            {
                string str = "0x";
                str += data1[i]; str += data1[i + 1];
                int a = Convert.ToInt32(str, 16);
                regi += a;
            }
            regi = 0x100 - regi % 0x100;
            return Convert.ToString(regi, 16).PadLeft(2, '0');
        }
        public void DataFromString(string input)
        {
            char[] data1 = input.ToCharArray();
                if (data1[0] != ':') return;
            if (data1.Length<15) return;
            for (int i=9;i<= data1.Length - 6; i+=4)
            {
                string str = "0x";
                str += data1[i]; str += data1[i+1];
                str += data1[i+2]; str += data1[i + 3];
                int a = Convert.ToInt32(str, 16);
                data.Add(Convert.ToUInt16(a));
            }
        }

    }
}
