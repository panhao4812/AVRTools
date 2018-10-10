using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace HidRawTools
{
    public partial class HidRawTools : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1024, 800);
            this.panel1.Location = new Point(2, 30);
            panel1.Size = new Size(1002, 396);
            PrintBox.Size = new Size(220, 322);
            PrintBox.Location = new Point(2, 428);
            textBox1.Size = new Size(220, 322);
            textBox1.Location = new Point(222, 428);
            this.checkedListBox1.Size = new Size(220, 323);
            checkedListBox1.Location = new Point(444, 428);
            dataGridView1.Size = new Size(338, 322);
            dataGridView1.Location = new Point(666, 428);
            dataGridView1.RowCount = Program.KeyName.Length + 1;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            this.dataGridView1.Rows[0].Cells[0].Value = -1;
            this.dataGridView1.Rows[0].Cells[1].Value = "Blank";
            this.dataGridView1.Rows[0].Cells[2].Value = "";
            this.dataGridView1.Rows[0].Cells[3].Value = 0;
            this.dataGridView1.Rows[0].Cells[4].Value = 0;
            for (int i = 0; i < Program.KeyName.Length; i++)
            {
                this.dataGridView1.Rows[i + 1].Cells[0].Value = i;
                this.dataGridView1.Rows[i + 1].Cells[1].Value = Program.KeyName[i];
                this.dataGridView1.Rows[i + 1].Cells[2].Value = Program.KeyName2[i];
                this.dataGridView1.Rows[i + 1].Cells[3].Value = Program.Keycode[i];
                this.dataGridView1.Rows[i + 1].Cells[4].Value = Program.Keymask[i];
            }
        }
        private void SaveMatrix_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save(matrixname);
        }
        private void SaveAsFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save("");
        }
        private void HidRawTools_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (matrixname != "") save(matrixname);
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeButton();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(220, 220, 230), 1);
            g.DrawRectangle(pen, new Rectangle(35, 95, 727, 247));
            //  pen.Color = Color.FromArgb(170, 170, 170);
            g.DrawRectangle(pen, new Rectangle(35, 40, 727, 50));
            //  pen.Color = Color.FromArgb(170, 170, 170);
            g.DrawRectangle(pen, new Rectangle(767, 40, 199, 302));

        }
        private void ClearAll_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            Clear();
            panel1.BackgroundImage = null;
            panel1.Controls.Clear();
            for (int i = 0; i < matrix.keycode.Length; i++)
            {
                matrix.keycode[i] = "";
            }
            checkedListBox1.Items.Clear();
            matrix = null;
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectkey != null) selectkey.BackColor = Color.White;
            if (e.Button == MouseButtons.Right)
            {
                selectkey = null;
            }
            else
            {
                ((Button)sender).BackColor = Color.LightSalmon;
                selectkey = ((Button)sender);
            }
        }
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectkey != null) selectkey.BackColor = Color.White;
            if (e.Button == MouseButtons.Right)
            {
                selectkey = null;
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
                selectkey2 = ((Button)sender);
                int index = Convert.ToInt32(selectkey2.Name);
                matrix.RGB[index, 3] = c.R;
                matrix.RGB[index, 4] = c.G;
                matrix.RGB[index, 5] = c.B;
            }
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (selectkey != null) selectkey.BackColor = Color.White;
                selectkey = null;
            }
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (selectkey != null)
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                selectkey.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                int index = Convert.ToInt32(selectkey.Name);
                matrix.keycode[index + layer * keyCount] = selectkey.Text;
            }
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.ClearSelection();
            }
        }
        private void OpenMatrix_StripMenuItem_Click(object sender, EventArgs e)
        {
            String path = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                matrixname = path;
            }
            else
            {
                return;
            }
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader srd = new StreamReader(fs);
                string str = srd.ReadLine();
                string[] chara = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (!loadmatrix(chara[1])) return;
                while (srd.Peek() != -1)
                {
                    str = srd.ReadLine();
                    chara = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (chara.Length == 3)
                    {
                        int index = Convert.ToInt32(chara[0]);
                        checkedListBox1.SetItemChecked(index, true);
                        AddButton(index, Program.shortname(chara[1]));
                        matrix.keycode[index] = Program.shortname(chara[1]);
                        matrix.keycode[index + keyCount] = Program.shortname(chara[2]);
                    }
                    else if (chara.Length == 2)
                    {
                        int index = Convert.ToInt32(chara[0]);
                        checkedListBox1.SetItemChecked(index, true);
                        AddButton(index, Program.shortname(chara[1]));
                        matrix.keycode[index] = Program.shortname(chara[1]);
                    }
                    else if (chara.Length == 1)
                    {
                        int index = Convert.ToInt32(chara[0]);
                        checkedListBox1.SetItemChecked(index, true);
                        AddButton(index, "");
                    }
                    else if (chara.Length == 5)
                    {
                        int index = Convert.ToInt32(chara[0]);
                        AddRGBButton(index, Convert.ToInt32(chara[1]),
                            Convert.ToInt32(chara[2]), Convert.ToInt32(chara[3]), Convert.ToInt32(chara[4]));
                    }
                }
                srd.Close();
                panel1.BackgroundImage = img;
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
                panel1.BackgroundImage = img;
            }
        }
        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDevice();
            try
            {
                if (HidDevice == null)
                {
                    //Clear();
                    Print("Invalid device");
                    return;
                }
                string codeTemp = ToEEP();
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
                HidDevice.Write(outdata); Thread.Sleep(60);
                for (ushort i = 0; i < matrix.eepromsize; i += 6)
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
                    Thread.Sleep(60);
                }
                outdata[1] = 0xFF; outdata[2] = 0xF2;
                HidDevice.Write(outdata); Thread.Sleep(60);
                Print("Upload finished");
            }
            catch (Exception ex) { Print(ex.ToString()); return; }
        }
        private void xShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD60_A")) { Open(); }
        }
        private void xShiftToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD60_B")) { Open(); }
        }
        private void tinykeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("Tinykey")) { Open(); }
        }
        private void xshiftToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (loadmatrix("bface60_B")) { Open(); }
        }
        private void minilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("bface60_minila")) { Open(); }
        }
        private void xD75ReToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD75_Re")) { Open(); }
        }
        private void xD004ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD004")) { Open(); }
        }
        private void StaryuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("Staryu")) { Open(); }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (layer != 0)
            {
                layer = 0;
                changeButton();
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (layer != 1)
            {
                layer = 1;
                changeButton();
            }
        }
        private void FixedRGBStripMenuItem_Click(object sender, EventArgs e)
        {
            if (matrix == null) return;
            if (matrix.RGB == null || matrix.RGB.GetUpperBound(0) < 0) return;
            if ((RGB_Type & 0x0F) == 0x01)
            {
                this.editToolStripMenuItem.Text = "Rainbow";
                RGB_Type &= (byte)0xF0;
                for (int i = matrix.RGB.GetLowerBound(0); i <= matrix.RGB.GetUpperBound(0); i++)
                {
                    matrix.RGB[i, 2] = RGB_Type;
                }
            }
            else
            {
                this.editToolStripMenuItem.Text = "FixedColor";
                RGB_Type |= (byte)0x01;
                for (int i = matrix.RGB.GetLowerBound(0); i <= matrix.RGB.GetUpperBound(0); i++)
                {
                    matrix.RGB[i, 2] = RGB_Type;
                    matrix.RGB[i, 3] = 255;
                    matrix.RGB[i, 4] = 255;
                    matrix.RGB[i, 5] = 255;
                }
            }
            Print("RGB_Type = " + RGB_Type);
            changeButton();
        }
        private void rainfullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (matrix == null) return;
            if (matrix.RGB == null || matrix.RGB.GetUpperBound(0) < 0) return;
            RGB_Type |= (byte)0x01;
            for (int i = matrix.RGB.GetLowerBound(0); i <= matrix.RGB.GetUpperBound(0); i++)
            {
                matrix.RGB[i, 2] = RGB_Type;
                matrix.RGB[i, 3] = 255;
                matrix.RGB[i, 4] = 255;
                matrix.RGB[i, 5] = 255;
            }
            Print("RGB_Type = " + RGB_Type);
            changeButton();
        }
        private void oNOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (matrix == null) return;
            if (matrix.RGB == null || matrix.RGB.GetUpperBound(0) < 0) return;

            if ((RGB_Type & 0xF0) == 0) { this.oNOFFToolStripMenuItem.Text = "Default OFF"; RGB_Type ^= (byte)0x10; }
            else { this.oNOFFToolStripMenuItem.Text = "Default ON"; RGB_Type ^= (byte)0x10; }
            for (int i = matrix.RGB.GetLowerBound(0); i <= matrix.RGB.GetUpperBound(0); i++)
            {
                matrix.RGB[i, 2] = RGB_Type;
            }
            Print("RGB_Type = " + RGB_Type);
            changeButton();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutText();
        }
        private void eEPROMToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void PrintBox_KeyDown(object sender, KeyEventArgs e)
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
        private void gBKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iencode = "GBK";
            UploadPrintBox();
        }
        private void unicodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iencode = "Unicode";
            UploadPrintBox();
        }
        private void writeToFlashInUnicodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iencode = "Unicode";
            WriteToHex();
        }
        private void writeToHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iencode = "GBK";
            WriteToHex();
        }
    }
}