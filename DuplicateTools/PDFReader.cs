using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicateTools
{
    public partial class PDFReader : Form
    {
        public PDFReader()
        {
            InitializeComponent();
        }
        public List<M_File> files = new List<M_File>();
        private void PDFReader_Load(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(axAcroPDF1.Width, axAcroPDF1.Height);
            if (files.Count == 0 || files == null) return;
            for (int i = 0; i < 1; i++)
            {
                if (axAcroPDF1.LoadFile(files[i].path_))
                {
                    axAcroPDF1.gotoFirstPage();
                    axAcroPDF1.DrawToBitmap(image, new Rectangle(0, 0, axAcroPDF1.Width, axAcroPDF1.Height));
                    image.Save("C:\\Users\\Administrator\\Pictures\\pic\\" +
                        Path.GetFileNameWithoutExtension(files[i].path_) + ".jpg");
                }

            }
        }
    }
}
