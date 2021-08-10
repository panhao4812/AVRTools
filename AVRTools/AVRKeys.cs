using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AVRKeys.Keyboard;
using System.IO;
using AVRKeys.HidLib;
using System.Threading;

namespace AVRTools
{
    /*
     * 原型
     */
    public partial class AVRKeys : Form
    {
        #region IO
        string SavePath = "";
        private void Open_Click(object sender, EventArgs e)
        {
            try
            {
                String path = "";
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                    SavePath = path;
                }
                else
                {
                    return;
                }
                IMatrix matrix = new IMatrix();
                matrix.InitFromFile(SavePath);
                ActiveMatrix = matrix;
                InitMatrrix();
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            FileSave(SavePath);
        }
        private void FileSave(string path)
        {
            try
            {
                if (ActiveMatrix == null) return;
                if (path == "")
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FilterIndex = 0;
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        path = sfd.FileName; SavePath = path;
                    }
                    else
                    {
                        return;
                    }
                }
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.SetLength(0);
                StreamWriter stream = new StreamWriter(fs);
                stream.Write(ActiveMatrix.ToString());
                stream.Flush();
                stream.Close();
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        private void SaveAs_Click(object sender, EventArgs e)
        {
            FileSave("");
        }
        private void Export_Keycap_Click(object sender, EventArgs e)
        {
            if (ActiveMatrix == null) return;
            try
            {            
                string path = "";
                SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FilterIndex = 0;
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        path = sfd.FileName; SavePath = path;
                    }
                    else
                    {
                        return;
                    }
                
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.SetLength(0);
                StreamWriter stream = new StreamWriter(fs);
                stream.Write(ActiveMatrix.ExportKeyCap());
                stream.Flush();
                stream.Close();
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }

        #endregion
        #region Load
        public IMatrix ActiveMatrix;
        public Button ActiveButton;
        public void Print(string str)
        {
            ConsoleBox.Text += str + "\r\n";
        }
        public void Clear()
        {
            ConsoleBox.Text = "";
        }                  
        private void DefaultLayout()
        {
            int Height1 = 20; int Width1 = 54;
            this.Size = new Size(850 + Width1, 561 + Height1);
            MatrixPanel.Size = new Size(838 + Width1, 250 + Height1);
            MatrixPanel.Location = new Point(0, 25);
            SelectKeysPanel.Size = new Size(838 + Width1, 250);
            SelectKeysPanel.Location = new Point(0, 272 + Height1);
            PrinterInputBox.Location = new Point(80, 3);
            PrinterEncodeBox.Location = new Point(530, 3);
            PrinterInputBox.Size = new Size(350, 215);
            PrinterEncodeBox.Size = new Size(350, 215);
            PrinterEncodeBox.Height += Height1;
            PrinterInputBox.Height += Height1;        
        }
        public AVRKeys()
        {
            InitializeComponent();
        }
        private void AVRKeys_Load(object sender, EventArgs e)
        {
            DefaultLayout();         
            FuncEncode = new IEncode(ConsoleBox);
            USPage.Controls.Clear();
            MacroPage.Controls.Clear();
            IOPage.Controls.Clear();
            ColorPage.Controls.Clear();
            IMatrix matrix104 = new PanelUS();
            List<Button> buttons1 = matrix104.CreateButton(36);
            for (int i = 0; i < buttons1.Count; i++)
            {
                buttons1[i].Text = matrix104.FuncCodes.FromFullName(matrix104.key_caps[i].layer1).ShortName;
                buttons1[i].MouseDown += new MouseEventHandler(Keycode_Button_MouseClick);
                Tip1.SetToolTip(buttons1[i], buttons1[i].Text);
                USPage.Controls.Add(IKeycap.UpdateButton(buttons1[i]));
            }
            IMatrix matrixMacro = new PanelMacro();
            List<Button> buttons3 = matrixMacro.CreateButton(40);
            for (int i = 0; i < buttons3.Count; i++)
            {
                buttons3[i].Text = matrixMacro.FuncCodes.FromFullName(matrixMacro.key_caps[i].layer1).ShortName;
                buttons3[i].MouseDown += new MouseEventHandler(Keycode_Button_MouseClick);
                Tip1.SetToolTip(buttons3[i], buttons3[i].Text);
                MacroPage.Controls.Add(IKeycap.UpdateButton(buttons3[i]));
            }
            List<Button> buttons2 = IColors.CreateButton(27);
            for (int i = 0; i < buttons2.Count; i++)
            {
                Tip1.SetToolTip(buttons2[i], buttons2[i].BackColor.R.ToString()+","+
                    buttons2[i].BackColor.G.ToString() + "," + buttons2[i].BackColor.B.ToString());
                buttons2[i].MouseDown += new MouseEventHandler(Color_Button_MouseClick);
                ColorPage.Controls.Add(IKeycap.UpdateButton(buttons2[i]));
            }        
        }
        private void ClearButton()
        {
            Layer1Page.Controls.Clear();
            Layer2Page.Controls.Clear();
            SchematicPage.Controls.Clear();
            IOPage.Controls.Clear();
            RGBPage.Controls.Clear();
            PidBox.Text = "";
            VidBox.Text = "";
            EEPBox.Text = "";
            AddressBox.Text = "";
            Length1Box.Text = "";
            Length2Box.Text = "";
        }
        #endregion
        #region panel       
        private void Layer1_Keycap_TextChanged(object sender, EventArgs e)
        {
            if (ActiveMatrix == null) return;
            int index = Convert.ToInt32(((Button)sender).Name);
            ActiveMatrix.key_caps[index].layer1 = ((Button)sender).Text;
        }
        private void Layer2_Keycap_TextChanged(object sender, EventArgs e)
        {
            if (ActiveMatrix == null) return;
            int index = Convert.ToInt32(((Button)sender).Name);
            ActiveMatrix.key_caps[index].layer2 = ((Button)sender).Text;
        }
        private void RGB_Keycap_TextChanged(object sender, EventArgs e)
        {
            if (ActiveMatrix == null) return;
            int index = Convert.ToInt32(((Button)sender).Name);
            string[] cr = ((Button)sender).Text.Split('/');
            ActiveMatrix.RGB[index].layer2 = cr[1];
        }
        private void Schematic_Keycap_TextChanged(object sender, EventArgs e)
        {
            if (ActiveMatrix == null) return;
            int index = Convert.ToInt32(((Button)sender).Name);
            string[] cr = ((Button)sender).Text.Split('/');
            ActiveMatrix.key_caps[index].R = Convert.ToInt32(cr[0]);
            ActiveMatrix.key_caps[index].C = Convert.ToInt32(cr[1]);
        }
        private void Keycap_Button_MouseClick(object sender, MouseEventArgs e)
        {
            if (keytest) { SelectKeysPanel.SelectedTab = ConsolePage; ConsolePage.Focus(); return; }
            //key button
            if (ActiveButton != null) { ActiveButton.FlatAppearance.BorderSize = 1; }
            if (e.Button == MouseButtons.Right)
            {
                ActiveButton = null;
            }
            else
            {
                ActiveButton = ((Button)sender);
                ActiveButton.FlatAppearance.BorderSize = 3;
            }
        }
        private void Keycode_Button_MouseClick(object sender, MouseEventArgs e)
        {
            if (ActiveButton == null) return;
            //key button      
            if (e.Button == MouseButtons.Right)
            {

            }
            else
            {
                if (ActiveButton.Parent.Name == "Layer1Page"
                    || ActiveButton.Parent.Name == "Layer2Page")
                {
                    ActiveButton.Text = ((Button)sender).Text;
                }
            }
        }
        private void IO_Button_MouseClick(object sender, MouseEventArgs e)
        {
            if (ActiveButton == null) return;
            //key button      
            if (e.Button == MouseButtons.Right)
            {

            }
            else
            {
                if (ActiveButton.Parent.Name == "SchematicPage")
                {
                    string[] strs1 = ActiveButton.Text.Split('/');
                    string[] strs2 = ((Button)sender).Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    string str2 = strs2[0];
                    string R = "", C = "";
                    if (str2[0] == 'r') { R = str2.Remove(0, 1); C = strs1[1]; }
                    else if (str2[0] == 'c') { R = strs1[0]; C = str2.Remove(0, 1); }
                    ActiveButton.Text = R + "/" + C;
                    ActiveButton.BackColor = ActiveMatrix.IOColors[Convert.ToInt32(C)];
                }
            }
        }
        private void Color_Button_MouseClick(object sender, MouseEventArgs e)
        {
            if (ActiveButton == null) return;
            //key button      
            if (e.Button == MouseButtons.Right)
            {

            }
            else
            {
                if (ActiveButton.Parent.Name == "RGBPage")
                {
                    ActiveButton.BackColor = ((Button)sender).BackColor;
                    string[] strs1 = ActiveButton.Text.Split('/');
                    ActiveButton.Text = strs1[0]+"/"+((Button)sender).Text;
                }
            }
        }
        private void Layer1_Enter(object sender, EventArgs e)
        {
            if (ActiveButton != null) { ActiveButton.FlatAppearance.BorderSize = 1; }
            ActiveButton = null;
        }
        private void Layer2_Enter(object sender, EventArgs e)
        {
            if (ActiveButton != null) { ActiveButton.FlatAppearance.BorderSize = 1; }
            ActiveButton = null;
        }
        private void Schematic_Enter(object sender, EventArgs e)
        {
            if (ActiveButton != null) { ActiveButton.FlatAppearance.BorderSize = 1; }
            ActiveButton = null;
            // if (!keytest) SelectKeysPanel.SelectedTab = IOPage;
        }
        private void ConsoleBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
        #endregion
        #region keyboard
        public Color KeycapColor = Color.White;
        private void InitMatrrix()
        {
            ClearButton();
            List<Button> buttons1 = ActiveMatrix.CreateButton(40);
            List<Button> buttons2 = ActiveMatrix.CreateButton(40);
            List<Button> buttons3 = ActiveMatrix.CreateButton(40);
            List<Button> buttons4 = ActiveMatrix.CreateIOButton(40);
            List<Button> buttons5 = ActiveMatrix.CreateRGBButton(40);
            for (int i = 0; i < buttons5.Count; i++)
            {
                buttons5[i].Text = ActiveMatrix.RGB[i].layer1+"/"+ ActiveMatrix.RGB[i].layer2;
                int colorIndex = Convert.ToInt32(ActiveMatrix.RGB[i].layer2);
                buttons5[i].BackColor = IColors.GetColor(colorIndex) ;
                buttons5[i].MouseDown += new MouseEventHandler(Keycap_Button_MouseClick);
                buttons5[i].TextChanged += new System.EventHandler(RGB_Keycap_TextChanged);
                RGBPage.Controls.Add(buttons5[i]);

            }
                for (int i = 0; i < buttons4.Count; i++)
            {
                buttons4[i].MouseDown += new MouseEventHandler(IO_Button_MouseClick);
                IOPage.Controls.Add(buttons4[i]);
            }
            for (int i = 0; i < buttons1.Count; i++)
            {
                buttons1[i].Text = ActiveMatrix.FuncCodes.FromFullName(ActiveMatrix.key_caps[i].layer1).ShortName;
                buttons1[i].BackColor = KeycapColor;
                buttons1[i].MouseDown += new MouseEventHandler(Keycap_Button_MouseClick);
                buttons1[i].TextChanged += new System.EventHandler(Layer1_Keycap_TextChanged);
                Layer1Page.Controls.Add(IKeycap.UpdateButton(buttons1[i]));
                buttons2[i].Text = ActiveMatrix.FuncCodes.FromFullName(ActiveMatrix.key_caps[i].layer2).ShortName;
                buttons2[i].BackColor = KeycapColor;
                buttons2[i].MouseDown += new MouseEventHandler(Keycap_Button_MouseClick);
                buttons2[i].TextChanged += new System.EventHandler(Layer2_Keycap_TextChanged);
                Layer2Page.Controls.Add(IKeycap.UpdateButton(buttons2[i]));
                buttons3[i].Text = ActiveMatrix.key_caps[i].R.ToString() + "/" + ActiveMatrix.key_caps[i].C.ToString();
                if (ActiveMatrix.ROWS != 0 || ActiveMatrix.COLS != 0)
                {
                    buttons3[i].BackColor = ActiveMatrix.IOColors[ActiveMatrix.key_caps[i].C];
                }
                buttons3[i].MouseDown += new MouseEventHandler(Keycap_Button_MouseClick);
                buttons3[i].TextChanged += new System.EventHandler(Schematic_Keycap_TextChanged);
                SchematicPage.Controls.Add(IKeycap.UpdateButton(buttons3[i]));
            }
            PidBox.Text = "0x" + ActiveMatrix.PRODUCT_ID.ToString("X");
            VidBox.Text = "0x" + ActiveMatrix.VENDOR_ID.ToString("X");
            EEPBox.Text = "0x" + ActiveMatrix.MAX_EEP.ToString("X");
            AddressBox.Text = "0x" + ActiveMatrix.ADD_EEP.ToString("X");
            Length1Box.Text = Convert.ToString(ActiveMatrix.MAX_EEP - ActiveMatrix.ADD_EEP);
            Length2Box.Text = Convert.ToString((ActiveMatrix.MAX_EEP - ActiveMatrix.ADD_EEP)/2);
        }
        private void ISO61_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK61_ISO();
            InitMatrrix();
        }
        private void ISO63_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK63_ISO();
            InitMatrrix();
        }
        private void ISO64_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK64_ISO();
            InitMatrrix();
        }
        private void ISO68_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK68_ISO();
            InitMatrrix();
        }
        private void ISO84_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK84_ISO();
            InitMatrrix();
        }
        private void ISO87_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK87_ISO();
            InitMatrrix();
        }
        private void ISO100_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK100_ISO();
            InitMatrrix();
        }
        private void ISO104_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK104_ISO();
            InitMatrrix();
        }
        private void ISO108_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK108_ISO();
            InitMatrrix();
        }
        private void WS64_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new WS64();
            InitMatrrix();
        }
        private void PG60_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new PG60();
            InitMatrrix();
        }
        #endregion
        #region uploadMatrix
        public static HidDevice HidDevice;
        private void Upload_Click(object sender, EventArgs e)
        {
            SelectKeysPanel.SelectedTab = ConsolePage;
            UploadMatrix();
        }
        private void EncodeMatrix_Click(object sender, EventArgs e)
        {
            SelectKeysPanel.SelectedTab = ConsolePage;
            if (ActiveMatrix == null)
            {
                Print("Nothing to upload,try to select a matrix.");
                return;
            }
            string codeTemp = ActiveMatrix.EncodeMatrix();
            Print(codeTemp);
        }
        private void OpenDevice()
        {
            try
            {
                HidDevice[] HidDeviceList = HidDevices.Enumerate(
                    ActiveMatrix.VENDOR_ID, ActiveMatrix.PRODUCT_ID, Convert.ToUInt16(0xFF31)).ToArray();
                if (HidDeviceList == null || HidDeviceList.Length == 0)
                {
                    Print("Connect usb device. Try open again or select a keyboard templet!");
                    HidDevice = null;
                    return;
                }
                for (int i = 0; i < HidDeviceList.Length; i++)
                {
                    Print(HidDeviceList[i].DevicePath);
                }
                HidDevice = HidDeviceList[0];
                if (HidDevice == null)
                {
                    Print("Connect usb device. Try open again.");
                    return;
                }
                Print("Device OK");
                byte[] outdata = new byte[9]; outdata[0] = 0;
                outdata[1] = 0xFF; outdata[2] = 0xFA;
                HidDevice.Write(outdata); Thread.Sleep(100);
                // 0xFFFA是open的flag
                // 0xFFF1是upload的flag
                // 0xFFF2是end的flag
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        private void UploadMatrix()
        {
            if (ActiveMatrix == null)
            {
                Print("Nothing to upload,try to select a matrix.");
                return;
            }
            OpenDevice();
            try
            {
                if (HidDevice == null)
                {
                    //Clear();
                    Print("Invalid device");
                    return;
                }
                string codeTemp = ActiveMatrix.EncodeMatrix();
                if (codeTemp == "")
                {
                    //Clear();
                    Print("Nothing to upload");
                    return;
                }
                string[] str = codeTemp.Split(',');

                //Clear();
                Print("Uploading");
                byte[] outdata = new byte[9]; outdata[0] = 0;
                outdata[1] = 0xFF; outdata[2] = 0xF1;
                HidDevice.Write(outdata); Thread.Sleep(100);
                for (ushort i = 0; i < ActiveMatrix.MAX_EEP; i += 6)
                {
                    outdata[0] = 0;
                    byte[] a = BitConverter.GetBytes(i);
                    outdata[1] = a[0]; outdata[2] = a[1];
                    if ((i + 5) < str.Length) { outdata[8] = Convert.ToByte(str[i + 5]); }
                    if ((i + 4) < str.Length) { outdata[7] = Convert.ToByte(str[i + 4]); }
                    if ((i + 3) < str.Length) { outdata[6] = Convert.ToByte(str[i + 3]); }
                    if ((i + 2) < str.Length) { outdata[5] = Convert.ToByte(str[i + 2]); }
                    if ((i + 1) < str.Length) { outdata[4] = Convert.ToByte(str[i + 1]); }
                    if (i < str.Length) { outdata[3] = Convert.ToByte(str[i]); }
                    else { break; }
                    HidDevice.Write(outdata);
                    string outdatastr = "";
                    outdatastr += outdata[1].ToString() + "/";
                    outdatastr += outdata[2].ToString() + "--";
                    outdatastr += outdata[3].ToString() + "/";
                    outdatastr += outdata[4].ToString() + "/";
                    outdatastr += outdata[5].ToString() + "/";
                    outdatastr += outdata[6].ToString() + "/";
                    outdatastr += outdata[7].ToString() + "/";
                    outdatastr += outdata[8].ToString();
                    Print(outdatastr);
                    Thread.Sleep(100);
                }
                outdata[1] = 0xFF; outdata[2] = 0xF2;
                HidDevice.Write(outdata); Thread.Sleep(100);
                Print("Upload finished");
            }
            catch (Exception ex) { Print(ex.ToString()); return; }
        }
        #endregion
        #region Testkey
        public bool keytest = false;
        protected override bool ProcessTabKey(bool forward)
        {
            return false;//禁用tab
        }
        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (keytest == false) return base.ProcessKeyPreview(ref m);
            long keyData = (long)m.LParam;
            keyData = keyData >> 16;
            Clear();
            Print(m.Msg.ToString("x") + " " + m.WParam.ToString() + " " + keyData.ToString("x"));
            //LParam 有键盘bios码,应该用这个来判断，注意码表版本
            for (int i = 0; i < MatrixPanel.SelectedTab.Controls.Count; i++)
            {
                if (m.Msg == 0x100 || m.Msg == 0x104)
                {
                    int code = ActiveMatrix.FuncCodes.FromShortName(
                        ((Button)MatrixPanel.SelectedTab.Controls[i]).Text).Bios;

                    if ((code & 0x0FFF) == (keyData & 0x0FFF))
                    {
                        ((Button)MatrixPanel.SelectedTab.Controls[i]).BackColor = Color.LightPink;
                    }
                }
                else if (m.Msg == 0x101 || m.Msg == 0x105)
                {
                    int code = ActiveMatrix.FuncCodes.FromShortName(
                        ((Button)MatrixPanel.SelectedTab.Controls[i]).Text).Bios;

                    if ((code & 0x0FFF) == (keyData & 0x0FFF))
                    {
                        ((Button)MatrixPanel.SelectedTab.Controls[i]).BackColor = Color.LightBlue;
                    }
                }
            }
            return true;
        }
        private void TestKey_Click(object sender, EventArgs e)
        {
            /*
         1、在Key事件的前置函数里面来获取按键bios码。
         2、在Form层级用protected override bool ProcessTabKey(bool forward)禁用tab键转移focus           
         */
            if (ActiveMatrix == null) return;
            for (int i = 0; i < Layer1Page.Controls.Count; i++)
            {
                ((Button)Layer1Page.Controls[i]).BackColor = KeycapColor;
            }
            for (int i = 0; i < Layer1Page.Controls.Count; i++)
            {
                ((Button)Layer2Page.Controls[i]).BackColor = KeycapColor;
            }
            if (TestKey_Enable.Text == "Close")
            {
                EnableControl();
                TestKey_Enable.Text = "Start";
                Layer1Page.BackColor = Color.White;
                Layer2Page.BackColor = Color.White;
                keytest = false;
            }
            else
            {
                //keytest start
                DisableControl();
                Clear();
                TestKey_Enable.Text = "Close";
                Layer1Page.BackColor = Color.LightGray;
                Layer2Page.BackColor = Color.LightGray;
                keytest = true;
            }
        }
        public void EnableControl()
        {
            menu1.Enabled = true;
            menu2.Enabled = true;
            menu3.Enabled = true;
            menu6.Enabled = true;
            SchematicPage.Enabled = true;
            USPage.Enabled = true;
            MacroPage.Enabled = true;
            IOPage.Enabled = true;
            RGBPage.Enabled = true;
            PrinterPage.Enabled = true;
           ColorPage.Enabled = true;
        }
        public void DisableControl()
        {
            SelectKeysPanel.SelectedTab = ConsolePage;
            MatrixPanel.SelectedTab = Layer1Page;
            menu1.Enabled = false;
            menu2.Enabled = false;
            menu3.Enabled = false;
            menu6.Enabled = false;
            SchematicPage.Enabled = false;
            USPage.Enabled = false;
            MacroPage.Enabled = false;
            IOPage.Enabled = false;
            RGBPage.Enabled = false;
            PrinterPage.Enabled = false;
            ColorPage.Enabled = false;
        }
        #endregion
        #region Printer
        public IEncode FuncEncode ;
        private void EncodeButton1_Click(object sender, EventArgs e)
        {
            FuncEncode.Solve(PrinterInputBox.Text, "GBK");
            PrinterEncodeBox.Text = FuncEncode.CodeHex;
        }
        private void EncodeButton2_Click(object sender, EventArgs e)
        {
            FuncEncode.Solve(PrinterInputBox.Text, "GB2312");
            PrinterEncodeBox.Text = FuncEncode.CodeHex;
        }
        private void EncodeButton3_Click(object sender, EventArgs e)
        {
          FuncEncode.Solve(PrinterInputBox.Text, "Big5");
            PrinterEncodeBox.Text = FuncEncode.CodeHex;
        }
        private void EncodeButton4_Click(object sender, EventArgs e)
        {
           FuncEncode.Solve(PrinterInputBox.Text, "Unicode");
            PrinterEncodeBox.Text = FuncEncode.CodeHex;
        }
        private void EncodeButton5_Click(object sender, EventArgs e)
        {
            FuncEncode.Solve(PrinterInputBox.Text, "UTF8");
            PrinterEncodeBox.Text = FuncEncode.CodeHex;
        }
        private void PrinterInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
        private void PrinterEncodeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
        private void Upload_Printer_Click(object sender, EventArgs e)
        {                
            OpenDevice();
            string CodeTemp= FuncEncode.CodeDec;
            try
            {
                if (ActiveMatrix == null) return;
                Print("eepromsize=" + ActiveMatrix.MAX_EEP.ToString());
                if (CodeTemp == "")
                {
                    Print("Nothing to upload");
                    return;
                }
                string[] str = CodeTemp.Split(',');
                if (HidDevice == null)
                {
                    Print("Invalid device");
                    return;
                }
                byte[] outdata = new byte[9]; outdata[0] = 0;
                byte[] a = new byte[2];
                outdata[1] = 0xFF; outdata[2] = 0xF1;
                HidDevice.Write(outdata); Thread.Sleep(100);//汇报符的等待时间和灯的延迟有关，必须大于一个灯的循环。
                for (ushort i = 0; (i * 2 + 4 + ActiveMatrix.ADD_EEP) < ActiveMatrix.MAX_EEP; i += 3)
                {
                    a = BitConverter.GetBytes((ushort)(i * 2 + ActiveMatrix.ADD_EEP));
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
                    Thread.Sleep(100);
                }
                outdata[1] = 0xFF; outdata[2] = 0xF2;
                HidDevice.Write(outdata); Thread.Sleep(100);
                Print("Upload finished");
            }
            catch (Exception ex) { Print(ex.ToString()); }    
    }
        #endregion
       
    }
}
