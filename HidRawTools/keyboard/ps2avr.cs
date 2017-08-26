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
            this.ROWS = 5;
            this.COLS = 15;
            this.rowPins = new byte[5] { 11, 12, 13, 14, 15 };
            this.colPins = new byte[15] { 0, 1, 2, 3, 4, 5, 6, 7, 23, 22, 21, 20, 19, 18, 31 };
            this.hexaKeys0 = new string[5, 15];
            this.hexaKeys1 = new string[5, 15];
            keycode = new string[113 * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            this.keycap = new double[113, 5] {
        {0,0,1,0,0 },//0
        {1,0,1,0,1 },//1
        {2,0,1,0,2 },//2
        {3,0,1,0,3 },//3
        {4,0,1,0,4 },//4
        {5,0,1,0,5 },//5
        {6,0,1,0,6 },//6
        {7,0,1,0,7 },//7
        {8,0,1,0,8 },//8
        {9,0,1,0,9 },//9
        {10,0,1,0,10 },//10
        {11,0,1,0,11 },//11
        {12,0,1,0,12 },//12
        {13,0,1,0,13 },//13
        {13,0,2,0,14 },//14
        {14,0,1,0,14 },//15
        {0,1,1.5,1,0 },//16
        {1.5,1,1,1,1 },//17
        {2.5,1,1,1,2 },//18
        {3.5,1,1,1,3 },//19
        {4.5,1,1,1,4 },//20
        {5.5,1,1,1,5 },
        {6.5,1,1,1,6 },
        {7.5,1,1,1,7 },
        {8.5,1,1,1,8 },
        {9.5,1,1,1,9 },//25
        {10.5,1,1,1,10 },
        {11.5,1,1,1,11 },
        {12.5,1,1,1,12 },
        {13.5,1,1.5,1,13 },//29
        {0,2,1.75,2,0 },//30
        {1.75,2,1,2,1 },
        {2.75,2,1,2,2 },
        {3.75,2,1,2,3 },
        {4.75,2,1,2,4 },
        {5.75,2,1,2,5 },//35
        {6.75,2,1,2,6 },
        {7.75,2,1,2,7 },
        {8.75,2,1,2,8 },
        {9.75,2,1,2,9 },
        {10.75,2,1,2,10 },//40
        {11.75,2,1,2,11 },//41
        {12.75,2,1,2,12 },
        {12.75,2,2.25,2,13 },//43
        {13.75,2,1.25,2,13 },
        {0,3,2.25,3,0 },//45
        {0,3,1.25,3,0 },
        {1.25,3,1,3,1 },
        {2.25,3,1,3,2 },
        {3.25,3,1,3,3 },
        {4.25,3,1,3,4 },//50
        {5.25,3,1,3,5 },
        {6.25,3,1,3,6 },
        {7.25,3,1,3,7 },
        {8.25,3,1,3,8 },
        {9.25,3,1,3,9 },//55
        {10.25,3,1,3,10 },
        {11.25,3,1,3,11 },
        {12.25,3,2.75,3,13 },
        {12.25,3,1.75,3,13 },
        {12.25,3,1,3,12 },//60
        {13.25,3,1.75,3,13 },
        {14,3,1,3,12 },
        {0,3,2,3,0 },//63
        {0,3,1,3,0 },
        {1,3,1,3,1 },//65
        {2,3,1,3,2 },//66
        {3,3,1,3,3 },
        {4,3,1,3,4 },
        {5,3,1,3,5 },
        {6,3,1,3,6 },//70
        {7,3,1,3,7 },
        {8,3,1,3,8 },
        {9,3,1,3,9 },
        {10,3,1,3,10 },
        {11,3,1,3,11 },//75
        {11.25,3,1.75,3,11 },
        {12,3,1,3,12 },//77
        {13,3,1,3,13 },//78
        {13,3,2,3,13 },
        {14,3,1,3,14 },//80
        {0,4,1.75,4,0 },
        {0,4,1.25,4,0 },//
        {0,4,1.5,4,0 },
        {1.25,4,1.25,4,1 },//
        {1.5,4,1.5,4,1 },
        {1.5,4,1,4,1 },
        {1.75,4,1.25,4,1 },
        {2.5,4,1.25,4,2 },//
        {2.5,4,1.5,4,2 },
        {3,4,1.25,4,2 },
        {4.25,4,1.25,4,3 },  
        {3.75,4,6.25,4,7 },//
        {3,4,7,4,5 },
        {4,4,7,4,5 },//
        {4,4,6,4,5 },
        {5.5,4,3,4,7 },
        {8.5,4,1.25,4,8 },
        {9.75,4,1.25,4,9 },
        {10,4,1,4,9 }, //
        {10,4,1.25,4,9 },
        {11,4,1,4,10 }, //
        {10,4,1.5,4,10 },
        {11.25,4,1.25,4,10 },
        {11.5,4,1,4,11 },//
        {11,4,1.5,4,11 },
        {12,4,1,4,11 },  //
        {12.5,4,1.25,4,12 },
        {12.5,4,1,4,12 },
        {13,4,1,4,12 }, //
        {13.75,4,1.25,4,13 },
        {13.5,4,1.5,4,13 },
        {14,4,1,4,13 }};
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
"14,KEY_BACKSPACE,KEY_DELETE",
"16,KEY_TAB,KEY_TAB",
"17,KEY_Q,KEYPAD_1",
"18,KEY_W,KEYPAD_2",
"19,KEY_E,KEYPAD_3",
"20,KEY_R,KEYPAD_4",
"21,KEY_T,KEYPAD_5",
"22,KEY_Y,KEYPAD_6",
"23,KEY_U,KEYPAD_7",
"24,KEY_I,KEYPAD_8",
"25,KEY_O,KEYPAD_9",
"26,KEY_P,KEYPAD_0",
"27,KEY_LEFT_BRACE,KEYPAD_MINUS",
"28,KEY_RIGHT_BRACE,KEYPAD_PLUS",
"29,KEY_BACKSLASH,KEY_BACKSLASH",
"30,KEY_CAPS_LOCK,KEY_CAPS_LOCK",
"31,KEY_A,MOUSE_LEFT",
"32,KEY_S,MOUSE_MID",
"33,KEY_D,MOUSE_RIGHT",
"34,KEY_F,",
"35,KEY_G,",
"36,KEY_H,",
"37,KEY_J,",
"38,KEY_K,",
"39,KEY_L,",
"40,KEY_SEMICOLON,",
"41,KEY_QUOTE,",
"43,KEY_ENTER,KEY_ENTER",
"63,KEY_SHIFT,KEY_SHIFT",
"66,KEY_Z,KEY_NUM_LOCK",
"67,KEY_X,KEY_SCROLL_LOCK",
"68,KEY_C,KEY_INSERT",
"69,KEY_V,KEY_PRINTSCREEN",
"70,KEY_B,",
"71,KEY_N,",
"72,KEY_M,",
"73,KEY_COMMA,AUDIO_VOL_DOWN",
"74,KEY_PERIOD,AUDIO_VOL_UP",
"75,KEY_SLASH,AUDIO_MUTE",
"77,KEY_SHIFT,KEY_PAGE_UP",
"78,KEY_UP,KEY_UP",
"80,KEY_RIGHT_CTRL,KEY_PAGE_DOWN",
"81,KEY_CTRL,KEY_CTRL",
"87,KEY_GUI,KEY_GUI",
"90,KEY_ALT,KEY_ALT",
"91,KEY_FN,KEY_FN",
"96,KEY_SPACE,KEY_SPACE",
"97,KEY_FN,KEY_FN",
"98,KEY_RIGHT_ALT,KEY_RIGHT_ALT",
"101,KEY_RIGHT_GUI,KEY_RIGHT_CTRL",
"106,KEY_LEFT,KEY_LEFT",
"109,KEY_DOWN,KEY_DOWN",
"112,KEY_RIGHT,KEY_RIGHT"
};
        }
    }
}
