using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVRKeys.Keyboard
{
    public class ICode
    {
        public string FullName = "";
        public string ShortName = "";
        public int KeyCode = 0;
        public int Bios = 0;
        public int KeyMask = 0;
        
        public ICode(string input) {
            string[] str = input.Split(',');
            KeyCode = Convert.ToInt32(str[0]);           
            Bios = Convert.ToInt32(str[1]);
            KeyMask = Convert.ToInt32(str[2]);
            ShortName = str[3];
            FullName = str[4];
        }
    }
    public class ICodes
    {
        List<ICode> codes = new List<ICode>();
        public ICodes()
        {
            codes = new List<ICode>();
            for (int i = 0; i < codelist.Length; i++)
            {
                codes.Add(new ICode(codelist[i]));
            }
        }
        public string[] codelist = new String[25]
     {
"0,B0","1,B1","2,B2","3,B3","4,B7",
"5,D0","6,D1","7,D2","8,D3","9,C6",
"10,C7","11,D6","12,D7","13,B4","14,B5",
"15,B6","16,F7","17,F6","18,F5","19,F4",
"20,F1","21,F0","22,D4","23,D5","24,E6",
     };
        public ICode FromCode(int pin)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].KeyCode == pin) return codes[i];
            }
            return null;
        }
        public ICode FromFullName(string pin)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].FullName == pin) return codes[i];
            }
            return null;
        }
        public ICode FromShortName(string pin)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].ShortName == pin) return codes[i];
            }
            return null;
        }
        public ICode FromBios(int pin)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].Bios == pin) return codes[i];
            }
            return null;
        }
    }
    public class IIO
    {
        public string Name = "";
        public int Index = -1;
        public IIO(string input) {
            string[] str = input.Split(',');
            Index = Convert.ToInt32(str[0]);
            Name = str[1];
        }
    }
    public class IMega32U4
    {
        public List<IIO> codes ;
        public IMega32U4()
        {
            codes = new List<IIO>();
           for(int i = 0; i < pins.Length; i++)
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
        public  string GetIOName(int pin)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].Index == pin) return codes[i].Name;
            }
            return "";
        }
        public  int GetIOIndex(string pin)
        {
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].Name == pin) return codes[i].Index;
            }
            return -1;
        }
    }

}
