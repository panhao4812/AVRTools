using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HidRawTools
{
    public partial class HidRawTools : Form
    {
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
            Print(m.Msg.ToString("x")+ " "+ m.WParam.ToString() + " " +keyData.ToString("x"));
            //LParam 有键盘bios码,应该用这个来判断，注意码表版本
            for (int i = 0; i < KeymapPanel.Controls.Count; i++)
            {
                if (m.Msg == 0x100|| m.Msg == 0x104)
                {
                    int code = IKeycode.KeyName2BIOS(((Button)KeymapPanel.Controls[i]).Text);
                    
                    if ((code & 0x0FFF) == (keyData & 0x0FFF))
                    {
                        ((Button)KeymapPanel.Controls[i]).BackColor = Color.LightPink;
                    }
                }
                else if (m.Msg == 0x101 || m.Msg == 0x105)
                {
                    int code = IKeycode.KeyName2BIOS(((Button)KeymapPanel.Controls[i]).Text);

                    if ((code & 0x0FFF) == (keyData & 0x0FFF))
                    {
                        ((Button)KeymapPanel.Controls[i]).BackColor = Color.LightBlue;
                    }
                }
            }
            return true;
        }
        public HidRawTools()
        {
            InitializeComponent();
        }
        public static void ThreadProc()
        {
            libusbtool form = new libusbtool();//第2个窗体
            form.ShowDialog();
        }
        private void HidRawTools_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1024, 800);
            this.KeymapPanel.Location = new Point(2, 30);
            KeymapPanel.Size = new Size(1002, 396);
            PrintBox.Size = new Size(220, 322);
            PrintBox.Location = new Point(2, 428);
            ConsoleBox.Size = new Size(220, 322);
            ConsoleBox.Location = new Point(222, 428);
            this.KeymapEditBox.Size = new Size(220, 323);
            KeymapEditBox.Location = new Point(444, 428);
            KeycodeSelectionBox.Size = new Size(338, 322);
            KeycodeSelectionBox.Location = new Point(666, 428);
            KeycodeSelectionBox.RowCount = IKeycode.KeyName.Length + 1;
            for (int i = 0; i < this.KeycodeSelectionBox.Columns.Count; i++)
            {
                this.KeycodeSelectionBox.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            this.KeycodeSelectionBox.Rows[0].Cells[0].Value = -1;
            this.KeycodeSelectionBox.Rows[0].Cells[1].Value = "Blank";
            this.KeycodeSelectionBox.Rows[0].Cells[2].Value = "";
            this.KeycodeSelectionBox.Rows[0].Cells[3].Value = 0;
            this.KeycodeSelectionBox.Rows[0].Cells[4].Value = 0;
            for (int i = 0; i < IKeycode.KeyName.Length; i++)
            {
                this.KeycodeSelectionBox.Rows[i + 1].Cells[0].Value = i;
                this.KeycodeSelectionBox.Rows[i + 1].Cells[1].Value = IKeycode.KeyName[i];
                this.KeycodeSelectionBox.Rows[i + 1].Cells[2].Value = IKeycode.KeyName2[i];
                this.KeycodeSelectionBox.Rows[i + 1].Cells[3].Value = IKeycode.Keycode[i];
                this.KeycodeSelectionBox.Rows[i + 1].Cells[4].Value = IKeycode.Keymask[i];
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            FileSave(MatrixName);
        }
        private void SaveAsFile_Click(object sender, EventArgs e)
        {
            FileSave("");
        }
        private void HidRawTools_FormClosing(object sender, FormClosingEventArgs e)
        {
           // if (MatrixName != "") FileSave(MatrixName);
        }
        private void CheckedLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeButton();
        }
        private void KeymapPanel_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = KeymapPanel.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(220, 220, 230), 1);
            g.DrawRectangle(pen, new Rectangle(35, 95, 727, 247));
            //  pen.Color = Color.FromArgb(170, 170, 170);
            g.DrawRectangle(pen, new Rectangle(35, 40, 727, 50));
            //  pen.Color = Color.FromArgb(170, 170, 170);
            g.DrawRectangle(pen, new Rectangle(767, 40, 199, 302));

        }
        private void ClearAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < KeymapEditBox.Items.Count; i++)
            {
                KeymapEditBox.SetItemChecked(i, false);
            }
            Clear();
            KeymapPanel.BackgroundImage = null;
            KeymapPanel.Controls.Clear();
            for (int i = 0; i < ActiveMatrix.keycode.Length; i++)
            {
                ActiveMatrix.keycode[i] = "";
            }
            KeymapEditBox.Items.Clear();
            ActiveMatrix = null;
        }
        private void KeymapPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (SelectKey1 != null) SelectKey1.BackColor = Color.White;
                SelectKey1 = null;
            }
        }
        private void KeycodeBox_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectKey1 != null)
            {
                int i = KeycodeSelectionBox.CurrentCell.RowIndex;
                SelectKey1.Text = KeycodeSelectionBox.Rows[i].Cells[2].Value.ToString();
                int index = Convert.ToInt32(SelectKey1.Name);
                ActiveMatrix.keycode[index + Layer * KeyCount] = SelectKey1.Text;
            }
        }
        private void KeycodeBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                KeycodeSelectionBox.ClearSelection();
            }
        }
        private void OpenMatrix_Click(object sender, EventArgs e)
        {
            FileOpen();
        }
        private void Upload_Click(object sender, EventArgs e)
        {
            UploadMatrix();
        }
        private void Layer0Button_MouseClick(object sender, MouseEventArgs e)
        {
            //key button
            if (SelectKey1 != null) SelectKey1.BackColor = Color.White;
            if (e.Button == MouseButtons.Right)
            {
                SelectKey1 = null;
            }
            else
            {
                ((Button)sender).BackColor = Color.LightSalmon;
                SelectKey1 = ((Button)sender);
            }
            ConsoleBox.Focus();
        }
        private void Layer1Button_MouseClick(object sender, MouseEventArgs e)
        {
            //RGB_button
            if (SelectKey1 != null) SelectKey1.BackColor = Color.White;
            if (e.Button == MouseButtons.Right)
            {
                SelectKey1 = null;
            }
            else
            {
                ColorDialog myColorDialog = new ColorDialog();
                Color c = Color.White;
                if (myColorDialog.ShowDialog() == DialogResult.OK)
                {
                    c = myColorDialog.Color;

                }
                 ((Button)sender).BackColor = c;
                SelectKey2 = ((Button)sender);
                int index = Convert.ToInt32(SelectKey2.Name);
                ActiveMatrix.RGB[index, 3] = c.R;
                ActiveMatrix.RGB[index, 4] = c.G;
                ActiveMatrix.RGB[index, 5] = c.B;
            }
            ConsoleBox.Focus();
        }
        private void Layer0Button_CheckedChanged(object sender, EventArgs e)
        {
            if (Layer != 0)
            {
                Layer = 0;
                changeButton();
            }
            ConsoleBox.Focus();
        }
        private void Layer1Button_CheckedChanged(object sender, EventArgs e)
        {
            if (Layer != 1)
            {
                Layer = 1;
                changeButton();
            }
            ConsoleBox.Focus();
        }
        private void FixedRGB_Click(object sender, EventArgs e)
        {
            if (ActiveMatrix == null) return;
            if (ActiveMatrix.RGB == null || ActiveMatrix.RGB.GetUpperBound(0) < 0) return;
            RGB_Type++;
            if ((RGB_Type & 0x0F) > 1)
            {
                if (ActiveMatrix.Name != "CXT64") RGB_Type &= 0xF0;
            }
            if ((RGB_Type & 0x0F) > 2)
            {
                RGB_Type &= 0xF0;
            }

            if ((RGB_Type & 0x0F) == 0x00)
            {
                this.editToolStripMenuItem.Text = "Default is FixedColor,click to change.";

                for (int i = ActiveMatrix.RGB.GetLowerBound(0); i <= ActiveMatrix.RGB.GetUpperBound(0); i++)
                {
                    ActiveMatrix.RGB[i, 2] = RGB_Type;
                }
            }
            else if ((RGB_Type & 0x0F) == 0x01)
            {
                this.editToolStripMenuItem.Text = "Default is Rainbow,click to change.";

                for (int i = ActiveMatrix.RGB.GetLowerBound(0); i <= ActiveMatrix.RGB.GetUpperBound(0); i++)
                {
                    ActiveMatrix.RGB[i, 2] = RGB_Type;
                }
            }
            else
            {
                this.editToolStripMenuItem.Text = "Default is PrintLight,click to change.";

                for (int i = ActiveMatrix.RGB.GetLowerBound(0); i <= ActiveMatrix.RGB.GetUpperBound(0); i++)
                {
                    ActiveMatrix.RGB[i, 2] = RGB_Type;
                }
            }
            Print("RGB_Type = " + RGB_Type);
            changeButton();
        }
        private void ONOFFRGB_Click(object sender, EventArgs e)
        {

            if (ActiveMatrix == null) return;
            if (ActiveMatrix.RGB == null || ActiveMatrix.RGB.GetUpperBound(0) < 0) return;

            if ((RGB_Type & 0xF0) == 0) { this.oNOFFToolStripMenuItem.Text = "Default is ON,click to turn off."; RGB_Type ^= (byte)0x10; }
            else { this.oNOFFToolStripMenuItem.Text = "Default is OFF,click to turn on."; RGB_Type ^= (byte)0x10; }
            for (int i = ActiveMatrix.RGB.GetLowerBound(0); i <= ActiveMatrix.RGB.GetUpperBound(0); i++)
            {
                ActiveMatrix.RGB[i, 2] = RGB_Type;
            }
            Print("RGB_Type = " + RGB_Type);
            changeButton();
        }
        private void About_Click(object sender, EventArgs e)
        {
            AboutText();
        }
        private void DebugTools_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void PrintBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == System.Windows.Forms.Keys.Control && e.KeyCode == System.Windows.Forms.Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
        private void ConsoleBox_KeyDown(object sender, KeyEventArgs e)
        {        
                if (e.Modifiers == System.Windows.Forms.Keys.Control && e.KeyCode == System.Windows.Forms.Keys.A)
                {
                    ((TextBox)sender).SelectAll();
                }              
        }      
        private void GBK_Click(object sender, EventArgs e)
        {
            IEncode = "GBK";
            UploadPrintBox();
        }
        private void Unicode_Click(object sender, EventArgs e)
        {
            IEncode = "Unicode";
            UploadPrintBox();
        }
        private void WriteToFlash_Unicode_Click(object sender, EventArgs e)
        {
            IEncode = "Unicode";
            WriteToHex();
        }
        private void WriteToHex_GBK_Click(object sender, EventArgs e)
        {
            IEncode = "GBK";
            WriteToHex();
        }
        private void ExportMatrix_Click(object sender, EventArgs e)
        {
            FileExport("");
        }
        public bool loadmatrix(string _name)
        {
            if (_name == "XD60_A")
            {
                ActiveMatrix = new XD60_A();
                VidBox.Text = "32C4";
                PidBox.Text = "D060";
                PanelImage = null;
                PanelImage = Properties.Resources.xd60;
            }
            else if (_name == "XD60_B")
            {
                ActiveMatrix = new XD60_B();
                VidBox.Text = "32C4";
                PidBox.Text = "D060";
                PanelImage = null;
                PanelImage = Properties.Resources.xd60;
            }
            else if (_name == "bface60_minila")
            {
                ActiveMatrix = new bface60_minila();
                VidBox.Text = "32A0";
                PidBox.Text = "B060";
                PanelImage = null;
                //PanelImage = Properties.Resources.tinykey2;
            }
            else if (_name == "bface60_B")
            {
                ActiveMatrix = new bface60_B();
                VidBox.Text = "32A0";
                PidBox.Text = "B060";
                PanelImage = null;
                //PanelImage = Properties.Resources.tinykey2;
            }
            else if (_name == "Staryu")
            {
                ActiveMatrix = new Staryu();
                VidBox.Text = "32C2";
                PidBox.Text = "D005";
                PanelImage = null;
                PanelImage = Properties.Resources.staryu;
            }
            else if (_name == "XD004")
            {
                ActiveMatrix = new XD004();
                VidBox.Text = "16C2";
                PidBox.Text = "D004";
                PanelImage = null;
                PanelImage = Properties.Resources.xd04;
            }
            else if (_name == "Tinykey")
            {
                ActiveMatrix = new Tinykey();
                VidBox.Text = "D850";
                PidBox.Text = "D002";
                PanelImage = null;
                PanelImage = Properties.Resources.xd002;
            }
            else if (_name == "XD75_Re")
            {
                ActiveMatrix = new XD75_Re();
                VidBox.Text = "32C4";
                PidBox.Text = "D075";
                PanelImage = null;
                PanelImage = Properties.Resources.xd75;
            }
            else if (_name == "bface96")
            {
                ActiveMatrix = new bface96();
                VidBox.Text = "32A0";
                PidBox.Text = "B096";
                PanelImage = null;
            }
            else if (_name == "QMK60_ISO")
            {
                ActiveMatrix = new QMK60_ISO();
                VidBox.Text = "32C4";
                PidBox.Text = "A060";
                PanelImage = null;
            }
            else if (_name == "QMK60_175Shift")
            {
                ActiveMatrix = new QMK63();
                VidBox.Text = "32C4";
                PidBox.Text = "A060";
                PanelImage = null;
            }
            else if (_name == "QMK60_2Shift")
            {
                ActiveMatrix = new QMK64();
                VidBox.Text = "32C4";
                PidBox.Text = "A060";
                PanelImage = null;
            }
            else if (_name == "QMK96_ISO")
            {
                ActiveMatrix = new QMK96_ISO();
                VidBox.Text = "32C4";
                PidBox.Text = "A096";
                PanelImage = null;
            }
            else if (_name == "QMK84_ISO")
            {
                ActiveMatrix = new QMK84_ISO();
                VidBox.Text = "32C4";
                PidBox.Text = "A084";
                PanelImage = null;
            }
            else if (_name == "QMK87_ISO")
            {
                ActiveMatrix = new QMK87_ISO();
                VidBox.Text = "32C4";
                PidBox.Text = "A087";
                PanelImage = null;
            }
            else if (_name == "QMK68_ISO")
            {
                ActiveMatrix = new QMK68_ISO();
                VidBox.Text = "32C4";
                PidBox.Text = "A068";
                PanelImage = null;
            }
            else if (_name == "CXT64")
            {
                ActiveMatrix = new CXT64();
                VidBox.Text = "32C4";
                PidBox.Text = "F060";
                PanelImage = null;
            }
            else if (_name == "KC84_LILILI")
            {
                ActiveMatrix = new KC84_LILILI();
                VidBox.Text = "32C4";
                PidBox.Text = "F184";
                PanelImage = null;
            }
            else if (_name == "KC84_Vem")
            {
                ActiveMatrix = new KC84_Vem();
                VidBox.Text = "32C4";
                PidBox.Text = "F284";
                PanelImage = null;
            }
            else return false;
            Layer = 0;
            KeyCount = ActiveMatrix.keycap.GetUpperBound(0) + 1;
            ////////////////////////////////////////
            KeymapPanel.BackgroundImage = null;
            KeymapEditBox.Items.Clear();
            KeymapPanel.Controls.Clear();
            Clear();
            for (int i = 0; i < KeyCount; i++)
            {
                string name = i.ToString(); int length = 0;
                length = 4 - name.Length;
                for (int j = 0; j < length; j++) { name += " "; }
                name += "C:" + ActiveMatrix.keycap[i, 0].ToString();
                name += "/" + ActiveMatrix.keycap[i, 1].ToString();
                length = 16 - name.Length;
                for (int j = 0; j < length; j++) { name += " "; }
                name += "L:" + ActiveMatrix.keycap[i, 2].ToString();
                length = 24 - name.Length;
                for (int j = 0; j < length; j++) { name += " "; }
                name += "M:" + ActiveMatrix.keycap[i, 3].ToString() + "/" + ActiveMatrix.keycap[i, 4].ToString();
                KeymapEditBox.Items.Add(name);
            }
            layer1Button.Checked = false;
            Layer0Button.Checked = true;
            return true;
        }
        private void bface60_B_Click(object sender, EventArgs e)
        {
            if (loadmatrix("bface60_B")) { InitMatrix(); }
        }
        private void bface96_Click(object sender, EventArgs e)
        {
            if (loadmatrix("bface96")) { InitMatrix(); }
        }
        private void bface60_minila_Click(object sender, EventArgs e)
        {
            if (loadmatrix("bface60_minila")) { InitMatrix(); }
        }
        private void XD75_Re_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD75_Re")) { InitMatrix(); }
        }
        private void XD60_A_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD60_A")) { InitMatrix(); }
        }
        private void XD60_B_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD60_B")) { InitMatrix(); }
        }
        private void Tinykey_Click(object sender, EventArgs e)
        {
            if (loadmatrix("Tinykey")) { InitMatrix(); }
        }
        private void XD004_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD004")) { InitMatrix(); }
        }
        private void CXT64_Click(object sender, EventArgs e)
        {
            if (loadmatrix("CXT64")) { InitMatrix(); }
            Print(ActiveMatrix.Debug_output);
        }
        private void Vem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("KC84_Vem")) { InitMatrix(); }
            Print(ActiveMatrix.Debug_output);
        }
        private void lILILI_Click(object sender, EventArgs e)
        {
            if (loadmatrix("KC84_LILILI")) { InitMatrix(); }
            Print(ActiveMatrix.Debug_output);
        }
        private void QMK60_ISO(object sender, EventArgs e)
        {
            if (loadmatrix("QMK60_ISO")) { InitMatrix(); }
        }
        private void QMK60_175Shift_Click(object sender, EventArgs e)
        {
            if (loadmatrix("QMK60_175Shift")) { InitMatrix(); }
        }
        private void QMK60_2Shift_Click(object sender, EventArgs e)
        {
            if (loadmatrix("QMK60_2Shift")) { InitMatrix(); }
        }
        private void QMK96_ISO_Click(object sender, EventArgs e)
        {
            if (loadmatrix("QMK96_ISO")) { InitMatrix(); }
        }
        private void QMK84_Click(object sender, EventArgs e)
        {
            if (loadmatrix("QMK84_ISO")) { InitMatrix(); }
        }
        private void QMK68_Click(object sender, EventArgs e)
        {
            if (loadmatrix("QMK68_ISO")) { InitMatrix(); }
        }
        private void QMK87_Click(object sender, EventArgs e)
        {
            if (loadmatrix("QMK87_ISO")) { InitMatrix(); }
        }
        private void staryuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("Staryu")) { InitMatrix(); }
        }
        private void TestKeyMenuItem_Click(object sender, EventArgs e)
        {
            /*
            1、在Key事件的前置函数里面来获取按键bios码。
            2、在Form层级用protected override bool ProcessTabKey(bool forward)禁用tab键转移focus           
            */
            for (int i = 0; i < KeymapPanel.Controls.Count; i++)
            {
                if (((Button)KeymapPanel.Controls[i]).Size.Width > 25)
                {
                    //排除RGB button
                    ((Button)KeymapPanel.Controls[i]).BackColor = Color.White;
                }
            }
            if (clearToolStripMenuItem.Name == "Close")
            {
                EnableControl();
                clearToolStripMenuItem.Name = "start";
                KeymapPanel.BackColor = Color.White;
                keytest = false;         
            }
            else
            {
                //keytest start
                DisableControl();
                Clear();
                clearToolStripMenuItem.Name = "Close";
                KeymapPanel.BackColor = Color.LightGray;
                keytest = true;
            }
        }
    }
}