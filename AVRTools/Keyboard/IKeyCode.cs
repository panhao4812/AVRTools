using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVRKeys.Keyboard
{
   

    public static class IKeycode
    {
        public static int KeyName2BIOS(string keyName)
        {
            switch (keyName)
            {
                case "Ctrl": return 0x1d;
                case "Shift": return 0x2a;
                case "Alt": return 0x38;
                case "Gui": return 0x015b;
                case "lCtrl": return 0x1d;
                case "lShift": return 0x2a;
                case "lAlt": return 0x38;
                case "lGui": return 0x015b;
                case "rCtrl": return 0x011d;
                case "rShift": return 0x36;
                case "rAlt": return 0x0138;
                case "rGui": return 0x015b;
                case "A": return 0x1e;
                case "B": return 0x30;
                case "C": return 0x2e;
                case "D": return 0x20;
                case "E": return 0x12;
                case "F": return 0x21;
                case "G": return 0x22;
                case "H": return 0x23;
                case "I": return 0x17;
                case "J": return 0x24;
                case "K": return 0x25;
                case "L": return 0x26;
                case "M": return 0x32;
                case "N": return 0x31;
                case "O": return 0x18;
                case "P": return 0x19;
                case "Q": return 0x10;
                case "R": return 0x13;
                case "S": return 0x1f;
                case "T": return 0x14;
                case "U": return 0x16;
                case "V": return 0x2f;
                case "W": return 0x11;
                case "X": return 0x2d;
                case "Y": return 0x15;
                case "Z": return 0x2c;
                case "1": return 0x02;
                case "2": return 0x03;
                case "3": return 0x04;
                case "4": return 0x05;
                case "5": return 0x06;
                case "6": return 0x07;
                case "7": return 0x08;
                case "8": return 0x09;
                case "9": return 0x0a;
                case "0": return 0x0b;
                case "Enter": return 0x1c;
                case "Esc": return 0x01;
                case "<--": return 0x0e;
                case "Tab": return 0x0f;
                case "Space": return 0x39;
                case "_-": return 0x0c;
                case "+=": return 0x0d;
                case "{[": return 0x1a;
                case "]}": return 0x1b;
                case "|": return 0x2b;
                //    case "Number" : return  ;//US键盘没这个按键
                case ":;": return 0x27;
                case "“'": return 0x28;
                case "~": return 0x29;
                case "<,": return 0x33;
                case ".>": return 0x34;
                case "?/": return 0x35;
                case "CapsLK": return 0X3a;
                case "F1": return 0x3b;
                case "F2": return 0x3c;
                case "F3": return 0x3d;
                case "F4": return 0x3e;
                case "F5": return 0x3f;
                case "F6": return 0x40;
                case "F7": return 0x41;
                case "F8": return 0x42;
                case "F9": return 0x43;
                case "F10": return 0x44;
                case "F11": return 0x57;
                case "F12": return 0x58;
                case "PrtSc": return 0x0137;
                case "ScrLk": return 0x46;
                case "Pause": return 0x45;
                case "Insert": return 0x0152;
                case "Home": return 0x0147;
                case "PgUp": return 0x0149;
                case "Delete": return 0x0153;
                case "End": return 0x014f;
                case "PgDn": return 0x0151;
                case "→": return 0x014d;
                case "←": return 0x014b;
                case "↓": return 0x0150;
                case "↑": return 0x0148;
                case "NumLK": return 0x0145;
                case "p/": return 0x0135;
                case "p*": return 0x37;
                case "p-": return 0x4a;
                case "p+": return 0x4e;
                case "pENTER": return 0x011c;
                case "p1": return 0x4f;
                case "p2": return 0x50;
                case "p3": return 0x51;
                case "p4": return 0x4b;
                case "p5": return 0x4c;
                case "p6": return 0x4d;
                case "p7": return 0x47;
                case "p8": return 0x48;
                case "p9": return 0x49;
                case "p0": return 0x52;
                case "p.": return 0x53;  //.
            }
            return -1;

        }
        public static int KeyName2WIN(string keyName)
        {
            switch (keyName)
            {
                case "Ctrl": return 17;
                case "Shift": return 16;
                case "Alt": return 18;
                case "Gui": return 91;
                case "lCtrl": return 17;
                case "lShift": return 16;
                case "lAlt": return 18;
                case "lGui": return 91;
                case "rCtrl": return 163;
                case "rShift": return 161;
                case "rAlt": return 165;
                case "rGui": return 92;
                case "A": return 65;//0x41
                case "B": return 66;
                case "C": return 67;
                case "D": return 68;
                case "E": return 69;
                case "F": return 70;
                case "G": return 71;
                case "H": return 72;
                case "I": return 73;
                case "J": return 74;
                case "K": return 75;
                case "L": return 76;
                case "M": return 77;
                case "N": return 78;
                case "O": return 79;
                case "P": return 80;
                case "Q": return 81;
                case "R": return 82;
                case "S": return 83;
                case "T": return 84;
                case "U": return 85;
                case "V": return 86;
                case "W": return 87;
                case "X": return 88;
                case "Y": return 89;
                case "Z": return 90;
                case "1": return 49;
                case "2": return 50;
                case "3": return 51;
                case "4": return 52;
                case "5": return 53;
                case "6": return 54;
                case "7": return 55;
                case "8": return 56;
                case "9": return 57;
                case "0": return 48;
                case "Enter": return 13;
                case "Esc": return 27;
                case "<--": return 8;
                case "Tab": return 9;
                case "Space": return 32;
                case "_-": return 189;
                case "+=": return 187;
                case "{[": return 219;
                case "]}": return 221;
                case "|": return 220;
                //    case "Number" : return  ;//US键盘没这个按键
                case ":;": return 186;
                case "“'": return 222;
                case "~": return 192;
                case "<,": return 188;
                case ".>": return 190;
                case "?/": return 191;
                case "CapsLK": return 20;
                case "F1": return 112;
                case "F2": return 113;
                case "F3": return 114;
                case "F4": return 115;
                case "F5": return 116;
                case "F6": return 117;
                case "F7": return 118;
                case "F8": return 119;
                case "F9": return 120;
                case "F10": return 121;
                case "F11": return 122;
                case "F12": return 123;
                case "PrtSc": return 44;
                case "ScrLk": return 145;
                case "Pause": return 19;
                case "Insert": return 45;
                case "Home": return 36;
                case "PgUp": return 33;
                case "Delete": return 46;
                case "End": return 35;
                case "PgDn": return 34;
                case "→": return 39;
                case "←": return 37;
                case "↓": return 40;
                case "↑": return 38;
                case "NumLK": return 144;
                case "p/": return 111;
                case "p*": return 106;
                case "p-": return 109;
                case "p+": return 107;
                case "pENTER": return 13;
                case "p1": return 97;
                case "p2": return 98;
                case "p3": return 99;
                case "p4": return 100;
                case "p5": return 101;
                case "p6": return 102;
                case "p7": return 103;
                case "p8": return 104;
                case "p9": return 105;
                case "p0": return 96;
                case "p.": return 110;  //.
            }
            return -1;
        }
        public static int ASCII2scan(int ASCII)
        {
            //缺小键盘Enter键
            if (ASCII >= 65 && ASCII <= 90)
            {
                //a--z
                return ASCII - (65 - 0x04);
            }
            else if (ASCII == 48) return 0x27;//0
            else if (ASCII >= 49 && ASCII <= 57)
            {
                //1---9
                return ASCII - (49 - 0x1E);
            }
            else if (ASCII >= 112 && ASCII <= 123)
            {
                //F1---F12 58 69
                return ASCII - (112 - 0x3A);
            }
            else if (ASCII == 96) return 0x62;//0
            else if (ASCII >= 97 && ASCII <= 105)
            {
                //pad1---pad9 0x59 0x61
                return ASCII - (97 - 0x59);
            }
            else if (ASCII == 13) return 0x28;//0// ENTER
            else if (ASCII == 27) return 0x29;//0// ESC
            else if (ASCII == 8) return 0x2A;//0 // BACKSPACE
            else if (ASCII == 9) return 0x2B;//0 // TAB
            else if (ASCII == 32) return 0x2C;//0 // SPACE
            else if (ASCII == 189) return 0x2D;// KEY_SUB 0x2D           // - and _
            else if (ASCII == 187) return 0x2E;// KEY_EQUAL 0x2E         // = and +
            else if (ASCII == 219) return 0x2F;// KEY_LEFT_BRACKET 0x2F  // [ and {
            else if (ASCII == 221) return 0x30;// KEY_RIGHT_BRACKET 0x30 // ] and }
            else if (ASCII == 220) return 0x31;// KEY_VERTICAL_LINE 0x31 // "\" and |
            else if (ASCII == 186) return 0x33;// KEY_SEMICOLON 0x33     // ; and :
            else if (ASCII == 222) return 0x34;// KEY_QUOTE 0x34         // ' and "
            else if (ASCII == 192) return 0x35;// KEY_THROW 0x35         // ~ and `
            else if (ASCII == 188) return 0x36;// KEY_COMMA 0x36         // , and <
            else if (ASCII == 190) return 0x37;// KEY_DOT 0x37           // . and >
            else if (ASCII == 191) return 0x38;// KEY_QUESTION 0x38     //?
            else if (ASCII == 20) return 0x39;//0//CAPS
            else if (ASCII == 44) return 0x46;//KEY_PRT_SCR 0x46
            else if (ASCII == 145) return 0x47; //KEY_SCOLL_LOCK 0x47
            else if (ASCII == 19) return 0x48; //KEY_PAUSE 0x48
            else if (ASCII == 45) return 0x49; //KEY_INS 0x49
            else if (ASCII == 36) return 0x4A; //KEY_HOME 0x4A
            else if (ASCII == 33) return 0x4B;//KEY_PAGEUP 0x4B
            else if (ASCII == 46) return 0x4C;//KEY_DEL 0x4C
            else if (ASCII == 35) return 0x4D;//KEY_END 0x4D
            else if (ASCII == 34) return 0x4E;//KEY_PAGEDOWN 0x4E
            else if (ASCII == 39) return 0x4F;//KEY_RIGHT_ARROW 0x4F
            else if (ASCII == 37) return 0x50;//KEY_LEFT_ARROW 0x50
            else if (ASCII == 40) return 0x51;//KEY_DOWN_ARROW 0x51
            else if (ASCII == 38) return 82;//KEY_up_ARROW 0x51
            else if (ASCII == 144) return 0x53;// KEY_PAD_NUMLOCK 0x53
            else if (ASCII == 111) return 0x54;// KEY_PAD_DIV 0x54
            else if (ASCII == 106) return 0x55;// KEY_PAD_MUL 0x55
            else if (ASCII == 109) return 0x56;// KEY_PAD_SUB 0x56
            else if (ASCII == 107) return 0x57;// KEY_PAD_ADD 0x57
            else if (ASCII == 110) return 0x63;// KEY_PAD_DOT 0x63   
            else if (ASCII == 17) return 0x01;// KEY_LCTRL 0x01  
            else if (ASCII == 18) return 0x02;// KEY_LALT 0xE2   
            else if (ASCII == 16) return 0x04;// KEY_LSHFIT 0xE1 
            else if (ASCII == 91) return 0x08;// KEY_LWIN 0xE3   
            else if (ASCII == 92) return 0x10;// KEY_RWIN 0xE7   
            else if (ASCII == 161) return 0x20;// KEY_RSHIFT 0xE5 
            else if (ASCII == 165) return 0x40;// KEY_RALT 0xE6   
            else if (ASCII == 163) return 0x80;// KEY_RCTRL 0xE4 
                                               //else if (ASCII ==0 ) return 0x58;// KEY_PAD_ENTER 0x58
            else return -100;
        }
        public static string Arabit2Roman(int arabic)
        {
            string[] alpha = { "I", "V", "X", "L", "C", "D", "M" };
            string roman = "";
            int bit = 0;
            while (arabic > 0)
            {
                int tempnum = arabic % 10;
                switch (tempnum)
                {
                    case 3:
                        {
                            roman = alpha[bit] + roman;
                            tempnum--;
                            break;
                        }
                    case 2:
                        {
                            roman = alpha[bit] + roman;
                            tempnum--;
                            break;
                        }
                    case 1:
                        {
                            roman = alpha[bit] + roman;
                            break;
                        }
                    case 4:
                        {
                            roman = alpha[bit + 1] + roman;
                            roman = alpha[bit] + roman;
                            break;
                        }
                    case 8:
                        {
                            roman = alpha[bit] + roman;
                            tempnum--;
                            break;
                        }
                    case 7:
                        {
                            roman = alpha[bit] + roman;
                            tempnum--;
                            break;
                        }
                    case 6:
                        {
                            roman = alpha[bit] + roman;
                            tempnum--;
                            break;
                        }
                    case 5:
                        {
                            roman = alpha[bit + 1] + roman;
                            break;
                        }
                    case 9:
                        {
                            roman = alpha[bit + 2] + roman;
                            roman = alpha[bit] + roman;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                bit += 2;
                arabic = arabic / 10;
            }
            return roman;
        }
        public static string shortname(string name)
        {
            if (name == "0x00") return "0x00";
            for (int i = 0; i < KeyName.Length; i++)
            {
                if (name == KeyName[i] || name == KeyName2[i])
                {
                    return KeyName2[i];
                }
            }
            return "";
        }
        public static string longname(string name)
        {
            if (name == "0x00") return "0x00";
            for (int i = 0; i < KeyName.Length; i++)
            {
                if (name == KeyName[i] || name == KeyName2[i])
                {
                    return KeyName[i];
                }
            }
            return "";
        }
        public static int name2code(string name, out int mask)
        {
            mask = 0;
            if (name == "0x00") return 0;
            if (name == "") return 0;
            for (int i = 0; i < KeyName.Length; i++)
            {
                if (name == KeyName[i] || name == KeyName2[i])
                {
                    mask = Keymask[i];
                    return Keycode[i];
                }
            }
            return 0xFFFF;
        }
        public static int name2code(string name)
        {
            if (name == "0x00") return 0;
            if (name == "") return 0;
            for (int i = 0; i < KeyName.Length; i++)
            {
                if (name == KeyName[i] || name == KeyName2[i])
                {
                    return Keycode[i];
                }
            }
            return 0xFFFF;
        }
        public static string Code2ShortName(int code)
        {
            for (int i = 0; i < Keycode.Length; i++)
            {
                if (code == Keycode[i])
                {
                    return KeyName2[i];
                }
            }
            return "";
        }
        public static string Code2ShortName(int code, out int mask)
        {
            mask = 0;
            for (int i = 0; i < Keycode.Length; i++)
            {
                if (code == Keycode[i])
                {
                    mask = Keymask[i];
                    return KeyName2[i];
                }
            }
            return "";
        }
        #region KeyName2
        public static string[] KeyName2 =
       {
        "Ctrl" ,
        "Shift" ,
        "Alt" ,
        "Gui" ,
        "Ctrl_L" ,
        "Shift_L" ,
        "Alt_L" ,
        "Gui_L" ,
        "Ctrl_R" ,
        "Shift_R" ,
        "Alt_R" ,
        "Gui_R",

        "A" ,
        "B" ,
        "C" ,
        "D" ,
        "E" ,
        "F" ,
        "G" ,
        "H" ,
        "I" ,
        "J" ,
        "K" ,
        "L" ,
        "M" ,
        "N" ,
        "O" ,
        "P" ,
        "Q" ,
        "R" ,
        "S" ,
        "T" ,
        "U" ,
        "V" ,
        "W" ,
        "X" ,
        "Y" ,
        "Z" ,
        "1" ,
        "2" ,
        "3" ,
        "4" ,
        "5" ,
        "6" ,
        "7" ,
        "8" ,
        "9" ,
        "0" ,
        "Enter" ,
        "Esc" ,
        "<--" ,
        "Tab" ,
        "Space" ,
        "_-" ,
        "+=" ,
        "{[" ,
        "]}" ,
        "|" ,
        "Number" ,
        ":;" ,
        "“'" ,
        "~" ,
        "<," ,
        ".>" ,
        "?/" ,
        "CapsLK" ,
        "F1" ,
        "F2" ,
        "F3" ,
        "F4" ,
        "F5" ,
        "F6" ,
        "F7" ,
        "F8" ,
        "F9" ,
        "F10" ,
        "F11" ,
        "F12" ,
        "Prt" ,
        "Scl" ,
        "Pause" ,
        "Ins" ,
        "Home" ,
        "PgUp" ,
        "Del" ,
        "End" ,
        "PgDn" ,
        "→" ,
        "←" ,
        "↓" ,
        "↑" ,
        "Num" ,
        "p/" ,
        "p*" ,
        "p-" ,
        "p+" ,
        "Enter_p" ,
        "p1" ,
        "p2" ,
        "p3" ,
        "p4" ,
        "p5" ,
        "p6" ,
        "p7" ,
        "p8" ,
        "p9" ,
        "p0" ,
        "p." ,  //.
  
        "Mouse_Left" ,
        "Mouse_Right" ,
        "Mouse_Mid" ,
        "Mouse_4" ,
        "Mouse_5" ,
        "FN" ,
        "VOL0" ,
        "VOL+" ,
        "VOL-" ,
        "TRANSPORT_NEXT_TRACK" ,
        "TRANSPORT_PREV_TRACK" ,
        "TRANSPORT_STOP" ,
        "TRANSPORT_STOP_EJECT" ,
        "TRANSPORT_PLAY_PAUSE" ,
        /* Generic Desktop Page(0x01) - system power control */
        "POWERD" ,
        "SLEEP" ,
        "WAKEUP",
        "LED_Enable","RGB_Enable","ESC~","Print_EEP","Print_Flash","RGB_Effect","user6","user7"
    };
        #endregion
        #region KeyName
        public static string[] KeyName =
        {
        "KEY_CTRL" ,
        "KEY_SHIFT" ,
        "KEY_ALT" ,
        "KEY_GUI" ,
        "KEY_LEFT_CTRL" ,
        "KEY_LEFT_SHIFT" ,
        "KEY_LEFT_ALT" ,
        "KEY_LEFT_GUI" ,
        "KEY_RIGHT_CTRL" ,
        "KEY_RIGHT_SHIFT" ,
        "KEY_RIGHT_ALT" ,
        "KEY_RIGHT_GUI",

        "KEY_A" ,
        "KEY_B" ,
        "KEY_C" ,
        "KEY_D" ,
        "KEY_E" ,
        "KEY_F" ,
        "KEY_G" ,
        "KEY_H" ,
        "KEY_I" ,
        "KEY_J" ,
        "KEY_K" ,
        "KEY_L" ,
        "KEY_M" ,
        "KEY_N" ,
        "KEY_O" ,
        "KEY_P" ,
        "KEY_Q" ,
        "KEY_R" ,
        "KEY_S" ,
        "KEY_T" ,
        "KEY_U" ,
        "KEY_V" ,
        "KEY_W" ,
        "KEY_X" ,
        "KEY_Y" ,
        "KEY_Z" ,
        "KEY_1" ,
        "KEY_2" ,
        "KEY_3" ,
        "KEY_4" ,
        "KEY_5" ,
        "KEY_6" ,
        "KEY_7" ,
        "KEY_8" ,
        "KEY_9" ,
        "KEY_0" ,
        "KEY_ENTER" ,
        "KEY_ESC" ,
        "KEY_BACKSPACE" ,
        "KEY_TAB" ,
        "KEY_SPACE" ,
        "KEY_MINUS" ,
        "KEY_EQUAL" ,
        "KEY_LEFT_BRACE" ,
        "KEY_RIGHT_BRACE" ,
        "KEY_BACKSLASH" ,
        "KEY_NUMBER" ,
        "KEY_SEMICOLON" ,
        "KEY_QUOTE" ,
        "KEY_TILDE" ,
        "KEY_COMMA" ,
        "KEY_PERIOD" ,
        "KEY_SLASH" ,
        "KEY_CAPS_LOCK" ,
        "KEY_F1" ,
        "KEY_F2" ,
        "KEY_F3" ,
        "KEY_F4" ,
        "KEY_F5" ,
        "KEY_F6" ,
        "KEY_F7" ,
        "KEY_F8" ,
        "KEY_F9" ,
        "KEY_F10" ,
        "KEY_F11" ,
        "KEY_F12" ,
        "KEY_PRINTSCREEN" ,
        "KEY_SCROLL_LOCK" ,
        "KEY_PAUSE" ,
        "KEY_INSERT" ,
        "KEY_HOME" ,
        "KEY_PAGE_UP" ,
        "KEY_DELETE" ,
        "KEY_END" ,
        "KEY_PAGE_DOWN" ,
        "KEY_RIGHT" ,
        "KEY_LEFT" ,
        "KEY_DOWN" ,
        "KEY_UP" ,
        "KEY_NUM_LOCK" ,
        "KEYPAD_SLASH" ,
        "KEYPAD_ASTERIX" ,
        "KEYPAD_MINUS" ,
        "KEYPAD_PLUS" ,
        "KEYPAD_ENTER" ,
        "KEYPAD_1" ,
        "KEYPAD_2" ,
        "KEYPAD_3" ,
        "KEYPAD_4" ,
        "KEYPAD_5" ,
        "KEYPAD_6" ,
        "KEYPAD_7" ,
        "KEYPAD_8" ,
        "KEYPAD_9" ,
        "KEYPAD_0" ,
        "KEYPAD_PERIOD" ,  //.
  
        "MOUSE_LEFT" ,
        "MOUSE_RIGHT" ,
        "MOUSE_MID" ,
        "MOUSE_4" ,
        "MOUSE_5" ,

        "KEY_FN" ,

        "AUDIO_MUTE" ,
        "AUDIO_VOL_UP" ,
        "AUDIO_VOL_DOWN" ,
        "TRANSPORT_NEXT_TRACK" ,
        "TRANSPORT_PREV_TRACK" ,
        "TRANSPORT_STOP" ,
        "TRANSPORT_STOP_EJECT" ,
        "TRANSPORT_PLAY_PAUSE" ,
        /* Generic Desktop Page(0x01) - system power control */
        "SYSTEM_POWER_DOWN" ,
        "SYSTEM_SLEEP" ,
        "SYSTEM_WAKE_UP",
       "MACRO0","MACRO1","MACRO2","MACRO3","MACRO4","MACRO5","MACRO6","MACRO7"
    };
        #endregion
        #region Key
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
        #endregion
        #region Ascii 2 scancode
        public static int[] ascii_to_scan_code_table = {
	/* ASCII:   0 */0,
	/* ASCII:   1 */0,
	/* ASCII:   2 */0,
	/* ASCII:   3 */0,
	/* ASCII:   4 */0,
	/* ASCII:   5 */0,
	/* ASCII:   6 */0,
	/* ASCII:   7 */0,
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
        #endregion

        public static int[] Keycode =
{
0x01,0x02,0x04,0x08,0x01,0x02,0x04,0x08,0x10,0x20,0x40,0x80,
4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,
41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,
81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,
0x01,0x02,0x04,0x08,0x10,0,0xE2,0xE9,0xEA,0xB5,0xB6,0xB7,0xCC,0xCD,0x81,0x82,0x83,0x01,0x02,0x04,0x08,0x10,0x20,0x40,0x80
        };
        public static int[] Keymask =
        {
0x02,0x02,0x02,0x02,0x02,0x02,0x02,0x02,0x02,0x02,0x02,0x02,
1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
3,3,3,3,3,6,5,5,5,5,5,5,5,5,4,4,4,7,7,7,7,7,7,7,7
        };
      
    }
}
