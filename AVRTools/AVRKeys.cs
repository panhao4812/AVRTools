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
            int Height1 = 20; int Width1 = 54;
            this.Size = new Size(850+ Width1, 561+ Height1);
            MatrixPanel.Size = new Size(838 + Width1, 250+ Height1);
            MatrixPanel.Location = new Point(0, 25);
            SelectKeysPanel.Size = new Size(838 + Width1, 250);
            SelectKeysPanel.Location = new Point(0, 272+ Height1);
           // Panel panel = new Panel();
            //panel.Location = new Point(0, 0);
           // panel.Size =new Size( 1106, 279);
           // Layer1.Controls.Add(panel);
        }   
        public AVRKeys()
        {
            InitializeComponent();
        }
        private void ClearButton()
        {
            Layer1.Controls.Clear();
            Layer2.Controls.Clear();
            Schematic.Controls.Clear();
            WS2812.Controls.Clear();
            BackRGB.Controls.Clear();
        }
        private void InitMatrrix()
        {
            ClearButton();
            List<Button> buttons1 = ActiveMatrix.CreateButton();
            List<Button> buttons2 = ActiveMatrix.CreateButton();
            List<Button> buttons3 = ActiveMatrix.CreateButton();
            for (int i = 0; i < buttons1.Count; i++)
            {  
                        buttons1[i].Text = IKeycode.shortname(ActiveMatrix.keycaps[i].layer1);
                        Layer1.Controls.Add(buttons1[i]);
                        buttons2[i].Text = IKeycode.shortname(ActiveMatrix.keycaps[i].layer2);
                        Layer2.Controls.Add(buttons2[i]);
                buttons3[i].Text = ActiveMatrix.keycaps[i].R.ToString()+"/"+
                    ActiveMatrix.keycaps[i].C.ToString();
                Schematic.Controls.Add(buttons3[i]);
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

        private void ISO100_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
          
        }
    }
}
