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
            this.PrintFlashAddress = 0;
            this.PrintEEpAddress = 297;
            this.eepromsize = 1024;
            this.flashsize = 0;

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
            this.PrintFlashAddress = 0;
            this.PrintEEpAddress = 297;
            this.eepromsize = 1024;
            this.flashsize = 0;

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
            RGB = new int[12, 6]{
                //x,y,type,r,g,b
 {530,12,1,255,255,255},
 {430,12,1,255,255,255},
 {330,12,1,255,255,255},
 {230,12,1,255,255,255},
 {130,12,1,255,255,255},
 {130,355,1,255,255,255},
 {230,355,1,255,255,255},
 {330,355,1,255,255,255},
 {430,355,1,255,255,255},
 {530,355,1,255,255,255},
 {630,355,1,255,255,255},
 {630,12,1,255,255,255}
            };
        }
    }
    class bface60_minila : bface60
    {
        public bface60_minila() : base()
        {
            this.Name = "bface60_minila";
            Defaultkeycode = new string[]{
"0,MACRO2,KEY_TILDE",
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
"70,KEY_B,MACRO0",
"71,KEY_N,MACRO1",
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
    class bface60_B : bface60
    {
        public bface60_B() : base()
        {
            this.Name = "bface60_minila";
            Defaultkeycode = new string[]{
"0,MACRO2,KEY_TILDE",
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
"29,KEY_BACKSLASH,MACRO3",
"30,KEY_CAPS_LOCK,KEY_CAPS_LOCK",
"31,KEY_A,MOUSE_LEFT",
"32,KEY_S,MOUSE_MID",
"33,KEY_D,MOUSE_RIGHT",
"34,KEY_F, ",
"35,KEY_G, ",
"36,KEY_H, ",
"37,KEY_J, ",
"38,KEY_K, ",
"39,KEY_L, ",
"40,KEY_SEMICOLON, ",
"41,KEY_QUOTE, ",
"43,KEY_ENTER,KEYPAD_ENTER",
"63,KEY_SHIFT,KEY_SHIFT",
"66,KEY_Z,KEY_NUM_LOCK",
"67,KEY_X,KEY_SCROLL_LOCK",
"68,KEY_C,KEY_INSERT",
"69,KEY_V,KEY_PRINTSCREEN",
"70,KEY_B,MACRO0",
"71,KEY_N,MACRO1",
"72,KEY_M, ",
"73,KEY_COMMA,AUDIO_VOL_DOWN",
"74,KEY_PERIOD,AUDIO_VOL_UP",
"75,KEY_SLASH,AUDIO_MUTE",
"77,KEY_RIGHT_SHIFT,KEY_RIGHT_SHIFT",
"78,KEY_UP,KEY_UP",
"80,KEY_RIGHT_CTRL,KEY_RIGHT_CTRL",
"82,KEY_CTRL,KEY_CTRL",
"84,KEY_FN,KEY_FN",
"88,KEY_ALT,KEY_ALT",
"92,KEY_SPACE,KEY_SPACE",
"99,KEY_FN,KEY_FN",
"101,KEY_FN,KEY_FN",
"106,KEY_LEFT,KEY_LEFT",
"109,KEY_DOWN,KEY_DOWN",
"112,KEY_RIGHT,KEY_RIGHT"
};
        }
    }
    class bface96 : IMatrix
    {
        public bface96()
        {
            this.ROWS = 8;
            this.COLS = 15;
            this.PrintFlashAddress = 0;
            this.PrintEEpAddress = (ushort)(10 + ROWS + COLS + (ROWS * COLS * 3) + (20 * 3) + 6);
            this.eepromsize = 1024;
            this.flashsize = 0;
            this.Name = "bface96";
            this.rowPins = new byte[8] { 8, 9, 10, 11, 12, 13, 14, 15 };
            this.colPins = new byte[15] { 0, 1, 2, 3, 4, 5, 6, 7, 23, 22, 21, 20, 19, 18, 31 };
            this.hexaKeys0 = new string[8, 15];
            this.hexaKeys1 = new string[8, 15];
            keycode = new string[99 * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            Defaultkeycode = new string[]{
"0,KEY_ESC,",
"1,KEY_F1,",
"2,KEY_F2,",
"3,KEY_F3,",
"4,KEY_F4,",
"5,KEY_F5,",
"6,KEY_F6,",
"7,KEY_F7,",
"8,KEY_F8,",
"9,KEY_F9,",
"10,KEY_F10,",
"11,KEY_F11,",
"12,KEY_F12,",
"13,KEY_PRINTSCREEN,",
"14,KEY_PAUSE,",
"15,KEY_INSERT,",
"16,KEY_DELETE,",
"17,KEY_PAGE_UP,",
"18,KEY_PAGE_DOWN,",
//----------------------------
"19,KEY_TILDE,",
"20,KEY_1,",
"21,KEY_2,",
"22,KEY_3,",
"23,KEY_4,",
"24,KEY_5,",
"25,KEY_6,",
"26,KEY_7,",
"27,KEY_8,",
"28,KEY_9,",
"29,KEY_0,",
"30,KEY_MINUS,",
"31,KEY_EQUAL,",
"32,KEY_BACKSPACE,",
"33,KEY_NUM_LOCK,",
"34,KEYPAD_SLASH,",
"35,KEYPAD_ASTERIX,",
"36,KEYPAD_MINUS,",
//------------------------
"37,KEY_TAB,",
"38,KEY_Q,",
"39,KEY_W,",
"40,KEY_E,",
"41,KEY_R,",
"42,KEY_T,",
"43,KEY_Y,",
"44,KEY_U,",
"45,KEY_I,",
"46,KEY_O,",
"47,KEY_P,",
"48,KEY_LEFT_BRACE,",
"49,KEY_RIGHT_BRACE,",
"50,KEY_BACKSLASH,",
"51,KEYPAD_7,",
"52,KEYPAD_8,",
"53,KEYPAD_9,",
"54,KEYPAD_PLUS,",
//-------------------------
"55,KEY_CAPS_LOCK,",
"56,KEY_A,",
"57,KEY_S,",
"58,KEY_D,",
"59,KEY_F,",
"60,KEY_G,",
"61,KEY_H,",
"62,KEY_J,",
"63,KEY_K,",
"64,KEY_L,",
"65,KEY_SEMICOLON,",
"66,KEY_QUOTE,",
"67,KEY_ENTER,",
"68,KEYPAD_4,",
"69,KEYPAD_5,",
"70,KEYPAD_6,",
//---------------------------------
"71,KEY_LEFT_SHIFT,",
"72,KEY_Z,",
"73,KEY_X,",
"74,KEY_C,",
"75,KEY_V,",
"76,KEY_B,",
"77,KEY_N,",
"78,KEY_M,",
"79,KEY_COMMA,",
"80,KEY_PERIOD,",
"81,KEY_SLASH,",
"82,KEY_RIGHT_SHIFT,",
"83,KEY_UP,",
"84,KEYPAD_1,",
"85,KEYPAD_2,",
"86,KEYPAD_3,",
"87,KEYPAD_ENTER,",
//////////////////////
"88,KEY_CTRL,",
"89,KEY_GUI,",
"90,KEY_ALT,",
"91,KEY_SPACE,",
"92,KEY_RIGHT_ALT,",
"93,KEY_FN,",
"94,KEY_LEFT,",
"95,KEY_DOWN,",
"96,KEY_RIGHT,",
"97,KEYPAD_0,",
"98,KEYPAD_PERIOD,"//98
};
            this.keycap = new double[99, 5] {
                //x y length  my mx
{0,-1,1,5,0},// 0
{1,-1,1,5,2},// 1
{2,-1,1,5,3},// 2
{3,-1,1,5,4},// 3
{4,-1,1,5,5},// 4
{5,-1,1,6,0},// 5
{6,-1,1,6,10},// 6
{7,-1,1,7,10},// 7
{8,-1,1,7,0},// 8
{9,-1,1,5,11},// 9
{10,-1,1,5,12},// 10
{11,-1,1,5,13},// 11
{12,-1,1,5,14},// 12
{13,-1,1,1,13},// 13
{14,-1,1,2,14},// 14
{15,-1,1,0,13},// 15
{16,-1,1,7,6},// 16
{17,-1,1,7,9},// 17
{18,-1,1,7,8},// 18
{0,0,1,4,0},// 19
{1,0,1,4,1},// 20
{2,0,1,4,2},// 21
{3,0,1,4,3},// 22
{4,0,1,4,4},// 23
{5,0,1,4,5},// 24
{6,0,1,6,1},// 25
{7,0,1,6,11},// 26
{8,0,1,7,11},// 27
{9,0,1,7,1},// 28
{10,0,1,4,10},// 29
{11,0,1,4,11},// 30
{12,0,1,4,12},// 31
{13,0,2,4,14},// 32
{15,0,1,4,6},// 33
{16,0,1,4,7},// 34
{17,0,1,4,8},// 35
{18,0,1,4,9},// 36
{0,1,1.5,3,0},// 37
{1.5,1,1,3,1},// 38
{2.5,1,1,3,2},// 39
{3.5,1,1,3,3},// 40
{4.5,1,1,3,4},// 41
{5.5,1,1,3,5},// 42
{6.5,1,1,6,2},// 43
{7.5,1,1,6,12},// 44
{8.5,1,1,7,12},// 45
{9.5,1,1,7,2},// 46
{10.5,1,1,3,10},// 47
{11.5,1,1,3,11},// 48
{12.5,1,1,3,12},// 49
{13.5,1,1.5,3,13},// 50
{15,1,1,3,6},// 51
{16,1,1,3,7},// 52
{17,1,1,3,8},// 53
{18,1,0.5,2,9},// 54
{0,2,1.75,2,0},// 55
{1.75,2,1,2,1},// 56
{2.75,2,1,2,2},// 57
{3.75,2,1,2,3},// 58
{4.75,2,1,2,4},// 59
{5.75,2,1,2,5},// 60
{6.75,2,1,6,3},// 61
{7.75,2,1,6,13},// 62
{8.75,2,1,7,13},// 63
{9.75,2,1,7,3},// 64
{10.75,2,1,2,10},// 65
{11.75,2,1,2,11},// 66
{12.75,2,2.25,2,13},// 67
{15,2,1,2,6},// 68
{16,2,1,2,7},// 69
{17,2,1,2,8},// 70
{0,3,2.25,1,0},// 71
{2.25,3,1,1,1},// 72
{3.25,3,1,1,2},// 73
{4.25,3,1,1,3},// 74
{5.25,3,1,1,4},// 75
{6.25,3,1,1,5},// 76
{7.25,3,1,6,4},// 77
{8.25,3,1,6,14},// 78
{9.25,3,1,7,14},// 79
{10.25,3,1,7,4},// 80
{11.25,3,1,1,10},// 81
{12.25,3,1.75,1,11},// 82
{14,3,1,6,8},// 83
{15,3,1,1,6},// 84
{16,3,1,1,7},// 85
{17,3,1,1,8},// 86
{18,3,0.5,0,9},// 87
{0,4,1.25,0,0},// 88
{1.25,4,1.25,0,1},// 89
{2.5,4,1.25,0,2},// 90
{3.75,4,6.25,6,5},// 91 space
{10,4,1.25,7,5},// 92 right alt
{11.25,4,1.75,0,11},// 93 fn
{13,4,1,6,6},// 94
{14,4,1,6,7},// 95
{15,4,1,6,9},// 96
{16,4,1,0,6},// 97
{17,4,1,0,8}// 98
            };
            RGB = new int[20, 6]{
                //x,y,type,r,g,b
 {6,172,1,255,255,255},
 {89,12,1,255,255,255},
 {189,12,1,255,255,255},
 {289,12,1,255,255,255},
 {389,12,1,255,255,255},
 {489,12,1,255,255,255},
 {589,12,1,255,255,255},
 {689,12,1,255,255,255},
 {789,12,1,255,255,255},
 {889,12,1,255,255,255},

 {970,172,1,255,255,255},
 {889,355,1,255,255,255},
 {789,355,1,255,255,255},
 {689,355,1,255,255,255},
 {589,355,1,255,255,255},
 {489,355,1,255,255,255},
 {389,355,1,255,255,255},
 {289,355,1,255,255,255},
 {189,355,1,255,255,255},
 {89,355,1,255,255,255}
            };
        }       
    }
}
