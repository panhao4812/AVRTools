using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidRawTools
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
            RGB = new int[64, 6];
            for(int i = 0; i < 64; i++)
            {
                double x = keycap[i, 0];
                double y = keycap[i, 1];
                Point Point1 = new Point(40 + (int)(x * HidRawTools.KeycapLength), 100 + (int)(y * HidRawTools.KeycapLength));
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
    { "0x00","KEY_SHIFT","KEY_Z","KEY_X","KEY_C","KEY_V","KEY_B","KEY_N","KEY_M","KEY_COMMA","KEY_PERIOD","KEY_SLASH","KEY_RIGHT_SHIFT","KEY_UP","KEY_DELETE"},
    { "KEY_CTRL","KEY_FN","0x00","KEY_ALT","0x00","0x00","KEY_SPACE","0x00","0x00","0x00","KEY_RIGHT_ALT","KEY_RIGHT_CTRL","KEY_LEFT","KEY_DOWN","KEY_RIGHT"}
          };        
            IUpdateMatrix();
            ///*
        }
    }
    class KC84_LILILI : QMK84_ISO
    {
        public KC84_LILILI()
        {
            this.Name = "KC84_LILILI";
            iniLayout();
            this.PrintFlashAddress = 0;
            this.ROWS = 6;
            this.COLS = 16;
            this.PrintEEpAddress = (ushort)(10 + ROWS + COLS + (ROWS * COLS * 3) + (keynum * 3) + 6);
            this.eepromsize = 1024;
            this.flashsize = 0x7000;
            this.rowPins = new byte[6] { 4, 15, 14, 13, 3, 2 };
            this.colPins = new byte[16] { 21, 20, 19, 18, 17, 16, 10, 9, 12, 11, 23, 22, 8, 7, 6, 5 };
            this.hexaKeys0 = new string[6, 16];
            this.hexaKeys1 = new string[6, 16];

            RGB = new int[keynum, 6];
            ///*
            for (int i = 0; i < keynum; i++)
            {
                double x = keycap[i, 0];
                double y = keycap[i, 1];
                Point Point1 = new Point(40 + (int)(x * HidRawTools.KeycapLength), 100 + (int)(y * HidRawTools.KeycapLength));
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
                double maxX = 16 * 48;
                //double maxY = 5 * 48 ;              
                int index = (int)(Point1.X / maxX * (IKeycode.Rcolors.Count() - 1));
                if (x > 14) index = (int)((Point1.X-12) / maxX * (IKeycode.Rcolors.Count() - 1));
                RGB[i, 3] = IKeycode.Rcolors[index];
                RGB[i, 4] = IKeycode.Gcolors[index];
                RGB[i, 5] = IKeycode.Bcolors[index];
                Debug_output += index.ToString() + ",";
                // Debug_output += RGB[i, 3].ToString() + ","+ RGB[i, 4].ToString()+ ","+RGB[i, 5].ToString() + ",";
            }
            //x,y,type,r,g,b
            //*/
            IhexaKeys0 = new string[,]{
{"KEY_ESC","KEY_F1","KEY_F2","KEY_F3","KEY_F4","KEY_F5","KEY_F6","KEY_F7","KEY_F8","KEY_F9","KEY_F10","KEY_F11","KEY_F12","KEY_PRINTSCREEN","KEY_PAUSE","KEY_DELETE"},
{ "KEY_TILDE","KEY_1","KEY_2","KEY_3","KEY_4","KEY_5","KEY_6","KEY_7","KEY_8","KEY_9","KEY_0","KEY_MINUS","KEY_EQUAL","0x00","KEY_BACKSPACE","KEY_HOME"},
{ "KEY_TAB","KEY_Q","KEY_W","KEY_E","KEY_R","KEY_T","KEY_Y","KEY_U","KEY_I","KEY_O","KEY_P","KEY_LEFT_BRACE","KEY_RIGHT_BRACE","0x00","KEY_BACKSLASH","KEY_PAGE_UP"},
{ "KEY_CAPS_LOCK","KEY_A","KEY_S","KEY_D","KEY_F","KEY_G","KEY_H","KEY_J","KEY_K","KEY_L","KEY_SEMICOLON","KEY_QUOTE","0x00","0x00","KEY_ENTER","KEY_PAGE_DOWN"},
{ "KEY_SHIFT","KEY_Z","KEY_X","KEY_C","KEY_V","KEY_B","KEY_N","KEY_M","KEY_COMMA","KEY_PERIOD","KEY_SLASH","0x00","0x00","KEY_RIGHT_SHIFT","KEY_UP","KEY_END"},
{ "KEY_CTRL","KEY_GUI","KEY_ALT","0x00","0x00","KEY_SPACE","0x00","0x00","0x00","KEY_RIGHT_ALT","KEY_FN","KEY_RIGHT_CTRL","0x00","KEY_LEFT","KEY_DOWN","KEY_RIGHT"}
                    };
            IUpdateMatrix();
        }
    }
    class KC84_Vem : QMK84_ISO
    {
        public KC84_Vem()
        {
            this.Name = "KC84_Vem";
            iniLayout();
            this.PrintFlashAddress = 0;
            this.ROWS = 6;
            this.COLS = 16;
            this.PrintEEpAddress = (ushort)(10 + ROWS + COLS + (ROWS * COLS * 3) + (keynum * 3) + 6);
            this.eepromsize = 1024;
            this.flashsize = 0x7000;
            this.rowPins = new byte[6] { 0, 1, 2, 3, 5, 6 };
            this.colPins = new byte[16] { 16, 17, 18, 19, 20, 21, 7, 8, 23, 22, 11, 12, 13, 14, 15, 9 };
            this.hexaKeys0 = new string[6, 16];
            this.hexaKeys1 = new string[6, 16];

            RGB = new int[keynum, 6];
            ///*
            for (int i = 0; i < keynum; i++)
            {
                double x = keycap[i, 0];
                double y = keycap[i, 1];
                Point Point1 = new Point(40 + (int)(x * HidRawTools.KeycapLength), 100 + (int)(y * HidRawTools.KeycapLength));
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
                double maxX = 16 * 48;
                //double maxY = 5 * 48 ;              
                int index = (int)(Point1.X / maxX * (IKeycode.Rcolors.Count() - 1));
                if (x > 14) index = (int)((Point1.X - 12) / maxX * (IKeycode.Rcolors.Count() - 1));
                RGB[i, 3] = IKeycode.Rcolors[index];
                RGB[i, 4] = IKeycode.Gcolors[index];
                RGB[i, 5] = IKeycode.Bcolors[index];
                Debug_output += index.ToString() + ",";
                // Debug_output += RGB[i, 3].ToString() + ","+ RGB[i, 4].ToString()+ ","+RGB[i, 5].ToString() + ",";
            }
            //x,y,type,r,g,b
            //*/
            IhexaKeys0 = new string[,]{
{"KEY_ESC","KEY_F1","KEY_F2","KEY_F3","KEY_F4","KEY_F5","KEY_F6","KEY_F7","KEY_F8","KEY_F9","KEY_F10","KEY_F11","KEY_F12","KEY_PRINTSCREEN","KEY_PAUSE","KEY_DELETE"},
{"KEY_TILDE","KEY_1","KEY_2","KEY_3","KEY_4","KEY_5","KEY_6","KEY_7","KEY_8","KEY_9","KEY_0","KEY_MINUS","KEY_EQUAL","0x00","KEY_BACKSPACE","KEY_HOME"},
{"KEY_TAB","0x00","KEY_Q","KEY_W","KEY_E","KEY_R","KEY_T","KEY_Y","KEY_U","KEY_I","KEY_O","KEY_P","KEY_LEFT_BRACE","KEY_RIGHT_BRACE","KEY_BACKSLASH","KEY_PAGE_UP"},
{"KEY_CAPS_LOCK","0x00","KEY_A","KEY_S","KEY_D","KEY_F","KEY_G","KEY_H","KEY_J","KEY_K","KEY_L","KEY_SEMICOLON","KEY_QUOTE","KEY_ENTER","0x00","KEY_PAGE_DOWN"},
{"0x00","KEY_SHIFT","KEY_Z","KEY_X","KEY_C","KEY_V","KEY_B","KEY_N","KEY_M","KEY_COMMA","KEY_PERIOD","KEY_SLASH","0x00","KEY_RIGHT_SHIFT","KEY_UP","KEY_END"},
{"KEY_CTRL","KEY_GUI","0x00","KEY_ALT","0x00","0x00","KEY_SPACE","0x00","0x00","0x00","KEY_RIGHT_ALT","KEY_FN","KEY_RIGHT_CTRL","KEY_LEFT","KEY_DOWN","KEY_RIGHT"}
                    };
            IUpdateMatrix();
        }
    }
}
