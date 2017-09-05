using LibUsbDotNet;
using LibUsbDotNet.Main;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Tinytools
{
    public partial class libusbtool : Form
    {
        string vid, pid;
        string eepromsize = "511";
        public static UsbDevice MyUsbDevice;
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
        private void libusbtool_Load(object sender, EventArgs e)
        {
            string str = Environment.CurrentDirectory + "\\tinytools.conf";
            loadOptions(str);
            str = Environment.CurrentDirectory + "\\avrdude.conf";
            if (!File.Exists(str))
            {
                Driver.Enabled = false;
            }
        }
        private void libusbtool_FormClosing(object sender, FormClosingEventArgs e)
        {
            string str = Environment.CurrentDirectory + "\\tinytools.conf";
            saveOptions(str);
        }
        bool uploadbyte(byte byte1, ushort index)
        {
            UsbSetupPacket pack = new UsbSetupPacket();
            pack.RequestType = (byte)UsbRequestType.TypeVendor;
            pack.Request = 0x08;//USBRQ_HID_GET_REPORT谁便写个标记 和固件对上即可
            pack.Value = byte1;
            pack.Index = (short)index;
            pack.Length = 8;
            int lengthTransferred = 0;
            return MyUsbDevice.ControlTransfer(ref pack, IntPtr.Zero, 4, out lengthTransferred);
        }
        bool uploadshort(ushort byte1, ushort index)
        {
            UsbSetupPacket pack = new UsbSetupPacket();
            pack.RequestType = (byte)UsbRequestType.TypeVendor;
            pack.Request = 0x16;//USBRQ_HID_GET_REPORT谁便写个标记 和固件对上即可
            pack.Value = (short)byte1;
            textBox3.Text += pack.Value.ToString() + ",";
            pack.Index = (short)index;
            pack.Length = 8;
            int lengthTransferred = 0;
            return MyUsbDevice.ControlTransfer(ref pack, IntPtr.Zero, 4, out lengthTransferred);
        }
        bool uploadempty(byte request)
        {
            UsbSetupPacket pack = new UsbSetupPacket();
            pack.RequestType = (byte)UsbRequestType.TypeVendor;
            pack.Request = request;//USBRQ_HID_GET_REPORT谁便写个标记 和固件对上即可
            pack.Value = 0x00;
            pack.Length = 8;
            int lengthTransferred = 0;
            return MyUsbDevice.ControlTransfer(ref pack, IntPtr.Zero, 4, out lengthTransferred);
        }
        void Printhex(int str)
        {
            string s = str.ToString("X");
            Print(s);
            Print(Convert.ToString(str, 2));
        }
        public static int GetHexadecimalValue(String strColorValue)
        {
            char[] nums = strColorValue.ToCharArray();
            int total = 0;
            try
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    String strNum = nums[i].ToString().ToUpper();
                    switch (strNum)
                    {
                        case "A":
                            strNum = "10";
                            break;
                        case "B":
                            strNum = "11";
                            break;
                        case "C":
                            strNum = "12";
                            break;
                        case "D":
                            strNum = "13";
                            break;
                        case "E":
                            strNum = "14";
                            break;
                        case "F":
                            strNum = "15";
                            break;
                        default:
                            break;
                    }
                    double power = Math.Pow(16, Convert.ToDouble(nums.Length - i - 1));
                    total += Convert.ToInt32(strNum) * Convert.ToInt32(power);
                }

            }
            catch (System.Exception ex)
            {
                String strErorr = ex.ToString();
                return 0;
            }


            return total;
        }
        public ushort ConvertChinese1(char str)
        {
            string str2 = Convert.ToString(str);
            byte[] data = Encoding.Unicode.GetBytes(str2);
            string Data1 = data[0].ToString("x"); if (Data1.Length == 1) Data1 = "0" + Data1;
            string Data2 = data[1].ToString("x"); if (Data2.Length == 1) Data2 = "0" + Data2;
            str2 = Data2 + Data1;
            ushort a3 = Convert.ToUInt16(str2, 16);
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
        private bool lisbusbdriver()
        {
            bool result = true;
            try
            {
                // string path = "";
                if (Directory.Exists("C:/Windows/syswow64"))
                {
                    Print("x64 dll： Windows/syswow64/libusb0.dll");
                    if (!File.Exists("C:/Windows/syswow64/libusb0.dll"))
                    {
                        //  path = Environment.CurrentDirectory + "/amd64/libusb0.dll";
                        //  File.Copy(path, "C:/Windows/syswow64/libusb0.dll");
                        //  Print("Installed");
                        Print("missed file");
                        result = false;
                    }
                }
                if (Directory.Exists("C:/Windows/system32"))
                {

                    Print("x86 dll： Windows/system32/libusb0.dll");
                    if (!File.Exists("C:/Windows/system32/libusb0.dll"))
                    {
                        //   path = Environment.CurrentDirectory + "/x86/libusb0.dll";
                        //   File.Copy(path, "C:/Windows/system32/libusb0.dll");
                        //    Print("Installed");
                        Print("missed file"); result = false;
                    }
                    Print("x86 sys： Windows/system32/drivers/libusb0.sys");
                    if (!File.Exists("C:/Windows/system32/drivers/libusb0.sys"))
                    {
                        //  path = Environment.CurrentDirectory + "/x86/libusb0.sys";
                        //   File.Copy(path, "C:/Windows/system32/drivers/libusb0.sys");
                        //  Print("Installed");
                        Print("missed file"); result = false;
                    }
                }
            }
            catch (Exception ex) { Print(ex.ToString()); }
            return result;
        }
        private void loadOptions(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamReader srd = new StreamReader(fs);
                string str = srd.ReadLine();
                string[] chara3 = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (chara3[0] == "eepromsize") eepromsize = chara3[1];
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
                stream.WriteLine("eepromsize," + eepromsize);
                stream.Write(textBox1.Text);
                stream.Flush();
                stream.Close();
            }
            catch { }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (vidbox.Text.Length == 0 || pidbox.Text.Length == 0)
                {
                    Clear();
                    Print("vid or pid error. Try open again");
                    return;
                }
                vid = vidbox.Text;
                pid = pidbox.Text;
                // Find and open the usb device.
                MyUsbDevice = UsbDevice.OpenUsbDevice(new UsbDeviceFinder(Convert.ToInt32(vid, 16), Convert.ToInt32(pid, 16)));
                if (MyUsbDevice == null)
                {
                    Clear();
                    Print("Connect usb device and install driver. Try open again");
                    //lisbusbdriver();
                    // libusbinf();
                    return;
                }
                IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    wholeUsbDevice.SetConfiguration(1);
                    wholeUsbDevice.ClaimInterface(0);
                }
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
        private void uploadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    Clear();
                    Print("Nothing to upload");
                    return;
                }
                string[] str = textBox2.Text.Split(',');
                if (MyUsbDevice == null)
                {
                    Clear();
                    Print("Invalid device");
                    return;
                }
                Clear();
                Print("Uploading");
                while (!uploadempty(0x01))
                {
                    Thread.Sleep(5);
                }
                for (int i = 0; i < str.Length; i++)
                {
                    if ((i * 2) > Convert.ToInt32(eepromsize)) break;
                    while (!uploadshort(Convert.ToUInt16(str[i]), Convert.ToUInt16(i * 2)))
                    {
                        Thread.Sleep(5);
                    }
                }
                while (!uploadempty(0x03))
                {
                    Thread.Sleep(5);
                }
                Print("Upload finished");
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (vidbox.Text.Length == 0 || pidbox.Text.Length == 0)
            {
                Clear();
                Print("vid or pid error. Try open again");
                return;
            }
            vid = vidbox.Text;
            pid = pidbox.Text;
            try
            {
                HidDevice[] HidDeviceList = HidDevices.Enumerate(Convert.ToInt32(vid, 16), Convert.ToInt32(pid, 16), (ushort)0xFF31).ToArray();
                if (HidDeviceList == null || HidDeviceList.Length == 0)
                {
                    Clear();
                    Print("Connect usb device and install driver. Try open again");
                    return;
                }
                for (int i = 0; i < HidDeviceList.Length; i++)
                {
                    Print(HidDeviceList[i].ToString());
                }
                if (HidDeviceList[0] == null)
                {
                    Clear();
                    Print("Connect usb device and install driver. Try open again");
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
        private void unicodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                        ushort a3 = ConvertChinese1(ch[j]);
                        output += a3.ToString();
                        //Printhex((int)a3);
                        if (j != length - 1) output += ",";
                    }
                }
                textBox2.Text = length2.ToString() + ",";
                textBox2.Text += output;
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        private void gBKToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                        ushort a3 = ConvertChinese2(ch[j], "GBK");
                        output += a3.ToString();
                        //Printhex((int)a3);
                        if (j != length - 1) output += ",";
                    }
                }
                textBox2.Text = length2.ToString() + ",";
                textBox2.Text += output;
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    Clear();
                    Print("Nothing to upload");
                    return;
                }
                string[] str = textBox2.Text.Split(',');
                if (HidDevice == null)
                {
                    Clear();
                    Print("Invalid device");
                    return;
                }
                Clear();
                Print("Uploading");
                byte[] outdata = new byte[9]; outdata[0] = 0;
                byte[] a = new byte[2];

                outdata[1] = 0xFF; outdata[2] = 0xF1;
                HidDevice.Write(outdata, 50); Thread.Sleep(50);

                for (ushort i = 0; (i * 2) < Convert.ToInt32(eepromsize); i += 3)
                {
                    a = BitConverter.GetBytes((ushort)(i * 2));
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
        private void libusbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lisbusbdriver())
            {
                try { Process proc = Process.Start("install-filter-win.exe"); }
                catch (Exception ex) { Print(ex.ToString()); }
            }
        }
    }
}