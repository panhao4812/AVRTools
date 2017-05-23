using LibUsbDotNet;
using LibUsbDotNet.Main;
using System;
using System.Diagnostics;
using System.IO;
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
        public void Print(Object str)
        {
            textBox1.Text += str.ToString()+ "\r\n";
        }
        public void Print2(Object str)
        {
            textBox2.Text += str.ToString() + "\r\n";
        }
      
        private void libusbtool_Load(object sender, EventArgs e)
        {
            string str = Environment.CurrentDirectory + "\\default.txt";
            loadOptions(str);
            Print2("vid: " + vid);
            Print2("pid: " + pid);
            Print("14,139,8,15,15,18,44,23,12,17,28,14,8,28,28");
        }

        private void loadOptions(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamReader srd = new StreamReader(fs);
                while (srd.Peek() != -1)
                {
                    string str = srd.ReadLine();
                    string[] chara = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (chara.Length > 1)
                    {
                        if (chara[0] == "vid") vid= chara[1];
                        else if (chara[0] == "pid") pid = chara[1];
                     
                    }
                }
                srd.Close();
            }
            catch (Exception ex)
            {
                Print2(ex.ToString());
            }
        }
    
        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyUsbDevice == null)
            {
                Print2("invalid device,open driver filter");
                return ;
            }
            string[] str = textBox1.Text.Split(',');
            while (!uploadempty(0x01))
            {
                Thread.Sleep(5);
            }
            for (short i = 0; i < str.Length; i++)
            {
                byte data1 = Convert.ToByte(str[i]);
                while (!uploadbyte(data1,i))
                {
                    Thread.Sleep(5);
                }
                textBox2.Text = "uploading..." + "\r\n";
                Print2((i+1).ToString() + " / " + str.Length.ToString());               
            }
            while (!uploadempty(0x03))
            {
                Thread.Sleep(5);
            }
            Print2("upload finished");
        }
        bool uploadbyte(short byte1,short index)
        {      
            UsbSetupPacket pack = new UsbSetupPacket();
            pack.RequestType = (byte)UsbRequestType.TypeVendor;
            pack.Request = 0x02;//USBRQ_HID_GET_REPORT谁便写个标记 和固件对上即可
            pack.Value =byte1;
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
        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Find and open the usb device.
                MyUsbDevice = UsbDevice.OpenUsbDevice(new UsbDeviceFinder(Convert.ToInt32(vid, 16), Convert.ToInt32(pid, 16)));
                if (MyUsbDevice == null) { Print2("invalid device,open driver filter");
                    Process proc = Process.Start("install-filter-win.exe");
                    return; }              
                IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    wholeUsbDevice.SetConfiguration(1);
                    wholeUsbDevice.ClaimInterface(0);
                }
                textBox2.Text = "valid device"+"\r\n";
                Print2("vid: " + vid);
                Print2("pid: " + pid);
            }
            catch (Exception ex)
            {
                Print2(ex.ToString());
            }
        }
    }
}