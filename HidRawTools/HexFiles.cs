using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidRawTools
{
    class Hex
    {
        public Hex() {
            data = new List<ushort>();
        }
        public Hex(List<string>_data)
        {
            data = new List<ushort>();
            for(int i = 0; i < _data.Count; i++)
            {
                data.Add(Convert.ToUInt16(_data[i]));
            }
        }
        public Hex(string[] _data)
        {
            data = new List<ushort>();
            for (int i = 0; i < _data.Length; i++)
            {
                data.Add(Convert.ToUInt16(_data[i]));
            }
        }
        public List<ushort> data;
        public string Write(int address)
        {
            string output = "";
            for (int i = 0; i < data.Count; i += 8)
            {
                string buffer1 = ":10";
                buffer1 += Convert.ToString(address, 16).PadLeft(4, '0');
                buffer1 += "00";
                int regi = 0;
                for (int j = 0; j < 8; j++) {
                    int index = i  + j;
                    if (index < data.Count) { buffer1 += Convert.ToString(data[index], 16).PadLeft(4, '0'); }
                    else { buffer1 += "0000"; }                                      
                    }

                output += buffer1 + "\r\n";
                address += 16;
            }
            output += ":00000001FF";
            return output;
        }
        

    }
}
