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
        public  int ROWS = 5;
        public  int COLS = 14;
        public byte[] rowPins = { 5, 6, 7, 8, 23 };
        public byte[] colPins = { 21, 20, 24, 10, 9, 15, 22, 1, 4, 14, 13, 12, 11, 3 };
        public byte[,] hexaKeys0 = {
    {Program.KEY_ESC,Program.KEY_1,Program.KEY_2,Program.KEY_3,Program.KEY_4,Program.KEY_5,Program.KEY_6,Program.KEY_7,Program.KEY_8,Program.KEY_9,Program.KEY_0,Program.KEY_MINUS,Program.KEY_EQUAL,Program.KEY_BACKSPACE},
    {Program.KEY_TAB,Program.KEY_Q,Program.KEY_W,Program.KEY_E,Program.KEY_R,Program.KEY_T,Program.KEY_Y,Program.KEY_U,Program.KEY_I,Program.KEY_O,Program.KEY_P,Program.KEY_LEFT_BRACE,Program.KEY_RIGHT_BRACE,Program.KEY_BACKSLASH},
    {Program.KEY_CAPS_LOCK,Program.KEY_A,Program.KEY_S,Program.KEY_D,Program.KEY_F,Program.KEY_G,Program.KEY_H,Program.KEY_J,Program.KEY_K,Program.KEY_L,Program.KEY_SEMICOLON,Program.KEY_QUOTE,0x00,Program.KEY_ENTER},
    {Program.KEY_LEFT_SHIFT,0x00,Program.KEY_Z,Program.KEY_X,Program.KEY_C,Program.KEY_V,Program.KEY_B,Program.KEY_N,Program.KEY_M,Program.KEY_COMMA,Program.KEY_PERIOD,0x00, Program.KEY_SLASH,Program.KEY_UP},
    {Program.KEY_LEFT_CTRL,Program.KEY_FN,Program.KEY_LEFT_ALT,0x00,0x00,Program.KEY_SPACE,0x00,Program.KEY_SLASH,Program.KEY_LEFT,0x00,Program.KEY_FN,Program.KEY_RIGHT_CTRL,Program.KEY_DOWN, Program.KEY_RIGHT}};
         byte[,] hexaKeys1 = {
    {Program.KEY_TILDE,Program.KEY_F1,Program.KEY_F2,Program.KEY_F3,Program.KEY_F4,Program.KEY_F5,Program.KEY_F6,Program.KEY_F7,Program.KEY_F8,Program.KEY_F9,Program.KEY_F10,Program.KEY_F11,Program.KEY_F12, Program.KEY_DELETE},
    {Program.KEY_TAB,Program.KEYPAD_1,Program.KEYPAD_2,Program.KEYPAD_3,Program.KEYPAD_4,Program.KEYPAD_5,Program.KEYPAD_6,Program.KEYPAD_7,Program.KEYPAD_8,Program.KEYPAD_9,Program.KEYPAD_0,Program.KEYPAD_MINUS,Program.KEYPAD_PLUS,Program.KEY_BACKSLASH},
    {Program.KEY_CAPS_LOCK, Program.MOUSE_LEFT,Program.MOUSE_MID,Program.MOUSE_RIGHT,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,Program.KEY_ENTER},
    {Program.KEY_LEFT_SHIFT,0x00,Program.KEY_NUM_LOCK ,Program.KEY_SCROLL_LOCK,Program.KEY_INSERT,Program.KEY_PRINTSCREEN,0x00,0x00,0x00,Program.AUDIO_VOL_DOWN,Program.AUDIO_VOL_UP,0x00,0x00,Program.KEY_UP},
    {Program.KEY_LEFT_CTRL,Program.KEY_FN,Program.KEY_LEFT_ALT,0x00,0x00,Program.KEY_SPACE,0x00,0x00,Program.KEY_LEFT,0x00,Program.KEY_FN,Program.KEY_RIGHT_CTRL,Program.KEY_DOWN,Program.KEY_RIGHT}};
        //keymask_bits:7-press 654-hexatype0 3-press 210-hexatype1
        //type: 1-key 2-modifykey 3-mousekey 4-systemkey 5-consumerkey 6-FN 7-consumerkeyAL,8-consumerkeyAC
        public byte[,] keymask ={
    {0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11},
    {0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11},
    {0x11,0x13,0x13,0x13,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x00,0x11},
    {0x22,0x00,0x11,0x11,0x11,0x11,0x10,0x10,0x10,0x15,0x15,0x00,0x10,0x11},
    {0x22,0x66,0x22,0x00,0x00,0x11,0x00,0x10,0x11,0x00,0x66,0x22,0x11,0x11}};
        public int[,] posX = {
    { 0,90,180,270,360,450,540,630,720,810,900,990,1080,1170 },
    { 0,135,225,315,405,495,585,675,765,855,945,1035,1125,1215},
    {0,160,250,340,430,520,610,700,790,880,970,1060,0xFF,1150},
    {0,0xFF,205,295,385,475,565,655,745,835,925,1015,0xFF,1260},
    {0,115,230,0xFF,0xFF,345,0xFF,1170,900,0xFF,990,1080,1170,1260 }
     };
   
    }
}
