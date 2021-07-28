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
        public override string ToString()
        {
            string str = "";
            str += X.ToString() + ",";
            str += Y.ToString() + ",";
            str += L.ToString() + ",";
            str += R.ToString() + ",";
            str += C.ToString() + ",";
            str += layer1 + ",";
            str += layer2;
            return str;
        }
        public float X = 0;
        public float Y = 0;
        public int R = 0;
        public int C = 0;
        public float L = 0;
        public string layer1;
        public string layer2;
        public IKeycap(string input)
        {
            string[] str = input.Split(',');
            R = Convert.ToInt32(str[3]);
            C = Convert.ToInt32(str[4]);
            X = Convert.ToSingle(str[0]);
            Y = Convert.ToSingle(str[1]);
            L = Convert.ToSingle(str[2]);
            layer1 = str[5]; layer2 = str[6];
        }
        public static Button UpdateButton(Button button)
        {
            //fix fond size
            if (button.Width < 40|| button.Height < 40|| button.Text.Length > 3)
            {
                button.Font = new Font(button.Font.SystemFontName, button.Font.Size - 1);
            } 
            if (button.Text.Length >5)
            {
                button.Font = new Font(button.Font.SystemFontName, button.Font.Size - 2);
            }        
            return button;
        }
        public Button CreateButton(int U1)
        {
            Button button = new Button();
            float x = X * U1 + 1;
            float y = Y * U1 + 1;
            button.Width = (int)(U1 * L) - 2;
            button.Height = (int)U1 - 2;
            if (L == 0.5)
            {
                button.Width = (int)U1 - 2;
                button.Height = (int)(U1 * 2) - 2;
            }
            button.Location = new Point((int)x, (int)y);
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.White;
            button.Font = new Font("Arial", 9);
            button.TextAlign = ContentAlignment.TopLeft;
            return button;
        }
    }
    public class IMatrix
    {
        public ICodes FuncCodes = new ICodes();
        public IMega32U4 FuncMega32U4 = new IMega32U4();
        public IColors FuncColors = new IColors();
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
        public int[] rgb_pos;//
        public int[] rgb_rainbow;//
        public int[] rgb_fixcolor;//
        public IMatrix() { }
        /// //////////
        public void MCU_Init(string MCU)
        {
            if (MCU == "__AVR_ATmega32U2__")
            {
                this.VENDOR_ID = 0x32C2;
                this.FLASH_END_ADDRESS = 0x7000;
                this.MAX_EEP = 0x03FF;
                MAX_DELAY = 0x0010;
            }
            if (MCU == "__AVR_ATmega32U4__")
            {
                this.VENDOR_ID = 0x32C4;
                this.FLASH_END_ADDRESS = 0x7000;
                this.MAX_EEP = 0x03FF;
                MAX_DELAY = 0x0010;
            }
        }
        public void WS2812_Init(int WS2812_pin, int WS2812_count, int Effect_count)
        {
            WS2812_PIN = WS2812_pin;
            WS2812_COUNT = WS2812_count;
            RGB_EFFECT_COUNT = Effect_count;
            rgb_pos = new int[WS2812_COUNT];
            rgb_rainbow = new int[WS2812_COUNT];
            rgb_fixcolor = new int[(WS2812_COUNT * 3)];
        }
        public void KeyCap_Init(string[] keycap)
        {
            if (keycap.Length <= 0) return;
            for (int i = 0; i < keycap.Length; i++)
            {
                key_caps.Add(new IKeycap(keycap[i]));
            }
        }
        public void EEP_Init()
        {
            int ADD_INDEX = 10;
            int ADD_ROW = ADD_INDEX + ROWS;
            int ADD_COL = ADD_ROW + COLS;
            int ADD_KEYS1 = ADD_COL + (ROWS * COLS);
            int ADD_KEYS2 = ADD_KEYS1 + (ROWS * COLS);
            int ADD_RGB_FIX = ADD_KEYS2 + (ROWS * COLS);
            int ADD_RGBTYPE = ADD_RGB_FIX + (WS2812_COUNT * 3);
            ADD_EEP = ADD_RGBTYPE + 6;
        }
        public void Matrix_Init(int[] R, int[] C)
        {
            row_pins = R; col_pins = C;
            ROWS = R.Length; COLS = C.Length;
            hexa_keys0 = new int[ROWS, COLS];
            hexa_keys1 = new int[ROWS, COLS];
            key_mask = new int[ROWS, COLS];
        }
        public List<Button> CreateButton(int U1)
        {
            List<Button> bus = new List<Button>();
            for (int i = 0; i < this.key_caps.Count; i++)
            {
                Button button = key_caps[i].CreateButton(U1);
                button.Name = i.ToString();
                bus.Add(button);
            }
            return bus;
        }
        public List<Button> CreateIOButton(int U1)
        {
            List<Button> bus = new List<Button>();
            if (ROWS == 0 && COLS == 0) return bus;
            for (int i = 0; i < this.row_pins.Length; i++)
            {
                Button button = new Button();
                float x = i * U1 + 1;
                float y = 0 * U1 + 1;
                button.Width = (int)U1 - 2;
                button.Height = (int)U1 - 2;
                button.Location = new Point((int)x, (int)y);
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = Color.White;
                button.Font = new Font("Courier10 BT", 8);
                button.TextAlign = ContentAlignment.TopLeft;
                button.Text = "r"+i.ToString() + "\r\n" + FuncMega32U4.GetIOName(row_pins[i]);
                bus.Add(button);
            }
            for (int i = 0; i < this.col_pins.Length; i++)
            {
                Button button = new Button();
                float x = i * U1 + 1;
                float y = 1 * U1 + 1;
                button.Width = (int)U1 - 2;
                button.Height = (int)U1 - 2;
                button.Location = new Point((int)x, (int)y);
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = Color.White;
                button.Font = new Font("Courier10 BT", 8);
                button.TextAlign = ContentAlignment.TopLeft;
                button.Text ="c"+i.ToString()+"\r\n"+ FuncMega32U4.GetIOName(col_pins[i]);
                bus.Add(button);
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
                    output += key_caps[i].ToString() + "\r\n";
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
    public partial class QMK61_ISO : IMatrix
    {
        public QMK61_ISO()
        {
            this.NAME = "QMK61_ISO";
            MCU_Init("__AVR_ATmega32U4__");
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK63_ISO : IMatrix
    {
        public QMK63_ISO()
        {
            this.NAME = "QMK63_ISO";
            MCU_Init("__AVR_ATmega32U4__");
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK64_ISO : IMatrix
    {
        public QMK64_ISO()
        {
            this.NAME = "QMK64_ISO";
            MCU_Init("__AVR_ATmega32U4__");
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK68_ISO : IMatrix
    {
        public QMK68_ISO()
        {
            this.NAME = "QMK68_ISO";
            MCU_Init("__AVR_ATmega32U4__");
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK84_ISO : IMatrix
    {
        public QMK84_ISO()
        {
            this.NAME = "QMK84_ISO";
            MCU_Init("__AVR_ATmega32U4__");
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK87_ISO : IMatrix
    {
        public QMK87_ISO()
        {
            this.NAME = "QMK87_ISO";
            MCU_Init("__AVR_ATmega32U4__");
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK100_ISO : IMatrix
    {
        public QMK100_ISO()
        {
            this.NAME = "QMK100_ISO";
            MCU_Init("__AVR_ATmega32U4__");
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK104_ISO : IMatrix
    {
        public QMK104_ISO()
        {
            this.NAME = "QMK104_ISO";
            MCU_Init("__AVR_ATmega32U4__");
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK108_ISO : IMatrix
    {
        public QMK108_ISO()
        {
            this.NAME = "QMK108_ISO";
            MCU_Init("__AVR_ATmega32U4__");
            KeyCap_Init(keycap);
        }
    }
}
