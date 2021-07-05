using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidRawTools
{
    public class IMatrix
    {
        public string Debug_output = "";
        public IMatrix() { }
        public int ROWS;
        public int COLS;
        public byte[] rowPins;
        public byte[] colPins;
        public string[,] hexaKeys0 = new string[5, 14];
        public string[,] hexaKeys1 = new string[5, 14];
        public byte[,] keymask = new byte[5, 14];
        public double[,] keycap;
        public string Name = "unamed";
        public string[] keycode;
        public string[] Defaultkeycode;
        public int[,] RGB = null;
        public ushort PrintFlashAddress = 0;
        public ushort PrintEEpAddress = 0;
        public ushort eepromsize = 0;
        public ushort flashsize = 0;
        /// ///////////////////////////////////////////////////
        public string[,] IhexaKeys0;
        public void IUpdateMatrix()
        {
            // 不能有重复键
            if (Defaultkeycode.Length < 1) return;
            for (int i = 0; i < Defaultkeycode.Length; i++)
            {
                string str = Defaultkeycode[i];
                string[] strs = str.Split(',');
                int index = Convert.ToInt32(strs[0]);
                bool sign = false;
                int ii, jj;
                for (ii = 0; ii < this.ROWS; ii++)
                {
                    for (jj = 0; jj < this.COLS; jj++)
                    {
                        if (strs[1] == IhexaKeys0[ii, jj])
                        {
                            keycap[index, 4] = jj; keycap[index, 3] = ii;
                            sign = true;
                        }
                        if (sign) break;
                    }
                    if (sign) break;
                }
            }
        }
    }
    class QMK60_ISO : IMatrix
    {
        public QMK60_ISO()
        {
            this.Name = "QMK60_ISO";
            iniLayout();
        }
        public const int keynum = 61;
        public void iniLayout()
        {
            RGB = null;
            //rgb如果是轴灯，前两个坐标值给0,0，如果没有则写null
            keycode = new string[keynum * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            Defaultkeycode = new string[keynum];
            for (int i = 0; i < Defaultkeycode.Length; i++)
            {
                Defaultkeycode[i] = i.ToString();
            }
            this.keycap = new double[keynum, 5] {
{0,0,1,0,0},// 0
{1,0,1,0,1},// 1
{2,0,1,0,2},// 2
{3,0,1,0,3},// 3
{4,0,1,0,4},// 4
{5,0,1,0,5},// 5
{6,0,1,0,6},// 6
{7,0,1,0,7},// 7
{8,0,1,0,8},// 8
{9,0,1,0,9},// 9
{10,0,1,0,10},// 10
{11,0,1,0,11},// 11
{12,0,1,0,12},// 12
{13,0,2,0,13},// 13
{0,1,1.5,1,0},// 14
{1.5,1,1,1,1},// 15
{2.5,1,1,1,2},// 16
{3.5,1,1,1,3},// 17
{4.5,1,1,1,4},// 18
{5.5,1,1,1,5},// 19
{6.5,1,1,1,6},// 20
{7.5,1,1,1,7},// 21
{8.5,1,1,1,8},// 22
{9.5,1,1,1,9},// 23
{10.5,1,1,1,10},// 24
{11.5,1,1,1,11},// 25
{12.5,1,1,1,12},// 26
{13.5,1,1.5,1,13},// 27
{0,2,1.75,2,0},// 28
{1.75,2,1,2,1},// 29
{2.75,2,1,2,2},// 30
{3.75,2,1,2,3},// 31
{4.75,2,1,2,4},// 32
{5.75,2,1,2,5},// 33
{6.75,2,1,2,6},// 34
{7.75,2,1,2,7},// 35
{8.75,2,1,2,8},// 36
{9.75,2,1,2,9},// 37
{10.75,2,1,2,10},// 38
{11.75,2,1,2,11},// 39
{12.75,2,2.25,2,13},// 40
{0,3,2.25,3,0},// 41
{2.25,3,1,3,2},// 42
{3.25,3,1,3,3},// 43
{4.25,3,1,3,4},// 44
{5.25,3,1,3,5},// 45
{6.25,3,1,3,6},// 46
{7.25,3,1,3,7},// 47
{8.25,3,1,3,8},// 48
{9.25,3,1,3,9},// 49
{10.25,3,1,3,10},// 50
{11.25,3,1,3,11},// 51
{12.25,3,2.75,3,13},// 52
{0,4,1.25,4,0},// 53
{1.25,4,1.25,4,1},// 54
{2.5,4,1.25,4,2},// 55
{3.75,4,6.25,4,5},// 56
{10,4,1.25,4,10},// 57
{11.25,4,1.25,4,11},// 58
{12.5,4,1.25,4,12},// 59
{13.75,4,1.25,4,13}// 60
            };
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
"13,KEY_BACKSPACE,KEY_DELETE",
"14,KEY_TAB,KEY_TAB",
"15,KEY_Q,KEYPAD_1",
"16,KEY_W,KEYPAD_2",
"17,KEY_E,KEYPAD_3",
"18,KEY_R,KEYPAD_4",
"19,KEY_T,KEYPAD_5",
"20,KEY_Y,KEYPAD_6",
"21,KEY_U,KEYPAD_7",
"22,KEY_I,KEYPAD_8",
"23,KEY_O,KEYPAD_9",
"24,KEY_P,KEYPAD_0",
"25,KEY_LEFT_BRACE,KEYPAD_MINUS",
"26,KEY_RIGHT_BRACE,KEYPAD_PLUS",
"27,KEY_BACKSLASH,KEY_BACKSLASH",
"28,KEY_CAPS_LOCK,KEY_CAPS_LOCK",
"29,KEY_A,MOUSE_LEFT",
"30,KEY_S,MOUSE_MID",
"31,KEY_D,MOUSE_RIGHT",
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
"42,KEY_Z,MACRO0",
"43,KEY_X,MACRO1",
"44,KEY_C,MACRO5",
"45,KEY_V,",
"46,KEY_B,",
"47,KEY_N,KEY_NUM_LOCK",
"48,KEY_M,KEY_SCROLL_LOCK",
"49,KEY_COMMA,AUDIO_VOL_DOWN",
"50,KEY_PERIOD,AUDIO_VOL_UP",
"51,KEY_SLASH,AUDIO_MUTE",
"52,KEY_RIGHT_SHIFT,KEY_RIGHT_SHIFT",
"53,KEY_CTRL,KEY_CTRL",
"54,KEY_FN,KEY_FN",
"55,KEY_ALT,KEY_ALT",
"56,KEY_LEFT,KEY_SPACE",
"57,KEY_RIGHT_ALT,KEY_RIGHT_ALT",
"58,KEY_LEFT,KEY_UP",
"59,KEY_RIGHT,KEY_DOWN",
"60,KEY_RIGHT_CTRL,KEY_RIGHT_CTRL"
            };
        }
    }
    class QMK84_ISO : IMatrix
    {
        public QMK84_ISO()
        {
            this.Name = "QMK84_ISO";
            iniLayout();
        }
        public const int keynum = 84;
        public void iniLayout()
        {
            RGB = null;
            keycode = new string[keynum * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            Defaultkeycode = new string[keynum];
            for (int i = 0; i < Defaultkeycode.Length; i++)
            {
                Defaultkeycode[i] = i.ToString();
            }
            this.keycap = new double[keynum, 5] {
{0,-1,1,0,0},// 0
{1,-1,1,0,1},// 1
{2,-1,1,0,2},// 2
{3,-1,1,0,3},// 3
{4,-1,1,0,4},// 4
{5,-1,1,0,5},// 5
{6,-1,1,0,6},// 6
{7,-1,1,0,7},// 7
{8,-1,1,0,8},// 8
{9,-1,1,0,9},// 9
{10,-1,1,0,10},// 10
{11,-1,1,0,11},// 11
{12,-1,1,0,12},// 12
{13,-1,1,0,13},// 13
{14,-1,1,0,14},// 14
{15,-1,1,0,15},// 15
{0,0,1,1,0},// 16
{1,0,1,1,1},// 17
{2,0,1,1,2},// 18
{3,0,1,1,3},// 19
{4,0,1,1,4},// 20
{5,0,1,1,5},// 21
{6,0,1,1,6},// 22
{7,0,1,1,7},// 23
{8,0,1,1,8},// 24
{9,0,1,1,9},// 25
{10,0,1,1,10},// 26
{11,0,1,1,11},// 27
{12,0,1,1,12},// 28
{13,0,2,1,14},// 29
{15,0,1,1,15},// 30
{0,1,1.5,2,0},// 31
{1.5,1,1,2,1},// 32
{2.5,1,1,2,2},// 33
{3.5,1,1,2,3},// 34
{4.5,1,1,2,4},// 35
{5.5,1,1,2,5},// 36
{6.5,1,1,2,6},// 37
{7.5,1,1,2,7},// 38
{8.5,1,1,2,8},// 39
{9.5,1,1,2,9},// 40
{10.5,1,1,2,10},// 41
{11.5,1,1,2,11},// 42
{12.5,1,1,2,12},// 43
{13.5,1,1.5,2,14},// 44
{15,1,1,2,15},// 45
{0,2,1.75,3,0},// 46
{1.75,2,1,3,1},// 47
{2.75,2,1,3,2},// 48
{3.75,2,1,3,3},// 49
{4.75,2,1,3,4},// 50
{5.75,2,1,3,5},// 51
{6.75,2,1,3,6},// 52
{7.75,2,1,3,7},// 53
{8.75,2,1,3,8},// 54
{9.75,2,1,3,9},// 55
{10.75,2,1,3,10},// 56
{11.75,2,1,3,11},// 57
{12.75,2,2.25,3,14},// 58
{15,2,1,3,15},// 59
{0,3,2.25,4,0},// 60
{2.25,3,1,4,1},// 61
{3.25,3,1,4,2},// 62
{4.25,3,1,4,3},// 63
{5.25,3,1,4,4},// 64
{6.25,3,1,4,5},// 65
{7.25,3,1,4,6},// 66
{8.25,3,1,4,7},// 67
{9.25,3,1,4,8},// 68
{10.25,3,1,4,9},// 69
{11.25,3,1,4,10},// 70
{12.25,3,1.75,4,13},// 71
{14,3,1,4,14},// 72
{15,3,1,4,15},// 73
{0,4,1.25,0,0},// 74
{1.25,4,1.25,0,1},// 75
{2.5,4,1.25,0,2},// 76
{3.75,4,6.25,5,5},// 77
{10,4,1,5,9},// 78
{11,4,1,5,10},// 79
{12,4,1,5,11},// 80
{13,4,1,5,13},// 81
{14,4,1,5,14},// 82
{15,4,1,5,15}// 83
};
            Defaultkeycode = new string[]{
"0,KEY_ESC,KEY_ESC",
"1,KEY_F1,KEY_F1",
"2,KEY_F2,KEY_F2",
"3,KEY_F3,KEY_F3",
"4,KEY_F4,KEY_F4",
"5,KEY_F5,KEY_F5",
"6,KEY_F6,KEY_F6",
"7,KEY_F7,KEY_F7",
"8,KEY_F8,KEY_F8",
"9,KEY_F9,KEY_F9",
"10,KEY_F10,KEY_F10",
"11,KEY_F11,KEY_F11",
"12,KEY_F12,KEY_F12",
"13,KEY_PRINTSCREEN,KEY_PRINTSCREEN",
"14,KEY_PAUSE,KEY_PAUSE",
"15,KEY_DELETE,KEY_DELETE",
"16,KEY_TILDE,KEY_TILDE",
"17,KEY_1,KEYPAD_1",
"18,KEY_2,KEYPAD_2",
"19,KEY_3,KEYPAD_3",
"20,KEY_4,KEYPAD_4",
"21,KEY_5,KEYPAD_5",
"22,KEY_6,KEYPAD_6",
"23,KEY_7,KEYPAD_7",
"24,KEY_8,KEYPAD_8",
"25,KEY_9,KEYPAD_9",
"26,KEY_0,KEYPAD_0",
"27,KEY_MINUS,KEYPAD_MINUS",
"28,KEY_EQUAL,KEYPAD_PLUS",
"29,KEY_BACKSPACE,KEY_BACKSPACE",
"30,KEY_HOME,KEY_HOME",
"31,KEY_TAB,KEY_TAB",
"32,KEY_Q,",
"33,KEY_W,",
"34,KEY_E,",
"35,KEY_R,",
"36,KEY_T,",
"37,KEY_Y,",
"38,KEY_U,",
"39,KEY_I,",
"40,KEY_O,",
"41,KEY_P,",
"42,KEY_LEFT_BRACE,",
"43,KEY_RIGHT_BRACE,",
"44,KEY_BACKSLASH,KEY_BACKSLASH",
"45,KEY_PAGE_UP,KEY_PAGE_UP",
"46,KEY_CAPS_LOCK,KEY_CAPS_LOCK",
"47,KEY_A,MOUSE_LEFT",
"48,KEY_S,MOUSE_MID",
"49,KEY_D,MOUSE_RIGHT",
"50,KEY_F,",
"51,KEY_G,",
"52,KEY_H,",
"53,KEY_J,",
"54,KEY_K,",
"55,KEY_L,",
"56,KEY_SEMICOLON,",
"57,KEY_QUOTE,",
"58,KEY_ENTER,KEY_ENTER",
"59,KEY_PAGE_DOWN,KEY_PAGE_DOWN",
"60,KEY_SHIFT,KEY_SHIFT",
"61,KEY_Z,KEY_NUM_LOCK",
"62,KEY_X,MACRO1",
"63,KEY_C,MACRO5",
"64,KEY_V,",
"65,KEY_B,",
"66,KEY_N,",
"67,KEY_M,",
"68,KEY_COMMA,AUDIO_VOL_DOWN",
"69,KEY_PERIOD,AUDIO_VOL_UP",
"70,KEY_SLASH,AUDIO_MUTE",
"71,KEY_RIGHT_SHIFT,KEY_RIGHT_SHIFT",
"72,KEY_UP,KEY_UP",
"73,KEY_END,KEY_END",
"74,KEY_CTRL,KEY_CTRL",
"75,KEY_GUI,KEY_GUI",
"76,KEY_ALT,KEY_ALT",
"77,KEY_SPACE,KEY_SPACE",
"78,KEY_RIGHT_ALT,KEY_RIGHT_ALT",
"79,KEY_FN,KEY_FN",
"80,KEY_RIGHT_CTRL,KEY_RIGHT_CTRL",
"81,KEY_LEFT,KEY_LEFT",
"82,KEY_DOWN,KEY_DOWN",
"83,KEY_RIGHT,KEY_RIGHT"
            };
        }
    }
    class QMK96_ISO : IMatrix
    {
        public QMK96_ISO()
        {
            this.Name = "QMK96_ISO";
            iniLayout();
        }
        public const int keynum = 100;
        public void iniLayout()
        {
            RGB = null;
            keycode = new string[keynum * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            Defaultkeycode = new string[keynum];
            for (int i = 0; i < Defaultkeycode.Length; i++)
            {
                Defaultkeycode[i] = i.ToString();
            }
            this.keycap = new double[keynum, 5] {
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
{3.75,4,6.25,6,5},// 91
{10,4,1,7,5},// 92
{11,4,1,0,11},// 93
{12,4,1,0,11},//94 
{13,4,1,6,6},// 95
{14,4,1,6,7},// 96
{15,4,1,6,9},// 97
{16,4,1,0,6},// 98
{17,4,1,0,8},// 99
            };
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
"94,KEY_RIGHT_CTRL,",
"95,KEY_LEFT,",
"96,KEY_DOWN,",
"97,KEY_RIGHT,",
"98,KEYPAD_0,",
"99,KEYPAD_PERIOD,"//98
};
        }
    }
    class QMK64 : IMatrix
    {
        public QMK64()
        {
            this.Name = "QMK60_2Shift";
            iniLayout();
        }
        public const int keynum = 64;
        public void iniLayout()
        {
            RGB = null;
            keycode = new string[keynum * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            Defaultkeycode = new string[keynum];
            for (int i = 0; i < Defaultkeycode.Length; i++)
            {
                Defaultkeycode[i] = i.ToString();
            }
            this.keycap = new double[keynum, 5] {
                {0,0,1,0,0},// 0
{1,0,1,0,1},// 1
{2,0,1,0,2},// 2
{3,0,1,0,3},// 3
{4,0,1,0,4},// 4
{5,0,1,0,5},// 5
{6,0,1,0,6},// 6
{7,0,1,0,7},// 7
{8,0,1,0,8},// 8
{9,0,1,0,9},// 9
{10,0,1,0,10},// 10
{11,0,1,0,11},// 11
{12,0,1,0,12},// 12
{13,0,2,0,14},// 13
{0,1,1.5,1,0},// 14
{1.5,1,1,1,1},// 15
{2.5,1,1,1,2},// 16
{3.5,1,1,1,3},// 17
{4.5,1,1,1,4},// 18
{5.5,1,1,1,5},// 19
{6.5,1,1,1,6},// 20
{7.5,1,1,1,7},// 21
{8.5,1,1,1,8},// 22
{9.5,1,1,1,9},// 23
{10.5,1,1,1,10},// 24
{11.5,1,1,1,11},// 25
{12.5,1,1,1,12},// 26
{13.5,1,1.5,1,13},// 27
{0,2,1.75,2,0},// 28
{1.75,2,1,2,1},// 29
{2.75,2,1,2,2},// 30
{3.75,2,1,2,3},// 31
{4.75,2,1,2,4},// 32
{5.75,2,1,2,5},// 33
{6.75,2,1,2,6},// 34
{7.75,2,1,2,7},// 35
{8.75,2,1,2,8},// 36
{9.75,2,1,2,9},// 37
{10.75,2,1,2,10},// 38
{11.75,2,1,2,11},// 39
{12.75,2,2.25,2,13},// 40
{0,3,2,3,0},// 41
{2,3,1,3,2},// 42
{3,3,1,3,3},// 43
{4,3,1,3,4},// 44
{5,3,1,3,5},// 45
{6,3,1,3,6},// 46
{7,3,1,3,7},// 47
{8,3,1,3,8},// 48
{9,3,1,3,9},// 49
{10,3,1,3,10},// 50
{11,3,1,3,11},// 51
{12,3,1,3,12},// 52
{13,3,1,3,13},// 53
{14,3,1,3,14},// 54
{0,4,1.25,4,0},// 55
{1.25,4,1.25,4,1},// 56
{2.5,4,1.25,4,2},// 57
{3.75,4,6.25,4,7},// 58
{10,4,1,4,9},// 59
{11,4,1,4,10},// 60
{12,4,1,4,11},// 61
{13,4,1,4,12},// 62
{14,4,1,4,13}// 63
            };
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
"13,KEY_BACKSPACE,KEY_DELETE",
"14,KEY_TAB,KEY_TAB",
"15,KEY_Q,KEYPAD_1",
"16,KEY_W,KEYPAD_2",
"17,KEY_E,KEYPAD_3",
"18,KEY_R,KEYPAD_4",
"19,KEY_T,KEYPAD_5",
"20,KEY_Y,KEYPAD_6",
"21,KEY_U,KEYPAD_7",
"22,KEY_I,KEYPAD_8",
"23,KEY_O,KEYPAD_9",
"24,KEY_P,KEYPAD_0",
"25,KEY_LEFT_BRACE,KEYPAD_MINUS",
"26,KEY_RIGHT_BRACE,KEYPAD_PLUS",
"27,KEY_BACKSLASH,KEY_BACKSLASH",
"28,KEY_CAPS_LOCK,KEY_CAPS_LOCK",
"29,KEY_A,MOUSE_LEFT",
"30,KEY_S,MOUSE_MID",
"31,KEY_D,MOUSE_RIGHT",
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
"43,KEY_X,MACRO1",
"44,KEY_C,MACRO5",
"45,KEY_V,",
"46,KEY_B,",
"47,KEY_N,",
"48,KEY_M,",
"49,KEY_COMMA,AUDIO_VOL_DOWN",
"50,KEY_PERIOD,AUDIO_VOL_UP",
"51,KEY_SLASH,AUDIO_MUTE",
"52,KEY_RIGHT_SHIFT,KEY_RIGHT_SHIFT",
"53,KEY_UP,KEY_UP",
"54,KEY_DELETE,KEY_DELETE",
"55,KEY_CTRL,KEY_CTRL",
"56,KEY_FN,KEY_FN",
"57,KEY_ALT,KEY_ALT",
"58,KEY_SPACE,KEY_SPACE",
"59,KEY_RIGHT_ALT,KEY_RIGHT_ALT",
"60,KEY_RIGHT_CTRL,KEY_RIGHT_CTRL",
"61,KEY_LEFT,KEY_LEFT",
"62,KEY_DOWN,KEY_DOWN",
"63,KEY_RIGHT,KEY_RIGHT"
 };
        }
    }
    class QMK63 : IMatrix
    {
        public QMK63()
        {
            this.Name = "QMK60_175Shift";
            iniLayout();
        }
        public const int keynum = 63;
        public void iniLayout()
        {
            RGB = null;
            keycode = new string[keynum * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            Defaultkeycode = new string[keynum];
            for (int i = 0; i < Defaultkeycode.Length; i++)
            {
                Defaultkeycode[i] = i.ToString();
            }
this.keycap = new double[keynum, 5] {
{0,0,1,0,0},// 0
{1,0,1,0,1},// 1
{2,0,1,0,2},// 2
{3,0,1,0,3},// 3
{4,0,1,0,4},// 4
{5,0,1,0,5},// 5
{6,0,1,0,6},// 6
{7,0,1,0,7},// 7
{8,0,1,0,8},// 8
{9,0,1,0,9},// 9
{10,0,1,0,10},// 10
{11,0,1,0,11},// 11
{12,0,1,0,12},// 12
{13,0,2,0,13},// 13
{0,1,1.5,1,0},// 14
{1.5,1,1,1,1},// 15
{2.5,1,1,1,2},// 16
{3.5,1,1,1,3},// 17
{4.5,1,1,1,4},// 18
{5.5,1,1,1,5},// 19
{6.5,1,1,1,6},// 20
{7.5,1,1,1,7},// 21
{8.5,1,1,1,8},// 22
{9.5,1,1,1,9},// 23
{10.5,1,1,1,10},// 24
{11.5,1,1,1,11},// 25
{12.5,1,1,1,12},// 26
{13.5,1,1.5,1,13},// 27
{0,2,1.75,2,0},// 28
{1.75,2,1,2,1},// 29
{2.75,2,1,2,2},// 30
{3.75,2,1,2,3},// 31
{4.75,2,1,2,4},// 32
{5.75,2,1,2,5},// 33
{6.75,2,1,2,6},// 34
{7.75,2,1,2,7},// 35
{8.75,2,1,2,8},// 36
{9.75,2,1,2,9},// 37
{10.75,2,1,2,10},// 38
{11.75,2,1,2,11},// 39
{12.75,2,2.25,2,13},// 40
{0,3,2.25,3,0},// 41
{2.25,3,1,3,2},// 42
{3.25,3,1,3,3},// 43
{4.25,3,1,3,4},// 44
{5.25,3,1,3,5},// 45
{6.25,3,1,3,6},// 46
{7.25,3,1,3,7},// 47
{8.25,3,1,3,8},// 48
{9.25,3,1,3,9},// 49
{10.25,3,1,3,10},// 50
{14,3,1,3,12},// 51
{11.25,3,1.75,4,7},// 52
{13,3,1,3,13},// 53
{10,4,1,4,10},// 54
{11,4,1,4,11},// 55
{12,4,1,4,8},// 56
{13,4,1,4,12},// 57
{14,4,1,4,13},// 58
{0,4,1.25,4,0},// 59
{1.25,4,1.25,4,1},// 60
{2.5,4,1.25,4,2},// 61
{3.75,4,6.25,4,5}//62
};
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
"13,KEY_BACKSPACE,KEY_DELETE",
"14,KEY_TAB,KEY_TAB",
"15,KEY_Q,KEYPAD_1",
"16,KEY_W,KEYPAD_2",
"17,KEY_E,KEYPAD_3",
"18,KEY_R,KEYPAD_4",
"19,KEY_T,KEYPAD_5",
"20,KEY_Y,KEYPAD_6",
"21,KEY_U,KEYPAD_7",
"22,KEY_I,KEYPAD_8",
"23,KEY_O,KEYPAD_9",
"24,KEY_P,KEYPAD_0",
"25,KEY_LEFT_BRACE,KEYPAD_MINUS",
"26,KEY_RIGHT_BRACE,KEYPAD_PLUS",
"27,KEY_BACKSLASH,KEY_BACKSLASH",
"28,KEY_CAPS_LOCK,KEY_CAPS_LOCK",
"29,KEY_A,MOUSE_LEFT",
"30,KEY_S,MOUSE_MID",
"31,KEY_D,MOUSE_RIGHT",
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
"44,KEY_C,MACRO5",
"45,KEY_V,",
"46,KEY_B,",
"47,KEY_N,",
"48,KEY_M,",
"49,KEY_COMMA,AUDIO_VOL_DOWN",
"50,KEY_PERIOD,AUDIO_VOL_UP",
"51,KEY_SLASH,KEY_SLASH",
"52,KEY_RIGHT_SHIFT,AUDIO_MUTE",
"53,KEY_UP,KEY_UP",
"54,KEY_FN,KEY_FN",
"55,KEY_FN,KEY_FN",
"56,KEY_LEFT,KEY_LEFT",
"57,KEY_DOWN,KEY_DOWN",
"58,KEY_RIGHT,KEY_RIGHT",
"59,KEY_CTRL,KEY_CTRL",
"60,KEY_FN,KEY_FN",
"61,KEY_ALT,KEY_ALT",
"62,KEY_SPACE,KEY_SPACE"
};
        }
    }
    class QMK68_ISO : IMatrix
    {
        public QMK68_ISO()
        {
            this.Name = "QMK68_ISO";
            iniLayout();
        }
        public const int keynum = 68;
        public void iniLayout()
        {
            RGB = null;
            keycode = new string[keynum * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            Defaultkeycode = new string[keynum];
            for (int i = 0; i < Defaultkeycode.Length; i++)
            {
                Defaultkeycode[i] = i.ToString();
            }
this.keycap = new double[keynum, 5] {
{0,0,1,1,0},// 0
{1,0,1,1,1},// 1
{2,0,1,1,2},// 2
{3,0,1,1,3},// 3
{4,0,1,1,4},// 4
{5,0,1,1,5},// 5
{6,0,1,1,6},// 6
{7,0,1,1,7},// 7
{8,0,1,1,8},// 8
{9,0,1,1,9},// 9
{10,0,1,1,10},// 10
{11,0,1,1,11},// 11
{12,0,1,1,12},// 12
{13,0,2,1,14},// 13
{15,0,1,1,15},// 14
{0,1,1.5,2,0},// 15
{1.5,1,1,2,1},// 16
{2.5,1,1,2,2},// 17
{3.5,1,1,2,3},// 18
{4.5,1,1,2,4},// 19
{5.5,1,1,2,5},// 20
{6.5,1,1,2,6},// 21
{7.5,1,1,2,7},// 22
{8.5,1,1,2,8},// 23
{9.5,1,1,2,9},// 24
{10.5,1,1,2,10},// 25
{11.5,1,1,2,11},// 26
{12.5,1,1,2,12},// 27
{13.5,1,1.5,2,14},// 28
{15,1,1,2,15},// 29
{0,2,1.75,3,0},// 30
{1.75,2,1,3,1},// 31
{2.75,2,1,3,2},// 32
{3.75,2,1,3,3},// 33
{4.75,2,1,3,4},// 34
{5.75,2,1,3,5},// 35
{6.75,2,1,3,6},// 36
{7.75,2,1,3,7},// 37
{8.75,2,1,3,8},// 38
{9.75,2,1,3,9},// 39
{10.75,2,1,3,10},// 40
{11.75,2,1,3,11},// 41
{12.75,2,2.25,3,14},// 42
{15,2,1,3,15},// 43
{0,3,2.25,4,0},// 44
{2.25,3,1,4,1},// 45
{3.25,3,1,4,2},// 46
{4.25,3,1,4,3},// 47
{5.25,3,1,4,4},// 48
{6.25,3,1,4,5},// 49
{7.25,3,1,4,6},// 50
{8.25,3,1,4,7},// 51
{9.25,3,1,4,8},// 52
{10.25,3,1,4,9},// 53
{11.25,3,1,4,10},// 54
{12.25,3,1.75,4,13},// 55
{14,3,1,4,14},// 56
{15,3,1,4,15},// 57
{0,4,1.25,0,0},// 58
{1.25,4,1.25,0,1},// 59
{2.5,4,1.25,0,2},// 60
{3.75,4,6.25,5,5},// 61
{10,4,1,5,9},// 62
{11,4,1,5,10},// 63
{12,4,1,5,11},// 64
{13,4,1,5,13},// 65
{14,4,1,5,14},// 66
{15,4,1,5,15}// 67
};
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
"13,KEY_BACKSPACE,KEY_BACKSPACE",
"14,KEY_DELETE,KEY_DELETE",
"15,KEY_TAB,KEY_TAB",
"16,KEY_Q,KEYPAD_1",
"17,KEY_W,KEYPAD_2",
"18,KEY_E,KEYPAD_3",
"19,KEY_R,KEYPAD_4",
"20,KEY_T,KEYPAD_5",
"21,KEY_Y,KEYPAD_6",
"22,KEY_U,KEYPAD_7",
"23,KEY_I,KEYPAD_8",
"24,KEY_O,KEYPAD_9",
"25,KEY_P,KEYPAD_0",
"26,KEY_LEFT_BRACE,KEYPAD_MINUS",
"27,KEY_RIGHT_BRACE,KEYPAD_PLUS",
"28,KEY_BACKSLASH,KEY_BACKSLASH",
"29,KEY_PAGE_UP,KEY_PAGE_UP",
"30,KEY_CAPS_LOCK,KEY_CAPS_LOCK",
"31,KEY_A,",
"32,KEY_S,",
"33,KEY_D,",
"34,KEY_F,",
"35,KEY_G,",
"36,KEY_H,",
"37,KEY_J,",
"38,KEY_K,",
"39,KEY_L,",
"40,KEY_SEMICOLON,",
"41,KEY_QUOTE,",
"42,KEY_ENTER,KEY_ENTER",
"43,KEY_PAGE_DOWN,KEY_PAGE_DOWN",
"44,KEY_LEFT_SHIFT,KEY_SHIFT",
"45,KEY_Z,KEY_NUM_LOCK",
"46,KEY_X,MACRO1",
"47,KEY_C,MACRO5",
"48,KEY_V,",
"49,KEY_B,",
"50,KEY_N,",
"51,KEY_M,",
"52,KEY_COMMA,AUDIO_VOL_DOWN",
"53,KEY_PERIOD,AUDIO_VOL_UP",
"54,KEY_SLASH,AUDIO_MUTE",
"55,KEY_RIGHT_SHIFT,KEY_RIGHT_SHIFT",
"56,KEY_UP,KEY_UP",
"57,KEY_END,KEY_END",
"58,KEY_CTRL,KEY_CTRL",
"59,KEY_GUI,KEY_GUI",
"60,KEY_ALT,KEY_ALT",
"61,KEY_SPACE,KEY_SPACE",
"62,KEY_RIGHT_ALT,KEY_RIGHT_ALT",
"63,KEY_FN,KEY_FN",
"64,KEY_RIGHT_CTRL,KEY_RIGHT_CTRL",
"65,KEY_LEFT,KEY_LEFT",
"66,KEY_DOWN,KEY_DOWN",
"67,KEY_RIGHT,KEY_RIGHT"
 };
        }
    }
    class QMK87_ISO : IMatrix
    {
        public QMK87_ISO()
        {
            this.Name = "QMK87_ISO";
            iniLayout();
        }
        public const int keynum = 87;
        public void iniLayout()
        {
            RGB = null;
            keycode = new string[keynum * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            Defaultkeycode = new string[keynum];
            for (int i = 0; i < Defaultkeycode.Length; i++)
            {
                Defaultkeycode[i] = i.ToString();
            }
            this.keycap = new double[keynum, 5] {
                {0,-1,1,5,0},// 0
{2,-1,1,5,2},// 1
{3,-1,1,5,3},// 2
{4,-1,1,5,4},// 3
{5,-1,1,5,5},// 4
{6.5,-1,1,6,0},// 5
{7.5,-1,1,6,10},// 6
{8.5,-1,1,7,10},// 7
{9.5,-1,1,7,0},// 8
{11,-1,1,5,11},// 9
{12,-1,1,5,12},// 10
{13,-1,1,5,13},// 11
{14,-1,1,5,14},// 12
{15,-1,1,0,13},// 13
{16,-1,1,7,6},// 14
{17,-1,1,7,9},// 15
{0,0,1,4,0},// 16
{1,0,1,4,1},// 17
{2,0,1,4,2},// 18
{3,0,1,4,3},// 19
{4,0,1,4,4},// 20
{5,0,1,4,5},// 21
{6,0,1,6,1},// 22
{7,0,1,6,11},// 23
{8,0,1,7,11},// 24
{9,0,1,7,1},// 25
{10,0,1,4,10},// 26
{11,0,1,4,11},// 27
{12,0,1,4,12},// 28
{13,0,2,4,14},// 29
{15,0,1,4,6},// 30
{16,0,1,4,7},// 31
{17,0,1,4,8},// 32
{0,1,1.5,3,0},// 33
{1.5,1,1,3,1},// 34
{2.5,1,1,3,2},// 35
{3.5,1,1,3,3},// 36
{4.5,1,1,3,4},// 37
{5.5,1,1,3,5},// 38
{6.5,1,1,6,2},// 39
{7.5,1,1,6,12},// 40
{8.5,1,1,7,12},// 41
{9.5,1,1,7,2},// 42
{10.5,1,1,3,10},// 43
{11.5,1,1,3,11},// 44
{12.5,1,1,3,12},// 45
{13.5,1,1.5,3,13},// 46
{15,1,1,3,6},// 47
{16,1,1,3,7},// 48
{17,1,1,3,8},// 49
{0,2,1.75,2,0},// 50
{1.75,2,1,2,1},// 51
{2.75,2,1,2,2},// 52
{3.75,2,1,2,3},// 53
{4.75,2,1,2,4},// 54
{5.75,2,1,2,5},// 55
{6.75,2,1,6,3},// 56
{7.75,2,1,6,13},// 57
{8.75,2,1,7,13},// 58
{9.75,2,1,7,3},// 59
{10.75,2,1,2,10},// 60
{11.75,2,1,2,11},// 61
{12.75,2,2.25,2,13},// 62
{0,3,2.25,1,0},// 63
{2.25,3,1,1,1},// 64
{3.25,3,1,1,2},// 65
{4.25,3,1,1,3},// 66
{5.25,3,1,1,4},// 67
{6.25,3,1,1,5},// 68
{7.25,3,1,6,4},// 69
{8.25,3,1,6,14},// 70
{9.25,3,1,7,14},// 71
{10.25,3,1,7,4},// 72
{11.25,3,1,1,10},// 73
{12.25,3,2.75,1,11},// 74
{16,3,1,1,7},// 75
{0,4,1.25,0,0},// 76
{1.25,4,1.25,0,1},// 77
{2.5,4,1.25,0,2},// 78
{3.75,4,6.25,6,5},// 79
{10,4,1.25,7,5},// 80
{11.25,4,1.25,0,11},// 81
{12.5,4,1.25,0,11},// 82
{13.75,4,1.25,6,6},// 83
{15,4,1,6,9},// 84
{16,4,1,0,6},// 85
{17,4,1,0,8}// 86
            };
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
"14,KEY_SCROLL_LOCK,",
"15,KEY_PAUSE,",
"16,KEY_TILDE,",
"17,KEY_1,",
"18,KEY_2,",
"19,KEY_3,",
"20,KEY_4,",
"21,KEY_5,",
"22,KEY_6,",
"23,KEY_7,",
"24,KEY_8,",
"25,KEY_9,",
"26,KEY_0,",
"27,KEY_MINUS,",
"28,KEY_EQUAL,",
"29,KEY_BACKSPACE,",
"30,KEY_INSERT,",
"31,KEY_HOME,",
"32,KEY_PAGE_UP,",
"33,KEY_TAB,",
"34,KEY_Q,",
"35,KEY_W,",
"36,KEY_E,",
"37,KEY_R,",
"38,KEY_T,",
"39,KEY_Y,",
"40,KEY_U,",
"41,KEY_I,",
"42,KEY_O,",
"43,KEY_P,",
"44,KEY_LEFT_BRACE,",
"45,KEY_RIGHT_BRACE,",
"46,KEY_BACKSLASH,",
"47,KEY_DELETE,",
"48,KEY_END,",
"49,KEY_PAGE_DOWN,",
"50,KEY_CAPS_LOCK,",
"51,KEY_A,",
"52,KEY_S,",
"53,KEY_D,",
"54,KEY_F,",
"55,KEY_G,",
"56,KEY_H,",
"57,KEY_J,",
"58,KEY_K,",
"59,KEY_L,",
"60,KEY_SEMICOLON,",
"61,KEY_QUOTE,",
"62,KEY_ENTER,",
"63,KEY_LEFT_SHIFT,",
"64,KEY_Z,",
"65,KEY_X,",
"66,KEY_C,",
"67,KEY_V,",
"68,KEY_B,",
"69,KEY_N,",
"70,KEY_M,",
"71,KEY_COMMA,",
"72,KEY_PERIOD,",
"73,KEY_SLASH,",
"74,KEY_RIGHT_SHIFT,",
"75,KEY_UP,",
"76,KEY_CTRL,",
"77,KEY_GUI,",
"78,KEY_ALT,",
"79,KEY_SPACE,",
"80,KEY_RIGHT_ALT,",
"81,KEY_RIGHT_GUI,",
"82,KEY_FN,",
"83,KEY_RIGHT_CTRL,",
"84,KEY_LEFT,",
"85,KEY_DOWN,",
"86,KEY_RIGHT,"
};
        }
    }
}
