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
            pid = "3412"; vid = "DDDD";
        }
        bool uploadbyte(byte byte1, short index)
        {
            UsbSetupPacket pack = new UsbSetupPacket();
            pack.RequestType = (byte)UsbRequestType.TypeVendor;
            pack.Request = 0x08;//USBRQ_HID_GET_REPORT谁便写个标记 和固件对上即可
            pack.Value = byte1;
            pack.Index = index;
            pack.Length = 8;
            int lengthTransferred = 0;
            return MyUsbDevice.ControlTransfer(ref pack, IntPtr.Zero, 4, out lengthTransferred);
        }
        bool uploadshort(short byte1, short index)
        {
            UsbSetupPacket pack = new UsbSetupPacket();
            pack.RequestType = (byte)UsbRequestType.TypeVendor;
            pack.Request = 0x16;//USBRQ_HID_GET_REPORT谁便写个标记 和固件对上即可
            pack.Value = byte1;
            pack.Index = index;
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
                while (!uploadshort(Convert.ToInt16(str[0]), Convert.ToInt16(0)))
                {
                    Thread.Sleep(5);
                }
                for (int i = 1; i < str.Length; i++)
                {
                    while (!uploadbyte(Convert.ToByte(str[i]),  Convert.ToInt16(1+i)))
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
                Print("English 0-127");
                int code = 0;
                int length = ch.Length;
                if (length > 508) length = 508;
                string output= length.ToString()+",";
                for (int j = 0; j < length; j++)
                {
                    if (ch[j] < 126 && ch[j]>0)
                    {
                        code = Program.ascii_to_scan_code_table[(int)ch[j]];
                        output += code.ToString();
                        if (j != length - 1) output += ",";
                    }
                    else if ( ch[j] < 0xFFFF)
                    {
                        //汉字
                        byte[] data = Encoding.GetEncoding("UTF-16").GetBytes(ch, j, 1);
                        for (int i = 0; i < data.Length; i++)
                        {
                            output += data[i].ToString();
                        }
                        if (j != length - 1) output += ",";
                    }
                    
                }
                textBox2.Text = "";
                textBox2.Text = output;
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        private void libusbinf()
        {
            try
            {
                Process proc = Process.Start("install-filter-win.exe");
                Clear();
                Print("select Install a device filter");
                Print("select vid=" + vid + " pid=" + pid);
                Print("press Install");
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
                Clear();
                string path = "";
                if (Directory.Exists("C:/Windows/syswow64"))
                {
                    Print("x64 dll： Windows/syswow64/libusb0.dll");
                    if (!File.Exists("C:/Windows/syswow64/libusb0.dll"))
                    {
                        path = Environment.CurrentDirectory + "/amd64/libusb0.dll";
                        File.Copy(path, "C:/Windows/syswow64/libusb0.dll");
                        Print("Installed");
                    }
                }
                if (Directory.Exists("C:/Windows/system32"))
                {

                    Print("x86 dll： Windows/system32/libusb0.dll");
                    if (!File.Exists("C:/Windows/system32/libusb0.dll"))
                    {
                        path = Environment.CurrentDirectory + "/x86/libusb0.dll";
                        File.Copy(path, "C:/Windows/system32/libusb0.dll");
                        Print("Installed");
                    }
                    Print("x86 sys： Windows/system32/drivers/libusb0.sys");
                    if (!File.Exists("C:/Windows/system32/drivers/libusb0.sys"))
                    {
                        path = Environment.CurrentDirectory + "/x86/libusb0.sys";
                        File.Copy(path, "C:/Windows/system32/drivers/libusb0.sys");
                        Print("Installed");
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
                    Print("invalid device");
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
    }
}