namespace TinyToolsLite
{
    partial class GH60_Tools
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layer1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xD60ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layer2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.layer2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layer1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Box1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.KeyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyNameShort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keymask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Box2 = new System.Windows.Forms.TextBox();
            this.matrix1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.layer1ToolStripMenuItem,
            this.layer2ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1006, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.convertToolStripMenuItem,
            this.uploadToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.openToolStripMenuItem.Text = "HID";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(142, 26);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.convertToolStripMenuItem.Text = "Convert";
            this.convertToolStripMenuItem.Click += new System.EventHandler(this.convertToolStripMenuItem_Click);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // layer1ToolStripMenuItem
            // 
            this.layer1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xD60ToolStripMenuItem,
            this.layer2ToolStripMenuItem1});
            this.layer1ToolStripMenuItem.Name = "layer1ToolStripMenuItem";
            this.layer1ToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.layer1ToolStripMenuItem.Text = "XD60";
            // 
            // xD60ToolStripMenuItem
            // 
            this.xD60ToolStripMenuItem.Name = "xD60ToolStripMenuItem";
            this.xD60ToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.xD60ToolStripMenuItem.Text = "Matrix1";
            this.xD60ToolStripMenuItem.Click += new System.EventHandler(this.xD60ToolStripMenuItem_Click);
            // 
            // layer2ToolStripMenuItem1
            // 
            this.layer2ToolStripMenuItem1.Name = "layer2ToolStripMenuItem1";
            this.layer2ToolStripMenuItem1.Size = new System.Drawing.Size(140, 26);
            this.layer2ToolStripMenuItem1.Text = "Matrix2";
            this.layer2ToolStripMenuItem1.Click += new System.EventHandler(this.layer2ToolStripMenuItem1_Click);
            // 
            // layer2ToolStripMenuItem
            // 
            this.layer2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layer1ToolStripMenuItem1});
            this.layer2ToolStripMenuItem.Name = "layer2ToolStripMenuItem";
            this.layer2ToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.layer2ToolStripMenuItem.Text = "GH60";
            // 
            // layer1ToolStripMenuItem1
            // 
            this.layer1ToolStripMenuItem1.Name = "layer1ToolStripMenuItem1";
            this.layer1ToolStripMenuItem1.Size = new System.Drawing.Size(140, 26);
            this.layer1ToolStripMenuItem1.Text = "Matrix1";
            this.layer1ToolStripMenuItem1.Click += new System.EventHandler(this.layer1ToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(900, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "PID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(792, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "VID";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(833, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(55, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "CCCC";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(941, 5);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(55, 20);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "3415";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Box1
            // 
            this.Box1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Box1.BackColor = System.Drawing.Color.White;
            this.Box1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Box1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Box1.Location = new System.Drawing.Point(2, 409);
            this.Box1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Box1.Multiline = true;
            this.Box1.Name = "Box1";
            this.Box1.ReadOnly = true;
            this.Box1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Box1.Size = new System.Drawing.Size(330, 340);
            this.Box1.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.matrix1});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(6, 30);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersWidth = 55;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.Size = new System.Drawing.Size(1000, 185);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView2.ColumnHeadersHeight = 30;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c2});
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView2.Location = new System.Drawing.Point(0, 220);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView2.RowHeadersWidth = 55;
            this.dataGridView2.RowTemplate.Height = 30;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView2.Size = new System.Drawing.Size(1000, 185);
            this.dataGridView2.TabIndex = 20;
            this.dataGridView2.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellEnter);
            this.dataGridView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseClick);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyName,
            this.KeyNameShort,
            this.KeyCode,
            this.Keymask});
            this.dataGridView3.Location = new System.Drawing.Point(670, 409);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowTemplate.Height = 25;
            this.dataGridView3.RowTemplate.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(330, 338);
            this.dataGridView3.TabIndex = 21;
            this.dataGridView3.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellEnter);
            this.dataGridView3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView3_MouseClick);
            // 
            // KeyName
            // 
            this.KeyName.HeaderText = "KeyName";
            this.KeyName.Name = "KeyName";
            this.KeyName.ReadOnly = true;
            this.KeyName.Width = 150;
            // 
            // KeyNameShort
            // 
            this.KeyNameShort.HeaderText = "ShortName";
            this.KeyNameShort.Name = "KeyNameShort";
            this.KeyNameShort.ReadOnly = true;
            this.KeyNameShort.Width = 80;
            // 
            // KeyCode
            // 
            this.KeyCode.FillWeight = 60F;
            this.KeyCode.HeaderText = "KeyCode";
            this.KeyCode.Name = "KeyCode";
            this.KeyCode.ReadOnly = true;
            this.KeyCode.Width = 50;
            // 
            // Keymask
            // 
            this.Keymask.FillWeight = 60F;
            this.Keymask.HeaderText = "KeyMask";
            this.Keymask.Name = "Keymask";
            this.Keymask.ReadOnly = true;
            this.Keymask.Width = 30;
            // 
            // Box2
            // 
            this.Box2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Box2.BackColor = System.Drawing.Color.White;
            this.Box2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Box2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Box2.Location = new System.Drawing.Point(336, 409);
            this.Box2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Box2.Multiline = true;
            this.Box2.Name = "Box2";
            this.Box2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Box2.Size = new System.Drawing.Size(330, 340);
            this.Box2.TabIndex = 22;
            this.Box2.Text = "1 select Matrix on the title\r\n2 Click Hid--Open to connect device\r\n3 Click Hid--U" +
    "pload to upload eeprom\r\n4 Enjoy";
            // 
            // matrix1
            // 
            this.matrix1.HeaderText = "Matrix keys";
            this.matrix1.Name = "matrix1";
            this.matrix1.ReadOnly = true;
            this.matrix1.Width = 300;
            // 
            // c2
            // 
            this.c2.HeaderText = "Matrix FN";
            this.c2.Name = "c2";
            this.c2.ReadOnly = true;
            this.c2.Width = 300;
            // 
            // GH60_Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1006, 755);
            this.Controls.Add(this.Box2);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Box1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GH60_Tools";
            this.Text = "GH60_Tools";
            this.Load += new System.EventHandler(this.GH60_Tools_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layer1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layer2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xD60ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layer2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem layer1ToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox Box1;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TextBox Box2;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyNameShort;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keymask;
        private System.Windows.Forms.DataGridViewTextBoxColumn matrix1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2;
    }
}