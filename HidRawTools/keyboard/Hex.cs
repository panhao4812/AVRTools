using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidRawTools.keyboard
{
    public class Hex
    {

        public Hex()
        {
            data = new List<ushort>();
        }
        public Hex(List<string> _data)
        {
            data = new List<ushort>();
            for (int i = 0; i < _data.Count; i++)
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
        public string Write(int address, int end)
        {

            string output = "";
            for (int i = 0; i < data.Count; i += 8)
            {
                if (address >= end - 16) break;
                string buffer1 = ":10";
                buffer1 += Convert.ToString(address, 16).PadLeft(4, '0');
                buffer1 += "00";
                for (int j = 0; j < 8; j++)
                {
                    int index = i + j;
                    if (index < data.Count)
                    {
                        char[] bytes = Convert.ToString(data[index], 16).PadLeft(4, '0').ToArray();
                        char[] bytes2 = { bytes[2], bytes[3], bytes[0], bytes[1] };
                        string str = new string(bytes2);
                        buffer1 += str;
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
            for (int i = 1; i < data1.Length; i += 2)
            {
                string str = "0x";
                str += data1[i]; str += data1[i + 1];
                int a = Convert.ToInt32(str, 16);
                regi += a;
            }
            regi = 0x100 - regi % 0x100;
            if (regi == 0x100) regi = 0;
            return Convert.ToString(regi, 16).PadLeft(2, '0');
        }
        public void DataFromString(string input)
        {
            char[] data1 = input.ToCharArray();
            if (data1[0] != ':') return;
            if (data1.Length < 15) return;
            for (int i = 9; i <= data1.Length - 6; i += 4)
            {
                string str = "0x";
                str += data1[i]; str += data1[i + 1];
                str += data1[i + 2]; str += data1[i + 3];
                int a = Convert.ToInt32(str, 16);
                data.Add(Convert.ToUInt16(a));
            }
        }
    }
}
