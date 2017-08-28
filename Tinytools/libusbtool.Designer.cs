namespace Tinytools
{
    partial class libusbtool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(libusbtool));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Driver = new System.Windows.Forms.ToolStripMenuItem();
            this.libusbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unicodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vidbox = new System.Windows.Forms.TextBox();
            this.pidbox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.textBox1.Location = new System.Drawing.Point(2, 147);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(385, 405);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(393, 147);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(385, 405);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(2, 31);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(776, 110);
            this.textBox3.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Driver,
            this.connectToolStripMenuItem,
            this.convertToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Driver
            // 
            this.Driver.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.libusbToolStripMenuItem,
            this.openToolStripMenuItem,
            this.uploadToolStripMenuItem1});
            this.Driver.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Driver.Name = "Driver";
            this.Driver.Size = new System.Drawing.Size(69, 24);
            this.Driver.Text = "Libusb";
            // 
            // libusbToolStripMenuItem
            // 
            this.libusbToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.libusbToolStripMenuItem.Name = "libusbToolStripMenuItem";
            this.libusbToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.libusbToolStripMenuItem.Text = "Driver";
            this.libusbToolStripMenuItem.Click += new System.EventHandler(this.libusbToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // uploadToolStripMenuItem1
            // 
            this.uploadToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uploadToolStripMenuItem1.Name = "uploadToolStripMenuItem1";
            this.uploadToolStripMenuItem1.Size = new System.Drawing.Size(137, 26);
            this.uploadToolStripMenuItem1.Text = "Upload";
            this.uploadToolStripMenuItem1.Click += new System.EventHandler(this.uploadToolStripMenuItem1_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.uploadToolStripMenuItem});
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.connectToolStripMenuItem.Text = "HidRaw";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(137, 26);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unicodeToolStripMenuItem,
            this.gBKToolStripMenuItem});
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.convertToolStripMenuItem.Text = "Convert";
            // 
            // unicodeToolStripMenuItem
            // 
            this.unicodeToolStripMenuItem.Name = "unicodeToolStripMenuItem";
            this.unicodeToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.unicodeToolStripMenuItem.Text = "Unicode";
            this.unicodeToolStripMenuItem.Click += new System.EventHandler(this.unicodeToolStripMenuItem_Click);
            // 
            // gBKToolStripMenuItem
            // 
            this.gBKToolStripMenuItem.Name = "gBKToolStripMenuItem";
            this.gBKToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.gBKToolStripMenuItem.Text = "GBK";
            this.gBKToolStripMenuItem.Click += new System.EventHandler(this.gBKToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(692, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "pid";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(600, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "vid";
            // 
            // vidbox
            // 
            this.vidbox.BackColor = System.Drawing.Color.White;
            this.vidbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vidbox.Location = new System.Drawing.Point(633, 6);
            this.vidbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vidbox.Multiline = true;
            this.vidbox.Name = "vidbox";
            this.vidbox.Size = new System.Drawing.Size(53, 20);
            this.vidbox.TabIndex = 19;
            this.vidbox.Text = "D850";
            this.vidbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pidbox
            // 
            this.pidbox.BackColor = System.Drawing.Color.White;
            this.pidbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pidbox.Location = new System.Drawing.Point(725, 6);
            this.pidbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pidbox.Multiline = true;
            this.pidbox.Name = "pidbox";
            this.pidbox.Size = new System.Drawing.Size(53, 20);
            this.pidbox.TabIndex = 18;
            this.pidbox.Text = "0102";
            this.pidbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // libusbtool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 555);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vidbox);
            this.Controls.Add(this.pidbox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "libusbtool";
            this.Text = "libusbtool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.libusbtool_FormClosing);
            this.Load += new System.EventHandler(this.libusbtool_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Driver;
        private System.Windows.Forms.ToolStripMenuItem libusbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unicodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gBKToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox vidbox;
        private System.Windows.Forms.TextBox pidbox;
    }
}