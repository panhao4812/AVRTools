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
            MCU_Init("WS64",0x32C4, 0xF164);
            //KeyCap_Init(keycap);     
            int[] row_pins=new int[5]{ 8,7,6,5,24};
            int[] col_pins = new int[14] { 18, 19, 20, 21, 4, 16, 22, 11, 12, 13, 14, 15, 9, 10 };
            IO_Init(row_pins, col_pins, FuncMega32U4.GetIOIndex("F6"), 64, 3); 
        }
    }
}
