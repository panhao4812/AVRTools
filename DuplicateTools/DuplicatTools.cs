using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicateTools
{   
    public partial class DuplicatTools : Form
    {
        Random rnd = new Random();
  
       public List<M_File> files = new List<M_File>();
        List<int> dumplsit = new List<int>();
        List<int> newlist = new List<int>();
        public void Clear()
        {
            this.textBox1.Text = "";
        }
        public void Print(string str)
        {
            this.textBox1.Text +=str+ "\r\n";
        }
        public DuplicatTools()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(800, 600);
            this.dataGridView1.Size = new Size(390, 430);
            this.dataGridView2.Size = new Size(390, 430);
            this.dataGridView1.Location = new Point(0, 130);
            this.dataGridView2.Location = new Point(394, 130);
            this.textBox1.Location = new Point(0, 26);
            this.textBox1.Size = new Size(784, 92);
            this.progressBar1.Location = new Point(0, 120);
            this.progressBar1.Size = new Size(784, 8);

            dataGridView1.ColumnCount = 1;
            dataGridView2.ColumnCount = 1;
         
        }
        public string OpenFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                return fbd.SelectedPath;
            }
            return null;
        }
        private int SortList(M_File a, M_File b) 
        {
            if (a == null&&b!=null) return -1;
            if (b == null&&a!=null) return 1;
            if (b == null && a == null) return 0;
            if (a.size_ > b.size_) 
            {
                return 1;
            }
            else if (a.size_ < b.size_)
            {
                return -1;
            }
            return 0;
        }         
        public static void ListAllFiles(string dir, ref List<string> output)
        {
            if (Directory.Exists(dir))
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                    {
                        output.Add(d);
                    }
                    else
                        ListAllFiles(d, ref output);
                }
            }
        }
        private void pathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = files.Count;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = files[i].shortpath_;
            }
            if (dumplsit.Count < 1) return;
            dataGridView2.RowCount = dumplsit.Count;
            for (int i = 0; i < dumplsit.Count; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = files[dumplsit[i]].shortpath_;
            }
        }
        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = files.Count;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = files[i].name_;
            }
            if (dumplsit.Count < 1) return;
            dataGridView2.RowCount = dumplsit.Count;
            for (int i = 0; i < dumplsit.Count; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = files[dumplsit[i]].name_;
            }
        }
        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = files.Count;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = files[i].size_;
            }
            if (dumplsit.Count < 1) return;
            dataGridView2.RowCount = dumplsit.Count;
            for (int i = 0; i < dumplsit.Count; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = files[dumplsit[i]].size_;
            }
        }     
        private void moveToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Clear();
            if (dumplsit.Count < 1) return;
            string path = OpenFolder();
            if (path == null || path == "") { return; }
            for(int i = 0; i < dumplsit.Count; i++)
            {
                try {
                    string pathout = path + files[dumplsit[i]].shortpath_;
                    string folderout=Path.GetDirectoryName(pathout);
                    string ext = Path.GetExtension(pathout);
                    string name = Path.GetFileNameWithoutExtension(pathout);
                    if (!Directory.Exists(folderout)) Directory.CreateDirectory(folderout);
                    int step = 1;
                    while(File.Exists(pathout))
                    {
                        pathout = folderout + "\\" + name + "-"+ step.ToString()+ ext;
                        step++;
                    }

                    File.Move(files[dumplsit[i]].path_, pathout);
                }
                catch (Exception ex) { 
                Print("==>"+files[dumplsit[i]].path_);
                Print(ex.ToString());
                    continue;                  
                }
            }
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            Print(files[e.RowIndex].path_);
        }
        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
            int i = dumplsit[e.RowIndex];
            Clear();
            Print(files[i].path_);
            dataGridView1.Rows[i].Selected = true;
            if(i>6)dataGridView1.FirstDisplayedScrollingRowIndex = i-6;
            else dataGridView1.FirstDisplayedScrollingRowIndex = 0;
        }
        private void basepathToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clear();
            string BasePath = OpenFolder();
            if (BasePath == null || BasePath == "") { return; }
            if (Directory.Exists(BasePath)) Print(BasePath);
            files.Clear();
            dumplsit.Clear();
            newlist.Clear();    
            List<string> path_ = new List<string>();
            ListAllFiles(BasePath, ref path_);
            if (path_.Count < 2) return;
            for (int i = 0; i < path_.Count; i++)
            {
                files.Add(new M_File(path_[i], BasePath));
            }
            if (this.files.Count < 2) return;          
            progressBar1.Value = 0;
            Print("Finish List Files");
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            files.Sort(SortList);
            newlist.Add(0);
            int total = this.files.Count - 1;
            for (int i = 1; i < this.files.Count; i++)
            {
                backgroundWorker1.ReportProgress((int)(i*100/total));
                bool sign = true;
                for (int j = 0; j < newlist.Count; j++)
                {
                    if (files[i].equalto(files[newlist[j]]))
                    {
                        sign = false;
                    }
                }
                if (sign) { newlist.Add(i); }
                else { dumplsit.Add(i); }
            }          
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
           
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Print("Finish Sort");
            dataGridView1.RowCount = files.Count;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = files[i].shortpath_;
            }
            dataGridView1.ClearSelection();
            if (dumplsit.Count < 1) return;
            dataGridView2.RowCount = dumplsit.Count;
            for (int i = 0; i < dumplsit.Count; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = files[dumplsit[i]].shortpath_;
            }
        }
        public static void ThreadProc()
        {
            PDFReader form = new PDFReader();//第2个窗体 
            form.ShowDialog();
        }
        private void testPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            */
            PDFReader form = new PDFReader();//第2个窗体 
            form.files = this.files;
            form.ShowDialog();
        }
    }
    public class M_File
    {
        public string path_ = "";
        public string shortpath_ = "";
        public string name_ = "";
        public long size_ = 0;
        public string MD5 = "";
        public M_File(string path, string Folder)
        {
            path_ = path;
            name_ = Path.GetFileName(path);
            FileInfo MyFileInfo = new FileInfo(path);
            size_ = MyFileInfo.Length;
            shortpath_ = path.Remove(0, Folder.Length);
        }
        public void GetMD5HashFromFile()
        {
            if (MD5 != "") return;
            try
            {
                FileStream file = new FileStream(this.path_, FileMode.Open, FileAccess.Read);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                MD5 = sb.ToString();
            }
            catch
            {
                MD5 = "null";
                return;
            }
        }
        public bool equalto(M_File f1)
        {
            if (f1.size_ != this.size_) return false;
            else
            {
                this.GetMD5HashFromFile();
                f1.GetMD5HashFromFile();
                if (this.MD5 == "null" || f1.MD5 == "null") return false;
                if (this.MD5 == f1.MD5) return true;
                return false;
            }

        }
    }
}
