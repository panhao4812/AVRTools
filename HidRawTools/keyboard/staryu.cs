using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidRawTools
{
    class Staryu : IMatrix
    {
        public Staryu()
        {
            this.PrintFlashAddress = 0x2200;
            this.PrintEEpAddress = 40;
            this.eepromsize = 1024;
            this.flashsize = 0x7000;

            this.Name = "Staryu";
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
            RGB = new int[1, 6]{ {782,255,0,255,255,255} };
           
        }
    }
    class XD004 : IMatrix
    {
        public XD004()
        {
            this.PrintFlashAddress = 0x2400;
            this.PrintEEpAddress = 39;
            this.eepromsize = 512;
            this.flashsize = 0x3000;

            this.Name = "XD004";
            this.ROWS = 1;
            this.COLS = 4;
            this.rowPins = new byte[1] { 0xFF };
            this.colPins = new byte[4] { 19, 16, 12, 4 };
            this.hexaKeys0 = new string[1, 4];
            this.hexaKeys1 = new string[1, 4];
            keycode = new string[4 * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            this.keycap = new double[4, 5] {
                {0,-1,1,0,0 },
                {1,-1,1,0,1 },
                {2,-1,1,0,2 },
                {3,-1,1,0,3 },
            };
            Defaultkeycode = new string[]{
"0,KEY_1,MACRO1",
"1,KEY_3,MACRO3",
"2,KEY_4,MACRO4",
"3,KEY_FN,KEY_FN",
            };
            RGB = new int[2, 6]{
                //x,y,type,r,g,b
                 {75,12,1,255,255,255},
                 {170,12,1,255,255,255} };
        }
    }
    class Tinykey : IMatrix
    {
        public Tinykey()
        {
            this.PrintFlashAddress = 0;
            this.PrintEEpAddress = 31;
            this.eepromsize = 512;
            this.flashsize = 0;

            this.Name = "Tinykey";
            this.ROWS = 1;
            this.COLS = 2;
            this.rowPins = new byte[1] { 0xFF };
            this.colPins = new byte[2] { 0, 1 };
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
"0,MACRO1,MACRO1",
"1,MACRO3,MACRO3"
            };
            RGB = new int[2, 6]{
                //x,y,type,r,g,b
 {832,355,0,255,255,255},
 {878,355,0,255,255,255}
            };
        }
    }
}

