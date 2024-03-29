﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVRKeys.Keyboard
{
    public partial class QMK68_ISO
    {
        #region kecap
        string[] keycap = new string[68]{
"0,0,1,1,0,MACRO2,KEY_TILDE",
"1,0,1,1,1,KEY_1,KEY_F1",
"2,0,1,1,2,KEY_2,KEY_F2",
"3,0,1,1,3,KEY_3,KEY_F3",
"4,0,1,1,4,KEY_4,KEY_F4",
"5,0,1,1,5,KEY_5,KEY_F5",
"6,0,1,1,6,KEY_6,KEY_F6",
"7,0,1,1,7,KEY_7,KEY_F7",
"8,0,1,1,8,KEY_8,KEY_F8",
"9,0,1,1,9,KEY_9,KEY_F9",
"10,0,1,1,10,KEY_0,KEY_F10",
"11,0,1,1,11,KEY_MINUS,KEY_F11",
"12,0,1,1,12,KEY_EQUAL,KEY_F12",
"13,0,2,1,14,KEY_BACKSPACE,KEY_BACKSPACE",
"15,0,1,1,15,KEY_DELETE,KEY_DELETE",
"0,1,1.5,2,0,KEY_TAB,KEY_TAB",
"1.5,1,1,2,1,KEY_Q,KEYPAD_1",
"2.5,1,1,2,2,KEY_W,KEYPAD_2",
"3.5,1,1,2,3,KEY_E,KEYPAD_3",
"4.5,1,1,2,4,KEY_R,KEYPAD_4",
"5.5,1,1,2,5,KEY_T,KEYPAD_5",
"6.5,1,1,2,6,KEY_Y,KEYPAD_6",
"7.5,1,1,2,7,KEY_U,KEYPAD_7",
"8.5,1,1,2,8,KEY_I,KEYPAD_8",
"9.5,1,1,2,9,KEY_O,KEYPAD_9",
"10.5,1,1,2,10,KEY_P,KEYPAD_0",
"11.5,1,1,2,11,KEY_LEFT_BRACE,KEYPAD_MINUS",
"12.5,1,1,2,12,KEY_RIGHT_BRACE,KEYPAD_PLUS",
"13.5,1,1.5,2,14,KEY_BACKSLASH,KEY_PRINTSCREEN",
"15,1,1,2,15,KEY_PAGE_UP,KEY_HOME",
"0,2,1.75,3,0,KEY_CAPS_LOCK,KEY_CAPS_LOCK",
"1.75,2,1,3,1,KEY_A,",
"2.75,2,1,3,2,KEY_S,",
"3.75,2,1,3,3,KEY_D,",
"4.75,2,1,3,4,KEY_F,",
"5.75,2,1,3,5,KEY_G,",
"6.75,2,1,3,6,KEY_H,",
"7.75,2,1,3,7,KEY_J,",
"8.75,2,1,3,8,KEY_K,",
"9.75,2,1,3,9,KEY_L,",
"10.75,2,1,3,10,KEY_SEMICOLON,",
"11.75,2,1,3,11,KEY_QUOTE,",
"12.75,2,2.25,3,14,KEY_ENTER,KEY_ENTER",
"15,2,1,3,15,KEY_PAGE_DOWN,KEY_PAUSE",
"0,3,2.25,4,0,KEY_SHIFT,KEY_SHIFT",
"2.25,3,1,4,1,KEY_Z,KEY_NUM_LOCK",
"3.25,3,1,4,2,KEY_X,MACRO1",
"4.25,3,1,4,3,KEY_C,MACRO5",
"5.25,3,1,4,4,KEY_V,",
"6.25,3,1,4,5,KEY_B,",
"7.25,3,1,4,6,KEY_N,",
"8.25,3,1,4,7,KEY_M,",
"9.25,3,1,4,8,KEY_COMMA,AUDIO_VOL_DOWN",
"10.25,3,1,4,9,KEY_PERIOD,AUDIO_VOL_UP",
"11.25,3,1,4,10,KEY_SLASH,AUDIO_MUTE",
"12.25,3,1.75,4,13,KEY_RIGHT_SHIFT,KEY_RIGHT_SHIFT",
"14,3,1,4,14,KEY_UP,KEY_UP",
"15,3,1,4,15,KEY_END,KEY_INSERT",
"0,4,1.25,0,0,KEY_CTRL,KEY_CTRL",
"1.25,4,1.25,0,1,KEY_GUI,KEY_GUI",
"2.5,4,1.25,0,2,KEY_ALT,KEY_ALT",
"3.75,4,6.25,5,5,KEY_SPACE,KEY_SPACE",
"10,4,1,5,9,KEY_RIGHT_ALT,KEY_RIGHT_ALT",
"11,4,1,5,10,KEY_FN,KEY_FN",
"12,4,1,5,11,KEY_RIGHT_CTRL,KEY_RIGHT_CTRL",
"13,4,1,5,13,KEY_LEFT,KEY_LEFT",
"14,4,1,5,14,KEY_DOWN,KEY_DOWN",
"15,4,1,5,15,KEY_RIGHT,KEY_RIGHT"
            };
        #endregion
    }
}
