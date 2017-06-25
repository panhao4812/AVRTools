using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyToolsLite
{
    class XD60
    {
        public XD60() { }
        public int ROWS = 5;
        public int COLS = 14;
        public byte[] rowPins = { 5, 6, 7, 8, 23 };
        public byte[] colPins = { 21, 20, 24, 10, 9, 15, 22, 1, 4, 14, 13, 12, 11, 3 };
        public string[,] hexaKeys0 = {
    {"ESC","1","2","3","4","5","6","7","8","9","0","MINUS","EQUAL","BACKSPACE"},
    {"TAB","Q","W","E","R","T","Y","U","I","O","P","LEFT_BRACE","RIGHT_BRACE","BACKSLASH"},
    {"CAPS_LOCK","A","S","D","F","G","H","J","K","L","SEMICOLON","QUOTE","0x00","ENTER"},
    {"LEFT_SHIFT","0x00","Z","X","C","V","B","N","M","COMMA","PERIOD","0x00", "SLASH","UP"},
    {"LEFT_CTRL","FN","LEFT_ALT","0x00","0x00","SPACE","0x00","SLASH","LEFT","0x00","FN","RIGHT_CTRL","DOWN", "RIGHT"}};
        public string[,] hexaKeys1 = {
    {"TILDE","F1","F2","F3","F4","F5","F6","F7","F8","F9","F10","F11","F12", "DELETE"},
    {"TAB","KEYPAD_1","KEYPAD_2","KEYPAD_3","KEYPAD_4","KEYPAD_5","KEYPAD_6","KEYPAD_7","KEYPAD_8","KEYPAD_9","KEYPAD_0","KEYPAD_MINUS","KEYPAD_PLUS","BACKSLASH"},
    {"CAPS_LOCK", "MOUSE_LEFT","MOUSE_MID","MOUSE_RIGHT","0x00","0x00","0x00","0x00","0x00","0x00","0x00","0x00","0x00","ENTER"},
    {"LEFT_SHIFT","0x00","NUM_LOCK","SCROLL_LOCK","INSERT","PRINTSCREEN","0x00","0x00","0x00","VOL_DOWN","VOL_UP","0x00","0x00","UP"},
    {"LEFT_CTRL","FN","LEFT_ALT","0x00","0x00","SPACE","0x00","0x00","LEFT","0x00","FN","RIGHT_CTRL","DOWN","RIGHT"}};
        //keymask_bits:7-press 654-hexatype0 3-press 210-hexatype1
        //type: 1-key 2-modifykey 3-mousekey 4-systemkey 5-consumerkey 6-FN 7-consumerkeyAL,8-consumerkeyAC
        public byte[,] keymask ={
    {0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11},
    {0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11},
    {0x11,0x13,0x13,0x13,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x00,0x11},
    {0x22,0x00,0x11,0x11,0x11,0x11,0x10,0x10,0x10,0x15,0x15,0x00,0x10,0x11},
    {0x22,0x66,0x22,0x00,0x00,0x11,0x00,0x10,0x11,0x00,0x66,0x22,0x11,0x11}};
        public string ushort2byte(ushort a)
        {
            byte[] output = BitConverter.GetBytes(a);
            return output[0].ToString()+","+output[2].ToString();
        }
        public string short2byte(short a)
        {
            byte[] output = BitConverter.GetBytes(a);
            return output[0].ToString() + "," + output[2].ToString();
        }
        public string byte2byte(byte a)
        {
            return a.ToString();
        }
        public string ToEEP()
        {
            ushort add1 = 10;
            ushort add2 = (ushort)(add1 + 5);
            ushort add3 = (ushort)(add2 + 14);
            ushort add4 = (ushort)(add3 + 70);
            ushort add5 = (ushort)(add4 + 70);
            StringBuilder output = new StringBuilder();
            output.Append(add1); output.Append(",");
            output.Append(add2); output.Append(",");
            output.Append(add3); output.Append(",");
            output.Append(add4); output.Append(",");
            output.Append(add5); output.Append(",");
            for(int i = 0; i < ROWS; i++)
            {
                output.Append(rowPins[i]); output.Append(",");
            }
            for (int i = 0; i < COLS; i++)
            {
                output.Append(colPins[i]); output.Append(",");
            }
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    int code = Program.name2code(hexaKeys0[r, c]);
                    output.Append(code); output.Append(",");
                }
            }
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    int code = Program.name2code(hexaKeys1[r, c]);
                    output.Append(code); output.Append(",");
                }
            }
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    output.Append(keymask[r, c]); output.Append(",");
                }
            }
            output.Append((byte)0);
            return output.ToString();
        }


    }
}
