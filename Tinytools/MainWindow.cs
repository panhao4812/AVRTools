﻿using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Tinytools
{
    public partial class MainWindow : Form
    {
        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern int PostMessage(IntPtr hWnd, int Msg, uint wParam, int lParam);
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        public const int WM_CHAR = 0x0102;
        public const int WM_char = 256;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            string str = Environment.CurrentDirectory + "\\default.txt";
            loadOptions(str);
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            string str = Environment.CurrentDirectory + "\\default.txt";
            saveOptions(str);
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
                    if (chara[0] == "-c") c_box.Text = chara[1];
                    else if (chara[0] == "-p") p_box.Text = chara[1];
                    else if (chara[0] == "-b") b_box.Text = chara[1];
                    else if (chara[0] == "-P") p_box2.Text = chara[1];
                    else if (chara[0] == "cd") cd_box.Text = chara[1];
                    else if (chara[0] == "lfuse") lfuse_box.Text = chara[1];
                    else if (chara[0] == "hfuse") hfuse_box.Text = chara[1];
                    else if (chara[0] == "efuse") efuse_box.Text = chara[1];
                        else if (chara[0] == "lock") lock_box.Text = chara[1];
                        else if (chara[0] == "flash") flash_box.Text = chara[1];
                    else if (chara[0] == "eeprom") eeprom_box.Text = chara[1];
                }
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
                StreamWriter stream = new StreamWriter(fs);
                string output = "";
                output += "-c," + c_box.Text + "\r\n";
                output += "-p," + p_box.Text + "\r\n";
                output += "-b," + b_box.Text + "\r\n";
                output += "-P," + p_box2.Text + "\r\n";
                output += "cd," + cd_box.Text + "\r\n";
                output += "flash," + flash_box.Text + "\r\n";
                output += "lfuse," + lfuse_box.Text + "\r\n";
                output += "hfuse," + hfuse_box.Text + "\r\n";
                output += "efuse," + efuse_box.Text + "\r\n";
                output += "lock," + lock_box.Text + "\r\n";
                output += "eeprom," + eeprom_box.Text;
                stream.Write(output);
                stream.Close();
            }
            catch { }
        }
       
        private void libusbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ThreadProc2));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        public static void ThreadProc2()
        {
            libusbtool form = new libusbtool();//第3个窗体
            form.ShowDialog();
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            string str = "";
            if (of.ShowDialog() == DialogResult.OK)
            {
                str = of.FileName.ToString(); loadOptions(str);
            }         
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            string str = "";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                str = sf.FileName.ToString();saveOptions(str);
            }          
        }
        private void CMD_Click(object sender, EventArgs e)
        {
            Process proc = Process.Start("CMD.Exe");
        }
        IntPtr hCMD = IntPtr.Zero;

        void printw(string str)
        {
            hCMD = FindWindow("ConsoleWindowClass", null);
            char[] strs = str.ToCharArray();
            for (int i = 0; i < strs.Length; i++)
            {
                PostMessage(hCMD, WM_CHAR, strs[i], 0);
            }
            PostMessage(hCMD, WM_CHAR, 13, 0);
        }
        private void SEND_Click(object sender, EventArgs e)
        {
            if (Main_box.Text != "") printw(Main_box.Text);
        }
        private void path_cd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog of = new FolderBrowserDialog();
            string path = "";
            if (of.ShowDialog() == DialogResult.OK)
            {
                path = of.SelectedPath.ToString();
            }
            cd_box.Text = path.Replace('\\', '/');
        }
        private void path_flash_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "(*.hex)|*.hex";
            if (of.ShowDialog() == DialogResult.OK)
            {
                flash_box.Text = of.FileName.ToString();
            }
            flash_box.Text = flash_box.Text.Replace('\\', '/');
        }
        private void path_eeprom_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "(*.eep)|*.eep";
           
            if (of.ShowDialog() == DialogResult.OK)
            {
                eeprom_box.Text = of.FileName.ToString();
            }
            eeprom_box.Text = eeprom_box.Text.Replace('\\', '/');
        }
        private void cd_Click(object sender, EventArgs e)
        {
            if (cd_box.Text == "") return;
            Main_box.Text = "cd " + cd_box.Text;
            char c1 = cd_box.Text.ToCharArray()[0];
            char c2 = cd_box.Text.ToCharArray()[1];
            char[] c3 = { c1, c2 };
            printw(new string(c3));
        }

        private void flash_Click(object sender, EventArgs e)
        {
            if (flash_box.Text == "") return;
            string str = "avrdude";
            str += " -c " + c_box.Text;
            str += " -p " + p_box.Text;
            str += " -b " + b_box.Text;
            str += " -P " + p_box2.Text;
            str += " -U flash:w:";
            Main_box.Text = str + flash_box.Text + ":i";
        }

        private void verify_Click(object sender, EventArgs e)
        {
            string str = "avrdude";
            str += " -c " + c_box.Text;
            str += " -p " + p_box.Text;
            str += " -b " + b_box.Text;
            str += " -P " + p_box2.Text;
            Main_box.Text = str + " -q -v -F";
        }

        private void fuse_Click(object sender, EventArgs e)
        {
            string str = "avrdude";
            str += " -c " + c_box.Text;
            str += " -p " + p_box.Text;
            str += " -b " + b_box.Text;
            str += " -P " + p_box2.Text;
            str += " -u" ;
            if (hfuse_box.Text!="") str += " -U hfuse:w:"+ hfuse_box.Text+":m";
            if (lfuse_box.Text != "") str += " -U lfuse:w:" + lfuse_box.Text + ":m";
            if (efuse_box.Text != "") str += " -U efuse:w:" + efuse_box.Text + ":m";
            if (lock_box.Text != "") str += " -U lock:w:" + lock_box.Text + ":m";
            Main_box.Text = str;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string str = "avrdude";
            str += " -c " + c_box.Text;
            str += " -p " + p_box.Text;
            str += " -b " + b_box.Text;
            str += " -P " + p_box2.Text;
            Main_box.Text = str + " -q";
        }

        private void eeprom_Click(object sender, EventArgs e)
        {
            if (eeprom_box.Text == "") return;
            string str = "avrdude";
            str += " -c " + c_box.Text;
            str += " -p " + p_box.Text;
            str += " -b " + b_box.Text;
            str += " -P " + p_box2.Text;
            str += " -U eeprom:w:";
            Main_box.Text = str + eeprom_box.Text ;
        }

        private void m_path_flash_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "(*.hex)|*.hex";
            if (of.ShowDialog() == DialogResult.OK)
            {
                m_flash_box.Text = of.FileName.ToString();
            }
            m_flash_box.Text = m_flash_box.Text.Replace('\\', '/');
        }

        private void m_flash_Click(object sender, EventArgs e)
        {
            if (m_flash_box.Text == "") return;
            string str = "micronucleus ";
            str += m_flash_box.Text;
            Main_box.Text = str;
        }

       

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("v1.00 by zian");
        }
    }
}
