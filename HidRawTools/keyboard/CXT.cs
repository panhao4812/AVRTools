using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidRawTools.keyboard
{
    class CXT64: QMK60_2Shift
    {
     
        public CXT64(){
         
            this.Name = "CXT64";
            iniLayout();
            this.PrintFlashAddress = 0;
            this.ROWS = 5;
            this.COLS = 15;
            this.PrintEEpAddress = (ushort)(10 + ROWS + COLS + (ROWS * COLS * 3) + (64 * 3) + 6);
            this.eepromsize = 1024;
            this.flashsize = 0x7000;         
            this.rowPins = new byte[5] { 10, 9, 15, 14, 13 };
            this.colPins = new byte[15] { 16, 17, 18, 19, 20, 21, 24, 0, 1, 2, 3, 5, 6, 7, 8 };
            this.hexaKeys0 = new string[5, 15];
            this.hexaKeys1 = new string[5, 15];
            Defaultkeycode = new string[]{
            "0,KEY_TILDE,KEY_TILDE",
"1,KEY_1,KEY_F1",
"2,KEY_2,KEY_F2",
"3,KEY_3,KEY_F3",
"4,KEY_4,KEY_F4",
"5,KEY_5,KEY_F5",
"6,KEY_6,KEY_F6",
"7,KEY_7,KEY_F7",
"8,KEY_8,KEY_F8",
"9,KEY_9,KEY_F9",
"10,KEY_0,KEY_F10",
"11,KEY_MINUS,KEY_F11",
"12,KEY_EQUAL,KEY_F12",
"13,KEY_BACKSPACE,KEY_DELETE",
"14,KEY_TAB,",
"15,KEY_Q,",
"16,KEY_W,",
"17,KEY_E,",
"18,KEY_R,",
"19,KEY_T,",
"20,KEY_Y,",
"21,KEY_U,",
"22,KEY_I,",
"23,KEY_O,",
"24,KEY_P,",
"25,KEY_LEFT_BRACE,",
"26,KEY_RIGHT_BRACE,",
"27,KEY_BACKSLASH,",
"28,KEY_CAPS_LOCK,",
"29,KEY_A,",
"30,KEY_S,",
"31,KEY_D,",
"32,KEY_F,",
"33,KEY_G,",
"34,KEY_H,",
"35,KEY_J,",
"36,KEY_K,",
"37,KEY_L,",
"38,KEY_SEMICOLON,",
"39,KEY_QUOTE,",
"40,KEY_ENTER,",
"41,KEY_SHIFT,",
"42,KEY_Z,KEY_NUM_LOCK",
"43,KEY_X,MACRO1",
"44,KEY_C,MACRO5",
"45,KEY_V,",
"46,KEY_B,",
"47,KEY_N,",
"48,KEY_M,",
"49,KEY_COMMA,",
"50,KEY_PERIOD,",
"51,KEY_SLASH,",
"52,KEY_RIGHT_SHIFT,",
"53,KEY_UP,",
"54,KEY_RIGHT_CTRL,",
"55,KEY_CTRL,",
"56,KEY_FN,KEY_FN",
"57,KEY_ALT,",
"58,KEY_SPACE,",
"59,KEY_FN2,KEY_FN",
"60,KEY_FN3,KEY_FN",
"61,KEY_LEFT,",
"62,KEY_DOWN,",
"63,KEY_RIGHT," };
            RGB = new int[64, 6];
            for(int i = 0; i < 64; i++)
            {
                double x = keycap[i, 0];
                double y = keycap[i, 1];
                Point Point1 = new Point(40 + (int)(x * HidRawTools.keycaplength), 100 + (int)(y * HidRawTools.keycaplength));
                if (x > 14)
                {
                    Point1.X += 12;
                }
                if (y < 0)
                {
                    Point1.Y -= 9;
                }
                RGB[i, 0] = Point1.X;
                RGB[i, 1] = Point1.Y;
                RGB[i, 2] = 1;
                double maxX = 15 * 48 ;
                //double maxY = 5 * 48 ;
                int index = (int)(Point1.X / maxX* (IKeycode.Rcolors.Count()-1));
                RGB[i, 3] = IKeycode.Rcolors[index];
                RGB[i, 4] = IKeycode.Gcolors[index]; 
                RGB[i, 5] = IKeycode.Bcolors[index];
                //Debug_output += RGB[i, 3].ToString() + ","+ RGB[i, 4].ToString()+ ","+RGB[i, 5].ToString() + ",";
            }
            //x,y,type,r,g,b
            ///*
            IhexaKeys0 = new string[,] {
            { "MACRO2","KEY_1","KEY_2","KEY_3","KEY_4","KEY_5","KEY_6","KEY_7","KEY_8","KEY_9","KEY_0","KEY_MINUS","KEY_EQUAL","0x00","KEY_BACKSPACE"},
    { "KEY_TAB","0x00","KEY_Q","KEY_W","KEY_E","KEY_R","KEY_T","KEY_Y","KEY_U","KEY_I","KEY_O","KEY_P","KEY_LEFT_BRACE","KEY_RIGHT_BRACE","KEY_BACKSLASH"},
    { "KEY_CAPS_LOCK","0x00","KEY_A","KEY_S","KEY_D","KEY_F","KEY_G","KEY_H","KEY_J","KEY_K","KEY_L","KEY_SEMICOLON","KEY_QUOTE","KEY_ENTER","0x00"},
    { "0x00","KEY_SHIFT","KEY_Z","KEY_X","KEY_C","KEY_V","KEY_B","KEY_N","KEY_M","KEY_COMMA","KEY_PERIOD","KEY_SLASH","KEY_RIGHT_SHIFT","KEY_UP","KEY_RIGHT_CTRL"},
    { "KEY_CTRL","KEY_FN","0x00","KEY_ALT","0x00","0x00","KEY_SPACE","0x00","0x00","0x00","KEY_FN2","KEY_FN3","KEY_LEFT","KEY_DOWN","KEY_RIGHT"}
          };        
            IUpdateMatrix();
            ///*
        }
    }
}
