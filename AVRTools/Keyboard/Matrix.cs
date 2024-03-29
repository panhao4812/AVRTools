﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

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
        public double X = 0;
        public double Y = 0;
        public int R = 0;
        public int C = 0;
        public double L = 0;
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
            double L = button.Width / button.Height;
            if (L < 1) L = 1 / L;
            if (button.Width < 40 || button.Height < 40 )
            {
                button.Font = new Font(button.Font.SystemFontName, button.Font.Size - 1);
            }
            if (button.Text.Length/L >= 5)
            {
                button.Font = new Font(button.Font.SystemFontName, button.Font.Size - 2);
            }
            return button;
        }
        public Button CreateButton(int U1)
        {
            return CreateButton(U1, new SizeF(1, 1), new PointF(0, 0));
        }
        public Button CreateButton(int U1, SizeF scale, PointF Shift)
        {
            Button button = new Button();
            double x = (X + Shift.X) * U1*scale.Width + 1;
            double y = (Y + Shift.Y) * U1*scale.Height + 1;
            button.Width = (int)(U1 * scale.Width * L) - 2;
            button.Height = (int)(U1* scale.Height) - 2;
            if (L == 0.5)
            {
                button.Width = (int)(U1 * scale.Width) - 2;
                button.Height = (int)(U1 * scale.Height /L) - 2;
            }
            button.Location = new Point((int)x, (int)y);
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.White;
            button.Font = new Font("Arial", 9);
            button.TextAlign = ContentAlignment.TopLeft;
            button.TabStop = false;
            return button;
        }
    }
    public class IMatrix
    {
        public ICodes FuncCodes = new ICodes();
        public IMega32U4 FuncMega32U4 = new IMega32U4();
        public Color[] IOColors = IColors.GetIOColors();
        public List<IKeycap> key_caps = new List<IKeycap>();
        public List<IKeycap> RGB = new List<IKeycap>();
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
        public void MCU_Init(string Name, int VID, int PID)
        {
            this.NAME = Name;
            if (VID == 0x32C2 || VID == 0x32C4)
            {
                this.VENDOR_ID = VID; this.PRODUCT_ID = PID;
                this.FLASH_END_ADDRESS = 0x8000-0x0800-1;//32k-2k(boot)-1
                this.MAX_EEP = 0x0400-1;//1k-1
                MAX_DELAY = 0x0010;
            }
            if (VID == 0x16C2 || VID == 0x16C4)
            {
                this.VENDOR_ID = VID; this.PRODUCT_ID = PID;
                this.FLASH_END_ADDRESS = 0x4000 - 0x0400 - 1;//16k-1k(boot)-1
                this.MAX_EEP = 0x0200-1;//512-1
                MAX_DELAY = 0x0010;
            }
        }
        public void KeyCap_Init(string[] keycap)
        {
            if (keycap.Length <= 0) return;
            key_caps.Clear();
            for (int i = 0; i < keycap.Length; i++)
            {
                key_caps.Add(new IKeycap(keycap[i]));
            }
        }
        public void RGB_Init(string[] keycap)
        {
            if (rgb_pos == null) return;
            if (keycap.Length <= 0) return;
            RGB.Clear();
            for (int i = 0; i < keycap.Length; i++)
            {
                RGB.Add(new IKeycap(keycap[i]));
            }
            if(rgb_pos.Length == RGB.Count)
            {
                for (int i = 0; i < rgb_pos.Length; i++)
                {
                    RGB[i].layer1 = rgb_pos[i].ToString();

                    double maxX = 21;
                    //double maxY = 5 * 48 ;
                    int index = (int)(RGB[i].X / maxX * 254);
                    RGB[i].layer2 = index.ToString();
                }
            }
        }
        public void IO_Init(int[] R, int[] C, int WS2812_pin, int WS2812_count, int Effect_count)
        {
            row_pins = R; col_pins = C;
            ROWS = R.Length; COLS = C.Length;
            hexa_keys0 = new int[ROWS, COLS];
            hexa_keys1 = new int[ROWS, COLS];
            key_mask = new int[ROWS, COLS];
            WS2812_PIN = WS2812_pin;
            WS2812_COUNT = WS2812_count;
            RGB_EFFECT_COUNT = Effect_count;
            if(rgb_pos==null)rgb_pos = new int[WS2812_COUNT];
            rgb_rainbow = new int[WS2812_COUNT];
            rgb_fixcolor = new int[(WS2812_COUNT * 3)];
            for (int i = 0; i < rgb_fixcolor.Length; i++)
            {
                rgb_fixcolor[i] = 128;
            }
            ADD_EEP = 10 + ROWS + COLS + (ROWS * COLS * 3) + (WS2812_COUNT * 3) + 6;
        }
        public List<Button> CreateButton(int U1)
        {
            List<Button> bus = new List<Button>();
            if (this.key_caps.Count == 0) return bus;
            PointF shift=new PointF(0,0);
            for (int i = 0; i < this.key_caps.Count; i++)
            {
                if ((float)key_caps[i].Y < (-shift.Y)) { shift.Y = Math.Abs((float)key_caps[i].Y); }
                if ((float)key_caps[i].X < (-shift.X)) { shift.X = Math.Abs((float)key_caps[i].X); }
            }
                for (int i = 0; i < this.key_caps.Count; i++)
            {
                Button button = key_caps[i].CreateButton(U1, new SizeF(1, 1), shift);
                button.Name = i.ToString();
                bus.Add(button);
            }
            return bus;
        }
        public List<Button> CreateRGBButton(int U1)
        {
            List<Button> bus = new List<Button>();
            if (this.RGB.Count == 0) return bus;
            PointF shift = new PointF(0, 0);
            for (int i = 0; i < this.RGB.Count; i++)
            {
                if ((float)RGB[i].Y < (-shift.Y)) { shift.Y = Math.Abs((float)RGB[i].Y);}
                if ((float)RGB[i].X < (-shift.X)) { shift.X = Math.Abs((float)RGB[i].X);}
            }
            for (int i = 0; i < this.RGB.Count; i++)
            {
                Button button = RGB[i].CreateButton(U1,new SizeF(1,1),shift);
                button.Name = i.ToString();
                button.Font = new Font("Courier10 BT", 7);
                bus.Add(button);
            }
            return bus;
        }
        public List<Button> CreateIOButton(int U1)
        {
            List<Button> bus = new List<Button>();
            if (ROWS == 0 && COLS == 0) return bus;
            for (int i = 0; i < ROWS; i++)
            {
                Button button = new Button();
                double x = i * U1 + 1;
                double y = 0 * U1 + 1;
                button.Width = (int)U1 - 2;
                button.Height = (int)U1 - 2;
                button.Location = new Point((int)x, (int)y);
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = Color.White;
                button.Font = new Font("Courier10 BT", 8);
                button.TextAlign = ContentAlignment.TopLeft;
                button.Text = "r" + i.ToString() + "\r\n" + FuncMega32U4.GetIOName(row_pins[i]);
                button.TabStop = false;
                bus.Add(button);
            }
            
            for (int i = 0; i < COLS; i++)
            {
                Button button = new Button();
                double x = i * U1 + 1;
                double y = 1 * U1 + 1;
                button.Width = (int)U1 - 2;
                button.Height = (int)U1 - 2;
                button.Location = new Point((int)x, (int)y);
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = Color.White;
                button.Font = new Font("Courier10 BT", 8);
                button.TextAlign = ContentAlignment.TopLeft;
                button.Text = "c" + i.ToString() + "\r\n" + FuncMega32U4.GetIOName(col_pins[i]);
                button.BackColor = IOColors[i];
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
        public string ExportKeyCap()
        {
            if (this.key_caps.Count > 0)
            {
                string output = "";
                for (int i = 0; i < this.key_caps.Count; i++)
                {
                    output +="\""+ key_caps[i].ToString() + "\","+"\r\n";
                }
                return output;
            }
            else return "";
        }
        public void InitFromFile(string Path)
        {
            FileStream fs = new FileStream(Path, FileMode.Open);
            StreamReader srd = new StreamReader(fs); ;
            string datastring;
            string[] datastrings;
            bool keycap_sign = false;
            List<string> keycaps = new List<string>();
            while (srd.Peek() != -1)
            {
                string str = srd.ReadLine();
                if (keycap_sign)
                {
                    keycaps.Add(str);
                }
                switch (str)
                {
                    case "Name":
                        this.NAME = srd.ReadLine();
                        break;
                    case "VENDOR_ID":
                        this.VENDOR_ID = Convert.ToInt32(srd.ReadLine());
                        break;
                    case "PRODUCT_ID":
                        this.PRODUCT_ID = Convert.ToInt32(srd.ReadLine());
                        break;
                    case "WS2812_COUNT":
                        this.WS2812_COUNT = Convert.ToInt32(srd.ReadLine());
                        break;
                    case "WS2812_PIN":
                        this.WS2812_PIN = Convert.ToInt32(srd.ReadLine());
                        break;
                    case "RGB_EFFECT_COUNT":
                        this.RGB_EFFECT_COUNT = Convert.ToInt32(srd.ReadLine());
                        break;
                    case "RowPins":
                        datastring = srd.ReadLine();
                        if (datastring == "") { ROWS = 0; break; }
                        datastrings = datastring.Split(new Char[] { ',' },StringSplitOptions.RemoveEmptyEntries);
                        ROWS = datastrings.Length;
                        if (ROWS < 0) { ROWS = 0; break; }
                        row_pins = new int[ROWS];
                        for (int i = 0; i < ROWS; i++)
                        {
                            row_pins[i] = Convert.ToInt32(datastrings[i]);
                        }
                        break;
                    case "ColPins":
                        datastring = srd.ReadLine();
                        if (datastring=="") { COLS = 0; break; }
                        datastrings = datastring.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        COLS = datastrings.Length;
                        if (COLS < 0) { COLS = 0; break; }
                        col_pins = new int[COLS];
                        for (int i = 0; i < COLS; i++)
                        {
                            col_pins[i] = Convert.ToInt32(datastrings[i]);
                        }
                        break;
                    case "RGBPos":
                        datastring = srd.ReadLine();
                        if (datastring == "") { break; }
                        datastrings = datastring.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        int Count = datastrings.Length;
                        if (Count < 0) { break; }
                        rgb_pos = new int[Count];
                        for (int i = 0; i < Count; i++)
                        {
                            rgb_pos[i] = Convert.ToInt32(datastrings[i]);
                        }
                        break;
                    case "KeyCap":
                        keycap_sign = true;
                        break;
                }
            }
            srd.Close();
            MCU_Init(NAME, VENDOR_ID, PRODUCT_ID);
            if (row_pins != null && col_pins != null)
            {
                IO_Init(row_pins, col_pins, WS2812_PIN, WS2812_COUNT, RGB_EFFECT_COUNT);
            }
            KeyCap_Init(keycaps.ToArray());
            if (rgb_pos != null)
            {
                RGB_Init(keycaps.ToArray());
            }
        }
        public override string ToString()
        {
            string str = "";
            str += "Name" + "\r\n" + NAME + "\r\n";
            str += "VENDOR_ID" + "\r\n" + VENDOR_ID.ToString() + "\r\n";
            str += "PRODUCT_ID" + "\r\n" + PRODUCT_ID.ToString() + "\r\n";
            str += "WS2812_PIN" + "\r\n" + WS2812_PIN.ToString() + "\r\n";
            str += "WS2812_COUNT" + "\r\n" + WS2812_COUNT.ToString() + "\r\n";
            str += "RGB_EFFECT_COUNT" + "\r\n" + RGB_EFFECT_COUNT.ToString() + "\r\n";
            str += "RowPins" + "\r\n";
            for (int i = 0; i < ROWS; i++)
            {
                str += row_pins[i].ToString() + ",";
            }
            str += "\r\n";
            str += "ColPins" + "\r\n";
            for (int i = 0; i < COLS; i++)
            {
                str += col_pins[i].ToString() + ",";
            }
            if (rgb_pos != null)
            {
                str += "\r\n";
                str += "RGBPos" + "\r\n";          
                for (int i = 0; i < rgb_pos.Length; i++)
                {
                    str += rgb_pos[i].ToString() + ",";
                }            
            }
            str += "\r\n";
            str += "KeyCap" + "\r\n";
            str += PrintKeyCap();
            return str;
        }
        public string EncodeMatrix()
        {          
            if (ROWS == 0 && COLS == 0) return "";
            for (int i = 0; i < key_caps.Count; i++)
            {
                this.hexa_keys0[key_caps[i].R, key_caps[i].C] = FuncCodes.FromFullName( key_caps[i].layer1).KeyCode;
                key_mask[key_caps[i].R, key_caps[i].C] = FuncCodes.FromFullName(key_caps[i].layer1).KeyMask * 16;
                this.hexa_keys1[key_caps[i].R, key_caps[i].C] = FuncCodes.FromFullName(key_caps[i].layer2).KeyCode;
                key_mask[key_caps[i].R, key_caps[i].C] += FuncCodes.FromFullName(key_caps[i].layer2).KeyMask;
            }
            for (int i = 0; i < rgb_pos.Length; i++)
            {
                //int index = Convert.ToInt32(RGB[i].layer1);
                int colorIndex = Convert.ToInt32(RGB[i].layer2);
                rgb_fixcolor[i * 3] = IColors.Rcolors[colorIndex];
                rgb_fixcolor[i * 3+1] = IColors.Gcolors[colorIndex];
                rgb_fixcolor[i * 3+2] = IColors.Bcolors[colorIndex];
            }
                try
            {
                ushort add1 = 5 * 2;
                ushort add2 = (ushort)(add1 + ROWS);
                ushort add3 = (ushort)(add2 + COLS);
                ushort add4 = (ushort)(add3 + ROWS * COLS);
                ushort add5 = (ushort)(add4 + ROWS * COLS);
                StringBuilder output = new StringBuilder();
                byte[] a = BitConverter.GetBytes(add1);
                output.Append(a[0]); output.Append(","); output.Append(a[1]); output.Append(",");
                a = BitConverter.GetBytes(add2);
                output.Append(a[0]); output.Append(","); output.Append(a[1]); output.Append(",");
                a = BitConverter.GetBytes(add3);
                output.Append(a[0]); output.Append(","); output.Append(a[1]); output.Append(",");
                a = BitConverter.GetBytes(add4);
                output.Append(a[0]); output.Append(","); output.Append(a[1]); output.Append(",");
                a = BitConverter.GetBytes(add5);
                output.Append(a[0]); output.Append(","); output.Append(a[1]); output.Append(",");
                for (int i = 0; i < ROWS; i++)
                {
                    output.Append(row_pins[i]); output.Append(",");
                }
                for (int i = 0; i < COLS; i++)
                {
                    output.Append(col_pins[i]); output.Append(",");
                }
                for (int r = 0; r < ROWS; r++)
                {
                    for (int c = 0; c < COLS; c++)
                    {
                        output.Append(hexa_keys0[r, c]); output.Append(",");
                    }
                }
                for (int r = 0; r < ROWS; r++)
                {
                    for (int c = 0; c < COLS; c++)
                    {
                        output.Append(hexa_keys1[r, c]); output.Append(",");
                    }
                }
                for (int r = 0; r < ROWS; r++)
                {
                    for (int c = 0; c < COLS; c++)
                    {
                        output.Append(key_mask[r, c]); output.Append(",");
                    }
                }
                for (int i = 0; i < rgb_fixcolor.Length; i++)
                {
                    output.Append(rgb_fixcolor[i]); output.Append(",");
                }
                output.Append(RGB_TYPE);
                return output.ToString();
            }
            catch
            {
                return "";
            }
        }
    }
    public partial class PanelUS : IMatrix
    {
        public PanelUS()
        {
            this.NAME = "Panel104";
            KeyCap_Init(keycap);
        }
    }
    public partial class PanelMacro : IMatrix
    {
        public PanelMacro()
        {
            this.NAME = "PanelMacro";
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK61_ISO : IMatrix
    {
        public QMK61_ISO()
        {
            this.NAME = "QMK61_ISO";
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK63_ISO : IMatrix
    {
        public QMK63_ISO()
        {
            this.NAME = "QMK63_ISO";
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK64_ISO : IMatrix
    {
        public QMK64_ISO()
        {
            this.NAME = "QMK64_ISO";
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK68_ISO : IMatrix
    {
        public QMK68_ISO()
        {
            this.NAME = "QMK68_ISO";
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK84_ISO : IMatrix
    {
        public QMK84_ISO()
        {
            this.NAME = "QMK84_ISO";
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK87_ISO : IMatrix
    {
        public QMK87_ISO()
        {
            this.NAME = "QMK87_ISO";
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK100_ISO : IMatrix
    {
        public QMK100_ISO()
        {
            this.NAME = "QMK100_ISO";
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK104_ISO : IMatrix
    {
        public QMK104_ISO()
        {
            this.NAME = "QMK104_ISO";
            KeyCap_Init(keycap);
        }
    }
    public partial class QMK108_ISO : IMatrix
    {
        public QMK108_ISO()
        {
            this.NAME = "QMK108_ISO";
            KeyCap_Init(keycap);
        }
    }
}
