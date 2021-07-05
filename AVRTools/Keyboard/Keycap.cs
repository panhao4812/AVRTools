using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AVRKeys.Keyboard
{
   public class Keycap: System.Windows.Forms.Button
    {
      public Keycap()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.BringToFront();
            this.TabStop = false;
        }
        public Keycap(string str)
        {
            // posX,posY,1U,MatrixROW,MatrixCol,key1,key2
        }
    }
}
