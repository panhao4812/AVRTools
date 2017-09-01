using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidRawTools
{
    class staryu : IMatrix
    {
        public staryu()
        {
            this.Name = "staryu";
            this.ROWS = 1;
            this.COLS = 5;
            this.rowPins = new byte[1] { 0xFF };
            this.colPins = new byte[5] { 16, 17, 18, 19, 20 };
            this.hexaKeys0 = new string[1, 5];
            this.hexaKeys1 = new string[1, 5];
            keycode = new string[24 * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            this.keycap = new double[24, 5] {
                {15,0,1,-1,-1 },
                {16,0,1,-1,-1 },
                {17,0,1,-1,-1 },
                {18,0,1,-1,-1 },
                {15,1,1,-1,-1 },
                {16,1,1,-1,-1 },
                {17,1,1,-1,-1 },
                {18,1,1,-1,-1 },
                {15,2,1,-1,-1 },
                {16,2,1,-1,-1 },
                {17,2,1,-1,-1 },
                {18,2,1,-1,-1 },
                {15,3,1,-1,-1 },
                {16,3,1,0,0 },
                {17,3,1,0,1 },
                {18,3,1,-1,-1 },
                {15,4,1,0,2 },
                {16,4,1,0,3 },
                {17,4,1,0,4 },
                {18,4,1,-1,-1 },
                {15,-1,1,-1,-1 },
                {16,-1,1,-1,-1 },
                {17,-1,1,-1,-1 },
                {18,-1,1,-1,-1 }
            };
            Defaultkeycode = new string[]{
"13,KEY_UP,MACRO4",
"14,KEY_FN,KEY_FN",
"16,KEY_LEFT,MACRO5",
"17,KEY_DOWN,MACRO6",
"18,KEY_RIGHT,MACRO7"
            };
        }
    }
}

