using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HidRawTools
{
    public partial class HidRawTools : Form
    {
        IMatrix ActiveMatrix = null;
        public static double KeycapLength = 48;
        public static double KeycapOffset = 1;
        Button SelectKey1 = null;
        Button SelectKey2 = null;
        public int KeyCount = 0;
        int Layer = 0;
        string MatrixName = "";
        string CodeTemp = "";
        string IEncode = "GBK";
        byte RGB_Type = 0;
        Image PanelImage = null; Image TempImage = null;
        public bool keytest = false;
        public static HidDevice HidDevice;
        public void Clear()
        {
            ConsoleBox.Text = "";
        }
        public void Print(Object str)
        {
            ConsoleBox.Text += str.ToString() + "\r\n";
        }
        private void FileOpen()
        {
            String path = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                MatrixName = path;
            }
            else
            {
                return;
            }
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader srd = new StreamReader(fs);
                string str = srd.ReadLine();
                string[] chara = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (!loadmatrix(chara[1])) return;
                while (srd.Peek() != -1)
                {
                    str = srd.ReadLine();
                    chara = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (chara.Length == 3)
                    {
                        int index = Convert.ToInt32(chara[0]);
                        KeymapEditBox.SetItemChecked(index, true);
                        AddButton(index, IKeycode.shortname(chara[1]));
                        ActiveMatrix.keycode[index] = IKeycode.shortname(chara[1]);
                        ActiveMatrix.keycode[index + KeyCount] = IKeycode.shortname(chara[2]);
                    }
                    else if (chara.Length == 2)
                    {
                        int index = Convert.ToInt32(chara[0]);
                        KeymapEditBox.SetItemChecked(index, true);
                        AddButton(index, IKeycode.shortname(chara[1]));
                        ActiveMatrix.keycode[index] = IKeycode.shortname(chara[1]);
                    }
                    else if (chara.Length == 1)
                    {
                        int index = Convert.ToInt32(chara[0]);
                        KeymapEditBox.SetItemChecked(index, true);
                        AddButton(index, "");
                    }
                    else if (chara.Length == 5)
                    {
                        int index = Convert.ToInt32(chara[0]);
                        AddRGBButton(index, Convert.ToInt32(chara[1]),
                            Convert.ToInt32(chara[2]), Convert.ToInt32(chara[3]), Convert.ToInt32(chara[4]));
                    }
                }
                srd.Close();
                KeymapPanel.BackgroundImage = PanelImage;
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
                KeymapPanel.BackgroundImage = PanelImage;
            }
        }
        private void FileExport(string path)
        {
            try
            {
                if (ActiveMatrix == null)
                {
                    Clear();
                    Print("Open a keyboard templet and try again!");
                    return;
                }
                if (path == "")
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        path = sfd.FileName;
                        MatrixName = path;
                    }
                    else
                    {
                        return;
                    }
                }
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.SetLength(0);
                StreamWriter stream = new StreamWriter(fs);
                string output = "name," + ActiveMatrix.Name + "\r\n";
                output += "PrintFlashAddress," + ActiveMatrix.PrintFlashAddress.ToString() + "\r\n";
                output += "PrintEEpAddress ," + ActiveMatrix.PrintEEpAddress.ToString() + "\r\n";
                output += "eepromsize ," + ActiveMatrix.eepromsize.ToString() + "\r\n";
                output += "flashsize ," + ActiveMatrix.flashsize.ToString() + "\r\n";
                if (ActiveMatrix.rowPins != null && ActiveMatrix.colPins != null)
                {
                    output += "ROWS ," + ActiveMatrix.ROWS.ToString() + "\r\n";
                    for (int i = 0; i < ActiveMatrix.rowPins.Length; i++)
                    {
                        output += ActiveMatrix.rowPins[i].ToString();
                        if (i != ActiveMatrix.rowPins.Length - 1) output += ",";
                    }

                    output += "\r\n";
                    output += "COLS ," + ActiveMatrix.COLS.ToString() + "\r\n";
                    for (int i = 0; i < ActiveMatrix.colPins.Length; i++)
                    {
                        output += ActiveMatrix.colPins[i].ToString();
                        if (i != ActiveMatrix.colPins.Length - 1) output += ",";
                    }
                    output += "\r\n";
                }
                for (int i = 0; i < KeymapEditBox.CheckedIndices.Count; i++)
                {
                    int index = KeymapEditBox.CheckedIndices[i];
                    string str = i.ToString();
                    //  string[] chara = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    output += "\"" + str + "," +
                        IKeycode.longname(ActiveMatrix.keycode[index]) + "," +
                        IKeycode.longname(ActiveMatrix.keycode[index + KeyCount]) + "\"," + "\r\n";
                }

                for (int i = 0; i < KeymapEditBox.CheckedIndices.Count; i++)
                {
                    int index = KeymapEditBox.CheckedIndices[i];
                    string str = i.ToString();
                    output += "{" +
                            ActiveMatrix.keycap[index, 0].ToString() + "," +
                            ActiveMatrix.keycap[index, 1].ToString() + "," +
                            ActiveMatrix.keycap[index, 2].ToString() + "," +
                            ActiveMatrix.keycap[index, 3].ToString() + "," +
                            ActiveMatrix.keycap[index, 4].ToString() + "}," + @"// " + str + "\r\n";
                }
                if (ActiveMatrix.RGB != null)
                {
                    for (int i = ActiveMatrix.RGB.GetLowerBound(0); i <= ActiveMatrix.RGB.GetUpperBound(0); i++)
                    {
                        output += "{" + i.ToString() + "," +
                            ActiveMatrix.RGB[i, 2].ToString() + "," +
                            ActiveMatrix.RGB[i, 3].ToString() + "," +
                            ActiveMatrix.RGB[i, 4].ToString() + "," +
                            ActiveMatrix.RGB[i, 5].ToString() + "}," + "\r\n";
                    }
                }
                for (int i = 0; i < KeymapEditBox.CheckedIndices.Count; i++)
                {
                    int index = KeymapEditBox.CheckedIndices[i];
                    string str = i.ToString();
                    //  string[] chara = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    output += "\"" +
                         ActiveMatrix.keycap[index, 0].ToString() + "," +
                            ActiveMatrix.keycap[index, 1].ToString() + "," +
                            ActiveMatrix.keycap[index, 2].ToString() + "," +
                            ActiveMatrix.keycap[index, 3].ToString() + "," +
                            ActiveMatrix.keycap[index, 4].ToString() + "," + 
                    IKeycode.longname(ActiveMatrix.keycode[index]) + "," +
                        IKeycode.longname(ActiveMatrix.keycode[index + KeyCount]) + "\"," + "\r\n";
                }
                stream.Write(output);
                stream.Flush();
                stream.Close();
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        private void FileSave(string path)
        {
            try
            {
                if (ActiveMatrix == null)
                {
                    Clear();
                    Print("Open a keyboard templet and try again!");
                    return;
                }
                if (path == "")
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FilterIndex = 2;
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        path = sfd.FileName;
                        MatrixName = path;
                    }
                    else
                    {
                        return;
                    }
                }
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.SetLength(0);
                StreamWriter stream = new StreamWriter(fs);
                string output = "matrix," + ActiveMatrix.Name + "\r\n";
                for (int i = 0; i < KeymapEditBox.CheckedIndices.Count; i++)
                {
                    int index = KeymapEditBox.CheckedIndices[i];
                    string str = index.ToString();
                    //  string[] chara = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    output += str + "," + IKeycode.longname(ActiveMatrix.keycode[index])
                        + "," + IKeycode.longname(ActiveMatrix.keycode[index + KeyCount]) + "\r\n";
                }
                if (ActiveMatrix.RGB != null)
                {
                    for (int i = ActiveMatrix.RGB.GetLowerBound(0); i <= ActiveMatrix.RGB.GetUpperBound(0); i++)
                    {
                        output += i.ToString() + "," + ActiveMatrix.RGB[i, 2].ToString() + "," + ActiveMatrix.RGB[i, 3].ToString()
                            + "," + ActiveMatrix.RGB[i, 4].ToString() + "," + ActiveMatrix.RGB[i, 5].ToString() + "\r\n";
                    }
                }
                stream.Write(output);
                stream.Flush();
                stream.Close();
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        private void OpenDevice()
        {
            ushort vid = 0, pid = 0;
            if (VidBox.Text != "" && PidBox.Text != "")
            {
                vid = (ushort)Convert.ToInt32(VidBox.Text, 16);
                pid = (ushort)Convert.ToInt32(PidBox.Text, 16);
            }
            Clear();
            Print("0x" + vid.ToString("x"));
            Print("0x" + pid.ToString("x"));
            try
            {
                HidDevice[] HidDeviceList = HidDevices.Enumerate(vid, pid, Convert.ToUInt16(0xFF31)).ToArray();
                if (HidDeviceList == null || HidDeviceList.Length == 0)
                {
                    Print("Connect usb device. Try open again or select a keyboard templet!");
                    HidDevice = null;
                    return;
                }
                for (int i = 0; i < HidDeviceList.Length; i++)
                {
                    Print(HidDeviceList[i].DevicePath);                   
                }
                HidDevice = HidDeviceList[0];
                if (HidDevice == null)
                {
                    Print("Connect usb device. Try open again.");
                    return;
                }
                Print("Device OK");
                byte[] outdata = new byte[9]; outdata[0] = 0;
                outdata[1] = 0xFF; outdata[2] = 0xFA;
                HidDevice.Write(outdata); Thread.Sleep(100);
                // 0xFFFA是open的flag
                // 0xFFF1是upload的flag
                // 0xFFF2是end的flag
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }
        private void InitMatrix()
        {
            try
            {
                for (int i = 0; i < ActiveMatrix.Defaultkeycode.Length; i++)
                {
                    string str = ActiveMatrix.Defaultkeycode[i];
                    string[] chara = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (chara.Length == 3)
                    {
                        int index = Convert.ToInt32(chara[0]);
                        KeymapEditBox.SetItemChecked(index, true);
                        AddButton(index, IKeycode.shortname(chara[1]));
                        ActiveMatrix.keycode[index] = IKeycode.shortname(chara[1]);
                        ActiveMatrix.keycode[index + KeyCount] = IKeycode.shortname(chara[2]);
                    }
                    else if (chara.Length == 2)
                    {
                        int index = Convert.ToInt32(chara[0]);
                        KeymapEditBox.SetItemChecked(index, true);
                        AddButton(index, IKeycode.shortname(chara[1]));
                        ActiveMatrix.keycode[index] = IKeycode.shortname(chara[1]);
                    }
                    else if (chara.Length == 1)
                    {
                        int index = Convert.ToInt32(chara[0]);
                        KeymapEditBox.SetItemChecked(index, true);
                        AddButton(index, "");
                    }
                }
                if (ActiveMatrix.RGB != null)
                {
                    AddRGBButton();
                    RGB_Type = (Byte)ActiveMatrix.RGB[0, 2];
                    if ((RGB_Type & 0x0F) == 0x00)
                    {
                        this.editToolStripMenuItem.Text = "Default is FixedColor,click to change.";
                    }
                    else if ((RGB_Type & 0x0F) == 0x01)
                    {
                        this.editToolStripMenuItem.Text = "Default is Rainbow,click to change.";
                    }
                    else if ((RGB_Type & 0x0F) == 0x02)
                    {
                        this.editToolStripMenuItem.Text = "Default is PrintLight,click to change.";
                    }
                    if ((RGB_Type & 0xF0) == 0x10)
                    {
                        this.oNOFFToolStripMenuItem.Text = "Default is ON,click to turn off.";
                    }
                    else
                    {
                        this.oNOFFToolStripMenuItem.Text = "Default is OFF,click to turn on.";
                    }
                }
                KeymapPanel.BackgroundImage = PanelImage;
            }
            catch (Exception ex)
            {
                Print(ex.ToString());
                KeymapPanel.BackgroundImage = PanelImage;
            }
        }
        private void WriteToHex()
        {
            EncodePrintBox(IEncode);
            try
            {
                if (CodeTemp == "")
                {
                    Print("Nothing to write");
                    return;
                }
                string[] str = CodeTemp.Split(',');
                Hex hex1 = new Hex(str);
                string hex0 = "";
                if (ActiveMatrix == null) { Print("Select a keyboard templet!"); return; }
                else if (ActiveMatrix.Name == "XD004")
                {
                    hex0 = Encoding.Default.GetString(Properties.Resources.XD004);
                }
                else if (ActiveMatrix.Name == "Staryu")
                {
                    //hex0 = Encoding.Default.GetString(Properties.Resources.Staryu);                  
                }
                else { return; }
                if (ActiveMatrix.PrintFlashAddress == 0 || ActiveMatrix.flashsize == 0)
                {
                    Print("Keyboard can't Print Flash");
                    return;
                }
                hex0 += hex1.Write(ActiveMatrix.PrintFlashAddress, ActiveMatrix.flashsize);
                Print(ActiveMatrix.PrintFlashAddress);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "hex files (*.hex)|*.hex|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
                    fs.SetLength(0);
                    StreamWriter stream = new StreamWriter(fs);
                    stream.Write(hex0);
                    stream.Flush();
                    stream.Close();
                }
                else
                {
                    Print("Keyboard can't Print Flash");
                    return;
                }
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        private void EncodePrintBox(string _code)
        {
            try
            {
                //Clear();
                CodeTemp = "";
                char[] ch = PrintBox.Text.ToArray();
                if (ch == null || ch.Length == 0)
                {
                    CodeTemp += "0";
                    Print("Uploading RGB parameter!Nothing for printing!");
                    return;
                }
                // Print("English 0-127 GBK > " + 0x8080);
                int length = ch.Length;
                string output = "";
                int length2 = length;
                for (int j = 0; j < length; j++)
                {
                    if (ch[j] < 127 && ch[j] >= 0)
                    {
                        int code = IKeycode.ascii_to_scan_code_table[(int)ch[j]];
                        if (code != 0)
                        {
                            output += code.ToString();
                            if (j != length - 1) output += ",";
                        }
                        else
                        {
                            length2--;
                        }
                    }
                    else if (ch[j] <= 0xFFFF)
                    {
                        //汉字                     
                        ushort a3 = ConvertChinese1(ch[j], _code);
                        output += a3.ToString();
                        //Printhex((int)a3);
                        if (j != length - 1) output += ",";
                    }
                }
                CodeTemp += length2.ToString() + ",";
                CodeTemp += output;
                Print(CodeTemp);
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        private void UploadPrintBox()
        {
            OpenDevice();
            EncodePrintBox(IEncode);
            try
            {
                if (ActiveMatrix == null) return;
                Print("eepromsize=" + ActiveMatrix.eepromsize.ToString());
                if (CodeTemp == "")
                {
                    Print("Nothing to upload");
                    return;
                }

                string[] str = CodeTemp.Split(',');
                if (HidDevice == null)
                {
                    Print("Invalid device");
                    return;
                }
                byte[] outdata = new byte[9]; outdata[0] = 0;
                byte[] a = new byte[2];
                outdata[1] = 0xFF; outdata[2] = 0xF1;
                HidDevice.Write(outdata); Thread.Sleep(100);//汇报符的等待时间和灯的延迟有关，必须大于一个灯的循环。
                for (ushort i = 0; (i * 2 + 4 + ActiveMatrix.PrintEEpAddress) < ActiveMatrix.eepromsize; i += 3)
                {
                    a = BitConverter.GetBytes((ushort)(i * 2 + ActiveMatrix.PrintEEpAddress));
                    outdata[1] = a[0]; outdata[2] = a[1];
                    if ((i + 2) < str.Length)
                    {
                        ushort data3 = Convert.ToUInt16(str[i + 2]);
                        //Print(data3);
                        a = BitConverter.GetBytes(data3);
                        outdata[7] = a[0]; outdata[8] = a[1];
                    }
                    if ((i + 1) < str.Length)
                    {
                        ushort data2 = Convert.ToUInt16(str[i + 1]);
                        //Print(data2);
                        a = BitConverter.GetBytes(data2);
                        outdata[5] = a[0]; outdata[6] = a[1];
                    }
                    if (i < str.Length)
                    {
                        ushort data1 = Convert.ToUInt16(str[i]);
                        //Print(data1);
                        a = BitConverter.GetBytes(data1);
                        outdata[3] = a[0]; outdata[4] = a[1];
                    }
                    else { break; }
                    HidDevice.Write(outdata);
                    string outdatastr = "";
                    for (int k = 1; k < outdata.Length; k++)
                    {
                        outdatastr += outdata[k].ToString() + "/";
                    }
                    Print(outdatastr);
                    Thread.Sleep(100);
                }
                outdata[1] = 0xFF; outdata[2] = 0xF2;
                HidDevice.Write(outdata); Thread.Sleep(100);
                Print("Upload finished");
            }
            catch (Exception ex) { Print(ex.ToString()); }
        }
        public string EncodeMatrix()
        {
            int r, c, index;
            // try{
            for (r = 0; r < ActiveMatrix.ROWS; r++)
            {
                for (c = 0; c < ActiveMatrix.COLS; c++)
                {
                    ActiveMatrix.hexaKeys0[r, c] = "0x00";
                    ActiveMatrix.hexaKeys1[r, c] = "0x00";
                }
            }
            for (int i = 0; i < KeymapEditBox.CheckedIndices.Count; i++)
            {
                index = KeymapEditBox.CheckedIndices[i];
                string str0 = ActiveMatrix.keycode[index];
                string str1 = ActiveMatrix.keycode[index + KeyCount];
                r = (int)ActiveMatrix.keycap[index, 3];
                c = (int)ActiveMatrix.keycap[index, 4];
                ActiveMatrix.hexaKeys0[r, c] = str0;
                ActiveMatrix.hexaKeys1[r, c] = str1;
                Print(r.ToString() + "," + c.ToString() + ":" + str0 + " , " + str1);
            }
            //  }catch(Exception ex) { Print(ex.ToString());}
            try
            {
                ushort add1 = 5 * 2;
                ushort add2 = (ushort)(add1 + ActiveMatrix.ROWS);
                ushort add3 = (ushort)(add2 + ActiveMatrix.COLS);
                ushort add4 = (ushort)(add3 + ActiveMatrix.ROWS * ActiveMatrix.COLS);
                ushort add5 = (ushort)(add4 + ActiveMatrix.ROWS * ActiveMatrix.COLS);
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
                for (int i = 0; i < ActiveMatrix.ROWS; i++)
                {
                    output.Append(ActiveMatrix.rowPins[i]); output.Append(",");
                }
                for (int i = 0; i < ActiveMatrix.COLS; i++)
                {
                    output.Append(ActiveMatrix.colPins[i]); output.Append(",");
                }
                int[,] mask = new int[ActiveMatrix.ROWS, ActiveMatrix.COLS];
                for (r = 0; r < ActiveMatrix.ROWS; r++)
                {
                    for (c = 0; c < ActiveMatrix.COLS; c++)
                    {
                        string code1 = ActiveMatrix.hexaKeys0[r, c];
                        int mask1 = 0;
                        int code = IKeycode.name2code(code1, out mask1);
                        mask[r, c] += mask1 * 16;
                        output.Append(code); output.Append(",");
                    }
                }
                for (r = 0; r < ActiveMatrix.ROWS; r++)
                {
                    for (c = 0; c < ActiveMatrix.COLS; c++)
                    {
                        string code2 = ActiveMatrix.hexaKeys1[r, c];
                        int mask2 = 0;
                        int code = IKeycode.name2code(code2, out mask2);
                        mask[r, c] += mask2;
                        output.Append(code); output.Append(",");
                    }
                }
                for (r = 0; r < ActiveMatrix.ROWS; r++)
                {
                    for (c = 0; c < ActiveMatrix.COLS; c++)
                    {
                        output.Append(mask[r, c]); output.Append(",");
                    }
                }
                if (ActiveMatrix != null)
                {
                    if (ActiveMatrix.RGB != null && ActiveMatrix.RGB.GetUpperBound(0) >= 0)
                    {
                        for (int i = ActiveMatrix.RGB.GetLowerBound(0); i <= ActiveMatrix.RGB.GetUpperBound(0); i++)
                        {
                            output.Append(ActiveMatrix.RGB[i, 3]); output.Append(",");
                            output.Append(ActiveMatrix.RGB[i, 4]); output.Append(",");
                            output.Append(ActiveMatrix.RGB[i, 5]); output.Append(",");
                        }
                    }
                }
                output.Append(RGB_Type);
                return output.ToString();
            }
            catch
            {
                return "Select a Matrix.Try again.";
            }
        }
        private void UploadMatrix()
        {
            OpenDevice();
            try
            {
                if (HidDevice == null)
                {
                    //Clear();
                    Print("Invalid device");
                    return;
                }
                string codeTemp = EncodeMatrix();
                if (codeTemp == "")
                {
                    //Clear();
                    Print("Nothing to upload");
                    return;
                }
                string[] str = codeTemp.Split(',');

                //Clear();
                Print("Uploading");
                byte[] outdata = new byte[9]; outdata[0] = 0;
                outdata[1] = 0xFF; outdata[2] = 0xF1;
                HidDevice.Write(outdata); Thread.Sleep(100);
                for (ushort i = 0; i < ActiveMatrix.eepromsize; i += 6)
                {
                    outdata[0] = 0;
                    byte[] a = BitConverter.GetBytes(i);
                    outdata[1] = a[0]; outdata[2] = a[1];
                    if ((i + 5) < str.Length) { outdata[8] = Convert.ToByte(str[i + 5]); }
                    if ((i + 4) < str.Length) { outdata[7] = Convert.ToByte(str[i + 4]); }
                    if ((i + 3) < str.Length) { outdata[6] = Convert.ToByte(str[i + 3]); }
                    if ((i + 2) < str.Length) { outdata[5] = Convert.ToByte(str[i + 2]); }
                    if ((i + 1) < str.Length) { outdata[4] = Convert.ToByte(str[i + 1]); }
                    if (i < str.Length) { outdata[3] = Convert.ToByte(str[i]); }
                    else { break; }
                    HidDevice.Write(outdata);
                    string outdatastr = "";
                    outdatastr += outdata[1].ToString() + "/";
                    outdatastr += outdata[2].ToString() + "--";
                    outdatastr += outdata[3].ToString() + "/";
                    outdatastr += outdata[4].ToString() + "/";
                    outdatastr += outdata[5].ToString() + "/";
                    outdatastr += outdata[6].ToString() + "/";
                    outdatastr += outdata[7].ToString() + "/";
                    outdatastr += outdata[8].ToString();
                    Print(outdatastr);
                    Thread.Sleep(100);
                }
                outdata[1] = 0xFF; outdata[2] = 0xF2;
                HidDevice.Write(outdata); Thread.Sleep(100);
                Print("Upload finished");
            }
            catch (Exception ex) { Print(ex.ToString()); return; }
        }
        private void changeButton()
        {
            //Clear();
            TempImage = KeymapPanel.BackgroundImage;
            KeymapPanel.BackgroundImage = null;
            KeymapPanel.Controls.Clear();
            KeymapPanel.BackgroundImage = TempImage;
            for (int i = 0; i < KeymapEditBox.CheckedIndices.Count; i++)
            {
                string str = KeymapEditBox.CheckedIndices[i].ToString();
                int index = KeymapEditBox.CheckedIndices[i];
                AddButton(index, ActiveMatrix.keycode[index + Layer * KeyCount]);
            }
            AddRGBButton();
        }
        private void AddRGBButton(int i, Color c)
        {
            AddRGBButton(i, 0, c.R, c.G, c.B);
        }
        private void AddRGBButton(int i, int style, int R, int G, int B)
        {
            TempImage = KeymapPanel.BackgroundImage;
            KeymapPanel.BackgroundImage = null;
            if (ActiveMatrix == null) return;
            if (ActiveMatrix.RGB == null || ActiveMatrix.RGB.GetUpperBound(0) < 0) return;
            ActiveMatrix.RGB[i, 2] = style;
            ActiveMatrix.RGB[i, 3] = R; ActiveMatrix.RGB[i, 4] = G; ActiveMatrix.RGB[i, 5] = B;
            Button button = new Button();
            KeymapPanel.Controls.Add(button);
            Size size1 = new Size(25, 25);
            Point Point1 = new Point(ActiveMatrix.RGB[i, 0], ActiveMatrix.RGB[i, 1]);
            button.Size = size1;
            button.Location = Point1;
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.FromArgb(ActiveMatrix.RGB[i, 3], ActiveMatrix.RGB[i, 4], ActiveMatrix.RGB[i, 5]);
            if ((ActiveMatrix.RGB[i, 2] & (byte)0x0F) == 0) button.Text = i.ToString()+" c";
            else if ((ActiveMatrix.RGB[i, 2] & (byte)0x0F) == 0x01) { button.Text = "R"; }
            if ((ActiveMatrix.RGB[i, 2] & (byte)0xF0) == 0x10) { button.ForeColor = Color.Black; }
            else if ((ActiveMatrix.RGB[i, 2] & (byte)0xF0) == 0x00) { button.ForeColor = Color.Gray; }
            button.Font = new Font(button.Font.Name, 7);
            button.Name = i.ToString();
            button.TabStop = false; //禁用tab键 
            button.MouseDown += new MouseEventHandler(this.Layer1Button_MouseClick);
            KeymapPanel.BackgroundImage = TempImage;
        }
        private void AddRGBButton()
        {
            TempImage = KeymapPanel.BackgroundImage;
            KeymapPanel.BackgroundImage = null;
            if (ActiveMatrix == null) return;
            if (ActiveMatrix.RGB == null || ActiveMatrix.RGB.GetUpperBound(0) < 0) return;
            for (int i = ActiveMatrix.RGB.GetLowerBound(0); i <= ActiveMatrix.RGB.GetUpperBound(0); i++)
            {
                Button button = new Button();
                KeymapPanel.Controls.Add(button);
                Size size1 = new Size(25, 25);
                button.Font = new Font(button.Font.Name, 7);
                Point Point1 = new Point(ActiveMatrix.RGB[i, 0], ActiveMatrix.RGB[i, 1]);
                if (ActiveMatrix.Name == "CXT64"
                    || ActiveMatrix.Name == "KC84_LILILI"
                    || ActiveMatrix.Name == "KC84_Vem")
                {
                    //keycap led
                    Point1.Y -= 1; Point1.X -= 1;
                    size1 = new Size(18, 18);
                    button.Font = new Font(button.Font.Name, 6);
                }
                button.Size = size1;
                button.Location = Point1;
                button.FlatStyle = FlatStyle.Flat;
                if (ActiveMatrix.RGB[i, 2] == 0)
                {
                    button.BackColor = Color.FromArgb(ActiveMatrix.RGB[i, 3], ActiveMatrix.RGB[i, 4], ActiveMatrix.RGB[i, 5]);
                }
                else
                {
                    button.BackColor = Color.White;
                }
                if ((ActiveMatrix.RGB[i, 2] & (byte)0x0F) == 0) button.Text = i.ToString()+" c";//避免testkey识别冲突
                else if ((ActiveMatrix.RGB[i, 2] & (byte)0x0F) == 0x01) { button.Text = "R  c"; }
                else if ((ActiveMatrix.RGB[i, 2] & (byte)0x0F) == 0x02) { button.Text = "P  c"; }
                if ((ActiveMatrix.RGB[i, 2] & (byte)0xF0) == 0x10) { button.ForeColor = Color.Black; }
                else if ((ActiveMatrix.RGB[i, 2] & (byte)0xF0) == 0x00) { button.ForeColor = Color.FromArgb(200, 200, 200); }
                button.Name = i.ToString();
                button.BringToFront();
                button.TabStop = false; //禁用tab键 非必须
                button.MouseDown += new MouseEventHandler(this.Layer1Button_MouseClick);
            }
            KeymapPanel.BackgroundImage = TempImage;
        }
        private void AddButton(int index, string str)
        {
            TempImage = KeymapPanel.BackgroundImage;
            KeymapPanel.BackgroundImage = null;
            double x = ActiveMatrix.keycap[index, 0];
            double y = ActiveMatrix.keycap[index, 1];
            double length = ActiveMatrix.keycap[index, 2];
            double row = ActiveMatrix.keycap[index, 3];
            double col = ActiveMatrix.keycap[index, 4];
            Button button = new Button();
            KeymapPanel.Controls.Add(button);
            Size size1 = new Size((int)(KeycapLength * length - KeycapOffset * 2), (int)(KeycapLength - KeycapOffset * 2));
            Point Point1 = new Point(40 + (int)(x * KeycapLength), 100 + (int)(y * KeycapLength));
            if (x > 14)
            {
                Point1.X += 12;
            }
            if (y < 0)
            {
                Point1.Y -= 9;
            }
            if (length == 0.5)
            {
                size1.Width = (int)(KeycapLength - KeycapOffset * 2);
                size1.Height = (int)(KeycapLength * 2 - KeycapOffset * 2);
            }
            button.Size = size1;
            button.Location = Point1;
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.White;
            button.MouseDown += new MouseEventHandler(Layer0Button_MouseClick);
            button.Text = str;
            button.Name = index.ToString();
            // button.TabStop = false; //禁用tab键    
            KeymapPanel.BackgroundImage = TempImage;
        }
        private void AboutText()
        {
            Clear();
            /*
          Print("How to change key values and LED color:");
Print("1.Click on “Keyboard” button on the title bar, select “XD002”. (Keyboard->XD002)");
          Print("2.Click on the button icon that you want to change, and then select the desire key value from the chart at lower right corner.Click RGB on the title to change color config.If you want to use Rainbow LED, select RGB->Rainbow on the title bar.Otherwise, choose RGB->Fixed color.");
          Print("3.XD002 provide two layers(layer 0 and layer 1), you can click radio button on the title bar to alter the key values of another layer.");
          Print("4.Click on “Matrix” and select “Upload Matrix” to save changes.");
          Print("");
          Print("How to alter the printer content:");
          Print("1.Input the text content in Print Box.  The print box is at the lower left corner.");
          Print("2.Click on “Printer” on the title bar, select “Upload with GBK” to save the changes. Try to select “Upload with Unicode” If print garbled Korea.");
          Print("");

          Print("修改按键和灯");
          Print("");
          Print("步骤1: 点击标题栏keyboard，选择对应的键盘型号。"); Print("");
          Print("步骤2: 点击按键图标再点击右下角键值表编辑键值。");
          Print("点击RGB灯图标编辑灯的颜色。"); Print("");
          Print("步骤3: 点击Layer0/Layer1切换编辑第二层矩阵的键值。");
          Print("点击RGB编辑灯的模式。Rainbow表示彩虹渐变。FixColor表示单色。"); Print("");
          Print("步骤4: 点击标题栏Matrix上传修改内容。");
          Print("");
          Print("修改[打字机]内容");
          Print("");
          Print("步骤1: PrintBox输入中英文文本。"); Print("");
          Print("步骤2: 点击标题栏Printer - Upload with GBK上传修改内容。");
          Print("要切换中文编码则换成Printer - Upload with Unicode。");
          Print("");
          */
            Print("Click on “Keyboard” button on the title bar to select your templet."); Print("");
            Print("Detailed tutorial http://xiudi.fun/xd002/Manual.html "); Print("");

            Print("Enjoy!");
            Print("Author zian1  QQ 29347213");
        }
        public ushort ConvertChinese1(char str, string code)
        {
            string str2 = Convert.ToString(str);
            byte[] data; ushort a3;
            if (code == "GBK")
            {
                return ConvertChinese2(str, code);
            }
            else if (code == "Default")
            {
                data = Encoding.Default.GetBytes(str2);
                string Data1 = data[0].ToString("x"); if (Data1.Length == 1) Data1 = "0" + Data1;
                string Data2 = data[1].ToString("x"); if (Data2.Length == 1) Data2 = "0" + Data2;
                str2 = Data1 + Data2;
                a3 = Convert.ToUInt16(str2, 16);
                return a3;
            }
            else if (code == "Unicode")
            {
                data = Encoding.Unicode.GetBytes(str2);
            }
            else if (code == "UTF8")
            {
                data = Encoding.UTF8.GetBytes(str2);
            }
            else { Print("encoding error"); return 0; }
            string data1 = data[1].ToString("x"); if (data1.Length == 1) data1 = "0" + data1;
            string data2 = data[0].ToString("x"); if (data2.Length == 1) data2 = "0" + data2;
            str2 = data1 + data2;
            a3 = Convert.ToUInt16(str2, 16);
            return a3;
        }
        public ushort ConvertChinese2(char str, string code)
        {
            string str2 = Convert.ToString(str);
            byte[] data = Encoding.GetEncoding(code).GetBytes(str2);
            string Data1 = data[0].ToString("x"); if (Data1.Length == 1) Data1 = "0" + Data1;
            string Data2 = data[1].ToString("x"); if (Data2.Length == 1) Data2 = "0" + Data2;
            str2 = Data1 + Data2;
            ushort a3 = Convert.ToUInt16(str2, 16);
            return a3;
        }
        public void EnableControl()
        {
            VidBox.Enabled = true;
            PidBox.Enabled = true;
            menu1.Enabled = true;
            menu2.Enabled = true;
            menu3.Enabled = true;
            menu4.Enabled = true;
            menu5.Enabled = true;
            //menu6.Enabled = true;
            menu7.Enabled = true;
            KeycodeSelectionBox.Enabled = true;
            KeymapEditBox.Enabled = true;
            PrintBox.Enabled = true;
          //  ConsoleBox.Enabled = true;
        }
        public void DisableControl()
        {
            VidBox.Enabled = false;
            PidBox.Enabled = false;
            menu1.Enabled = false;
            menu2.Enabled = false;
            menu3.Enabled = false;
            menu4.Enabled = false;
            menu5.Enabled = false;
            //menu6.Enabled = false;
            menu7.Enabled = false;
            KeycodeSelectionBox.Enabled = false;
            KeymapEditBox.Enabled = false;
            PrintBox.Enabled = false;
           // ConsoleBox.Enabled = false;
        }

    }
}