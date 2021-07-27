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
using System.IO;

namespace AVRTools
{
    /*
     * 原型
     */
    public partial class AVRKeys : Form
    {
        public void Print(string str)
        {
            ConsoleBox.Text += str + "\r\n";
        }
        public IMatrix ActiveMatrix;
        public Button ActiveButton;
        string SavePath = "";
        public void DefaultLayout()
        {
            int Height1 = 20; int Width1 = 54;
            this.Size = new Size(850 + Width1, 561 + Height1);
            MatrixPanel.Size = new Size(838 + Width1, 250 + Height1);
            MatrixPanel.Location = new Point(0, 25);
            SelectKeysPanel.Size = new Size(838 + Width1, 250);
            SelectKeysPanel.Location = new Point(0, 272 + Height1);
            // Panel panel = new Panel();
            // panel.Location = new Point(0, 0);
            // panel.Size =new Size( 1106, 279);
            // Layer1.Controls.Add(panel);
        }
        public AVRKeys()
        {
            InitializeComponent();
        }
        private void AVRKeys_Load(object sender, EventArgs e)
        {
            DefaultLayout();
            US.Controls.Clear();
            IMatrix matrix104 = new QMK104_ISO();
            List<Button> buttons1 = matrix104.CreateButton(36);
            for (int i = 0; i < buttons1.Count; i++)
            {
                buttons1[i].Text = IKeycode.shortname(matrix104.key_caps[i].layer1);
                buttons1[i].BackColor = Color.LightSteelBlue;
                buttons1[i].MouseDown += new MouseEventHandler(SelectKey_Button_MouseClick);
                US.Controls.Add(IKeycap.UpdateButton(buttons1[i]));
            }
            }
        private void ClearButton()
        {
            Layer1.Controls.Clear();
            Layer2.Controls.Clear();
            Schematic.Controls.Clear();
        }
        private void InitMatrrix()
        {
            ClearButton();
            List<Button> buttons1 = ActiveMatrix.CreateButton(40);
            List<Button> buttons2 = ActiveMatrix.CreateButton(40);
            List<Button> buttons3 = ActiveMatrix.CreateButton(40);
            for (int i = 0; i < buttons1.Count; i++)
            {
                buttons1[i].Text = IKeycode.shortname(ActiveMatrix.key_caps[i].layer1);
                buttons1[i].BackColor = Color.LightSeaGreen;
                buttons1[i].MouseDown += new MouseEventHandler(Keycap_Button_MouseClick);
                Layer1.Controls.Add(IKeycap.UpdateButton(buttons1[i]));
                buttons2[i].Text = IKeycode.shortname(ActiveMatrix.key_caps[i].layer2);
                buttons2[i].BackColor = Color.LightSeaGreen;
                buttons2[i].MouseDown += new MouseEventHandler(Keycap_Button_MouseClick);
                Layer2.Controls.Add(IKeycap.UpdateButton(buttons2[i]));
                buttons3[i].Text = ActiveMatrix.key_caps[i].R.ToString() + "/" +
                ActiveMatrix.key_caps[i].C.ToString();
                buttons3[i].MouseDown += new MouseEventHandler(Keycap_Button_MouseClick);
                Schematic.Controls.Add(IKeycap.UpdateButton(buttons3[i]));
                
            }
            PidBox.Text = "0x" + ActiveMatrix.PRODUCT_ID.ToString("X");
            VidBox.Text = "0x" + ActiveMatrix.VENDOR_ID.ToString("X");
        }
        private void Layer1_Keycap_TextChanged(object sender, EventArgs e)
        {
            if (ActiveMatrix == null) return;
            int index = Convert.ToInt32(((Button)sender).Name);
            ActiveMatrix.key_caps[index].layer1=( (Button)sender).Text;
        }
        private void Layer2_Keycap_TextChanged(object sender, EventArgs e)
        {
            if (ActiveMatrix == null) return;
            int index = Convert.ToInt32(((Button)sender).Name);
            ActiveMatrix.key_caps[index].layer2 = ((Button)sender).Text;
        }
        private void Keycap_Button_MouseClick(object sender, MouseEventArgs e)
        {
            //key button
            if (ActiveButton != null) ActiveButton.BackColor = Color.LightSeaGreen;
            if (e.Button == MouseButtons.Right)
            {
                ActiveButton = null;
            }
            else
            {
                ((Button)sender).BackColor = Color.LightSalmon;
                ActiveButton = ((Button)sender);
            }  
        }
        private void SelectKey_Button_MouseClick(object sender, MouseEventArgs e)
        {
            //key button      
            if (e.Button == MouseButtons.Right)
            {
               
            }
            else
            {
                ActiveButton.Text = ((Button)sender).Text;
            }
        }
        #region IO
        private void Open_Click(object sender, EventArgs e)
        {
            String path = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                SavePath = path;
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
                if (chara.Length != 2) return;
                Print(chara[1]);
                List<string> strs = new List<string>();
                while (srd.Peek() != -1)
                {
                    strs.Add(srd.ReadLine());
                }
                srd.Close();
                IMatrix matrix = new IMatrix();
                matrix.NAME = chara[1];
                matrix.MCU_Init(chara[0]);
                matrix.KeyCap_Init(strs.ToArray());
                ActiveMatrix = matrix;
                InitMatrrix();
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            FileSave(SavePath);
        }
        private void FileSave(string path)
        {
            try
            {
                if (ActiveMatrix == null) return;
                if (path == "")
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FilterIndex = 0;
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        path = sfd.FileName; SavePath = path;
                    }
                    else
                    {
                        return;
                    }
                }
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.SetLength(0);
                StreamWriter stream = new StreamWriter(fs);
                string output = "";
                if (ActiveMatrix.VENDOR_ID == 0x32C4)
                {
                    output += "__AVR_ATmega32U4__," + ActiveMatrix.NAME + "\r\n";
                }
                else if (ActiveMatrix.VENDOR_ID == 0x32C2)
                {
                    output += "__AVR_ATmega32U2__," + ActiveMatrix.NAME + "\r\n";
                }
                else
                {
                    output += ActiveMatrix.NAME + "\r\n";
                    // can not be loaded
                }
                output += ActiveMatrix.PrintKeyCap();
                stream.Write(output);
                stream.Flush();
                stream.Close();
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        private void SaveAs_Click(object sender, EventArgs e)
        {
            FileSave("");
        }
        #endregion
        #region Matrix
        private void ISO61_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK61_ISO();
            InitMatrrix();
        }
        private void ISO63_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK63_ISO();
            InitMatrrix();
        }
        private void ISO64_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK64_ISO();
            InitMatrrix();
        }
        private void ISO68_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK68_ISO();
            InitMatrrix();
        }
        private void ISO84_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK84_ISO();
            InitMatrrix();
        }
        private void ISO87_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK87_ISO();
            InitMatrrix();
        }
        private void ISO100_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK100_ISO();
            InitMatrrix();
        }
        private void ISO104_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK104_ISO();
            InitMatrrix();
        }
        private void ISO108_Click(object sender, EventArgs e)
        {
            ActiveMatrix = new QMK108_ISO();
            InitMatrrix();
        }
        #endregion
        private void Upload_Click(object sender, EventArgs e)
        {

        }
        private void TestKey_Click(object sender, EventArgs e)
        {

        }

        private void Layer2_Leave(object sender, EventArgs e)
        {
           
        }

        private void Layer1_Leave(object sender, EventArgs e)
        {
            
        }

        private void Layer1_Enter(object sender, EventArgs e)
        {
            if (ActiveButton != null) ActiveButton.BackColor = Color.LightSeaGreen;
            ActiveButton = null;
        }

        private void Layer2_Enter(object sender, EventArgs e)
        {
            if (ActiveButton != null) ActiveButton.BackColor = Color.LightSeaGreen;
            ActiveButton = null;
        }
    }
}
