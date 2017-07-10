using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HidRawTools
{
    public partial class HidRawTools : Form
    {
        public HidRawTools()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1024, 800);
            this.panel1.Location = new Point(0, 31);
            panel1.Size = new Size(1006, 338);
            textBox1.Size = new Size(330, 322);
            textBox1.Location = new Point(2, 428);
            this.checkedListBox1.Size = new Size(330, 322);
            checkedListBox1.Location = new Point(334, 428);
            dataGridView1.Size = new Size(338, 322);
            dataGridView1.Location = new Point(666, 428);
            dataGridView1.RowCount = Program.KeyName.Length;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }     
            for (int i = 0; i < Program.KeyName.Length ; i++)
            {
                this.dataGridView1.Rows[i].Cells[0].Value = Program.KeyName[i];
                this.dataGridView1.Rows[i].Cells[1].Value = Program.KeyName2[i];
                this.dataGridView1.Rows[i].Cells[2].Value = Program.Keycode[i];
                this.dataGridView1.Rows[i].Cells[3].Value = Program.Keymask[i];
            }
        }
    }
}
