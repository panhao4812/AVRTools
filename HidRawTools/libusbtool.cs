using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace HidRawTools
{
    public partial class libusbtool : Form
    {
        string vid, pid, eepromsize;
        public static HidDevice HidDevice;
        public libusbtool()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            textBox3.Text = "";
        }
        public void Print(Object str)
        {
            textBox3.Text += str.ToString() + "\r\n";
        }
        private void libusbtool_FormClosing(object sender, FormClosingEventArgs e)
        {
            string str = Environment.CurrentDirectory + "\\EEPROMtools.conf";
            saveOptions(str);
        }
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
        private void loadOptions(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamReader srd = new StreamReader(fs);
                for (int k = 0; k < 4; k++)
                {
                    string str = srd.ReadLine();
                    string[] chara3 = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (chara3[0] == "eepromsize") eepbox.Text = chara3[1];
                    if (chara3[0] == "address") addbox.Text = chara3[1];
                    if (chara3[0] == "vid") vidbox.Text = chara3[1];
                    if (chara3[0] == "pid") pidbox.Text = chara3[1];
                }
                while (srd.Peek() != -1)
                {
                    textBox1.Text += srd.ReadLine() + "\r\n";
                }
                srd.Close();
            }
            catch { }
        }
        private void saveOptions(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.SetLength(0);
                StreamWriter stream = new StreamWriter(fs);
                stream.WriteLine("eepromsize," + eepbox.Text);
                stream.WriteLine("address," + addbox.Text);
                stream.WriteLine("vid," + vidbox.Text);
                stream.WriteLine("pid," + pidbox.Text);
                stream.Write(textBox1.Text);
                stream.Flush();
                stream.Close();
            }
            catch { }
        }
        private void OpenDevice()
        {
            if (vidbox.Text.Length == 0 || pidbox.Text.Length == 0||
                eepbox.Text.Length==0||addbox.Text.Length==0)
            {
                Clear();
                Print("vid or pid error. Try open again");
                return;
            }
            vid = vidbox.Text;
            pid = pidbox.Text;
            eepromsize = eepbox.Text;
            Print("vid:" + vidbox.Text.ToString());
            Print("pid:" + pidbox.Text.ToString());
            Print("eepromsize=" + eepromsize.ToString());
            try
            {
                HidDevice[] HidDeviceList = HidDevices.Enumerate(Convert.ToInt32(vid, 16), Convert.ToInt32(pid, 16), (ushort)0xFF31).ToArray();
                if (HidDeviceList == null || HidDeviceList.Length == 0)
                {
                    Clear();
                    Print("Device not found.Try open again!");
                    return;
                }
                for (int i = 0; i < HidDeviceList.Length; i++)
                {
                    Print(HidDeviceList[i].ToString());
                }
                if (HidDeviceList[0] == null)
                {
                    Clear();
                    Print("Device not found. Try open again!");
                    return;
                }
                HidDevice = HidDeviceList[0];
                Clear();
                Print("Device OK");
                Print("vid: 0x" + vid);
                Print("pid: 0x" + pid);
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        public string CodeHex = "";
        public string CodeDec = "";
        void encode(string _code)
        {
            CodeDec = ""; CodeHex = "";
            try
            {
                char[] ch = textBox1.Text.ToArray();

                if (ch == null || ch.Length == 0)
                {
                    Clear();
                    Print("Nothing to Convert");
                    return;
                }
                Clear();
                eepromsize = eepbox.Text;
                Print("eepromsize=" + eepromsize.ToString());
                Print("Encoding-->" + _code);
                int length = Convert.ToInt32(eepromsize) / 2 - 1;
                if (ch.Length < length) length = ch.Length;
                int length2 = length;
                for (int j = 0; j < length; j++)
                {
                    if (ch[j] < 127 && ch[j] >= 0)
                    {
                        int code = IKeycode.ascii_to_scan_code_table[(int)ch[j]];
                        if (code != 0)
                        {
                            CodeHex += code.ToString("X4");
                            CodeDec += code.ToString();
                            if (j != length - 1)
                            {
                                CodeHex += ","; CodeDec += ",";
                            }
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
                        CodeHex += a3.ToString("X4");
                        CodeDec += a3.ToString();
                        //Printhex((int)a3);
                        if (j != length - 1)
                        {
                            CodeHex += ","; CodeDec += ",";
                        }
                    }
                }
                CodeHex = length2.ToString("X4") + "," + CodeHex;
                CodeDec = length2.ToString() + "," + CodeDec;
                textBox2.Text = CodeHex;
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        private void unicodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encode("Unicode");
        }
        private void gBKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encode("GBK");
        }
        private void UTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encode("UTF8");
        }
        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDevice();                  
            try
            {
                int addr = 0;
                if (addbox.Text != ""|| addbox.Text !=null)
                {
                    addr = Convert.ToInt32(addbox.Text);
                }
                    if (textBox2.Text == "")
                {
                    
                    Print("Nothing to upload");
                    return;
                }
                string[] str = CodeDec.Split(',');
                if (HidDevice == null)
                {
                   
                    Print("Invalid device");
                    return;
                }
                Clear();
                Print("Uploading address=" + addr);
                byte[] outdata = new byte[9]; outdata[0] = 0;
                byte[] a = new byte[2];
                outdata[1] = 0xFF; outdata[2] = 0xF1;
                HidDevice.Write(outdata, 50); Thread.Sleep(50);
                for (ushort i = 0; (i * 2) < Convert.ToInt32(eepromsize); i += 3)
                {
                    a = BitConverter.GetBytes((ushort)(i * 2+addr));
                    outdata[1] = a[0]; outdata[2] = a[1];
                    if ((i + 2) < str.Length)
                    {
                        ushort data3 = Convert.ToUInt16(str[i + 2]);
                        //Print(data3);
                        a = BitConverter.GetBytes(data3);
                        outdata[7] = a[0]; outdata[8] = a[1];
                    }
                    if ((i + 1) < str.Length)
                    {
                        ushort data2 = Convert.ToUInt16(str[i + 1]);
                        //Print(data2);
                        a = BitConverter.GetBytes(data2);
                        outdata[5] = a[0]; outdata[6] = a[1];
                    }
                    if (i < str.Length)
                    {
                        ushort data1 = Convert.ToUInt16(str[i]);
                        //Print(data1);
                        a = BitConverter.GetBytes(data1);
                        outdata[3] = a[0]; outdata[4] = a[1];
                    }
                    else { break; }
                    HidDevice.Write(outdata, 50);
                    string outdatastr = "";
                    for (int k = 1; k < outdata.Length; k++)
                    {
                        outdatastr += outdata[k].ToString() + "/";
                    }
                    Print(outdatastr);
                    Thread.Sleep(50);
                }
                outdata[1] = 0xFF; outdata[2] = 0xF2;
                HidDevice.Write(outdata, 50); Thread.Sleep(50);
                Print("Upload finished");
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }    
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }     
        private void libusbtool_Load(object sender, EventArgs e)
        {
            string str = Environment.CurrentDirectory + "\\EEPROMtools.conf";
            loadOptions(str);
        }
    }
}