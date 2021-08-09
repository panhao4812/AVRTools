using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVRKeys.Keyboard
{
    public class ICode
    {
        public string FullName = "";
        public string ShortName = "";
        public int KeyCode = 0;
        public int Bios = 0;
        public int KeyMask = 0;
        public ICode()
        {
        }
        public ICode(string input)
        {
            string[] str = input.Split(',');
            KeyCode = ToNumber(str[0]);
            Bios = ToNumber(str[1]);
            KeyMask = ToNumber(str[2]);
            ShortName = str[3];
            FullName = str[4];
        }
        public int ToNumber(string str)
        {
            if (str.Contains("0x") || str.Contains("0X") || str.Contains("ox") || str.Contains("oX"))
            {
                str = str.Remove(0, 2);
                return Int32.Parse(str, System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            return Convert.ToInt32(str);
        }
    }
    public class ICodes
    {
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
        List<ICode> codes = new List<ICode>();
        public ICodes()
        {
            codes = new List<ICode>();
            for (int i = 0; i < codelist.Length; i++)
            {
                codes.Add(new ICode(codelist[i]));
            }
        }
        public ICode FromCode(int pin)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].KeyCode == pin) return codes[i];
            }
            return new ICode();
        }
        public ICode FromFullName(string pin)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].FullName == pin) return codes[i];
            }
            return new ICode();
        }
        public ICode FromShortName(string pin)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].ShortName == pin) return codes[i];
            }
            return new ICode();
        }
        public ICode FromBios(int pin)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].Bios == pin) return codes[i];
            }
            return new ICode();
        }
        #region code
        public string[] codelist = new String[133]
     {
"0x01,0x1d,0x02,Ctrl,KEY_CTRL",
"0x02,0x2a,0x02,Shift,KEY_SHIFT",
"0x04,0x38,0x02,Alt,KEY_ALT",
"0x08,0x015b,0x02,Win,KEY_GUI",
"0x01,0x1d,0x02,左C,KEY_LEFT_CTRL",
"0x02,0x2a,0x02,左S,KEY_LEFT_SHIFT",
"0x04,0x38,0x02,左A,KEY_LEFT_SHIFT",
"0x08,0x015b,0x02,左W,KEY_LEFT_GUI",
"0x10,0x011d,0x02,右C,KEY_RIGHT_CTRL",
"0x20,0x36,0x02,右S,KEY_RIGHT_SHIFT",
"0x40,0x0138,0x02,右A,KEY_RIGHT_ALT",
"0x80,0x015b,0x02,右W,KEY_RIGHT_GUI",
"4,0x1e,0x01,A,KEY_A",
"5,0x30,0x01,B,KEY_B",
"6,0x2e,0x01,C,KEY_C",
"7,0x20,0x01,D,KEY_D",
"8,0x12,0x01,E,KEY_E",
"9,0x21,0x01,F,KEY_F",
"10,0x22,0x01,G,KEY_G",
"11,0x23,0x01,H,KEY_H",
"12,0x17,0x01,I,KEY_I",
"13,0x24,0x01,J,KEY_J",
"14,0x25,0x01,K,KEY_K",
"15,0x26,0x01,L,KEY_L",
"16,0x32,0x01,M,KEY_M",
"17,0x31,0x01,N,KEY_N",
"18,0x18,0x01,O,KEY_O",
"19,0x19,0x01,P,KEY_P",
"20,0x10,0x01,Q,KEY_Q",
"21,0x13,0x01,R,KEY_R",
"22,0x1f,0x01,S,KEY_S",
"23,0x14,0x01,T,KEY_T",
"24,0x16,0x01,U,KEY_U",
"25,0x2f,0x01,V,KEY_V",
"26,0x11,0x01,W,KEY_W",
"27,0x2d,0x01,X,KEY_X",
"28,0x15,0x01,Y,KEY_Y",
"29,0x2c,0x01,Z,KEY_Z",
"30,0x02,0x01,1,KEY_1",
"31,0x03,0x01,2,KEY_2",
"32,0x04,0x01,3,KEY_3",
"33,0x05,0x01,4,KEY_4",
"34,0x06,0x01,5,KEY_5",
"35,0x07,0x01,6,KEY_6",
"36,0x08,0x01,7,KEY_7",
"37,0x09,0x01,8,KEY_8",
"38,0x0a,0x01,9,KEY_9",
"39,0x0b,0x01,0,KEY_0",
"40,0x1c,0x01,回车,KEY_ENTER",
"41,0x01,0x01,Esc,KEY_ESC",
"42,0x0e,0x01,退格,KEY_BACKSPACE",
"43,0x0f,0x01,Tab,KEY_TAB",
"44,0x39,0x01,空格,KEY_SPACE",
"45,0x0c,0x01,减号,KEY_MINUS",
"46,0x0d,0x01,加号,KEY_EQUAL",
"47,0x1a,0x01,{[,KEY_LEFT_BRACE",
"48,0x1b,0x01,]},KEY_RIGHT_BRACE",
"49,0x2b,0x01,顿号,KEY_BACKSLASH",
"50,0x00,0x01,数字,KEY_NUMBER",
"51,0x27,0x01,冒号,KEY_SEMICOLON",
"52,0x28,0x01,引号,KEY_QUOTE",
"53,0x29,0x01,波浪,KEY_TILDE",
"54,0x33,0x01,逗号,KEY_COMMA",
"55,0x34,0x01,句号,KEY_PERIOD",
"56,0x35,0x01,问号,KEY_SLASH",
"57,0X3a,0x01,大小写,KEY_CAPS_LOCK",
"58,0x3b,0x01,F1,KEY_F1",
"59,0x3c,0x01,F2,KEY_F2",
"60,0x3d,0x01,F3,KEY_F3",
"61,0x3e,0x01,F4,KEY_F4",
"62,0x3f,0x01,F5,KEY_F5",
"63,0x40,0x01,F6,KEY_F6",
"64,0x41,0x01,F7,KEY_F7",
"65,0x42,0x01,F8,KEY_F8",
"66,0x43,0x01,F9,KEY_F9",
"67,0x44,0x01,F10,KEY_F10",
"68,0x57,0x01,F11,KEY_F11",
"69,0x58,0x01,F12,KEY_F12",
"70,0x0137,0x01,截屏,KEY_PRINTSCREEN",
"71,0x46,0x01,滚动锁,KEY_SCROLL_LOCK",
"72,0x45,0x01,暂停,KEY_PAUSE",
"73,0x0152,0x01,Ins,KEY_INSERT",
"74,0x0147,0x01,Home,KEY_HOME",
"75,0x0149,0x01,上翻页,KEY_PAGE_UP",
"76,0x0153,0x01,Del,KEY_DELETE",
"77,0x014f,0x01,End,KEY_END",
"78,0x0151,0x01,下翻页,KEY_PAGE_DOWN",
"79,0x014d,0x01,→,KEY_RIGHT",
"80,0x014b,0x01,←,KEY_LEFT",
"81,0x0150,0x01,↓,KEY_DOWN",
"82,0x0148,0x01,↑,KEY_UP",
"83,0x0145,0x01,Num,KEY_NUM_LOCK",
"84,0x0135,0x01,p/,KEYPAD_SLASH",
"85,0x37,0x01,p*,KEYPAD_ASTERIX",
"86,0x4a,0x01,p-,KEYPAD_MINUS",
"87,0x4e,0x01,p+,KEYPAD_PLUS",
"88,0x011c,0x01,小回车,KEYPAD_ENTER",
"89,0x4f,0x01,p1,KEYPAD_1",
"90,0x50,0x01,p2,KEYPAD_2",
"91,0x51,0x01,p3,KEYPAD_3",
"92,0x4b,0x01,p4,KEYPAD_4",
"93,0x4c,0x01,p5,KEYPAD_5",
"94,0x4d,0x01,p6,KEYPAD_6",
"95,0x47,0x01,p7,KEYPAD_7",
"96,0x48,0x01,p8,KEYPAD_8",
"97,0x49,0x01,p9,KEYPAD_9",
"98,0x52,0x01,p0,KEYPAD_0",
"99,0x53,0x01,p.,KEYPAD_PERIOD",
"0x01,0x00,0x03,鼠左,MOUSE_LEFT",
"0x02,0x00,0x03,鼠右,MOUSE_RIGHT",
"0x04,0x00,0x03,鼠中,MOUSE_MID",
"0x08,0x00,0x03,鼠4,MOUSE_4",
"0x10,0x00,0x03,鼠5,MOUSE_5",
"0,0x00,0x06,FN,KEY_FN",
"0xE2,0x00,0x05,静音,AUDIO_MUTE",
"0xE9,0x00,0x05,音+,AUDIO_VOL_UP",
"0xEA,0x00,0x05,音-,AUDIO_VOL_DOWN",
"0xB5,0x00,0x05,TRANSPORT_NEXT_TRACK,TRANSPORT_NEXT_TRACK",
"0xB6,0x00,0x05,TRANSPORT_PREV_TRACK,TRANSPORT_PREV_TRACK",
"0xB7,0x00,0x05,TRANSPORT_STOP,TRANSPORT_STOP",
"0xCC,0x00,0x05,TRANSPORT_STOP_EJECT,TRANSPORT_STOP_EJECT",
"0xCD,0x00,0x05,TRANSPORT_PLAY_PAUSE,TRANSPORT_PLAY_PAUSE",
"0x81,0x00,0x04,POWERD,SYSTEM_POWER_DOWN",
"0x82,0x00,0x04,SLEEP,SYSTEM_SLEEP",
"0x83,0x00,0x04,WAKEUP,SYSTEM_WAKE_UP",
"0x01,0x00,0x07,LED_Enable,MACRO0",
"0x02,0x00,0x07,RGB_Enable,MACRO1",
"0x04,0x00,0x07,ESC~,MACRO2",
"0x08,0x00,0x07,Print_EEP,MACRO3",
"0x10,0x00,0x07,Print_Flash,MACRO4",
"0x20,0x00,0x07,RGB_Effect,MACRO5",
"0x40,0x00,0x07,user6,MACRO6",
"0x80,0x00,0x07,user7,MACRO7"
     };
        #endregion
    }
    public class IIO
    {
        public string Name = "";
        public int Index = -1;
        public IIO(string input)
        {
            string[] str = input.Split(',');
            Index = Convert.ToInt32(str[0]);
            Name = str[1];
        }
    }
    public class IMega32U4
    {
        public List<IIO> codes;
        public IMega32U4()
        {
            codes = new List<IIO>();
            for (int i = 0; i < pins.Length; i++)
            {
                codes.Add(new IIO(pins[i]));
            }
        }
        public string[] pins = new String[25]
        {
"0,B0","1,B1","2,B2","3,B3","4,B7",
"5,D0","6,D1","7,D2","8,D3","9,C6",
"10,C7","11,D6","12,D7","13,B4","14,B5",
"15,B6","16,F7","17,F6","18,F5","19,F4",
"20,F1","21,F0","22,D4","23,D5","24,E6",
        };
        public string GetIOName(int pin)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].Index == pin) return codes[i].Name;
            }
            return "";
        }
        public int GetIOIndex(string pin)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].Name == pin) return codes[i].Index;
            }
            return -1;
        }
    }
    public class IColors
    {
        public static List<Button> CreateButton(int U1)
        {
            List<Button> bus = new List<Button>();
            int count = (int)(40.0 / U1 * 22);
            for (int i = 0; i < Rcolors.Length; i++)
            {
                float x = i % count * U1 + 1;
                float y = (i / count) * U1 + 1;
                Button button = new Button();
                button.Text = i.ToString();
                button.BackColor = GetColor(i);
                button.Font = new Font("Courier10 BT", 6);
                button.TextAlign = ContentAlignment.TopLeft;
                button.TabStop = false;
                button.Width = (int)U1 - 2;
                button.Height = (int)U1 - 2;
                button.Location = new Point((int)x, (int)y);
                button.FlatStyle = FlatStyle.Flat;
                bus.Add(button);
            }
            return bus;
        }
        public Color[] IOColors = new Color[21];
        public IColors()
        {
            for (int i = 0; i < 21; i++)
            {
                if (i % 2 == 0)
                {
                    IOColors[i] = GetColor((int)((float)i / 21.0 * 250.0));
                }
                else if (i > 0)
                {
                    IOColors[i] = Color.FromArgb(255, 255 - IOColors[i - 1].R, 255 - IOColors[i - 1].G, 255 - IOColors[i - 1].B);
                }
            }
        }
        public static Color GetColor(int index)
        {
            return Color.FromArgb(Rcolors[index], Gcolors[index], Bcolors[index]);
        }
        public static int[] Rcolors = new int[255]
{
    243,243,243,243,242,242,241,241,240,240,239,239,238,238,237,237,236,236,236,236,236,236,235,234,233,
    232,231,229,227,226,224,222,220,219,217,216,214,213,212,211,211,210,210,210,208,206,202,198,193,187,
    181,174,167,159,152,145,138,131,125,119,114,110,107,104,103,103,103,102,102,101,100,99,97,96,94,
    92,90,87,85,82,80,77,75,72,69,67,64,61,59,56,54,52,50,48,46,44,43,42,41,40,
    39,39,39,39,38,38,37,36,34,32,30,28,26,24,22,19,17,15,13,11,9,7,5,4,3,
    2,1,1,1,1,1,2,2,3,4,4,5,6,7,8,9,10,11,12,13,14,15,16,16,17,
    17,18,18,18,18,19,20,22,24,26,29,32,35,38,42,46,49,53,57,60,64,67,70,72,74,
    76,78,78,79,79,80,82,85,90,95,100,107,114,122,130,139,147,156,165,173,181,188,195,202,207,
    212,215,218,219,220,220,220,221,222,222,224,225,226,227,229,231,232,234,236,237,239,240,242,243,244,
    245,246,246,247,247,247,247,247,247,247,247,246,246,246,246,246,245,245,245,245,244,244,244,244,244,
    243,243,243,243,243
};
        public static int[] Gcolors = new int[255]
{
    57,57,56,55,54,52,50,48,46,43,41,38,36,34,32,30,29,28,27,27,27,27,26,25,24,
    23,21,20,18,16,15,13,11,9,7,6,4,3,2,1,1,0,0,0,0,0,0,0,0,0,
    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,4,5,7,8,10,
    13,15,18,20,23,26,29,32,35,38,41,44,47,50,52,55,58,60,62,64,66,67,69,70,71,
    71,72,72,72,74,76,79,83,88,93,99,105,112,119,126,134,141,148,155,162,168,174,179,183,187,
    189,191,192,192,192,192,191,191,190,190,189,188,188,187,186,185,184,184,183,182,181,180,180,179,179,
    178,178,178,178,178,178,178,178,179,179,179,180,180,181,181,182,182,183,183,184,184,184,185,185,185,
    186,186,186,186,186,186,187,188,190,192,194,196,199,202,205,208,211,214,217,220,223,226,228,230,232,
    234,235,236,237,237,237,236,234,232,230,227,223,220,215,211,206,202,197,192,187,183,178,174,171,168,
    165,163,161,160,159,159,158,157,154,151,148,144,139,134,128,122,116,110,103,97,91,85,80,75,70,
    66,63,60,59,57
};
        public static int[] Bcolors = new int[255]
{
    0,0,2,4,6,10,14,18,23,27,32,37,42,46,50,54,56,58,60,60,60,61,62,64,66,
    69,72,76,79,83,87,91,95,99,102,106,109,111,114,116,117,118,118,118,118,118,118,118,118,118,
    119,119,119,119,119,119,119,119,120,120,120,120,120,120,120,120,120,120,121,121,122,123,124,125,126,
    127,129,130,132,133,135,136,138,140,142,143,145,147,148,150,151,153,154,155,157,158,158,159,160,160,
    161,161,161,161,162,163,165,167,170,173,176,180,184,188,192,196,200,204,208,212,215,219,221,224,226,
    227,228,229,229,228,226,223,219,214,208,201,194,187,179,170,162,153,145,136,129,121,114,108,103,98,
    95,92,91,90,90,89,87,85,82,79,76,72,67,63,58,53,48,43,38,33,29,24,20,17,14,
    12,10,9,8,8,8,9,9,10,11,12,13,14,15,17,18,20,21,23,24,25,27,28,29,30,
    31,31,32,32,32,32,32,32,31,31,30,30,29,29,28,27,27,26,25,24,24,23,22,22,21,
    21,21,20,20,20,20,20,20,19,19,18,17,16,15,14,13,12,10,9,8,7,6,4,3,3,
    2,1,1,0,0
};
    }
    public class IHex
    {

        public IHex()
        {
            data = new List<ushort>();
        }
        public IHex(List<string> _data)
        {
            data = new List<ushort>();
            for (int i = 0; i < _data.Count; i++)
            {
                data.Add(Convert.ToUInt16(_data[i]));
            }
        }
        public IHex(string[] _data)
        {
            data = new List<ushort>();
            for (int i = 0; i < _data.Length; i++)
            {
                data.Add(Convert.ToUInt16(_data[i]));
            }
        }
        public List<ushort> data;
        public string Write(int address, int end)
        {

            string output = "";
            for (int i = 0; i < data.Count; i += 8)
            {
                if (address >= end - 16) break;
                string buffer1 = ":10";
                buffer1 += Convert.ToString(address, 16).PadLeft(4, '0');
                buffer1 += "00";
                for (int j = 0; j < 8; j++)
                {
                    int index = i + j;
                    if (index < data.Count)
                    {
                        char[] bytes = Convert.ToString(data[index], 16).PadLeft(4, '0').ToArray();
                        char[] bytes2 = { bytes[2], bytes[3], bytes[0], bytes[1] };
                        string str = new string(bytes2);
                        buffer1 += str;
                    }
                    else { buffer1 += "0000"; }
                }
                buffer1 += IHex.Tail(buffer1);
                output += buffer1 + "\r\n";
                address += 16;
            }
            output += ":00000001FF";
            return output;
        }
        public static string Tail(string input)
        {
            char[] data1 = input.ToCharArray();
            if (data1[0] != ':') return "FF";
            int regi = 0;
            for (int i = 1; i < data1.Length; i += 2)
            {
                string str = "0x";
                str += data1[i]; str += data1[i + 1];
                int a = Convert.ToInt32(str, 16);
                regi += a;
            }
            regi = 0x100 - regi % 0x100;
            if (regi == 0x100) regi = 0;
            return Convert.ToString(regi, 16).PadLeft(2, '0');
        }
        public void DataFromString(string input)
        {
            char[] data1 = input.ToCharArray();
            if (data1[0] != ':') return;
            if (data1.Length < 15) return;
            for (int i = 9; i <= data1.Length - 6; i += 4)
            {
                string str = "0x";
                str += data1[i]; str += data1[i + 1];
                str += data1[i + 2]; str += data1[i + 3];
                int a = Convert.ToInt32(str, 16);
                data.Add(Convert.ToUInt16(a));
            }
        }
    }
    public class IEncode
    {
        public TextBox console;
        public IEncode(TextBox Cons) { console = Cons; }
        public void Print(string str)
        {
            console.Text += str;
        }
        public void Clear()
        {
            console.Text = "";
        }
        public string CodeDec = "";
        public string CodeHex = "";
        public void Solve(string input, string encode)
        {
            CodeDec = ""; CodeHex = ""; Clear();
            try
            {
                char[] ch = input.ToArray();
                if (ch == null || ch.Length == 0)
                {
                    Print("Nothing to encode!");
                    return;
                }
                //Print("English 0-127 GBK > " + 0x8080);
                int length = ch.Length;
                int length2 = length;
                for (int j = 0; j < length; j++)
                {
                    if (ch[j] < 127 && ch[j] >= 0)
                    {
                        int code = ascii_to_scan_code_table[(int)ch[j]];
                        if (code != 0)
                        {
                            if (j != 0) { CodeHex += ","; CodeDec += ","; }
                            CodeHex +=  code.ToString("x");
                            CodeDec +=  code.ToString();
                        }
                        else
                        {
                            length2--;
                        }
                    }
                    else if (ch[j] <= 0xFFFF)
                    {
                        //汉字   
                        string a3 = ConvertChinese1(ch[j], encode);
                        if (j!= 0){CodeHex += ","; CodeDec += ",";}
                        CodeHex +=  a3;
                        CodeDec +=  Convert.ToUInt16(a3, 16).ToString();
                    }
                }
                CodeHex = length2.ToString("x") + CodeHex;
                CodeDec += length2.ToString() + CodeDec;

            }
            catch (Exception ex)
            {
                Print(ex.ToString());
                return;
            }
        }
        public string ConvertChinese1(char str, string code)
        {
            string str2 = Convert.ToString(str);
            byte[] data;
            //ushort a3;
            if (code == "GBK"|| code =="gbk")
            {
                return ConvertChinese2(str, code);
            }
            else if (code == "Unicode" || code == "unicode")
            {
                data = Encoding.Unicode.GetBytes(str2);
            }
            else if (code == "UTF8"|| code == "utf8" || code == "UTF-8")
            {
                data = Encoding.UTF8.GetBytes(str2);
            }
            else if (code == "Big5" || code == "big5" || code == "BIG5")
            {
                return ConvertChinese2(str, code);
            }
            else if (code == "GB2312")
            {
                return ConvertChinese2(str, code);
            }
            else { Print("encoding error"); return "0x00"; }
            string data1 = data[1].ToString("x"); if (data1.Length == 1) data1 = "0" + data1;
            string data2 = data[0].ToString("x"); if (data2.Length == 1) data2 = "0" + data2;
            str2 = data1 + data2;
            return str2;
            //a3 = Convert.ToUInt16(str2, 16);
            //return a3;
        }
        public string ConvertChinese2(char str, string code)
        {
            string str2 = Convert.ToString(str);
            byte[] data = Encoding.GetEncoding(code).GetBytes(str2);
            string Data1 = "00"; string Data2 = "00";
            if (data.Length == 0) { }
            else if (data.Length == 1) {
                Data1 = data[0].ToString("x"); if (Data1.Length == 1) Data1 = "0" + Data1;
            }
            else
            {
                Data1 = data[0].ToString("x"); if (Data1.Length == 1) Data1 = "0" + Data1;
                Data2 = data[1].ToString("x"); if (Data2.Length == 1) Data2 = "0" + Data2;
            }
            str2 = Data1 + Data2;
            return str2;
            //ushort a3 = Convert.ToUInt16(str2, 16);
            //return a3;
        }
        #region ascii
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
    }
}
