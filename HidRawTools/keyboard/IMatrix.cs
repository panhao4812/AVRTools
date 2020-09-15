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

        /// ///////////////////////////////////////////////////
        public byte[,] IhexaKeys0, Ikeymask;
        public void IUpdateMatrix()
        {
            if (Defaultkeycode.Length < 1) return;
            for (int i = 0; i < Defaultkeycode.Length; i++)
            {
                string str = Defaultkeycode[i];
                string[] strs = str.Split(',');
                int index = Convert.ToInt32(strs[0]);
                bool sign = false;
                int ii, jj, mask; mask = 0;
                for (ii = 0; ii < this.ROWS; ii++)
                {
                    for (jj = 0; jj < this.COLS; jj++)
                    {

                        int nameid = IKeycode.name2code(strs[1], out mask);
                        if (nameid == IhexaKeys0[ii, jj] && Ikeymask[ii, jj] == mask * 16)
                        {
                            keycap[index, 4] = jj; keycap[index, 3] = ii;
                            sign = true;
                        }
                        if (sign) break;
                    }
                    if (sign)
                    {
                        break;
                    }
                }
            }
        }
    }
    class QMK60_ISO : IMatrix
    {
        public QMK60_ISO(){
         this.Name = "QMK60_ISO";
            iniLayout();
            }
        const int keynum = 113;
        public void iniLayout()
        {
           
            keycode = new string[keynum * 2];
            for (int i = 0; i < keycode.Length; i++)
            {
                keycode[i] = "";
            }
            Defaultkeycode = new string[keynum];
            for (int i = 0; i < Defaultkeycode.Length; i++)
            {
                Defaultkeycode[i] = i.ToString();
            }
            this.keycap = new double[keynum, 5] {
        {0,0,1,0,0 },//0
        {1,0,1,0,1 },//1
        {2,0,1,0,2 },//2
        {3,0,1,0,3 },//3
        {4,0,1,0,4 },//4
        {5,0,1,0,5 },//5
        {6,0,1,0,6 },//6
        {7,0,1,0,7 },//7
        {8,0,1,0,8 },//8
        {9,0,1,0,9 },//9
        {10,0,1,0,10 },//10
        {11,0,1,0,11 },//11
        {12,0,1,0,12 },//12
        {13,0,1,0,13 },//13
        {13,0,2,0,14 },//14
        {14,0,1,0,14 },//15
        {0,1,1.5,1,0 },//16
        {1.5,1,1,1,1 },//17
        {2.5,1,1,1,2 },//18
        {3.5,1,1,1,3 },//19
        {4.5,1,1,1,4 },//20
        {5.5,1,1,1,5 },
        {6.5,1,1,1,6 },
        {7.5,1,1,1,7 },
        {8.5,1,1,1,8 },
        {9.5,1,1,1,9 },//25
        {10.5,1,1,1,10 },
        {11.5,1,1,1,11 },
        {12.5,1,1,1,12 },
        {13.5,1,1.5,1,13 },//29
        {0,2,1.75,2,0 },//30
        {1.75,2,1,2,1 },
        {2.75,2,1,2,2 },
        {3.75,2,1,2,3 },
        {4.75,2,1,2,4 },
        {5.75,2,1,2,5 },//35
        {6.75,2,1,2,6 },
        {7.75,2,1,2,7 },
        {8.75,2,1,2,8 },
        {9.75,2,1,2,9 },
        {10.75,2,1,2,10 },//40
        {11.75,2,1,2,11 },//41
        {12.75,2,1,2,12 },
        {12.75,2,2.25,2,13 },//43
        {13.75,2,1.25,2,13 },
        {0,3,2.25,3,0 },//45
        {0,3,1.25,3,0 },
        {1.25,3,1,3,1 },
        {2.25,3,1,3,2 },
        {3.25,3,1,3,3 },
        {4.25,3,1,3,4 },//50
        {5.25,3,1,3,5 },
        {6.25,3,1,3,6 },
        {7.25,3,1,3,7 },
        {8.25,3,1,3,8 },
        {9.25,3,1,3,9 },//55
        {10.25,3,1,3,10 },
        {11.25,3,1,3,11 },
        {12.25,3,2.75,3,13 },
        {12.25,3,1.75,3,13 },
        {12.25,3,1,3,12 },//60
        {13.25,3,1.75,3,13 },
        {14,3,1,3,12 },
        {0,3,2,3,0 },//63
        {0,3,1,3,0 },
        {1,3,1,3,1 },//65
        {2,3,1,3,2 },//66
        {3,3,1,3,3 },
        {4,3,1,3,4 },
        {5,3,1,3,5 },
        {6,3,1,3,6 },//70
        {7,3,1,3,7 },
        {8,3,1,3,8 },
        {9,3,1,3,9 },
        {10,3,1,3,10 },
        {11,3,1,3,11 },//75
        {11.25,3,1.75,3,11 },
        {12,3,1,3,12 },//77
        {13,3,1,3,13 },//78
        {13,3,2,3,13 },
        {14,3,1,3,14 },//80
        {0,4,1.75,4,0 },
        {0,4,1.25,4,0 },//
        {0,4,1.5,4,0 },
        {1.25,4,1.25,4,1 },//
        {1.5,4,1.5,4,1 },
        {1.5,4,1,4,1 },
        {1.75,4,1.25,4,1 },
        {2.5,4,1.25,4,2 },//
        {2.5,4,1.5,4,2 },
        {3,4,1.25,4,2 },
        {4.25,4,1.25,4,3 },
        {3.75,4,6.25,4,7 },//
        {3,4,7,4,5 },
        {4,4,7,4,5 },//
        {4,4,6,4,5 },
        {5.5,4,3,4,7 },
        {8.5,4,1.25,4,8 },
        {9.75,4,1.25,4,9 },
        {10,4,1,4,9 }, //
        {10,4,1.25,4,9 },
        {11,4,1,4,10 }, //
        {10,4,1.5,4,10 },
        {11.25,4,1.25,4,10 },
        {11.5,4,1,4,11 },//
        {11,4,1.5,4,11 },
        {12,4,1,4,11 },  //
        {12.5,4,1.25,4,12 },
        {12.5,4,1,4,12 },
        {13,4,1,4,12 }, //
        {13.75,4,1.25,4,13 },
        {13.5,4,1.5,4,13 },
        {14,4,1,4,13 }};
            RGB = null;
            //rgb如果是轴灯，前两个坐标值给0,0，如果没有则写null
        }
    }
    class QMK84_ISO : IMatrix
    {

    }
    class QMK96_ISO : IMatrix
    {

    }
    class QMK60_2Shift : IMatrix
    {

    }
    class QMK60_175Shift : IMatrix
    {

    }
    class QMK68_ISO : IMatrix
    {

    }
    class QMK87_ISO : IMatrix
    {

    }
}
