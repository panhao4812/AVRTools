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
        Image img = null; Image img2 = null;
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
                for (int i = matrix.RGB.GetLowerBound(0); i <= matrix.RGB.GetUpperBound(0); i++)
                {
                    output += i.ToString() + "," + matrix.RGB[i, 2].ToString() + "," + matrix.RGB[i, 3].ToString()
                        + "," + matrix.RGB[i, 4].ToString() + "," + matrix.RGB[i, 5].ToString() + "\r\n";
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
            img2 = panel1.BackgroundImage;
            panel1.BackgroundImage = null;
            panel1.Controls.Clear();
            panel1.BackgroundImage = img2; 
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
                RGB_Type = (Byte)matrix.RGB[0, 2];
                if ((RGB_Type & 0x0F) == 0x01)
                {
                    this.editToolStripMenuItem.Text = "FixedColor";
                }
                else
                {
                    this.editToolStripMenuItem.Text = "Rainbow";
                }
                if ((RGB_Type & 0xF0) == 0x10)
                {
                    this.oNOFFToolStripMenuItem.Text = "Default OFF";
                }
                else
                {
                    this.oNOFFToolStripMenuItem.Text = "Default ON";
                }
                panel1.BackgroundImage = img;
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
                panel1.BackgroundImage = img;
            }
        }
        private void OpenDevice()
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
                    Print("Connect usb device. Try open again or select a keyboard templet!");
                    HidDevice = null;
                    return;
                }
                for (int i = 0; i < HidDeviceList.Length; i++)
                {
                    //Print(HidDeviceList[i].DevicePath);
                    HidDevice = HidDeviceList[0];
                    break;
                }
                if (HidDevice == null)
                {
                    Print("Connect usb device. Try open again.");
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
                img = Properties.Resources.tinykey3;
            }
            else if (_name == "XD60_B")
            {
                matrix = new XD60_B();
                img = Properties.Resources.tinykey3;
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
                img = Properties.Resources.tinykey2;
            }
            else if (_name == "bface60_B")
            {
                matrix = new bface60_B();
                img = Properties.Resources.tinykey2;
            }
            else if (_name == "staryu")
            {
                matrix = new staryu();
            }
            else if (_name == "Tinykey")
            {
                matrix = new Tinykey();
                img = Properties.Resources.tinykey;
            }
            else if (_name == "XD75_Re")
            {
                matrix = new XD75_Re();
                img = Properties.Resources.tinykey4;
            }
            else return false;
            layer = 0;         
            keyCount = matrix.keycap.GetUpperBound(0) + 1;
            ////////////////////////////////////////
            panel1.BackgroundImage = null;
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
             radioButton2.Checked = false;
             radioButton1.Checked = true;
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
                //Clear();
                CodeTemp = "";
                char[] ch = PrintBox.Text.ToArray();
                if (ch == null || ch.Length == 0)
                {
                    CodeTemp += "0";
                    Print("Uploading RGB parameter!Nothing for printing!");
                    return;
                }
               // Print("English 0-127 GBK > " + 0x8080);
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
            Print("eepromsize=" + eepromsize.ToString());
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
                for (ushort i = 0; (i * 2 + 4 + addr) < eepromsize; i += 3)
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
        public void AddRGBButton(int i, Color c)
        {
            AddRGBButton(i, 0, c.R, c.G, c.B);
        }
        public void AddRGBButton(int i, int style, int R, int G, int B)
        {
             img2 = panel1.BackgroundImage;
            panel1.BackgroundImage = null;
            if (matrix == null) return;
            if (matrix.RGB == null || matrix.RGB.GetUpperBound(0) < 0) return;
            matrix.RGB[i, 2] = style;
            matrix.RGB[i, 3] = R; matrix.RGB[i, 4] = G; matrix.RGB[i, 5] = B;
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
            panel1.BackgroundImage = img2;
        }
        public void AddRGBButton()
        {
             img2 = panel1.BackgroundImage;
            panel1.BackgroundImage = null;
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
                else if ((matrix.RGB[i, 2] & (byte)0xF0) == 0x00) { button.ForeColor = Color.FromArgb(200,200,200); }
                button.Font = new Font(button.Font.Name, 7);
                button.Name = i.ToString();
                button.MouseDown += new MouseEventHandler(this.button2_MouseClick);
            }
            panel1.BackgroundImage = img2;
        }
        public void AddButton(int index, string str)
        {
            img2 = panel1.BackgroundImage;
            panel1.BackgroundImage = null;
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
            panel1.BackgroundImage = img2;
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
        /*
        private void ps2avrUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("ps2avrU")) { Open(); }
            textBox3.Text = "32A0";
            textBox2.Text = "0160";
            textBox4.Text = "";
            eepromsize = 2048;
        }      
        private void staryuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("staryu")) { Open(); }
            textBox3.Text = "32C2";
            textBox2.Text = "0105";
            textBox4.Text = "";
            eepromsize = 1024;
        }
        private void gH60revCNYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("GH60_revCNY")) { Open(); }
            textBox3.Text = "32C4";
            textBox2.Text = "0260";
            textBox4.Text = "";
            eepromsize = 2048;
        }   
        */
        private void xShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD60_A")) { Open(); }
            textBox3.Text = "32C4";
            textBox2.Text = "0160";
            textBox4.Text = "281";
            eepromsize = 1024;
        }
        private void xShiftToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD60_B")) { Open(); }
            textBox3.Text = "32C4";
            textBox2.Text = "0160";
            textBox4.Text = "281";
            eepromsize = 1024;           
        }
        private void tinykeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("Tinykey")) { Open(); }
            textBox3.Text = "D850";
            textBox2.Text = "0102";
            textBox4.Text = "31";
            eepromsize = 512;
        }
        private void xshiftToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (loadmatrix("bface60_B")) { Open(); }
            textBox3.Text = "32A0";
            textBox2.Text = "0160";
            textBox4.Text = "297";
            eepromsize = 1024;
        }
        private void minilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("bface60_minila")) { Open(); }
            textBox3.Text = "32A0";
            textBox2.Text = "0160";
            textBox4.Text = "297";
            eepromsize = 1024;
        }
        private void xD75ReToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadmatrix("XD75_Re")) { Open(); }
            textBox3.Text = "32C4";
            textBox2.Text = "0375";
            textBox4.Text = "279";
            eepromsize = 1024;
        }
        private void AboutText()
        {
            Clear();
            /*
          Print("How to change key values and LED color:");
Print("1.Click on “Keyboard” button on the title bar, select “XD002”. (Keyboard->XD002)");
          Print("2.Click on the button icon that you want to change, and then select the desire key value from the chart at lower right corner.Click RGB on the title to change color config.If you want to use Rainbow LED, select RGB->Rainbow on the title bar.Otherwise, choose RGB->Fixed color.");
          Print("3.XD002 provide two layers(layer 0 and layer 1), you can click radio button on the title bar to alter the key values of another layer.");
          Print("4.Click on “Matrix” and select “Upload Matrix” to save changes.");
          Print("");
          Print("How to alter the printer content:");
          Print("1.Input the text content in Print Box.  The print box is at the lower left corner.");
          Print("2.Click on “Printer” on the title bar, select “Upload with GBK” to save the changes. Try to select “Upload with Unicode” If print garbled Korea.");
          Print("");

          Print("修改按键和灯");
          Print("");
          Print("步骤1: 点击标题栏keyboard，选择对应的键盘型号。"); Print("");
          Print("步骤2: 点击按键图标再点击右下角键值表编辑键值。");
          Print("点击RGB灯图标编辑灯的颜色。"); Print("");
          Print("步骤3: 点击Layer0/Layer1切换编辑第二层矩阵的键值。");
          Print("点击RGB编辑灯的模式。Rainbow表示彩虹渐变。FixColor表示单色。"); Print("");
          Print("步骤4: 点击标题栏Matrix上传修改内容。");
          Print("");
          Print("修改[打字机]内容");
          Print("");
          Print("步骤1: PrintBox输入中英文文本。"); Print("");
          Print("步骤2: 点击标题栏Printer - Upload with GBK上传修改内容。");
          Print("要切换中文编码则换成Printer - Upload with Unicode。");
          Print("");
          */
            Print("Click on “Keyboard” button on the title bar to select your templet."); Print("");
            Print("Detailed tutorial http://xiudi.fun/xd002/Manual.html "); Print("");

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
        public static void ThreadProc()
        {
            libusbtool form = new libusbtool();//第2个窗体
            form.ShowDialog();
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

        private void writeToHexToolStripMenuItem_Click(object sender, EventArgs e)
        {    
            Encode(iencode);           
            try
            {
                if (CodeTemp == "")
                {
                    Print("Nothing to write");
                    return;
                }
                string[] str = CodeTemp.Split(',');
                Hex hex1 = new Hex(str);
                Print(hex1.Write(0x0000));
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
    }
}