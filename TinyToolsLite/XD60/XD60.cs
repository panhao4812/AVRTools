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
        public byte[,] hexaKeys0 = {
    {Program.KEY_ESC,Program.KEY_1,Program.KEY_2,Program.KEY_3,Program.KEY_4,Program.KEY_5,Program.KEY_6,Program.KEY_7,Program.KEY_8,Program.KEY_9,Program.KEY_0,Program.KEY_MINUS,Program.KEY_EQUAL,Program.KEY_BACKSPACE},
    {Program.KEY_TAB,Program.KEY_Q,Program.KEY_W,Program.KEY_E,Program.KEY_R,Program.KEY_T,Program.KEY_Y,Program.KEY_U,Program.KEY_I,Program.KEY_O,Program.KEY_P,Program.KEY_LEFT_BRACE,Program.KEY_RIGHT_BRACE,Program.KEY_BACKSLASH},
    {Program.KEY_CAPS_LOCK,Program.KEY_A,Program.KEY_S,Program.KEY_D,Program.KEY_F,Program.KEY_G,Program.KEY_H,Program.KEY_J,Program.KEY_K,Program.KEY_L,Program.KEY_SEMICOLON,Program.KEY_QUOTE,0x00,Program.KEY_ENTER},
    {Program.KEY_LEFT_SHIFT,0x00,Program.KEY_Z,Program.KEY_X,Program.KEY_C,Program.KEY_V,Program.KEY_B,Program.KEY_N,Program.KEY_M,Program.KEY_COMMA,Program.KEY_PERIOD,0x00, Program.KEY_SLASH,Program.KEY_UP},
    {Program.KEY_LEFT_CTRL,Program.KEY_FN,Program.KEY_LEFT_ALT,0x00,0x00,Program.KEY_SPACE,0x00,Program.KEY_SLASH,Program.KEY_LEFT,0x00,Program.KEY_FN,Program.KEY_RIGHT_CTRL,Program.KEY_DOWN, Program.KEY_RIGHT}};
        public byte[,] hexaKeys1 = {
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
           { 0,4,8,12,16,20,24,28,32,36,40,44,48,52},
           { 0,6,10,14,18,22,26,30,34,38,42,46,50,54},
           { 0,7,11,15,19,23,27,31,35,39,43,47,0xFF,51},
           { 0,0xFF,9,13,17,21,25,29,33,37,41,0xFF,45,52},
           { 0,5,10,0xFF,0xFF,15,0xFF,56,40,0xFF,44,48,52,56}
 };
        public int[,] posY = {
           { 0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           { 1,1,1,1,1,1,1,1,1,1,1,1,1,1},
          { 2,2,2,2,2,2,2,2,2,2,2,2,2,2},
          { 3,3,3,3,3,3,3,3,3,3,3,3,3,3},
          { 4,4,4,4,4,4,4,3,4,4,4,4,4,4},
 };
        public int[,] lengthX = {
           {4,4,4,4,4,4,4,4,4,4,4,4,4,8},
           {6,4,4,4,4,4,4,4,4,4,4,4,4,6},
           {7,4,4,4,4,4,4,4,4,4,4,4,0xFF,9},
           { 9,0xFF,4,4,4,4,4,4,4,4,4,0xFF,7,4},
           { 5,5,5,0xFF,0xFF,25,0xFF,4,4,0xFF,4,4,4,4}
};


    }
}
