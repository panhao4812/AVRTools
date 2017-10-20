using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicateTools
{
   
    public partial class DuplicatTools : Form
    {
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
            {if (MD5 != "") return;
                try
                {
                    FileStream file = new FileStream(this.path_, FileMode.Open);
                    System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    byte[] retVal = md5.ComputeHash(file);
                    file.Close();
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < retVal.Length; i++)
                    {
                        sb.Append(retVal[i].ToString("x2"));
                    }
                    MD5= sb.ToString();
                }
                catch 
                {
                    MD5 = "";
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
                    if (this.MD5 == f1.MD5) return true;
                     return false;
                }
               
            }
        }
        List<M_File> files = new List<M_File>();
        List<int> dumplsit = new List<int>();
        List<int> newlist = new List<int>();
        public DuplicatTools()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(800, 600);
            this.dataGridView1.Size = new Size(390, 490);
            this.dataGridView2.Size = new Size(390, 490);
            this.dataGridView1.Location = new Point(0, 70);
            this.dataGridView2.Location = new Point(394, 70);
            this.textBox1.Location = new Point(0, 26);
            this.textBox1.Size = new Size(784, 42);
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
        private void basepathToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string path = OpenFolder();
            if (path == null || path == "") { return; }
            if (Directory.Exists(path)) textBox1.Text = path;
            List<string> path_ = new List<string>();         
            ListAllFiles(textBox1.Text, ref path_);
            if (path_.Count < 2) return;
            files.Clear();
            for (int i = 0; i < path_.Count; i++)
            {
                files.Add(new M_File(path_[i],path));
            }
            if (this.files.Count < 2) return;
            files.Sort(SortList);
            dumplsit = new List<int>();
            newlist = new List<int>();
            newlist.Add(0);
            for (int i = 1; i < this.files.Count; i++)
            {
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
            if (dumplsit.Count < 1) return;
            string path = OpenFolder();
            if (path == null || path == "") { return; }
            for(int i = 0; i < dumplsit.Count; i++)
            {
                try {
                    File.Move(files[dumplsit[i]].path_, path + files[dumplsit[i]].shortpath_);
                }
                catch { }
            }
        }
        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {for(int j=0;j< dataGridView1.Rows.Count; j++) { 
            dataGridView1.Rows[j].Selected = false;
            }
            int i = dumplsit[e.RowIndex];
            dataGridView1.Rows[i].Selected = true;
        }
    }
}
