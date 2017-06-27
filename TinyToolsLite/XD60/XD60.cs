using System.Windows.Forms;

namespace TinyToolsLite
{
    public partial class GH60_Tools : Form
    {
        public class IMatrix
        {
            public IMatrix() { }
            public int ROWS;
            public int COLS;
            public byte[] rowPins;
            public byte[] colPins;
            public string[,] hexaKeys0;
            public string[,] hexaKeys1;
            public byte[,] keymask=new byte[5, 14];
        }

        class XD60_A : IMatrix
        {
            public XD60_A()
            {
                this.ROWS = 5;
                this.COLS = 14;
                this.rowPins = new byte[5] { 5, 6, 7, 8, 23 };
                this.colPins = new byte[14] { 21, 20, 24, 10, 9, 15, 22, 1, 4, 14, 13, 12, 11, 3 };
                this.hexaKeys0 = new string[5, 14] {
    { "Esc","1","2","3","4","5","6","7","8","9","0","-","=","<--"},
    { "Tab","Q","W","E","R","T","Y","U","I","O","P","[","]","、"},
    { "CapsLK","A","S","D","F","G","H","J","K","L",";","“","0x00","Enter"},
    { "Shift","0x00","Z","X","C","V","B","N","M",",",".","0x00", "/","Up"},
    { "Ctrl","FN","Alt","0x00","0x00","Space","0x00","/","Left","0x00","FN","rCtrl","Down","Right"}
                };
                this.hexaKeys1 = new string[5, 14]{
    { "~","F1","F2","F3","F4","F5","F6","F7","F8","F9","F10","F11","F12", "Delete"},
    { "Tab","p1","p2","p3","p4","p5","p6","p7","p8","p9","p0","p-","p+","、"},
    { "CapsLK", "mLeft","mMid","mRight","0x00","0x00","0x00","0x00","0x00","0x00","0x00","0x00","0x00","Enter"},
    { "Shift","0x00","NumLK","ScrLk","Insert","PrtSc","0x00","0x00","0x00","VOL-","VOL+","0x00","0x00","Up"},
    { "Ctrl","FN","Alt","0x00","0x00","Space","0x00","0x00","Left","0x00","FN","rCtrl","Down","Right"}
                };
                //keymask_bits:7-press 654-hexatype0 3-press 210-hexatype1
                //type: 1-key 2-modifykey 3-mousekey 4-systemkey 5-consumerkey 6-FN 7-consumerkeyAL,8-consumerkeyAC
                this.keymask = new byte[5, 14]{
    { 0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11},
    { 0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11},
    { 0x11,0x13,0x13,0x13,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x00,0x11},
    { 0x22,0x00,0x11,0x11,0x11,0x11,0x10,0x10,0x10,0x15,0x15,0x00,0x10,0x11},
    { 0x22,0x66,0x22,0x00,0x00,0x11,0x00,0x10,0x11,0x00,0x66,0x22,0x11,0x11}
                };

            }
        }
        class XD60_B : IMatrix
        {
            public XD60_B()
            {
                this.ROWS = 5;
                this.COLS = 14;
                this.rowPins = new byte[5] { 5, 6, 7, 8, 23 };
                this.colPins = new byte[14] { 21, 20, 24, 10, 9, 15, 22, 1, 4, 14, 13, 12, 11, 3 };
                this.hexaKeys0 = new string[5, 14] {
    { "Esc","1","2","3","4","5","6","7","8","9","0","-","=","<--"},
    { "Tab","Q","W","E","R","T","Y","U","I","O","P","[","]","、"},
    { "CapsLK","A","S","D","F","G","H","J","K","L",";","“","0x00","Enter"},
    { "Shift","0x00","Z","X","C","V","B","N","M",",",".","0x00", "/","Up"},
    { "Ctrl","FN","Alt","0x00","0x00","Space","0x00","/","Left","0x00","FN","rCtrl","Down","Right"}
                };
                this.hexaKeys1 = new string[5, 14]{
    { "~","F1","F2","F3","F4","F5","F6","F7","F8","F9","F10","F11","F12", "Delete"},
    { "Tab","p1","p2","p3","p4","p5","p6","p7","p8","p9","p0","p-","p+","、"},
    { "CapsLK", "mLeft","mMid","mRight","0x00","0x00","0x00","0x00","0x00","0x00","0x00","0x00","0x00","Enter"},
    { "Shift","0x00","NumLK","ScrLk","Insert","PrtSc","0x00","0x00","0x00","VOL-","VOL+","0x00","0x00","Up"},
    { "Ctrl","FN","Alt","0x00","0x00","Space","0x00","0x00","Left","0x00","FN","rCtrl","Down","Right"}
                };             
            }
        }
    }
}
