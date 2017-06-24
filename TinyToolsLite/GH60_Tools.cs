using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyToolsLite
{
    public partial class GH60_Tools : Form
    {
        XD60 _xd60 = new XD60();
        double keycapsize = 11;
        double keyunitsize =0.5;
        static int _r=0;
        static int _c=0;
        public GH60_Tools()
        {
            InitializeComponent();       
        }
        private void GH60_Tools_Load(object sender, EventArgs e)
        {
                  
        }

        private void xD60ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            for (int r = 0; r < _xd60.ROWS; r++)
            {
                for (int c = 0; c < _xd60.COLS; c++)
                {
                    byte mask = _xd60.keymask[r, c];
                    if (mask != 0)
                    {
                        MButton bu = new MButton(r,c);
                        bu.FlatStyle = FlatStyle.Flat;
                        bu.BackColor = Color.White;
                        bu.Text = _xd60.hexaKeys0[r, c].ToString();
                        bu.Location = new Point((int)(_xd60.posX[r, c] * keycapsize) + 60,
                            (int)(keycapsize * 4 * _xd60.posY[r, c] + 10));
                        bu.Size = new Size((int)(keycapsize * _xd60.lengthX[r, c] - keyunitsize), (int)(keycapsize * 4 - keyunitsize));
                        this.panel1.Controls.Add(bu);
                    }
                }
            }
        }

        private void layer2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            for (int r = 0; r < _xd60.ROWS; r++)
            {
                for (int c = 0; c < _xd60.COLS; c++)
                {
                    byte mask = _xd60.keymask[r, c];
                    if (mask != 0)
                    {
                        MButton bu = new MButton(r,c);
                        bu.FlatStyle = FlatStyle.Flat;
                        bu.BackColor = Color.White;
                     
                        bu.Text = _xd60.hexaKeys1[r, c].ToString();
                        bu.Location = new Point((int)(_xd60.posX[r, c] * keycapsize) + 60,
                            (int)(keycapsize * 4 * _xd60.posY[r, c] + 10));
                        bu.Size = new Size((int)(keycapsize * _xd60.lengthX[r, c] - keyunitsize), (int)(keycapsize * 4 - keyunitsize));
                        this.panel1.Controls.Add(bu);
                    }
                }
            }
        }
      public class MButton : Button
        {
            int r,c;
            public  MButton(int R,int C)
            {
                r = R;c = C;
                this.Enter += new EventHandler(button1_Enter);
                this.Leave += new EventHandler(button1_Leave);
            }
            private void button1_Enter(object sender, EventArgs e)
            {
                this.BackColor = Color.Pink;
                GH60_Tools._c = c;
                GH60_Tools._r = r;

            }
            private void button1_Leave(object sender, EventArgs e)
            {
                this.BackColor = Color.White;
               
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
