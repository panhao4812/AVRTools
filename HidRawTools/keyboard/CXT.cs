using System;
using System.Collections.Generic;
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
"43,KEY_X,MACRO0",
"44,KEY_C,MACRO1",
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
"59,KEY_FN,KEY_FN",
"60,KEY_FN,KEY_FN",
"61,KEY_LEFT,",
"62,KEY_DOWN,",
"63,KEY_RIGHT," };
RGB=new int[64,6]{
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
{89,355,1,255,255,255},

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
{89,355,1,255,255,255},

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
{89,355,1,255,255,255},

{389,355,1,255,255,255},
{289,355,1,255,255,255},
{189,355,1,255,255,255},
{89,355,1,255,255,255}
            };
            IhexaKeys0 = new byte[,]{
      {IKeycode.KEY_TILDE,IKeycode.KEY_1,IKeycode.KEY_2,IKeycode.KEY_3,IKeycode.KEY_4,IKeycode.KEY_5,IKeycode.KEY_6,IKeycode.KEY_7,IKeycode.KEY_8,IKeycode.KEY_9,IKeycode.KEY_0,IKeycode.KEY_MINUS,IKeycode.KEY_EQUAL,0x00,IKeycode.KEY_BACKSPACE},
    {IKeycode.KEY_TAB,0x00,IKeycode.KEY_Q,IKeycode.KEY_W,IKeycode.KEY_E,IKeycode.KEY_R,IKeycode.KEY_T,IKeycode.KEY_Y,IKeycode.KEY_U,IKeycode.KEY_I,IKeycode.KEY_O,IKeycode.KEY_P,IKeycode.KEY_LEFT_BRACE,IKeycode.KEY_RIGHT_BRACE,IKeycode.KEY_BACKSLASH},
    {IKeycode.KEY_CAPS_LOCK,0x00,IKeycode.KEY_A,IKeycode.KEY_S,IKeycode.KEY_D,IKeycode.KEY_F,IKeycode.KEY_G,IKeycode.KEY_H,IKeycode.KEY_J,IKeycode.KEY_K,IKeycode.KEY_L,IKeycode.KEY_SEMICOLON,IKeycode.KEY_QUOTE,IKeycode.KEY_ENTER,0x00},
    {0x00,IKeycode.KEY_LEFT_SHIFT,IKeycode.KEY_Z,IKeycode.KEY_X,IKeycode.KEY_C,IKeycode.KEY_V,IKeycode.KEY_B,IKeycode.KEY_N,IKeycode.KEY_M,IKeycode.KEY_COMMA,IKeycode.KEY_PERIOD,IKeycode.KEY_SLASH,IKeycode.KEY_RIGHT_SHIFT,IKeycode.KEY_UP,IKeycode.KEY_RIGHT_CTRL},
    {IKeycode.KEY_LEFT_CTRL,IKeycode.KEY_FN,0x00,IKeycode.KEY_LEFT_ALT,0x00,0x00,IKeycode.KEY_SPACE,0x00,0x00,0x00,IKeycode.KEY_FN,IKeycode.KEY_FN,IKeycode.KEY_LEFT,IKeycode.KEY_DOWN,IKeycode.KEY_RIGHT}
};
            Ikeymask = new byte[,]  {
    {0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x00,0x11},
    {0x10,0x00,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10},
    {0x10,0x00,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x00},
    {0x00,0x22,0x11,0x17,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x22,0x11,0x22},
    {0x22,0x66,0x00,0x22,0x00,0x00,0x11,0x00,0x00,0x00,0x66,0x66,0x11,0x11,0x11}
};
            IUpdateMatrix();
        }
    }
}
