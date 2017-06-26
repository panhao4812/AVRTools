using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyToolsLite
{
    class XD60
    {
        public XD60() { }
        public int ROWS = 5;
        public int COLS = 14;
        public byte[] rowPins = { 5, 6, 7, 8, 23 };
        public byte[] colPins = { 21, 20, 24, 10, 9, 15, 22, 1, 4, 14, 13, 12, 11, 3 };
        public string[,] hexaKeys0 = {
    {"Esc","1","2","3","4","5","6","7","8","9","0","-","=","<--"},
    {"Tab","Q","W","E","R","T","Y","U","I","O","P","[","]","、"},
    {"CapsLK","A","S","D","F","G","H","J","K","L",";","“","0x00","Enter"},
    {"Shift","0x00","Z","X","C","V","B","N","M",",",".","0x00", "/","Up"},
    {"Ctrl","FN","Alt","0x00","0x00","Space","0x00","/","Left","0x00","FN","rCtrl","Down","Right"}};
        public string[,] hexaKeys1 = {
    {"~","F1","F2","F3","F4","F5","F6","F7","F8","F9","F10","F11","F12", "Delete"},
    {"Tab","p1","p2","p3","p4","p5","p6","p7","p8","p9","p0","p-","p+","、"},
    {"CapsLK", "mLeft","mMid","mRight","0x00","0x00","0x00","0x00","0x00","0x00","0x00","0x00","0x00","Enter"},
    {"Shift","0x00","NumLK","ScrLk","Insert","PrtSc","0x00","0x00","0x00","VOL-","VOL+","0x00","0x00","Up"},
    {"Ctrl","FN","Alt","0x00","0x00","Space","0x00","0x00","Left","0x00","FN","rCtrl","Down","Right"}};
        //keymask_bits:7-press 654-hexatype0 3-press 210-hexatype1
        //type: 1-key 2-modifykey 3-mousekey 4-systemkey 5-consumerkey 6-FN 7-consumerkeyAL,8-consumerkeyAC
        public byte[,] keymask ={
    {0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11},
    {0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11},
    {0x11,0x13,0x13,0x13,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x00,0x11},
    {0x22,0x00,0x11,0x11,0x11,0x11,0x10,0x10,0x10,0x15,0x15,0x00,0x10,0x11},
    {0x22,0x66,0x22,0x00,0x00,0x11,0x00,0x10,0x11,0x00,0x66,0x22,0x11,0x11}};
      


    }
}
