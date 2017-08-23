using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidRawTools
{
    class ps2avrU : IMatrix
    {
        public ps2avrU()
        {
            this.Name = "ps2avrU";
            this.ROWS = 8;
            this.COLS = 10;
            this.rowPins = new byte[8] { 8, 9, 10, 11, 12, 13, 14, 15 };
            this.colPins = new byte[10] { 1, 2, 3, 4, 5, 6, 7, 23, 22, 21 };
            this.hexaKeys0 = new string[8, 10];
            this.hexaKeys1 = new string[8, 10];

            Defaultkeycode = new string[]{
"0,KEY_ESC,KEY_TILDE",
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
"14,KEY_TAB,KEY_TAB",
"15,KEY_Q,MOUSE_LEFT",
"16,KEY_W,KEY_UP",
"17,KEY_E,MOUSE_RIGHT",
"18,KEY_R,",
"19,KEY_T,",
"20,KEY_Y,",
"21,KEY_U,",
"22,KEY_I,",
"23,KEY_O,",
"24,KEY_P,",
"25,KEY_LEFT_BRACE,",
"26,KEY_RIGHT_BRACE,",
"27,KEY_BACKSLASH,KEY_BACKSLASH",
"28,KEY_CAPS_LOCK,KEY_CAPS_LOCK",
"29,KEY_A,KEY_LEFT",
"30,KEY_S,KEY_DOWN",
"31,KEY_D,KEY_RIGHT",
"32,KEY_F,",
"33,KEY_G,",
"34,KEY_H,",
"35,KEY_J,",
"36,KEY_K,",
"37,KEY_L,",
"38,KEY_SEMICOLON,",
"39,KEY_QUOTE,",
"40,KEY_ENTER,KEY_ENTER",
"41,KEY_SHIFT,KEY_SHIFT",
"42,KEY_Z,KEY_NUM_LOCK",
"43,KEY_X,KEY_SCROLL_LOCK",
"44,KEY_C,KEY_INSERT",
"45,KEY_V,KEY_PRINTSCREEN",
"46,KEY_B,",
"47,KEY_N,",
"48,KEY_M,",
"49,KEY_COMMA,AUDIO_VOL_DOWN",
"50,KEY_PERIOD,AUDIO_VOL_UP",
"51,KEY_SLASH,AUDIO_MUTE",
"52,KEY_RIGHT_SHIFT,KEY_RIGHT_SHIFT",
"53,KEY_CTRL,KEY_CTRL",
"54,KEY_FN,KEY_FN",
"55,KEY_ALT,KEY_ALT",
"56,KEY_SPACE,KEY_SPACE",
"57,KEY_RIGHT_ALT,KEY_RIGHT_ALT",
"58,KEY_FN,KEY_FN",
"59,KEY_FN,KEY_FN",
"60,KEY_RIGHT_CTRL,KEY_RIGHT_CTRL"
};
            this.keycap = new double[61, 5]{
{0,0,1,6,0},
{1,0,1,7,0},
{2,0,1,7,1},
{3,0,1,7,2},
{4,0,1,7,3},
{5,0,1,6,3},
{6,0,1,6,4},
{7,0,1,7,4},
{8,0,1,7,5},
{9,0,1,7,6},
{10,0,1,7,7},
{11,0,1,6,7},
{12,0,1,6,5},
{13,0,2,6,9},//
{0,1,1.5,1,0},
{1.5,1,1,0,0},
{2.5,1,1,0,1},
{3.5,1,1,0,2},
{4.5,1,1,0,3},
{5.5,1,1,1,3},
{6.5,1,1,1,4},
{7.5,1,1,0,4},
{8.5,1,1,0,5},
{9.5,1,1,0,6},
{10.5,1,1,0,7},
{11.5,1,1,1,7},
{12.5,1,1,1,5},
{13.5,1,1.5,2,9},//
{0,2,1.75,1,1},
{1.75,2,1,2,0},
{2.75,2,1,2,1},
{3.75,2,1,2,2},
{4.75,2,1,2,3},
{5.75,2,1,3,3},
{6.75,2,1,3,4},
{7.75,2,1,2,4},
{8.75,2,1,2,5},
{9.75,2,1,2,6},
{10.75,2,1,2,7},
{11.75,2,1,3,7},
{12.75,2,2.25,4,9},//
{0,3,2.25,1,8},
{2.25,3,1,4,0},
{3.25,3,1,4,1},
{4.25,3,1,4,2},
{5.25,3,1,4,3},
{6.25,3,1,5,3},
{7.25,3,1,5,4},
{8.25,3,1,4,4},
{9.25,3,1,4,5},
{10.25,3,1,4,6},
{11.25,3,1,5,7},
{12.25,3,2.75,4,8},//
{0,4,1.25,0,8},
{1.25,4,1.25,0,9},
{2.5,4,1.25,3,8},
{3.75,4,6.25,3,9},
{10,4,1.25,5,8},
{11.25,4,1.25,6,8},
{12.5,4,1.25,5,6},
{13.75,4,1.25,2,8}
};
            keycode = new string[61 * 2];
            for (int i = 0; i < keycode.Length; i++) { keycode[i] = ""; }
        }
    }
    class bface60 : IMatrix
    {
        public bface60()
        {
            this.Name = "bface60";
            this.ROWS = 8;
            this.COLS = 10;
            this.rowPins = new byte[8] { 8, 9, 10, 11, 12, 13, 14, 15 };
            this.colPins = new byte[10] { 1, 2, 3, 4, 5, 6, 7, 23, 22, 21 };
            this.hexaKeys0 = new string[8, 10];
            this.hexaKeys1 = new string[8, 10];


        }
    }
}
