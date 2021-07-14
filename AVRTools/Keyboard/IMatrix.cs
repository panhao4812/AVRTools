using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace AVRKeys.Keyboard
{
    public class IMatrix
    {
        public string[] keycap = new string[0];
        public string Debug_output = "";
        public string Name = "unamed";
        /// ///////////////
        public int[,] hexaKeys0;
        public int[,] hexaKeys1;
        public int[,] keymask;
        public double[,] keycapLength;
        public Point[,] keycapPos;
        public int[,] RGB;
        public int ROWS = 0;
        public int COLS = 0;
        public int MAX_EEP = 0;
        public int FLASH_END_ADDRESS = 0;
        public int VENDOR_ID = 0;
        public int ADD_EEP = 0;
        public IMatrix() { }
        public int PRODUCT_ID = 0;
        public int[] rowPins;
        public int[] colPins;

        /// //////////
        public int WS2812_COUNT = 0;//optional
        public int WS2812_PIN = 0;//optional
        public int MAX_DELAY = 0;//optional
        public int RGB_EFFECT_COUNT = 0;//optional
        public int[] rgb_pos;//optional
        public int[] rgb_rainbow;//optional
        public int[] rgb_fixcolor;//optional

        public void MCU_Init(string MCU)
        {
            if (MCU == "__AVR_ATmega32U2__")
            {
                this.VENDOR_ID = 0x32C2;
                this.FLASH_END_ADDRESS = 0x7000;
                this.MAX_EEP = 0x03FF;
            }
            if (MCU == "__AVR_ATmega32U4__")
            {
                this.VENDOR_ID = 0x32C4;
                this.FLASH_END_ADDRESS = 0x7000;
                this.MAX_EEP = 0x03FF;
            }
        }
        public void WS2812_Init(int WS2812_count)
        {
            WS2812_COUNT =WS2812_count;
            int ADD_INDEX = 10;
            int ADD_ROW = ADD_INDEX + ROWS;
            int ADD_COL = ADD_ROW + COLS;
            int ADD_KEYS1 = ADD_COL + (ROWS * COLS);
            int ADD_KEYS2 = ADD_KEYS1 + (ROWS * COLS);
            int ADD_RGB = ADD_KEYS2 + (ROWS * COLS);
            int ADD_RGBTYPE = ADD_RGB + (WS2812_COUNT * 3);
            ADD_EEP = ADD_RGBTYPE + 6;
        }
        public void Matrix_Init()
        {
            List<int> Cols = new List<int>();
            List<int> Rows = new List<int>();
            if (keycap.Length <= 0) return;
            for (int i = 0; i < keycap.Length; i++)
            {
                string[] str = keycap[i].Split(',');
                Rows.Add(Convert.ToInt32(str[4]));
                Cols.Add(Convert.ToInt32(str[3]));
            }
            ROWS =Rows.Max(); COLS =Cols.Max();
            hexaKeys0 = new int[ROWS, COLS];
            hexaKeys1 = new int[ROWS, COLS];
            keymask = new int[ROWS, COLS];
            keycapLength = new double[ROWS, COLS];
            keycapPos = new Point[ROWS, COLS];
            RGB = new int[ROWS, COLS];
            for (int i = 0; i < keycap.Length; i++)
            {
                string[] str = keycap[i].Split(',');
                int row = Convert.ToInt32(str[4]);
                int col = Convert.ToInt32(str[3]);
                keycapLength[row, col] = Convert.ToInt32(str[2]);
                keycapPos[row, col] = new Point(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]));
                int mask1 = 0;
                int mask2 = 0;
                int code1 = IKeycode.name2code(str[5], out mask1);
                keymask[row, col] +=(mask1 * 16);
                hexaKeys0[row, col] =code1;
                int code2 = IKeycode.name2code(str[6], out mask2);
                keymask[row, col] +=mask2;
                hexaKeys1[row, col] =code2;
            }
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    double x = keycapPos[r, c].X + (keycapLength[r, c] - 1) / 2.0;
                    double y = keycapPos[r, c].Y;
                    double maxX = 22;
                    int index = (int)(x / maxX * (IKeycode.Rcolors.Count() - 1));
                    RGB[r, c] = index;
                }
            }      
        }
        public string PrintKeyCap()
        {
            if (this.keycap.Length > 0)
            {
                string output = "";
                for (int i = 0; i < this.keycap.Length; i++)
                {
                    output += keycap[i] + "\r\n";
                }
                return output;
            }
            else return "";
        }

    }
    class QMK60_ISO : IMatrix
    {
        public QMK60_ISO()
        {
            this.Name = "QMK60_ISO";
            this.keycap = new string[61]{
"0,0,1,0,0,MACRO2,KEY_TILDE",
"1,0,1,0,1,KEY_1,KEY_F1",
"2,0,1,0,2,KEY_2,KEY_F2",
"3,0,1,0,3,KEY_3,KEY_F3",
"4,0,1,0,4,KEY_4,KEY_F4",
"5,0,1,0,5,KEY_5,KEY_F5",
"6,0,1,0,6,KEY_6,KEY_F6",
"7,0,1,0,7,KEY_7,KEY_F7",
"8,0,1,0,8,KEY_8,KEY_F8",
"9,0,1,0,9,KEY_9,KEY_F9",
"10,0,1,0,10,KEY_0,KEY_F10",
"11,0,1,0,11,KEY_MINUS,KEY_F11",
"12,0,1,0,12,KEY_EQUAL,KEY_F12",
"13,0,2,0,13,KEY_BACKSPACE,KEY_DELETE",
"0,1,1.5,1,0,KEY_TAB,KEY_TAB",
"1.5,1,1,1,1,KEY_Q,KEYPAD_1",
"2.5,1,1,1,2,KEY_W,KEYPAD_2",
"3.5,1,1,1,3,KEY_E,KEYPAD_3",
"4.5,1,1,1,4,KEY_R,KEYPAD_4",
"5.5,1,1,1,5,KEY_T,KEYPAD_5",
"6.5,1,1,1,6,KEY_Y,KEYPAD_6",
"7.5,1,1,1,7,KEY_U,KEYPAD_7",
"8.5,1,1,1,8,KEY_I,KEYPAD_8",
"9.5,1,1,1,9,KEY_O,KEYPAD_9",
"10.5,1,1,1,10,KEY_P,KEYPAD_0",
"11.5,1,1,1,11,KEY_LEFT_BRACE,KEYPAD_MINUS",
"12.5,1,1,1,12,KEY_RIGHT_BRACE,KEYPAD_PLUS",
"13.5,1,1.5,1,13,KEY_BACKSLASH,KEY_BACKSLASH",
"0,2,1.75,2,0,KEY_CAPS_LOCK,KEY_CAPS_LOCK",
"1.75,2,1,2,1,KEY_A,MOUSE_LEFT",
"2.75,2,1,2,2,KEY_S,MOUSE_MID",
"3.75,2,1,2,3,KEY_D,MOUSE_RIGHT",
"4.75,2,1,2,4,KEY_F,",
"5.75,2,1,2,5,KEY_G,",
"6.75,2,1,2,6,KEY_H,",
"7.75,2,1,2,7,KEY_J,",
"8.75,2,1,2,8,KEY_K,",
"9.75,2,1,2,9,KEY_L,",
"10.75,2,1,2,10,KEY_SEMICOLON,",
"11.75,2,1,2,11,KEY_QUOTE,",
"12.75,2,2.25,2,13,KEY_ENTER,KEY_ENTER",
"0,3,2.25,3,0,KEY_SHIFT,KEY_SHIFT",
"2.25,3,1,3,2,KEY_Z,MACRO0",
"3.25,3,1,3,3,KEY_X,MACRO1",
"4.25,3,1,3,4,KEY_C,MACRO5",
"5.25,3,1,3,5,KEY_V,",
"6.25,3,1,3,6,KEY_B,",
"7.25,3,1,3,7,KEY_N,KEY_NUM_LOCK",
"8.25,3,1,3,8,KEY_M,KEY_SCROLL_LOCK",
"9.25,3,1,3,9,KEY_COMMA,AUDIO_VOL_DOWN",
"10.25,3,1,3,10,KEY_PERIOD,AUDIO_VOL_UP",
"11.25,3,1,3,11,KEY_SLASH,AUDIO_MUTE",
"12.25,3,2.75,3,13,KEY_RIGHT_SHIFT,KEY_RIGHT_SHIFT",
"0,4,1.25,4,0,KEY_CTRL,KEY_CTRL",
"1.25,4,1.25,4,1,KEY_FN,KEY_FN",
"2.5,4,1.25,4,2,KEY_ALT,KEY_ALT",
"3.75,4,6.25,4,5,KEY_SPACE,KEY_SPACE",
"10,4,1.25,4,10,KEY_RIGHT_ALT,KEY_RIGHT_ALT",
"11.25,4,1.25,4,11,KEY_LEFT,KEY_UP",
"12.5,4,1.25,4,12,KEY_RIGHT,KEY_DOWN",
"13.75,4,1.25,4,13,KEY_RIGHT_CTRL,KEY_RIGHT_CTRL"
            };
            MCU_Init("__AVR_ATmega32U4__");
            Matrix_Init();
        }

    }
}
