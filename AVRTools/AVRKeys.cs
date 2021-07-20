using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AVRKeys.Keyboard;
namespace AVRTools
{
    /*
     * 原型
     */
    public partial class AVRKeys : Form
    {
        public IMatrix ActiveMatrix;
        public Button ActiveButton;
        public void DefaultLayout()
        {
            this.Size = new Size(850, 561);
            MatrixPanel.Size = new Size(838, 250);
            MatrixPanel.Location = new Point(0, 25);
            SelectKeysPanel.Size = new Size(838, 250);
            SelectKeysPanel.Location = new Point(0, 272);
           // Panel panel = new Panel();
            //panel.Location = new Point(0, 0);
           // panel.Size =new Size( 1106, 279);
           // Layer1.Controls.Add(panel);
        }   
        public AVRKeys()
        {
            InitializeComponent();
        }
        private void InitMatrrix()
        {
            Button[,] buttons1 = ActiveMatrix.CreateButton();
            Button[,] buttons2 = ActiveMatrix.CreateButton();
            for (int r = 0; r < ActiveMatrix.ROWS; r++)
            {
                for (int c = 0; c < ActiveMatrix.COLS; c++)
                {
                    if (ActiveMatrix.keymask[r,c] != 0x00)
                    {
                        //button.MouseDown += new MouseEventHandler(Layer0Button_MouseClick);
                      
                        buttons1[r, c].Text = IKeycode.Code2ShortName(ActiveMatrix.hexaKeys0[r,c]);
                        Layer1.Controls.Add(buttons1[r, c]);
                        buttons2[r, c].Text = IKeycode.Code2ShortName(ActiveMatrix.hexaKeys1[r, c]);
                        Layer2.Controls.Add(buttons2[r, c]);
                    }
                }
            }
        }
        private void AVRKeys_Load(object sender, EventArgs e)
        {
            DefaultLayout();
        }
        private void ISO61_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK60_ISO();
            InitMatrrix();
        }
        private void ISO63_Click(object sender, EventArgs e)
        {

        }
        private void ISO64_Click(object sender, EventArgs e)
        {

        }
    }
}
