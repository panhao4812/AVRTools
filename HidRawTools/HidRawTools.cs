using System;
using System.Drawing;
using System.IO;
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
        int layer = 1;
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
            dataGridView1.RowCount = Program.KeyName.Length+1;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            this.dataGridView1.Rows[0].Cells[0].Value ="Blank";
            this.dataGridView1.Rows[0].Cells[1].Value ="";
            this.dataGridView1.Rows[0].Cells[2].Value = 0;
            this.dataGridView1.Rows[0].Cells[3].Value = 0;
            for (int i = 1; i < Program.KeyName.Length ; i++)
            {
                this.dataGridView1.Rows[i].Cells[0].Value = Program.KeyName[i];
                this.dataGridView1.Rows[i].Cells[1].Value = Program.KeyName2[i];
                this.dataGridView1.Rows[i].Cells[2].Value = Program.Keycode[i];
                this.dataGridView1.Rows[i].Cells[3].Value = Program.Keymask[i];
            }
        }
       
        private void matrix2ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    string str = checkedListBox1.CheckedIndices[i].ToString();
                  //  string[] chara = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    output += str+","+ panel1.Controls[i].Text+"\r\n";
                }
                stream.Write(output);
                stream.Flush();
                stream.Close();
            }
            catch { }
        }
        private void xD60AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadmatrix("XD60_A");
        }
        public bool loadmatrix(string _name)
        {
            if (_name == "XD60_A")
            {
                matrix = new XD60_A();
            }
            else return false;
            ////////////////////////////////////////
            checkedListBox1.Items.Clear();
            panel1.Controls.Clear();
            Clear();
            for (int i = 0; i < matrix.keycap.GetUpperBound(0); i++)
            {
                string name = ""; int length = 0;
                name += "X:" + matrix.keycap[i, 0].ToString();
                length = 10 - name.Length;
                for (int j = 0; j < length; j++) { name += " "; }
                name += "Y:" + matrix.keycap[i, 1].ToString();
                length = 20 - name.Length;
                for (int j = 0; j < length; j++) { name += " "; }
                name += "L:" + matrix.keycap[i, 2].ToString();
                checkedListBox1.Items.Add(name);
            }
            return true;
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Clear();
            panel1.Controls.Clear();
            
            for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
            {
                string str = checkedListBox1.CheckedIndices[i].ToString();              
                int index = Convert.ToInt32(str);
                AddButton(index, matrix.keycode[index*layer]);
            }
        }
        public void AddButton(int index,string str)
        {
            double x = matrix.keycap[index, 0];
            double y = matrix.keycap[index, 1];
            double length = matrix.keycap[index, 2];
            double row = matrix.keycap[index, 3];
            double col = matrix.keycap[index, 4];
            Button button = new Button();
            panel1.Controls.Add(button);
            button.Size = new Size((int)(keycaplength * length - keycapoffset * 2), (int)(keycaplength - keycapoffset * 2));
            button.Location = new Point(80 + (int)(x * keycaplength), 50 + (int)(y * keycaplength));
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.White;
            button.Enter += new System.EventHandler(this.button1_Enter);
            button.Text = str;
            button.Name = index.ToString();
        }
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
             for (int i = 0; i < checkedListBox1.Items.Count; i++) {
                checkedListBox1.SetItemChecked(i, false);
               }
            Clear();
            panel1.Controls.Clear();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            for(int i=0;i < panel1.Controls.Count; i++)
            {
              (  (Button)panel1.Controls[i]).BackColor = Color.White;
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
                selectkey.Text= dataGridView1.Rows[i].Cells[1].Value.ToString();
                matrix.keycode[Convert.ToInt32(selectkey.Name)*layer] = selectkey.Text;
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
                string Name = Path.GetFileNameWithoutExtension(path);
                if (!loadmatrix(Name)) return;
                try
                {
                    FileStream fs = new FileStream(path, FileMode.Open);
                    StreamReader srd = new StreamReader(fs);
                    while (srd.Peek() != -1)
                    {
                        string str = srd.ReadLine();
                        string[] chara = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        if (chara.Length ==2)
                        {
                            int index = Convert.ToInt32(chara[0]);                          
                                checkedListBox1.SetItemChecked(index, true);
                            AddButton(index, chara[1]);
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
                catch { }
            }           
        }

        private void layer1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (layer == 1)
            {
                layer = 2;
                this.menuStrip1.Items[3].Text = "CurrentLayer2";
            }
            else {
                layer = 1;
                this.menuStrip1.Items[3].Text = "CurrentLayer1";
            }
            }
    }
}
