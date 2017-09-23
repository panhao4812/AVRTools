using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HidRawTools
{
    public partial class TinyToolsLite : Form
    {
        public static HidDevice HidDevice;
        ushort vid = 0;
        ushort pid = 0;
        ushort eepromsize = 511;
        string CodeTemp = "";
        string iencode = "Default";
        public void Clear()
        {
            textBox2.Text = "";
        }
        public void Print(Object str)
        {
            textBox2.Text += str.ToString() + "\r\n";
        }
        public TinyToolsLite()
        {
            InitializeComponent();
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
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "") vid = (ushort)Convert.ToInt32(textBox3.Text, 16);
            if (textBox4.Text != "") pid = (ushort)Convert.ToInt32(textBox4.Text, 16);
            Clear();
            Print("0x" + vid.ToString("x"));
            Print("0x" + pid.ToString("x"));
            try
            {
                HidDevice[] HidDeviceList = HidDevices.Enumerate(vid, pid, Convert.ToUInt16(0xFF31)).ToArray();
                if (HidDeviceList == null || HidDeviceList.Length == 0)
                {
                    Print("Connect usb device and install driver. Try open again");
                    return;
                }
                for (int i = 0; i < HidDeviceList.Length; i++)
                {
                    Print(HidDeviceList[i].DevicePath);
                    HidDevice = HidDeviceList[0]; break;
                }
                if (HidDevice == null)
                {
                    Print("Connect usb device and install driver. Try open again");
                    return;
                }
                Print("Device OK");
                byte[] outdata = new byte[9]; outdata[0] = 0;
                outdata[1] = 0xFF; outdata[2] = 0xFA;
                HidDevice.Write(outdata); Thread.Sleep(60);
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Encode(iencode);
                int addr=24;          
                if (CodeTemp == "")
                {
                    Clear();
                    Print("Nothing to upload");
                    return;
                }
                string[] str = CodeTemp.Split(',');
                if (HidDevice == null)
                {
                    Clear();
                    Print("Invalid device");
                    return;
                }
                Print("Uploading address=" + addr);
                byte[] outdata = new byte[9]; outdata[0] = 0;
                byte[] a = new byte[2];

                outdata[1] = 0xFF; outdata[2] = 0xF1;
                HidDevice.Write(outdata); Thread.Sleep(60);

                for (ushort i = 0; (i * 2) < Convert.ToInt32(eepromsize); i += 3)
                {
                    a = BitConverter.GetBytes((ushort)(i * 2 + addr));
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
                    HidDevice.Write(outdata);
                    string outdatastr = "";
                    for (int k = 1; k < outdata.Length; k++)
                    {
                        outdatastr += outdata[k].ToString() + "/";
                    }
                    Print(outdatastr);
                    Thread.Sleep(60);
                }
                outdata[1] = 0xFF; outdata[2] = 0xF2;
                HidDevice.Write(outdata); Thread.Sleep(60);
                Print("Upload finished");
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        private void Encode(string _code)
        {
            try
            {
                if (this.checkBox1.Checked)
                {
                    CodeTemp = "2,";
                }
                else { CodeTemp = "0,"; }
                CodeTemp += this.hScrollBar1.Value.ToString() + ",";
                CodeTemp += this.hScrollBar2.Value.ToString() + ",";
                if (textBox7.Text == "" || textBox7.Text == string.Empty)
                {
                    CodeTemp += "0,";
                }
                else
                {
                    int rate = Convert.ToInt32(textBox7.Text);
                    if (rate < 0) rate = 0;
                    if (rate > 31) rate = 31;
                    textBox7.Text = rate.ToString();
                    if (rate != 0) rate = 32 - rate;
                    rate *= 0x0800;
                    CodeTemp += rate.ToString() + ",";
                }
                Clear();
                char[] ch = textBox1.Text.ToArray();

                if (ch == null || ch.Length == 0)
                {
                    CodeTemp += "0";                
                    Print("Uploading RGB parameter!Nothing for printing!");
                    return;
                }
                Print("English 0-127 GBK > " + 0x8080);

                int length = Convert.ToInt32(eepromsize) / 2 - 1;
                if (ch.Length < length) length = ch.Length;
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
              //  Print(CodeTemp);
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            Print("Author zian1");
            Print("step1: Click Hid-OpenDevice to Connect the device.");
            Print("step2: Copy or type something into the textbox on the left.");
            Print("step3: Click Encode-Unicode for QQ.Click Encode-GBK for text box.");
            Print("step4: Click Hid-Upload to burn codes into device.");
            Print("enjoy!");
        }
        private void gBKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iencode="GBK";
            this.encodeToolStripMenuItem.Text = "Encode(" + iencode+ ")";
        }
        private void unicodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iencode = "Unicode";
            this.encodeToolStripMenuItem.Text = "Encode(" + iencode + ")";
        }
        private void utiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iencode = "UTF8";
            this.encodeToolStripMenuItem.Text = "Encode(" + iencode + ")";
        }
        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iencode = "Default";
            this.encodeToolStripMenuItem.Text = "Encode(" + iencode + ")";
        }

        private void TinyToolsLite_Load(object sender, EventArgs e)
        {
            string str = Environment.CurrentDirectory + "\\XD002tools.conf";
            loadOptions(str);
        }     
        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            int index = this.hScrollBar1.Value;
            int r = Program.Rcolors[index];
            int g = Program.Gcolors[index];
            int b = Program.Bcolors[index];
            label3.BackColor = Color.FromArgb(r, g, b);
            rgb1.Text= this.hScrollBar1.Value.ToString();
        }
        private void hScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            int index = this.hScrollBar2.Value;
            int r = Program.Rcolors[index];
            int g = Program.Gcolors[index];
            int b = Program.Bcolors[index];
            label4.BackColor = Color.FromArgb(r, g, b);
            rgb2.Text = this.hScrollBar2.Value.ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
        private void loadOptions(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamReader srd = new StreamReader(fs);
                for (int k = 0; k < 2; k++)
                {
                    string str = srd.ReadLine();
                    string[] chara3 = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (chara3[0] == "vid") textBox3.Text = chara3[1];
                    if (chara3[0] == "pid") textBox4.Text = chara3[1];
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
                stream.WriteLine("vid," + textBox3.Text);
                stream.WriteLine("pid," + textBox4.Text);
                stream.Write(textBox1.Text);
                stream.Flush();
                stream.Close();
            }
            catch { }
        }

        private void TinyToolsLite_FormClosing(object sender, FormClosingEventArgs e)
        {
            string str = Environment.CurrentDirectory + "\\XD002tools.conf";
            saveOptions(str);
        }
    }
}
