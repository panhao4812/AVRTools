using System;
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
        public HidRawTools()
        {
            InitializeComponent();
          
        }
        public void Clear()
        {
            textBox1.Text = "";
        }
        public void Print(Object str)
        {
            textBox1.Text += str.ToString() + "\r\n";
        }
        IMatrix matrix;
        double keycaplength = 48;
        double keycapoffset = 1;
        Button selectkey = null;
        int layer = 0;
        public static HidDevice HidDevice;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1024, 800);
            this.panel1.Location = new Point(0, 31);
            panel1.Size = new Size(1006, 395);
            textBox1.Size = new Size(330, 322);
            textBox1.Location = new Point(2, 428);
            this.checkedListBox1.Size = new Size(330, 322);
            checkedListBox1.Location = new Point(334, 428);
            dataGridView1.Size = new Size(338, 322);
            dataGridView1.Location = new Point(666, 428);
            dataGridView1.RowCount = Program.KeyName.Length + 1;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            this.dataGridView1.Rows[0].Cells[0].Value = "Blank";
            this.dataGridView1.Rows[0].Cells[1].Value = "";
            this.dataGridView1.Rows[0].Cells[2].Value = 0;
            this.dataGridView1.Rows[0].Cells[3].Value = 0;
            for (int i = 0; i < Program.KeyName.Length; i++)
            {
                this.dataGridView1.Rows[i + 1].Cells[0].Value = Program.KeyName[i];
                this.dataGridView1.Rows[i + 1].Cells[1].Value = Program.KeyName2[i];
                this.dataGridView1.Rows[i + 1].Cells[2].Value = Program.Keycode[i];
                this.dataGridView1.Rows[i + 1].Cells[3].Value = Program.Keymask[i];
            }         
        }
        private void matrix2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 2;
                sfd.RestoreDirectory = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    path = sfd.FileName;
                    FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                    fs.SetLength(0);
                    StreamWriter stream = new StreamWriter(fs);
                    string output = "";
                    for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
                    {
                        int index = checkedListBox1.CheckedIndices[i];
                        string str = checkedListBox1.CheckedIndices[i].ToString();
                        //  string[] chara = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        output += str + "," + Program.longname(matrix.keycode[index]) + "," + Program.longname(matrix.keycode[index + keyCount]) + "\r\n";
                    }
                    stream.Write(output);
                    stream.Flush();
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        void save()
        {
            try
            {
                String path = Environment.CurrentDirectory + "/" + matrix.Name.ToString() + ".txt";
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.SetLength(0);
                StreamWriter stream = new StreamWriter(fs);
                string output = "";
                for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
                {
                    int index = checkedListBox1.CheckedIndices[i];
                    string str = checkedListBox1.CheckedIndices[i].ToString();
                    //  string[] chara = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    output +=str + "," + Program.longname(matrix.keycode[index]) + "," + Program.longname(matrix.keycode[index + keyCount]) + "\r\n";
                }
                stream.Write(output);
                stream.Flush();
                stream.Close();
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
     
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeButton();
        }
        void changeButton()
        {
            Clear();
            panel1.Controls.Clear();

            for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
            {
                string str = checkedListBox1.CheckedIndices[i].ToString();
                int index = checkedListBox1.CheckedIndices[i];
                AddButton(index, matrix.keycode[index + layer * keyCount]);
            }
        }
        public void AddButton(int index, string str)
        {
            double x = matrix.keycap[index, 0];
            double y = matrix.keycap[index, 1];
            double length = matrix.keycap[index, 2];
            double row = matrix.keycap[index, 3];
            double col = matrix.keycap[index, 4];
            Button button = new Button();
            panel1.Controls.Add(button);
            button.Size = new Size((int)(keycaplength * length - keycapoffset * 2), (int)(keycaplength - keycapoffset * 2));
            button.Location = new Point(35 + (int)(x * keycaplength), 100 + (int)(y * keycaplength));
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.White;
            button.Enter += new System.EventHandler(this.button1_Enter);
            button.Text = str;
            button.Name = index.ToString();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(220, 220, 230), 3);
            g.DrawRectangle(pen, new Rectangle(30, 95, 727, 247));
          //  pen.Color = Color.FromArgb(170, 170, 170);
            g.DrawRectangle(pen, new Rectangle(30, 40, 727, 50));
          //  pen.Color = Color.FromArgb(170, 170, 170);
            g.DrawRectangle(pen, new Rectangle(762, 40, 210, 302));
        }
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            Clear();
            panel1.Controls.Clear();
            for (int i = 0; i < matrix.keycode.Length; i++)
            {
                matrix.keycode[i] = "";
            }
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                ((Button)panel1.Controls[i]).BackColor = Color.White;
            }
            ((Button)sender).BackColor = Color.LightSalmon;
            selectkey = ((Button)sender);
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    ((Button)panel1.Controls[i]).BackColor = Color.White;
                }
                selectkey = null;
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (selectkey != null)
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                selectkey.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
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
        void Open()
        {
            try {
                for (int i = 0; i < matrix.Defaultkeycode.Length; i++) {
                    string str = matrix.Defaultkeycode[i];
                    string[] chara = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
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
                }
            }
            catch(Exception ex)
            {
                Print(ex.ToString());
            }
        }
        void Open(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader srd = new StreamReader(fs);
                while (srd.Peek() != -1)
                {
                    string str = srd.ReadLine();
                    string[] chara = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
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
                }
                srd.Close();
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        private void matrix1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String path = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                string Name = Path.GetFileNameWithoutExtension(path);
                if (!loadmatrix(Name)) return;
                Open(path);
            }
        }

        private void layer1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (layer == 0)
            {
                layer = 1;
                this.menuStrip1.Items[3].Text = "Layer1";
                changeButton();
            }
            else {
                layer = 0;
                this.menuStrip1.Items[3].Text = "Layer0";
                changeButton();
            }
        }

        private void HidRawTools_FormClosing(object sender, FormClosingEventArgs e)
        {
            save();
        }

        private void openDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ushort vid = 0, pid = 0;
            if (textBox3.Text != "" && textBox2.Text != "")
            {
                vid = (ushort)Convert.ToInt32(textBox3.Text, 16);
                pid = (ushort)Convert.ToInt32(textBox2.Text, 16);
            }
            Clear();
            Print("0x" + vid.ToString("x"));
            Print("0x" + pid.ToString("x"));
            try
            {
                HidDevice[] HidDeviceList = HidDevices.Enumerate(vid, pid, Convert.ToUInt16(0xFF31)).ToArray();
                if (HidDeviceList == null || HidDeviceList.Length == 0)
                {
                    Print("Connect usb device. Try open again");
                    return;
                }
                for (int i = 0; i < HidDeviceList.Length; i++)
                {
                    Print(HidDeviceList[i].DevicePath);
                    HidDevice = HidDeviceList[0];
                    break;
                }
                if (HidDevice == null)
                {
                    Print("Connect usb device. Try open again");
                    return;
                }
                Print("Device OK");
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        public string ToEEP()
        {
            for(int r = 0; r < matrix.ROWS; r++)
            {
                for (int c = 0; c < matrix.COLS; c++)
                {
                    matrix.hexaKeys0[r, c] = "0x00";
                    matrix.hexaKeys1[r, c] = "0x00";
                }
            }
            for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
            {
                int index = checkedListBox1.CheckedIndices[i];
                string str0 = matrix.keycode[index];
                string str1= matrix.keycode[index + keyCount];
                int r = (int)matrix.keycap[index, 3];
                int c = (int)matrix.keycap[index, 4];
                matrix.hexaKeys0[r, c] = str0;
                matrix.hexaKeys1[r, c] = str1;
            }
                try
            {
                ushort add1 = 5 * 2;
                ushort add2 = (ushort)(add1 + matrix.ROWS);
                ushort add3 = (ushort)(add2 + matrix.COLS);
                ushort add4 = (ushort)(add3 + matrix.ROWS* matrix.COLS);
                ushort add5 = (ushort)(add4 + matrix.ROWS * matrix.COLS);
                StringBuilder output = new StringBuilder();
                byte[] a = BitConverter.GetBytes(add1);
                output.Append(a[0]); output.Append(","); output.Append(a[1]); output.Append(",");
                a = BitConverter.GetBytes(add2);
                output.Append(a[0]); output.Append(","); output.Append(a[1]); output.Append(",");
                a = BitConverter.GetBytes(add3);
                output.Append(a[0]); output.Append(","); output.Append(a[1]); output.Append(",");
                a = BitConverter.GetBytes(add4);
                output.Append(a[0]); output.Append(","); output.Append(a[1]); output.Append(",");
                a = BitConverter.GetBytes(add5);
                output.Append(a[0]); output.Append(","); output.Append(a[1]); output.Append(",");
                for (int i = 0; i < matrix.ROWS; i++)
                {
                    output.Append(matrix.rowPins[i]); output.Append(",");
                }
                for (int i = 0; i < matrix.COLS; i++)
                {
                    output.Append(matrix.colPins[i]); output.Append(",");
                }
                int[,] mask = new int[matrix.ROWS, matrix.COLS];
                for (int r = 0; r < matrix.ROWS; r++)
                {
                    for (int c = 0; c < matrix.COLS; c++)
                    {
                        string code1 = matrix.hexaKeys0[r,c];
                        int mask1 = 0;
                        int code = Program.name2code(code1, out mask1);
                        mask[r, c] += mask1 * 16;
                        output.Append(code); output.Append(",");
                    }
                }
                for (int r = 0; r < matrix.ROWS; r++)
                {
                    for (int c = 0; c < matrix.COLS; c++)
                    {
                        string code2 = matrix.hexaKeys1[r, c];
                        int mask2 = 0;
                        int code = Program.name2code(code2, out mask2);
                        mask[r, c] += mask2;
                        output.Append(code); output.Append(",");
                    }
                }
                for (int r = 0; r < matrix.ROWS; r++)
                {
                    for (int c = 0; c < matrix.COLS; c++)
                    {
                        output.Append(mask[r, c]); output.Append(",");
                    }
                }
                output.Append((byte)0);
                return output.ToString();
            }
            catch
            {
                return "Select a Matrix.Try again.";
            }
        }
        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string codeTemp = ToEEP();
                if (codeTemp == "")
                {
                    Clear();
                    Print("Nothing to upload");
                    return;
                }
                string[] str = codeTemp.Split(',');
                if (HidDevice == null)
                {
                    Clear();
                    Print("Invalid device");
                    return;
                }
                Clear();
                Print("Uploading");
                byte[] outdata = new byte[9]; outdata[0] = 0;
                outdata[1] = 0xFF; outdata[2] = 0xF1;
                HidDevice.Write(outdata); Thread.Sleep(60);
                for (ushort i = 0; i < Convert.ToInt32(0x03FF); i += 6)
                {
                    outdata[0] = 0;
                    byte[] a = BitConverter.GetBytes(i);
                    outdata[1] = a[0]; outdata[2] = a[1];
                    if ((i + 5) < str.Length) outdata[8] = Convert.ToByte(str[i + 5]);
                    if ((i + 4) < str.Length) outdata[7] = Convert.ToByte(str[i + 4]);
                    if ((i + 3) < str.Length) outdata[6] = Convert.ToByte(str[i + 3]);
                    if ((i + 2) < str.Length) outdata[5] = Convert.ToByte(str[i + 2]);
                    if ((i + 1) < str.Length) outdata[4] = Convert.ToByte(str[i + 1]);
                    if (i < str.Length) outdata[3] = Convert.ToByte(str[i]);
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

        private void xD60BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD60_B")) { Open(); }
            textBox3.Text = "32C4";
              textBox2.Text = "0160";
        }
        private void gH60revCNYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("GH60_revCNY")) { Open(); }
            textBox3.Text = "32C4";
            textBox2.Text = "0260";
        }
        private void xD60AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD60_A")) { Open(); }
            textBox3.Text = "32C4";
            textBox2.Text = "0160";
        }
        private void ps2avrUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("ps2avrU")) { Open(); }
            textBox3.Text = "32A0";
            textBox2.Text = "0160";
        }
        private void ps2avrGB2XShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("bface60")) { Open(); }
            textBox3.Text = "32A0";
            textBox2.Text = "0160";
        }
        public int keyCount = 0;
        public bool loadmatrix(string _name)
        {
            if (_name == "XD60_A")
            {
                matrix = new XD60_A();
            }
            else if (_name == "XD60_B")
            {
                matrix = new XD60_B();
            }
            else if (_name == "ps2avrU")
            {
                matrix = new ps2avrU();
            }
            else if (_name == "GH60_revCNY")
            {
                matrix = new GH60_revCNY();
            }
            else if (_name == "bface60")
            {
                matrix = new bface60();
            }
            else return false;
            layer = 0;
            this.menuStrip1.Items[3].Text = "Layer0";
            keyCount = matrix.keycap.GetUpperBound(0) + 1;
            ////////////////////////////////////////
            checkedListBox1.Items.Clear();
            panel1.Controls.Clear();
            Clear();
            for (int i = 0; i < keyCount; i++)
            {
                string name = i.ToString(); int length = 0;
                length = 4 - name.Length;
                for (int j = 0; j < length; j++) { name += " "; }
                name += "C:" + matrix.keycap[i, 0].ToString();
                name += "/" + matrix.keycap[i, 1].ToString();
                length = 16 - name.Length;
                for (int j = 0; j < length; j++) { name += " "; }
                name += "L:" + matrix.keycap[i, 2].ToString();
                length = 24 - name.Length;
                for (int j = 0; j < length; j++) { name += " "; }
                name += "M:" + matrix.keycap[i, 3].ToString() + "/" + matrix.keycap[i, 4].ToString();
                checkedListBox1.Items.Add(name);
            }
            return true;
        }

        
    }
}
