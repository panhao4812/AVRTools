using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidRawTools
{
    public class IMatrix
    {
        public IMatrix() { }
        public int ROWS;
        public int COLS;
        public byte[] rowPins;
        public byte[] colPins;
        public string[,] hexaKeys0 = new string[5, 14];
        public string[,] hexaKeys1 = new string[5, 14];
        public byte[,] keymask = new byte[5, 14];
        public double[,] keycap;
        public string Name = "unamed";
        public string[] keycode;
        public string[] Defaultkeycode;
        public int[,] RGB = new int[0, 6];
        public ushort PrintFlashAddress = 0;
        public ushort PrintEEpAddress = 0;
        public ushort eepromsize = 0;
        public ushort flashsize = 0;
    }
}
