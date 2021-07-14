using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVRTools
{
    /*
     * 原型
     */
    public partial class AVRKeys : Form
    {
        public void DefaultLayout()
        {
            this.Size = new Size(850, 561);
            MatrixPanel.Size = new Size(838, 250);
            MatrixPanel.Location = new Point(0, 25);
            SelectKeysPanel.Size = new Size(838, 250);
            SelectKeysPanel.Location = new Point(0, 272);
        }   
        public AVRKeys()
        {
            InitializeComponent();
        }
        private void AddButton(int index, string str)
        {
            /*
            TempImage = KeymapPanel.BackgroundImage;
            KeymapPanel.BackgroundImage = null;
            double x = ActiveMatrix.keycap[index, 0];
            double y = ActiveMatrix.keycap[index, 1];
            double length = ActiveMatrix.keycap[index, 2];
            double row = ActiveMatrix.keycap[index, 3];
            double col = ActiveMatrix.keycap[index, 4];
            Button button = new Button();
            KeymapPanel.Controls.Add(button);
            Size size1 = new Size((int)(KeycapLength * length - KeycapOffset * 2), (int)(KeycapLength - KeycapOffset * 2));
            Point Point1 = new Point(40 + (int)(x * KeycapLength), 100 + (int)(y * KeycapLength));
            if (x > 14)
            {
                Point1.X += 12;
            }
            if (y < 0)
            {
                Point1.Y -= 9;
            }
            if (length == 0.5)
            {
                size1.Width = (int)(KeycapLength - KeycapOffset * 2);
                size1.Height = (int)(KeycapLength * 2 - KeycapOffset * 2);
            }
            button.Size = size1;
            button.Location = Point1;
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.White;
            button.MouseDown += new MouseEventHandler(Layer0Button_MouseClick);
            button.Text = str;
            button.Name = index.ToString();
            // button.TabStop = false; //禁用tab键    
            KeymapPanel.BackgroundImage = TempImage;
            */
        }
        private void AVRKeys_Load(object sender, EventArgs e)
        {
            DefaultLayout();
        }
        private void ISO60_Click(object sender, EventArgs e)
        {

        }
        private void ISO61_Click(object sender, EventArgs e)
        {

        }
        private void ISO64_Click(object sender, EventArgs e)
        {

        }
    }
}
