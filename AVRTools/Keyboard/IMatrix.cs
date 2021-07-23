using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace AVRKeys.Keyboard
{
    public class IKeycap
    {
        public string input = "";
        public float X = 0;
        public float Y = 0;
        public int R = 0;
        public int C = 0;
        public float L = 0;
        public string layer1;
        public string layer2;
        public static float U = 40;
        public IKeycap(string Str)
        {
            input = Str;
            string[] str = input.Split(',');
            R = Convert.ToInt32(str[3]);
            C = Convert.ToInt32(str[4]);
            X = Convert.ToSingle(str[0]);
            Y = Convert.ToSingle(str[1]);
            L = Convert.ToSingle(str[2]);
            layer1 = str[5]; layer2 = str[6];
        }
        public Button CreateButton()
        {
            Button button = new Button();
            float x = X * U + 1;
            float y = Y * U + 1;
            button.Width = (int)(U * L) - 2;
            button.Height = (int)U - 2;
            button.Location = new Point((int)x, (int)y);
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.White;
            button.Font = new Font("Arial", 7);
            button.TextAlign = ContentAlignment.TopLeft;
            //button.MouseDown += new MouseEventHandler(Layer0Button_MouseClick);
            //button.Text = IKeycode.Code2ShortName(hexaKeys0[r,c]);
            return button;
        }
    }
    public class IMatrix
    {
        public List<IKeycap> key_caps = new List<IKeycap>();
        public string DEBUG_OUTPUT = "";
        public string NAME = "unamed";
        /// ///////////////
        public int[,] hexa_keys0;
        public int[,] hexa_keys1;
        public int[,] key_mask;
        public int[] row_pins;
        public int[] col_pins;
        public int ROWS = 0;
        public int COLS = 0;
        public int VENDOR_ID = 0;
        public int PRODUCT_ID = 0;
        public int MAX_EEP = 0;
        public int FLASH_END_ADDRESS = 0;
        public int ADD_EEP = 0;
        public int MAX_DELAY = 0;
        /// ///////////////////////
        public int WS2812_PIN = 0;
        public int RGB_EFFECT_COUNT = 0;
        public int WS2812_COUNT = 0;
        public int RGB_TYPE = 0;
        //bit7->第1组 0 off, 1 on
        //bit6->第2组 0 off, 1 on
        //bit5->第full组 0 off, 1 on
        //bit4->第RGB组 0 off, 1 on
        //bit0-3-> RGB Effect
        public int[] rgb_pos;//optional
        public int[] rgb_rainbow;//optional
        public int[] rgb_fixcolor;//optional
        public IMatrix() { }
        /// //////////
        public void MCU_Init(string MCU)
        {
            if (MCU == "__AVR_ATmega32U2__")
            {
                this.VENDOR_ID = 0x32C2;
                this.FLASH_END_ADDRESS = 0x7000;
                this.MAX_EEP = 0x03FF;
                MAX_DELAY = 0x0200;
            }
            if (MCU == "__AVR_ATmega32U4__")
            {
                this.VENDOR_ID = 0x32C4;
                this.FLASH_END_ADDRESS = 0x7000;
                this.MAX_EEP = 0x03FF;
                MAX_DELAY = 0x0010;
            }
        }
        public void WS2812_Init(int WS2812_count)
        {
            WS2812_COUNT = WS2812_count;
            int ADD_INDEX = 10;
            int ADD_ROW = ADD_INDEX + ROWS;
            int ADD_COL = ADD_ROW + COLS;
            int ADD_KEYS1 = ADD_COL + (ROWS * COLS);
            int ADD_KEYS2 = ADD_KEYS1 + (ROWS * COLS);
            int ADD_RGB_FIX = ADD_KEYS2 + (ROWS * COLS);
            int ADD_RGBTYPE = ADD_RGB_FIX + (WS2812_COUNT * 3);
            ADD_EEP = ADD_RGBTYPE + 6;
        }

        public void Keycap_Init(string[] keycap)
        {
            if (keycap.Length <= 0) return;
            for (int i = 0; i < keycap.Length; i++)
            {
                key_caps.Add(new IKeycap(keycap[i]));
            }
        }
        public void Matrix_Init(int[] R, int[] C)
        {
            row_pins = R; col_pins = C;
            ROWS = R.Length; COLS = C.Length;
            hexa_keys0 = new int[ROWS, COLS];
            hexa_keys1 = new int[ROWS, COLS];
            key_mask = new int[ROWS, COLS];
        }
        public List<Button> CreateButton()
        {
            List<Button> bus = new List<Button>();
            for (int i = 0; i < this.key_caps.Count; i++)
            {
                bus.Add(key_caps[i].CreateButton());
            }
            return bus;
        }
        public string PrintKeyCap()
        {
            if (this.key_caps.Count > 0)
            {
                string output = "";
                for (int i = 0; i < this.key_caps.Count; i++)
                {
                    output += key_caps[i].input + "\r\n";
                }
                return output;
            }
            else return "";
        }
        public override string ToString()
        {
            string str = "";
            str += PrintKeyCap();
            str += "Debug_output " + DEBUG_OUTPUT + "\r\n";
            str += "Name " + NAME + "\r\n";
            str += "ROWS " + ROWS.ToString() + "\r\n";
            str += "COLS " + COLS.ToString() + "\r\n";
            str += "MAX_EEP " + MAX_EEP.ToString() + "\r\n";
            str += "FLASH_END_ADDRESS " + FLASH_END_ADDRESS.ToString() + "\r\n";
            str += "VENDOR_ID " + VENDOR_ID.ToString() + "\r\n";
            str += "PRODUCT_ID " + PRODUCT_ID.ToString() + "\r\n";
            str += "ADD_EEP " + ADD_EEP.ToString() + "\r\n";
            str += "WS2812_COUNT " + WS2812_COUNT.ToString() + "\r\n";
            str += "rowPins " + "\r\n";
            for (int i = 0; i < row_pins.Length; i++)
            {
                str += row_pins[i].ToString() + ",";
            }
            str += "\r\n";
            str += "colPins " + "\r\n";
            for (int i = 0; i < col_pins.Length; i++)
            {
                str += col_pins[i].ToString() + ",";
            }
            str += "\r\n";
            str += "hexaKeys0 " + "\r\n";
            for (int i = 0; i < hexa_keys0.GetUpperBound(0); i++)
            {
                for (int j = 0; j < hexa_keys0.GetUpperBound(1); j++)
                {
                    str += hexa_keys0[i, j].ToString() + ",";
                }
            }
            str += "\r\n";
            str += "hexaKeys1 " + "\r\n";
            for (int i = 0; i < hexa_keys1.GetUpperBound(0); i++)
            {
                for (int j = 0; j < hexa_keys1.GetUpperBound(1); j++)
                {
                    str += hexa_keys1[i, j].ToString() + ",";
                }
            }
            str += "\r\n";
            str += "keymask " + "\r\n";
            for (int i = 0; i < key_mask.GetUpperBound(0); i++)
            {
                for (int j = 0; j < key_mask.GetUpperBound(1); j++)
                {
                    str += key_mask[i, j].ToString() + ",";
                }
            }
            str += "\r\n";
            return str;
        }
    }

}
