using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyToolsLite
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GH60_Tools());
        }
        public static byte KEY_CTRL = 0x01;
        public static byte KEY_SHIFT = 0x02;
        public static byte KEY_ALT = 0x04;
        public static byte KEY_GUI = 0x08;
        public static byte KEY_LEFT_CTRL = 0x01;
        public static byte KEY_LEFT_SHIFT = 0x02;
        public static byte KEY_LEFT_ALT = 0x04;
        public static byte KEY_LEFT_GUI = 0x08;
        public static byte KEY_RIGHT_CTRL = 0x10;
        public static byte KEY_RIGHT_SHIFT = 0x20;
        public static byte KEY_RIGHT_ALT = 0x40;
        public static byte KEY_RIGHT_GUI = 0x80;

        public static byte KEY_A = 4;
        public static byte KEY_B = 5;
        public static byte KEY_C = 6;
        public static byte KEY_D = 7;
        public static byte KEY_E = 8;
        public static byte KEY_F = 9;
        public static byte KEY_G = 10;
        public static byte KEY_H = 11;
        public static byte KEY_I = 12;
        public static byte KEY_J = 13;
        public static byte KEY_K = 14;
        public static byte KEY_L = 15;
        public static byte KEY_M = 16;
        public static byte KEY_N = 17;
        public static byte KEY_O = 18;
        public static byte KEY_P = 19;
        public static byte KEY_Q = 20;
        public static byte KEY_R = 21;
        public static byte KEY_S = 22;
        public static byte KEY_T = 23;
        public static byte KEY_U = 24;
        public static byte KEY_V = 25;
        public static byte KEY_W = 26;
        public static byte KEY_X = 27;
        public static byte KEY_Y = 28;
        public static byte KEY_Z = 29;
        public static byte KEY_1 = 30;
        public static byte KEY_2 = 31;
        public static byte KEY_3 = 32;
        public static byte KEY_4 = 33;
        public static byte KEY_5 = 34;
        public static byte KEY_6 = 35;
        public static byte KEY_7 = 36;
        public static byte KEY_8 = 37;
        public static byte KEY_9 = 38;
        public static byte KEY_0 = 39;
        public static byte KEY_ENTER = 40;
        public static byte KEY_ESC = 41;
        public static byte KEY_BACKSPACE = 42;
        public static byte KEY_TAB = 43;
        public static byte KEY_SPACE = 44;
        public static byte KEY_MINUS = 45;
        public static byte KEY_EQUAL = 46;
        public static byte KEY_LEFT_BRACE = 47;
        public static byte KEY_RIGHT_BRACE = 48;
        public static byte KEY_BACKSLASH = 49;
        public static byte KEY_NUMBER = 50;
        public static byte KEY_SEMICOLON = 51;
        public static byte KEY_QUOTE = 52;
        public static byte KEY_TILDE = 53;
        public static byte KEY_COMMA = 54;
        public static byte KEY_PERIOD = 55;
        public static byte KEY_SLASH = 56;
        public static byte KEY_CAPS_LOCK = 57;
        public static byte KEY_F1 = 58;
        public static byte KEY_F2 = 59;
        public static byte KEY_F3 = 60;
        public static byte KEY_F4 = 61;
        public static byte KEY_F5 = 62;
        public static byte KEY_F6 = 63;
        public static byte KEY_F7 = 64;
        public static byte KEY_F8 = 65;
        public static byte KEY_F9 = 66;
        public static byte KEY_F10 = 67;
        public static byte KEY_F11 = 68;
        public static byte KEY_F12 = 69;
        public static byte KEY_PRINTSCREEN = 70;
        public static byte KEY_SCROLL_LOCK = 71;
        public static byte KEY_PAUSE = 72;
        public static byte KEY_INSERT = 73;
        public static byte KEY_HOME = 74;
        public static byte KEY_PAGE_UP = 75;
        public static byte KEY_DELETE = 76;
        public static byte KEY_END = 77;
        public static byte KEY_PAGE_DOWN = 78;
        public static byte KEY_RIGHT = 79;
        public static byte KEY_LEFT = 80;
        public static byte KEY_DOWN = 81;
        public static byte KEY_UP = 82;
        public static byte KEY_NUM_LOCK = 83;
        public static byte KEYPAD_SLASH = 84;
        public static byte KEYPAD_ASTERIX = 85;
        public static byte KEYPAD_MINUS = 86;
        public static byte KEYPAD_PLUS = 87;
        public static byte KEYPAD_ENTER = 88;
        public static byte KEYPAD_1 = 89;
        public static byte KEYPAD_2 = 90;
        public static byte KEYPAD_3 = 91;
        public static byte KEYPAD_4 = 92;
        public static byte KEYPAD_5 = 93;
        public static byte KEYPAD_6 = 94;
        public static byte KEYPAD_7 = 95;
        public static byte KEYPAD_8 = 96;
        public static byte KEYPAD_9 = 97;
        public static byte KEYPAD_0 = 98;
        public static byte KEYPAD_PERIOD = 99;  //.

        public static byte MOUSE_LEFT = 0x01;
        public static byte MOUSE_RIGHT = 0x02;
        public static byte MOUSE_MID = 0x04;
        public static byte MOUSE_4 = 0x08;
        public static byte MOUSE_5 = 0x10;

        public static byte KEY_FN = 0;
        public static byte REPORT_ID_MOUSE = 1;
        public static byte REPORT_ID_SYSTEM = 2;
        public static byte REPORT_ID_CONSUMER = 3;

        public static byte AUDIO_MUTE = 0xE2;
        public static byte AUDIO_VOL_UP = 0xE9;
        public static byte AUDIO_VOL_DOWN = 0xEA;
        public static byte TRANSPORT_NEXT_TRACK = 0xB5;
        public static byte TRANSPORT_PREV_TRACK = 0xB6;
        public static byte TRANSPORT_STOP = 0xB7;
        public static byte TRANSPORT_STOP_EJECT = 0xCC;
        public static byte TRANSPORT_PLAY_PAUSE = 0xCD;
        /* Generic Desktop Page(0x01) - system power control */
        public static byte SYSTEM_POWER_DOWN = 0x81;
        public static byte SYSTEM_SLEEP = 0x82;
        public static byte SYSTEM_WAKE_UP = 0x83;
        public static int[] ascii_to_scan_code_table = {
	// /* ASCII:   0 */
	0,
	// /* ASCII:   1 */
	0,
	// /* ASCII:   2 */
	0,
	// /* ASCII:   3 */
	0,
	// /* ASCII:   4 */
	0,
	// /* ASCII:   5 */
	0,
	// /* ASCII:   6 */
	0,
	// /* ASCII:   7 */
	0,
	/* ASCII:   8 */ 42,
	/* ASCII:   9 */ 43,
	/* ASCII:  10 */ 40,
	/* ASCII:  11 */ 0,
	/* ASCII:  12 */ 0,
	/* ASCII:  13 */ 0,
	/* ASCII:  14 */ 0,
	/* ASCII:  15 */ 0,
	/* ASCII:  16 */ 0,
	/* ASCII:  17 */ 0,
	/* ASCII:  18 */ 0,
	/* ASCII:  19 */ 0,
	/* ASCII:  20 */ 0,
	/* ASCII:  21 */ 0,
	/* ASCII:  22 */ 0,
	/* ASCII:  23 */ 0,
	/* ASCII:  24 */ 0,
	/* ASCII:  25 */ 0,
	/* ASCII:  26 */ 0,
	/* ASCII:  27 */ 41,
	/* ASCII:  28 */ 0,
	/* ASCII:  29 */ 0,
	/* ASCII:  30 */ 0,
	/* ASCII:  31 */ 0,
	/* ASCII:  32 */ 44,
	/* ASCII:  33 */ 158,
	/* ASCII:  34 */ 180,
	/* ASCII:  35 */ 160,
	/* ASCII:  36 */ 161,
	/* ASCII:  37 */ 162,
	/* ASCII:  38 */ 164,
	/* ASCII:  39 */ 52,
	/* ASCII:  40 */ 166,
	/* ASCII:  41 */ 167,
	/* ASCII:  42 */ 165,
	/* ASCII:  43 */ 174,
	/* ASCII:  44 */ 54,
	/* ASCII:  45 */ 45,
	/* ASCII:  46 */ 55,
	/* ASCII: / 47 */ 56,
	/* ASCII:  48 */ 39,
	/* ASCII:  49 */ 30,
	/* ASCII:  50 */ 31,
	/* ASCII:  51 */ 32,
	/* ASCII:  52 */ 33,
	/* ASCII:  53 */ 34,
	/* ASCII:  54 */ 35,
	/* ASCII:  55 */ 36,
	/* ASCII:  56 */ 37,
	/* ASCII:  57 */ 38,
	/* ASCII:  58 */ 179,
	/* ASCII:  59 */ 51,
	/* ASCII:  60 */ 182,
	/* ASCII:  61 */ 46,
	/* ASCII:  62 */ 183,
	/* ASCII:  ?63 */ 184,
	/* ASCII:  64 */ 159,
	/* ASCII: A 65 */ 132,
	/* ASCII:  66 */ 133,
	/* ASCII:  67 */ 134,
	/* ASCII:  68 */ 135,
	/* ASCII:  69 */ 136,
	/* ASCII:  70 */ 137,
	/* ASCII:  71 */ 138,
	/* ASCII:  72 */ 139,
	/* ASCII:  73 */ 140,
	/* ASCII:  74 */ 141,
	/* ASCII:  75 */ 142,
	/* ASCII:  76 */ 143,
	/* ASCII:  77 */ 144,
	/* ASCII:  78 */ 145,
	/* ASCII:  79 */ 146,
	/* ASCII:  80 */ 147,
	/* ASCII:  81 */ 148,
	/* ASCII:  82 */ 149,
	/* ASCII:  83 */ 150,
	/* ASCII:  84 */ 151,
	/* ASCII:  85 */ 152,
	/* ASCII:  86 */ 153,
	/* ASCII:  87 */ 154,
	/* ASCII:  88 */ 155,
	/* ASCII:  89 */ 156,
	/* ASCII: Z 90 */ 157,
	/* ASCII:  91 */ 47,
	/* ASCII:  92 */ 49,
	/* ASCII:  93 */ 48,
	/* ASCII:  94 */ 163,
	/* ASCII:  95 */ 173,
	/* ASCII:  96 */ 53,
	/* ASCII: a 97 */ 4,
	/* ASCII:  98 */ 5,
	/* ASCII:  99 */ 6,
	/* ASCII: 100 */ 7,
	/* ASCII: 101 */ 8,
	/* ASCII: 102 */ 9,
	/* ASCII: 103 */ 10,
	/* ASCII: 104 */ 11,
	/* ASCII: 105 */ 12,
	/* ASCII: 106 */ 13,
	/* ASCII: 107 */ 14,
	/* ASCII: 108 */ 15,
	/* ASCII: 109 */ 16,
	/* ASCII: 110 */ 17,
	/* ASCII: 111 */ 18,
	/* ASCII: 112 */ 19,
	/* ASCII: 113 */ 20,
	/* ASCII: 114 */ 21,
	/* ASCII: 115 */ 22,
	/* ASCII: 116 */ 23,
	/* ASCII: 117 */ 24,
	/* ASCII: 118 */ 25,
	/* ASCII: 119 */ 26,
	/* ASCII: 120 */ 27,
	/* ASCII: 121 */ 28,
	/* ASCII: 122 */ 29,
	/* ASCII: 123 */ 175,
	/* ASCII: 124 */ 177,
	/* ASCII: 125 */ 176,
	/* ASCII: 126 */ 181 };
    }
}
