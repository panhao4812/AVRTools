using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TinyToolsLite
{
    public partial class GH60_Tools : Form
    {
        public static HidDevice HidDevice;
        IMatrix _matrix = new IMatrix();
        public void Clear()
        {
            Box2.Text = "";
        }
        public void Print(Object str)
        {
            Box2.Text += str.ToString() + "\r\n";
        }
        public GH60_Tools()
        {
            InitializeComponent();
        }
        private void xD60ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _matrix = new XD60_A();
            initRows();

        }
        private void GH60_Tools_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1024, 800);
            dataGridView1.Size = new Size(1002, 185);
            dataGridView2.Size = new Size(1002, 185);
            dataGridView1.Location = new Point(2, 30);
            dataGridView2.Location = new Point(2, 220);
            Box2.Size = new Size(330, 340);
            Box2.Location = new Point(2, 410);
            dataGridView4.Size = new Size(330, 340);
            dataGridView4.Location = new Point(334, 410);
            dataGridView3.Size = new Size(338, 340);
            dataGridView3.Location = new Point(666, 410);
            for (int i = 0; i < this.dataGridView3.Columns.Count; i++)
            {
                this.dataGridView3.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            for (int i = 0; i < this.dataGridView4.Columns.Count; i++)
            {
                this.dataGridView4.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            dataGridView4.RowCount = Program.KeyName.Length - 17;
            int j = 0;
            for (int i = 0; i < Program.KeyName.Length - 17; i++)
            {
                this.dataGridView4.Rows[j].Cells[0].Value = Program.KeyName[i];
                this.dataGridView4.Rows[j].Cells[1].Value = Program.KeyName2[i];
                this.dataGridView4.Rows[j].Cells[2].Value = Program.Keycode[i];
                this.dataGridView4.Rows[j].Cells[3].Value = Program.Keymask[i]; j++;
            }
            dataGridView3.RowCount = 17;
            j = 0;
            for (int i = Program.KeyName.Length - 17; i < Program.KeyName.Length; i++)
            {
                this.dataGridView3.Rows[j].Cells[0].Value = Program.KeyName[i];
                this.dataGridView3.Rows[j].Cells[1].Value = Program.KeyName2[i];
                this.dataGridView3.Rows[j].Cells[2].Value = Program.Keycode[i];
                this.dataGridView3.Rows[j].Cells[3].Value = Program.Keymask[i];
                j++;
            }


        }
        void initRows()
        {
            dataGridView1.ColumnCount = _matrix.COLS;
            dataGridView1.RowCount = _matrix.ROWS;
            dataGridView2.ColumnCount = dataGridView1.ColumnCount;
            dataGridView2.RowCount = dataGridView1.RowCount;

            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].Width =
                    (1002 - dataGridView1.Rows[0].HeaderCell.Size.Width) / dataGridView1.ColumnCount;
                this.dataGridView2.Columns[i].Width =
                        (1002 - dataGridView2.Rows[0].HeaderCell.Size.Width) / dataGridView2.ColumnCount;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].HeaderCell.Value = "C" + (i + 1).ToString();
                dataGridView2.Columns[i].HeaderCell.Value = "C" + (i + 1).ToString();
            }
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].Height =
                  (185 - dataGridView1.Columns[0].HeaderCell.Size.Height) / (dataGridView1.RowCount);
                this.dataGridView2.Rows[i].Height =
                    (185 - dataGridView2.Columns[0].HeaderCell.Size.Height) / (dataGridView2.RowCount);
                this.dataGridView1.Rows[i].HeaderCell.Value = "R" + (i + 1).ToString();
                this.dataGridView1.Rows[i].Selected = false;
                this.dataGridView2.Rows[i].HeaderCell.Value = "R" + (i + 1).ToString();
                this.dataGridView2.Rows[i].Selected = false;
            }
            for (int r = 0; r < this.dataGridView1.RowCount; r++)
            {
                for (int c = 0; c < this.dataGridView1.ColumnCount; c++)
                {
                    string str1 = Program.shortname(_matrix.hexaKeys0[r, c]);
                    this.dataGridView1.Rows[r].Cells[c].Value = str1;
                    this.dataGridView1.Rows[r].Cells[c].Style.Font = new Font("Area", 9);
                    str1 = Program.shortname(_matrix.hexaKeys1[r, c]);
                    this.dataGridView2.Rows[r].Cells[c].Value = str1;
                    this.dataGridView2.Rows[r].Cells[c].Style.Font = new Font("Area", 9);
                }
            }
        }
        public string ushort2byte(ushort a)
        {
            byte[] output = BitConverter.GetBytes(a);
            return output[0].ToString() + "," + output[2].ToString();
        }
        public string short2byte(short a)
        {
            byte[] output = BitConverter.GetBytes(a);
            return output[0].ToString() + "," + output[2].ToString();
        }
        public string byte2byte(byte a)
        {
            return a.ToString();
        }
        public string ToEEP()
        {
            try
            {
                ushort add1 = 5 * 2;
                ushort add2 = (ushort)(add1 + 5);
                ushort add3 = (ushort)(add2 + 14);
                ushort add4 = (ushort)(add3 + 70);
                ushort add5 = (ushort)(add4 + 70);
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
                for (int i = 0; i < _matrix.ROWS; i++)
                {
                    output.Append(_matrix.rowPins[i]); output.Append(",");
                }
                for (int i = 0; i < _matrix.COLS; i++)
                {
                    output.Append(_matrix.colPins[i]); output.Append(",");
                }
                int[,] mask = new int[_matrix.ROWS, _matrix.COLS];
                for (int r = 0; r < _matrix.ROWS; r++)
                {
                    for (int c = 0; c < _matrix.COLS; c++)
                    {
                        string code1 = (string)this.dataGridView1.Rows[r].Cells[c].Value;
                        int mask1 = 0;
                        int code = Program.name2code(code1, out mask1);
                        mask[r, c] += mask1 * 16;
                        output.Append(code); output.Append(",");
                    }
                }
                for (int r = 0; r < _matrix.ROWS; r++)
                {
                    for (int c = 0; c < _matrix.COLS; c++)
                    {
                        string code2 = (string)this.dataGridView2.Rows[r].Cells[c].Value;
                        int mask2 = 0;
                        int code = Program.name2code(code2, out mask2);
                        mask[r, c] += mask2;
                        output.Append(code); output.Append(",");
                    }
                }
                for (int r = 0; r < _matrix.ROWS; r++)
                {
                    for (int c = 0; c < _matrix.COLS; c++)
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
        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.ClearSelection();
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
              //  dataGridView3.ClearSelection();
             //   dataGridView4.ClearSelection();
            }
        }
        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
             //   dataGridView3.ClearSelection();
              //  dataGridView4.ClearSelection();
            }
        }
        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
              //  dataGridView1.ClearSelection();
             //   dataGridView2.ClearSelection();
                dataGridView3.ClearSelection();
                dataGridView4.ClearSelection();
            }
        }
        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
             dataGridView4.ClearSelection();
            if (dataGridView1.CurrentCell != null && dataGridView1.SelectedCells.Count != 0)
            {
                int i = dataGridView3.CurrentCell.RowIndex;
                this.dataGridView1.CurrentCell.Value = dataGridView3.Rows[i].Cells[1].Value;
            }
            if (dataGridView2.CurrentCell != null && dataGridView2.SelectedCells.Count != 0)
            {
                int i = dataGridView3.CurrentCell.RowIndex;
                this.dataGridView2.CurrentCell.Value = dataGridView3.Rows[i].Cells[1].Value;
            }
        }
        private void dataGridView4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
              //  dataGridView1.ClearSelection();
              //  dataGridView2.ClearSelection();
                dataGridView3.ClearSelection();
                dataGridView4.ClearSelection();
            }
        }
        private void dataGridView4_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.ClearSelection();
            if (dataGridView1.CurrentCell != null && dataGridView1.SelectedCells.Count != 0)
            {
                int i = dataGridView4.CurrentCell.RowIndex;
                this.dataGridView1.CurrentCell.Value = dataGridView4.Rows[i].Cells[1].Value;
            }
            if (dataGridView2.CurrentCell != null && dataGridView2.SelectedCells.Count != 0)
            {
                int i = dataGridView4.CurrentCell.RowIndex;
                this.dataGridView2.CurrentCell.Value = dataGridView4.Rows[i].Cells[1].Value;
            }
        }
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ushort vid = 0, pid = 0;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                vid = (ushort)Convert.ToInt32(textBox1.Text, 16);
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
        private void label1_Click(object sender, EventArgs e)
        {

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
        private void layer1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _matrix = new GH60_CNY();
            initRows();
        }
        private void layer2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _matrix = new XD60_B();
            initRows();
        }

        private void hidToolsLiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        public static void ThreadProc()
        {
            TinyToolsLite form = new TinyToolsLite();//第3个窗体
            form.ShowDialog();
        }
    }
}
