using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVRKeys.Keyboard
{
    class WS64:QMK64_ISO
    {
        public WS64()
        {
            this.NAME = "WS64";
            MCU_Init("__AVR_ATmega32U4__");
            //KeyCap_Init(keycap);
            this.PRODUCT_ID = 0xF164;        
            int[] row_pins=new int[5]{ 8,7,6,5,24};
            int[] col_pins = new int[14] { 18, 19, 20, 21, 4, 16, 22, 11, 12, 13, 14, 15, 9, 10 };
            Matrix_Init(row_pins, col_pins);
            WS2812_Init(FuncMega32U4.GetIOIndex("F6"), 64, 3);
            EEP_Init();
        }
    }
}
