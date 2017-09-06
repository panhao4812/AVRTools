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
            keycode = new string[5 * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            this.keycap = new double[5, 5] {
                {16,3,1,0,0 },
                {17,3,1,0,1 },
                {15,4,1,0,4 },
                {16,4,1,0,3 },
                {17,4,1,0,2 },
            };
            Defaultkeycode = new string[]{
"0,KEY_UP,MACRO4",
"1,KEY_FN,KEY_FN",
"2,KEY_LEFT,MACRO5",
"3,KEY_DOWN,MACRO6",
"4,KEY_RIGHT,MACRO7"
            };
        }
    }
    class Tinykey : IMatrix
    {
        public Tinykey()
        {
            this.Name = "Tinykey";
            this.ROWS = 1;
            this.COLS = 2;
            this.rowPins = new byte[1] { 0xFF };
            this.colPins = new byte[2] { 0,1 };
            this.hexaKeys0 = new string[1, 2];
            this.hexaKeys1 = new string[1, 2];
            keycode = new string[2 * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            this.keycap = new double[2, 5] {                        
                {16,4,1,0,0 },
                {17,4,1,0,1 },                  
            };
            Defaultkeycode = new string[]{
"0,KEY_Z,MACRO1",
"1,KEY_X,MACRO3",

            };
        }
    }
}

