using LibUsbDotNet;
using LibUsbDotNet.Main;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        bool uploadbyte(short byte1, short index)
        {
            UsbSetupPacket pack = new UsbSetupPacket();
            pack.RequestType = (byte)UsbRequestType.TypeVendor;
            pack.Request = 0x02;//USBRQ_HID_GET_REPORT谁便写个标记 和固件对上即可
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
        private void driverToolStripMenuItem_Click(object sender, EventArgs e)
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
                for (short i = 0; i < str.Length; i++)
                {
                    byte data1 = Convert.ToByte(str[i]);
                    while (!uploadbyte(data1, i))
                    {
                        Thread.Sleep(5);
                    }
                }
                while (!uploadempty(0x03))
                {
                    Thread.Sleep(5);
                }
                Print("Upload finished");
           // }catch (Exception ex){Print(ex.ToString());}
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
        private void convertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string output = "";
            char[] ch = textBox1.Text.ToArray();
            int code = 0;
            int length = ch.Length;
            if (length <= 255) output += length.ToString() + ",0,";
            else if (length - 255 <= 255) output += "255," + (length-255).ToString() + ",";
            else if (length - 255 > 255)
            {
                output += "255,255,";
                length =510;
            }
            for (int j = 0; j < length; j++)
            {
                if (ch[j] < 126)
                {
                    code = Program.ascii_to_scan_code_table[(int)ch[j]];
                }
                if (code != 0)
                {
                    // output += (int)ch[j] + "|";
                    output += code.ToString();
                    if (j != length - 1) output += ",";
                }
                if (code == 40) output += "\r\n";
            }
            textBox2.Text = "";
            textBox2.Text = output;
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Find and open the usb device.
                MyUsbDevice = UsbDevice.OpenUsbDevice(new UsbDeviceFinder(Convert.ToInt32(vid, 16), Convert.ToInt32(pid, 16)));
                if (MyUsbDevice == null)
                {
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