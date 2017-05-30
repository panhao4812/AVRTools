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
        string vid, pid;string eepromsize="511";
        public libusbtool()
        {
            InitializeComponent();
        }
        public static UsbDevice MyUsbDevice;
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
            textBox3.Text +=  pack.Value.ToString()+",";
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
        private void uploadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //  try{
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
                if ((i*2)> Convert.ToInt32(eepromsize)) break;
                while (!uploadshort(Convert.ToUInt16(str[i]), Convert.ToUInt16(i*2)))
                {
                    Thread.Sleep(5);
                }
            }
            while (!uploadempty(0x03))
            {
                Thread.Sleep(5);
            }
            Print("Upload finished");
            //   }catch (Exception ex) { Print(ex.ToString()); }
        }
        public static void ThreadProc()
        {
            MainWindow form = new MainWindow();//第2个窗体
            form.ShowDialog();
        }
        private void cMDToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        void Printhex(int str)
        {
            string s = str.ToString("X");
            Print(s);           
            Print(Convert.ToString(str, 2));
        }
        private void convertToolStripMenuItem_Click(object sender, EventArgs e)
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
                Print("English 0-127 Chinese > "+0x8080);
               
                int length = Convert.ToInt32(eepromsize) / 2-1;
                if (ch.Length < length) length = ch.Length;
                string output = "";
                int length2 = length;
                for (int j = 0; j < length; j++)
                {
                    if (ch[j] <127 && ch[j]>=0)
                    {
                        int code  = Program.ascii_to_scan_code_table[(int)ch[j]];
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
                        ushort a3 = ConvertChinese2(ch[j], "utf-8");
                        output += a3.ToString();
                       // Printhex((int)a3);                      
                        if (j != length - 1) output += ",";
                    }
                }
                textBox2.Text = length2.ToString()+",";
                textBox2.Text += output;
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        public ushort ConvertChinese1(char str)
        {
            string str2 = Convert.ToString(str);
            byte[] data = Encoding.Default.GetBytes(str2);
            byte temple = data[0];
            data[0] = data[1]; data[1] = temple;
            ushort a3 = BitConverter.ToUInt16(data, 0);
            return a3;

        }
            public ushort ConvertChinese2(char str,string code)
        {
            string str2 = Convert.ToString(str);
            byte[] data = Encoding.GetEncoding(code).GetBytes(str2);
            byte temple = data[0];
            data[0] = data[1]; data[1] = temple;
            ushort a3 = BitConverter.ToUInt16(data, 0);
            return a3;
        }
        private void libusbinf()
        {
            try
            {
                string output = "";
                // Process proc = Process.Start("install-filter-win.exe");
                System.Diagnostics.Process pExecuteEXE = new System.Diagnostics.Process();
                pExecuteEXE.StartInfo.FileName = "CMD.exe";
                pExecuteEXE.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                pExecuteEXE.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                pExecuteEXE.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                pExecuteEXE.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                pExecuteEXE.StartInfo.CreateNoWindow = true;//不显示程序窗口
                string Arguments = "install-filter install --device=USB\\Vid_dddd.Pid_3412.Rev_0100" + "&exit";
                pExecuteEXE.Start();
                pExecuteEXE.StandardInput.WriteLine(Arguments);
                pExecuteEXE.StandardInput.AutoFlush = true;
                output = pExecuteEXE.StandardOutput.ReadToEnd();
                pExecuteEXE.WaitForExit();//无限期等待完成
                pExecuteEXE.Close();
                Print(output);
                //Print("select Install a device filter");
                // Print("select vid=" + vid + " pid=" + pid);
                // Print("press Install");
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        private void lisbusbdriver()
        {
            try
            {
                string path = "";
                if (Directory.Exists("C:/Windows/syswow64"))
                {
                    Print("x64 dll： Windows/syswow64/libusb0.dll");
                    if (!File.Exists("C:/Windows/syswow64/libusb0.dll"))
                    {
                        //  path = Environment.CurrentDirectory + "/amd64/libusb0.dll";
                        //  File.Copy(path, "C:/Windows/syswow64/libusb0.dll");
                        //  Print("Installed");
                        Print("missed file");
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
                        Print("missed file");
                    }
                    Print("x86 sys： Windows/system32/drivers/libusb0.sys");
                    if (!File.Exists("C:/Windows/system32/drivers/libusb0.sys"))
                    {
                        //  path = Environment.CurrentDirectory + "/x86/libusb0.sys";
                        //   File.Copy(path, "C:/Windows/system32/drivers/libusb0.sys");
                        //  Print("Installed");
                        Print("missed file");
                    }
                }
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                // Find and open the usb device.
                MyUsbDevice = UsbDevice.OpenUsbDevice(new UsbDeviceFinder(Convert.ToInt32(vid, 16), Convert.ToInt32(pid, 16)));
                if (MyUsbDevice == null)
                {
                    Clear();
                    Print("Install filter. Try open again");
                    lisbusbdriver();
                    libusbinf();
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
        private void loadOptions(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamReader srd = new StreamReader(fs);

                string str = srd.ReadLine();
                string[] chara1 = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (chara1[0] == "pid") pid = chara1[1];
                 str = srd.ReadLine();
                string[] chara2 = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (chara2[0] == "vid") vid = chara2[1];
                 str = srd.ReadLine();
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

        private void libusbFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {try { Process proc = Process.Start("install-filter-win.exe"); }
            catch(Exception ex) { Print(ex.ToString()); }         
        }

        private void saveOptions(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.SetLength(0);
                StreamWriter stream = new StreamWriter(fs);          
                stream.WriteLine( "pid," + pid );
                stream.WriteLine( "vid," + vid );
                stream.WriteLine( "eepromsize," + eepromsize);               
                stream.Write(textBox1.Text);
                stream.Flush();
                stream.Close();
            }
            catch { }
        }
    }
}