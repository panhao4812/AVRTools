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
        IMatrix matrix = null;
        double keycaplength = 48;
        double keycapoffset = 1;
        Button selectkey = null;
        Button selectkey2 = null;
        public int keyCount = 0;
        int layer = 0;
        string matrixname = "";
        ushort eepromsize = 512;
        string CodeTemp = "";
        string iencode = "GBK";
        byte RGB_Type = 0;
        int addr = 0;
        public static HidDevice HidDevice;
        void save(string path)
        {
            try
            {
                if (matrix == null)
                {
                    Clear();
                    Print("Open a keyboard templet and try again!");
                    return;
                }
                if (path == "")
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FilterIndex = 2;
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        path = sfd.FileName;
                        matrixname = path;
                    }
                    else
                    {
                        return;
                    }
                }
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.SetLength(0);
                StreamWriter stream = new StreamWriter(fs);
                string output = "matrix," + matrix.Name + "\r\n";
                for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
                {
                    int index = checkedListBox1.CheckedIndices[i];
                    string str = index.ToString();
                    //  string[] chara = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    output += str + "," + Program.longname(matrix.keycode[index])
                        + "," + Program.longname(matrix.keycode[index + keyCount]) + "\r\n";
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
        void changeButton()
        {
            //Clear();
            panel1.Controls.Clear();

            for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
            {
                string str = checkedListBox1.CheckedIndices[i].ToString();
                int index = checkedListBox1.CheckedIndices[i];
                AddButton(index, matrix.keycode[index + layer * keyCount]);
            }
            AddRGBButton();
        }
        void Open()
        {
            try
            {
                for (int i = 0; i < matrix.Defaultkeycode.Length; i++)
                {
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
                AddRGBButton();
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        public string ToEEP()
        {
            for (int r = 0; r < matrix.ROWS; r++)
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
                string str1 = matrix.keycode[index + keyCount];
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
                ushort add4 = (ushort)(add3 + matrix.ROWS * matrix.COLS);
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
                        string code1 = matrix.hexaKeys0[r, c];
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
                if (matrix != null)
                {
                    if (matrix.RGB != null && matrix.RGB.GetUpperBound(0) >= 0)
                    {
                        for (int i = matrix.RGB.GetLowerBound(0); i <= matrix.RGB.GetUpperBound(0); i++)
                        {
                            output.Append(matrix.RGB[i, 3]); output.Append(",");
                            output.Append(matrix.RGB[i, 4]); output.Append(",");
                            output.Append(matrix.RGB[i, 5]); output.Append(",");
                        }
                    }
                }
                output.Append(RGB_Type);
                return output.ToString();
            }
            catch
            {
                return "Select a Matrix.Try again.";
            }
        }
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
            else if (_name == "bface60_minila")
            {
                matrix = new bface60_minila();
            }
            else if (_name == "bface60_B")
            {
                matrix = new bface60_B();
            }
            else if (_name == "staryu")
            {
                matrix = new staryu();
            }
            else if (_name == "Tinykey")
            {
                matrix = new Tinykey();
            }
            else return false;
            layer = 0;
            radioButton1.Checked = true;
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
        public ushort ConvertChinese1(char str, string code)
        {
            string str2 = Convert.ToString(str);
            byte[] data; ushort a3;
            if (code == "GBK")
            {
                return ConvertChinese2(str, code);
            }
            else if (code == "Default")
            {
                data = Encoding.Default.GetBytes(str2);
                string Data1 = data[0].ToString("x"); if (Data1.Length == 1) Data1 = "0" + Data1;
                string Data2 = data[1].ToString("x"); if (Data2.Length == 1) Data2 = "0" + Data2;
                str2 = Data1 + Data2;
                a3 = Convert.ToUInt16(str2, 16);
                return a3;
            }
            else if (code == "Unicode")
            {
                data = Encoding.Unicode.GetBytes(str2);
            }
            else if (code == "UTF8")
            {
                data = Encoding.UTF8.GetBytes(str2);
            }
            else { Print("encoding error"); return 0; }
            string data1 = data[1].ToString("x"); if (data1.Length == 1) data1 = "0" + data1;
            string data2 = data[0].ToString("x"); if (data2.Length == 1) data2 = "0" + data2;
            str2 = data1 + data2;
            a3 = Convert.ToUInt16(str2, 16);
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
        private void Encode(string _code)
        {
            try
            {
                Clear();
                CodeTemp = "";
                char[] ch = PrintBox.Text.ToArray();
                if (ch == null || ch.Length == 0)
                {
                    CodeTemp += "0";
                    Print("Uploading RGB parameter!Nothing for printing!");
                    return;
                }
                Print("English 0-127 GBK > " + 0x8080);
                addr = 0;
                if (textBox4.Text != "" && textBox4.Text != null)
                {
                    addr = Convert.ToInt32(textBox4.Text);
                }
                Print("Uploading address=" + addr.ToString());
                int length = ch.Length;
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
                        ushort a3 = ConvertChinese1(ch[j], _code);
                        output += a3.ToString();
                        //Printhex((int)a3);
                        if (j != length - 1) output += ",";
                    }
                }

                CodeTemp += length2.ToString() + ",";
                CodeTemp += output;
                Print(CodeTemp);
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        private void UploadPrintBox()
        {
            OpenDevice();
            Encode(iencode);
            try
            {
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
                HidDevice.Write(outdata); Thread.Sleep(60);
                for (ushort i = 0; (i * 2 + 4 + addr) < Convert.ToInt32(eepromsize); i += 3)
                {
                    a = BitConverter.GetBytes((ushort)(i * 2 + addr));
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
                    Thread.Sleep(60);
                }
                outdata[1] = 0xFF; outdata[2] = 0xF2;
                HidDevice.Write(outdata); Thread.Sleep(60);
                Print("Upload finished");
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        public void AddRGBButton()
        {
            if (matrix == null) return;
            if (matrix.RGB == null || matrix.RGB.GetUpperBound(0) < 0) return;
            for (int i = matrix.RGB.GetLowerBound(0); i <= matrix.RGB.GetUpperBound(0); i++)
            {
                Button button = new Button();
                panel1.Controls.Add(button);
                Size size1 = new Size(25, 25);
                Point Point1 = new Point(matrix.RGB[i, 0], matrix.RGB[i, 1]);
                button.Size = size1;
                button.Location = Point1;
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = Color.FromArgb(matrix.RGB[i, 3], matrix.RGB[i, 4], matrix.RGB[i, 5]);
                if ((matrix.RGB[i, 2] & (byte)0x0F) == 0) button.Text = i.ToString();
                else if ((matrix.RGB[i, 2] & (byte)0x0F) == 0x01) { button.Text = "R"; }
                if ((matrix.RGB[i, 2] & (byte)0xF0) == 0x10) { button.ForeColor = Color.Black; }
                else if ((matrix.RGB[i, 2] & (byte)0xF0) == 0x00) { button.ForeColor = Color.Gray; }
                button.Font = new Font(button.Font.Name, 7);
                button.Name = i.ToString();
                button.MouseDown += new MouseEventHandler(this.button2_MouseClick);
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
            Size size1 = new Size((int)(keycaplength * length - keycapoffset * 2), (int)(keycaplength - keycapoffset * 2));
            Point Point1 = new Point(40 + (int)(x * keycaplength), 100 + (int)(y * keycaplength));
            if (x > 14)
            {
                Point1.X += 12;
            }
            if (y < 0)
            {
                Point1.Y -= 9;
            }
            button.Size = size1;
            button.Location = Point1;
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.White;
            button.MouseDown += new MouseEventHandler(this.button1_MouseClick);
            button.Text = str;
            button.Name = index.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1024, 800);
            this.panel1.Location = new Point(2, 30);
            panel1.Size = new Size(1002, 396);
            PrintBox.Size = new Size(220, 322);
            PrintBox.Location = new Point(2, 428);
            textBox1.Size = new Size(220, 322);
            textBox1.Location = new Point(222, 428);
            this.checkedListBox1.Size = new Size(220, 322);
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
        private void matrix2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save(matrixname);
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
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
            Pen pen = new Pen(Color.FromArgb(220, 220, 230), 3);
            g.DrawRectangle(pen, new Rectangle(35, 95, 727, 247));
            //  pen.Color = Color.FromArgb(170, 170, 170);
            g.DrawRectangle(pen, new Rectangle(35, 40, 727, 50));
            //  pen.Color = Color.FromArgb(170, 170, 170);
            g.DrawRectangle(pen, new Rectangle(767, 40, 199, 302));
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
        private void matrix1ToolStripMenuItem_Click(object sender, EventArgs e)
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
                }
                srd.Close();
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        void OpenDevice()
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
                byte[] outdata = new byte[9]; outdata[0] = 0;
                outdata[1] = 0xFF; outdata[2] = 0xFA;
                HidDevice.Write(outdata); Thread.Sleep(60);
                // 0xFFFA是open的flag
                // 0xFFF1是upload的flag
                // 0xFFF2是end的flag
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDevice();
            try
            {
                if (HidDevice == null)
                {
                    Clear();
                    Print("Invalid device");
                    return;
                }
                string codeTemp = ToEEP();
                if (codeTemp == "")
                {
                    Clear();
                    Print("Nothing to upload");
                    return;
                }
                string[] str = codeTemp.Split(',');

                Clear();
                Print("Uploading");
                byte[] outdata = new byte[9]; outdata[0] = 0;
                outdata[1] = 0xFF; outdata[2] = 0xF1;
                HidDevice.Write(outdata); Thread.Sleep(60);
                for (ushort i = 0; i < eepromsize; i += 6)
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
            textBox3.Text = "32C4";
            textBox2.Text = "0160";
            textBox4.Text = "";
        }
        private void xShiftToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD60_B")) { Open(); }
            textBox3.Text = "32C4";
            textBox2.Text = "0160";
            textBox4.Text = "";
        }
        private void xshiftToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (loadmatrix("bface60_B")) { Open(); }
            textBox3.Text = "32A0";
            textBox2.Text = "0160";
            textBox4.Text = "297";
        }
        private void minilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("bface60_minila")) { Open(); }
            textBox3.Text = "32A0";
            textBox2.Text = "0160";
            textBox4.Text = "297";
        }
        private void staryuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("staryu")) { Open(); }
            textBox3.Text = "32C2";
            textBox2.Text = "0105";
            textBox4.Text = "";
        }
        private void gH60revCNYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("GH60_revCNY")) { Open(); }
            textBox3.Text = "32C4";
            textBox2.Text = "0260";
            textBox4.Text = "";
        }
        private void ps2avrUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("ps2avrU")) { Open(); }
            textBox3.Text = "32A0";
            textBox2.Text = "0160";
            textBox4.Text = "";
        }
        private void tinykeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("Tinykey")) { Open(); }
            textBox3.Text = "D850";
            textBox2.Text = "0102";
            textBox4.Text = "31";
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clear();          
            Print("step1: Click keyboard to select your templet.");
            Print("step2: Edit keycap buttos and LED buttons.");
            Print("step3: Click layer0/layer1 to Edit page FN0/FN1.");
            Print("step4: Click Matrix-Upload to transfer data to your device.");
            Print("Enjoy!");
            Print("Author zian1  QQ 29347213");
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
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (matrix == null) return;
            if (matrix.RGB == null || matrix.RGB.GetUpperBound(0) < 0) return;
            for (int i = matrix.RGB.GetLowerBound(0); i <= matrix.RGB.GetUpperBound(0); i++)
            {
                matrix.RGB[i, 2] = 0x10;
            }
            RGB_Type = (byte)0x10;
            Print("RGB_Type = " + RGB_Type);
            changeButton();
        }
        private void rainfullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (matrix == null) return;
            if (matrix.RGB == null || matrix.RGB.GetUpperBound(0) < 0) return;
            for (int i = matrix.RGB.GetLowerBound(0); i <= matrix.RGB.GetUpperBound(0); i++)
            {
                matrix.RGB[i, 2] = 0x11;
                matrix.RGB[i, 3] = 255;
                matrix.RGB[i, 4] = 255;
                matrix.RGB[i, 5] = 255;
            }
            RGB_Type = (byte)0x11;
            Print("RGB_Type = " + RGB_Type);
            changeButton();
        }
        private void oNOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (matrix == null) return;
            if (matrix.RGB == null || matrix.RGB.GetUpperBound(0) < 0) return;
            for (int i = matrix.RGB.GetLowerBound(0); i <= matrix.RGB.GetUpperBound(0); i++)
            {
                matrix.RGB[i, 2] ^= (byte)0x10;
            }
            RGB_Type ^= (byte)0x10;
            Print("RGB_Type = " + RGB_Type);
            changeButton();
        }
    }
}