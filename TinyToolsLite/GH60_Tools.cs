using System;
using System.Drawing;
using System.Windows.Forms;

namespace TinyToolsLite
{
    public partial class GH60_Tools : Form
    {
        public void Clear()
        {
            Box2.Text = "";
        }
        public void Print(Object str)
        {
            Box2.Text += str.ToString() + "\r\n";
        }
        XD60 _xd60 = new XD60();
        public GH60_Tools()
        {
            InitializeComponent();       
        }
        private void convertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < this.dataGridView1.RowCount; r++)
            {
                for (int c = 0; c < this.dataGridView1.ColumnCount; c++)
                {
                }

            }
            Clear();
           Print( _xd60.ToEEP());
        }
        private void xD60ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < this.dataGridView1.RowCount; r++)
            {
                for (int c = 0; c < this.dataGridView1.ColumnCount; c++)
                {
                    string str1 = _xd60.hexaKeys0[r, c];
                    this.dataGridView1.Rows[r].Cells[c].Value = str1;
                    this.dataGridView1.Rows[r].Cells[c].Style.Font = new Font("Area", 10);
                    str1 = _xd60.hexaKeys1[r, c];
                    this.dataGridView2.Rows[r].Cells[c].Value = str1;
                    this.dataGridView2.Rows[r].Cells[c].Style.Font = new Font("Area", 10);
                }
            }
        }
        private void GH60_Tools_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView3.Columns.Count; i++)
            {
                this.dataGridView3.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView3.RowCount = Program.KeyName.Length;
            for (int i = 0; i < dataGridView3. RowCount; i++)
            {
                this.dataGridView3.Rows[i].Cells[0].Value = Program.KeyName[i];
                this.dataGridView3.Rows[i].Cells[1].Value = Program.KeyName2[i];
                this.dataGridView3.Rows[i].Cells[2].Value = Program.Keycode[i];
                this.dataGridView3.Rows[i].Cells[3].Value = Program.Keymask[i];
            }
            dataGridView1.RowCount = 5;  
           // dataGridView1.AutoResizeRows();
            dataGridView2.RowCount = 5;
         //   dataGridView2.AutoResizeRows();
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].Width = 67;
                this.dataGridView2.Columns[i].Width = 67;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].HeaderCell.Value = "r" + (i+1).ToString();
                this.dataGridView1.Rows[i].Selected = false;
                this.dataGridView2.Rows[i].HeaderCell.Value = "r" + (i + 1).ToString();
                this.dataGridView2.Rows[i].Selected = false;
            }                     
        }
    }
}
