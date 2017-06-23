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
        public GH60_Tools()
        {
            InitializeComponent();       
        }
        public Button[] _buttons = new Button[70];
        private void GH60_Tools_Load(object sender, EventArgs e)
        {
                  
        }
    }
}
