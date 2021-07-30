namespace AVRTools
{
    partial class AVRKeys
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AVRKeys));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu2 = new System.Windows.Forms.ToolStripMenuItem();
            this.iSOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iSO60ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.wS2812ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wS64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pG61ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Upload_Matrix = new System.Windows.Forms.ToolStripMenuItem();
            this.menu4 = new System.Windows.Forms.ToolStripMenuItem();
            this.TestKey_Enable = new System.Windows.Forms.ToolStripMenuItem();
            this.menu5 = new System.Windows.Forms.ToolStripMenuItem();
            this.hidRawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lEDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu6 = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectKeysPanel = new System.Windows.Forms.TabControl();
            this.US = new System.Windows.Forms.TabPage();
            this.Macro = new System.Windows.Forms.TabPage();
            this.IOPage = new System.Windows.Forms.TabPage();
            this.ConsolePage = new System.Windows.Forms.TabPage();
            this.ConsoleBox = new System.Windows.Forms.TextBox();
            this.Schematic = new System.Windows.Forms.TabPage();
            this.Layer2 = new System.Windows.Forms.TabPage();
            this.Layer1 = new System.Windows.Forms.TabPage();
            this.MatrixPanel = new System.Windows.Forms.TabControl();
            this.PidBox = new System.Windows.Forms.TextBox();
            this.VidBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SelectKeysPanel.SuspendLayout();
            this.ConsolePage.SuspendLayout();
            this.MatrixPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu1,
            this.menu2,
            this.menu3,
            this.menu4,
            this.menu5,
            this.menu6});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1112, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu1
            // 
            this.menu1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(65, 24);
            this.menu1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.Open_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // menu2
            // 
            this.menu2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iSOToolStripMenuItem,
            this.wS2812ToolStripMenuItem});
            this.menu2.Name = "menu2";
            this.menu2.Size = new System.Drawing.Size(87, 24);
            this.menu2.Text = "Matrix";
            // 
            // iSOToolStripMenuItem
            // 
            this.iSOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iSO60ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem1,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.iSOToolStripMenuItem.Name = "iSOToolStripMenuItem";
            this.iSOToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.iSOToolStripMenuItem.Text = "ISO";
            // 
            // iSO60ToolStripMenuItem
            // 
            this.iSO60ToolStripMenuItem.Name = "iSO60ToolStripMenuItem";
            this.iSO60ToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.iSO60ToolStripMenuItem.Text = "61";
            this.iSO60ToolStripMenuItem.Click += new System.EventHandler(this.ISO61_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem2.Text = "63";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ISO63_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem3.Text = "64";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ISO64_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem4.Text = "68";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.ISO68_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem5.Text = "84";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.ISO84_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem1.Text = "87";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ISO87_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem6.Text = "100";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.ISO100_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem7.Text = "104";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.ISO104_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(117, 26);
            this.toolStripMenuItem8.Text = "108";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.ISO108_Click);
            // 
            // wS2812ToolStripMenuItem
            // 
            this.wS2812ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wS64ToolStripMenuItem,
            this.pG61ToolStripMenuItem});
            this.wS2812ToolStripMenuItem.Name = "wS2812ToolStripMenuItem";
            this.wS2812ToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.wS2812ToolStripMenuItem.Text = "WS2812";
            // 
            // wS64ToolStripMenuItem
            // 
            this.wS64ToolStripMenuItem.Name = "wS64ToolStripMenuItem";
            this.wS64ToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.wS64ToolStripMenuItem.Text = "WS64";
            this.wS64ToolStripMenuItem.Click += new System.EventHandler(this.WS64_Click);
            // 
            // pG61ToolStripMenuItem
            // 
            this.pG61ToolStripMenuItem.Name = "pG61ToolStripMenuItem";
            this.pG61ToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.pG61ToolStripMenuItem.Text = "PG61";
            // 
            // menu3
            // 
            this.menu3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Upload_Matrix});
            this.menu3.Name = "menu3";
            this.menu3.Size = new System.Drawing.Size(87, 24);
            this.menu3.Text = "Upload";
            // 
            // Upload_Matrix
            // 
            this.Upload_Matrix.Name = "Upload_Matrix";
            this.Upload_Matrix.Size = new System.Drawing.Size(150, 26);
            this.Upload_Matrix.Text = "Matrix";
            this.Upload_Matrix.Click += new System.EventHandler(this.Upload_Click);
            // 
            // menu4
            // 
            this.menu4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestKey_Enable});
            this.menu4.Name = "menu4";
            this.menu4.Size = new System.Drawing.Size(98, 24);
            this.menu4.Text = "TestKey";
            // 
            // TestKey_Enable
            // 
            this.TestKey_Enable.Name = "TestKey_Enable";
            this.TestKey_Enable.Size = new System.Drawing.Size(106, 26);
            this.TestKey_Enable.Text = "ON";
            this.TestKey_Enable.Click += new System.EventHandler(this.TestKey_Click);
            // 
            // menu5
            // 
            this.menu5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hidRawToolStripMenuItem,
            this.lEDToolStripMenuItem,
            this.rGBToolStripMenuItem});
            this.menu5.Name = "menu5";
            this.menu5.Size = new System.Drawing.Size(76, 24);
            this.menu5.Text = "Tools";
            // 
            // hidRawToolStripMenuItem
            // 
            this.hidRawToolStripMenuItem.Name = "hidRawToolStripMenuItem";
            this.hidRawToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.hidRawToolStripMenuItem.Text = "HidRaw";
            // 
            // lEDToolStripMenuItem
            // 
            this.lEDToolStripMenuItem.Name = "lEDToolStripMenuItem";
            this.lEDToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.lEDToolStripMenuItem.Text = "LED";
            // 
            // rGBToolStripMenuItem
            // 
            this.rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            this.rGBToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.rGBToolStripMenuItem.Text = "RGB";
            // 
            // menu6
            // 
            this.menu6.Name = "menu6";
            this.menu6.Size = new System.Drawing.Size(65, 24);
            this.menu6.Text = "HELP";
            // 
            // SelectKeysPanel
            // 
            this.SelectKeysPanel.Controls.Add(this.US);
            this.SelectKeysPanel.Controls.Add(this.Macro);
            this.SelectKeysPanel.Controls.Add(this.IOPage);
            this.SelectKeysPanel.Controls.Add(this.ConsolePage);
            this.SelectKeysPanel.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectKeysPanel.Location = new System.Drawing.Point(0, 341);
            this.SelectKeysPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectKeysPanel.Name = "SelectKeysPanel";
            this.SelectKeysPanel.SelectedIndex = 0;
            this.SelectKeysPanel.Size = new System.Drawing.Size(1117, 312);
            this.SelectKeysPanel.TabIndex = 5;
            // 
            // US
            // 
            this.US.Location = new System.Drawing.Point(4, 29);
            this.US.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.US.Name = "US";
            this.US.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.US.Size = new System.Drawing.Size(1109, 279);
            this.US.TabIndex = 0;
            this.US.Text = "US";
            this.US.UseVisualStyleBackColor = true;
            // 
            // Macro
            // 
            this.Macro.Location = new System.Drawing.Point(4, 29);
            this.Macro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Macro.Name = "Macro";
            this.Macro.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Macro.Size = new System.Drawing.Size(1109, 279);
            this.Macro.TabIndex = 1;
            this.Macro.Text = "Macro";
            this.Macro.UseVisualStyleBackColor = true;
            // 
            // IOPage
            // 
            this.IOPage.Location = new System.Drawing.Point(4, 29);
            this.IOPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IOPage.Name = "IOPage";
            this.IOPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IOPage.Size = new System.Drawing.Size(1109, 279);
            this.IOPage.TabIndex = 2;
            this.IOPage.Text = "IO";
            this.IOPage.UseVisualStyleBackColor = true;
            // 
            // ConsolePage
            // 
            this.ConsolePage.Controls.Add(this.ConsoleBox);
            this.ConsolePage.Location = new System.Drawing.Point(4, 29);
            this.ConsolePage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConsolePage.Name = "ConsolePage";
            this.ConsolePage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConsolePage.Size = new System.Drawing.Size(1109, 279);
            this.ConsolePage.TabIndex = 3;
            this.ConsolePage.Text = "Console";
            this.ConsolePage.UseVisualStyleBackColor = true;
            // 
            // ConsoleBox
            // 
            this.ConsoleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleBox.Location = new System.Drawing.Point(3, 2);
            this.ConsoleBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConsoleBox.Multiline = true;
            this.ConsoleBox.Name = "ConsoleBox";
            this.ConsoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ConsoleBox.Size = new System.Drawing.Size(1103, 275);
            this.ConsoleBox.TabIndex = 0;
            this.ConsoleBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConsoleBox_KeyDown);
            // 
            // Schematic
            // 
            this.Schematic.Location = new System.Drawing.Point(4, 29);
            this.Schematic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Schematic.Name = "Schematic";
            this.Schematic.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Schematic.Size = new System.Drawing.Size(1109, 279);
            this.Schematic.TabIndex = 2;
            this.Schematic.Text = "Schematic";
            this.Schematic.UseVisualStyleBackColor = true;
            this.Schematic.Enter += new System.EventHandler(this.Schematic_Enter);
            // 
            // Layer2
            // 
            this.Layer2.Location = new System.Drawing.Point(4, 29);
            this.Layer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Layer2.Name = "Layer2";
            this.Layer2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Layer2.Size = new System.Drawing.Size(1109, 279);
            this.Layer2.TabIndex = 1;
            this.Layer2.Text = "Layer2";
            this.Layer2.UseVisualStyleBackColor = true;
            this.Layer2.Enter += new System.EventHandler(this.Layer2_Enter);
            // 
            // Layer1
            // 
            this.Layer1.Location = new System.Drawing.Point(4, 29);
            this.Layer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Layer1.Name = "Layer1";
            this.Layer1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Layer1.Size = new System.Drawing.Size(1109, 279);
            this.Layer1.TabIndex = 0;
            this.Layer1.Text = "Layer1";
            this.Layer1.UseVisualStyleBackColor = true;
            this.Layer1.Enter += new System.EventHandler(this.Layer1_Enter);
            // 
            // MatrixPanel
            // 
            this.MatrixPanel.Controls.Add(this.Layer1);
            this.MatrixPanel.Controls.Add(this.Layer2);
            this.MatrixPanel.Controls.Add(this.Schematic);
            this.MatrixPanel.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatrixPanel.Location = new System.Drawing.Point(0, 31);
            this.MatrixPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MatrixPanel.Name = "MatrixPanel";
            this.MatrixPanel.SelectedIndex = 0;
            this.MatrixPanel.Size = new System.Drawing.Size(1117, 312);
            this.MatrixPanel.TabIndex = 6;
            // 
            // PidBox
            // 
            this.PidBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PidBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PidBox.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PidBox.Location = new System.Drawing.Point(1051, 5);
            this.PidBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PidBox.Multiline = true;
            this.PidBox.Name = "PidBox";
            this.PidBox.ReadOnly = true;
            this.PidBox.Size = new System.Drawing.Size(53, 20);
            this.PidBox.TabIndex = 22;
            this.PidBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VidBox
            // 
            this.VidBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VidBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VidBox.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VidBox.Location = new System.Drawing.Point(956, 5);
            this.VidBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VidBox.Multiline = true;
            this.VidBox.Name = "VidBox";
            this.VidBox.ReadOnly = true;
            this.VidBox.Size = new System.Drawing.Size(53, 20);
            this.VidBox.TabIndex = 21;
            this.VidBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(921, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "VID";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1015, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "PID";
            // 
            // AVRKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1112, 654);
            this.Controls.Add(this.PidBox);
            this.Controls.Add(this.VidBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MatrixPanel);
            this.Controls.Add(this.SelectKeysPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AVRKeys";
            this.Text = "AVRKeys";
            this.Load += new System.EventHandler(this.AVRKeys_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.SelectKeysPanel.ResumeLayout(false);
            this.ConsolePage.ResumeLayout(false);
            this.ConsolePage.PerformLayout();
            this.MatrixPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu2;
        private System.Windows.Forms.ToolStripMenuItem menu3;
        private System.Windows.Forms.ToolStripMenuItem menu4;
        private System.Windows.Forms.TabControl SelectKeysPanel;
        private System.Windows.Forms.TabPage US;
        private System.Windows.Forms.TabPage Macro;
        private System.Windows.Forms.ToolStripMenuItem menu5;
        private System.Windows.Forms.ToolStripMenuItem hidRawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iSOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iSO60ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem Upload_Matrix;
        private System.Windows.Forms.ToolStripMenuItem TestKey_Enable;
        private System.Windows.Forms.ToolStripMenuItem lEDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu6;
        private System.Windows.Forms.TabPage Schematic;
        private System.Windows.Forms.TabPage Layer2;
        private System.Windows.Forms.TabPage Layer1;
        private System.Windows.Forms.TabControl MatrixPanel;
        private System.Windows.Forms.TabPage IOPage;
        private System.Windows.Forms.TabPage ConsolePage;
        private System.Windows.Forms.TextBox ConsoleBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox PidBox;
        private System.Windows.Forms.TextBox VidBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem wS2812ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wS64ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pG61ToolStripMenuItem;
    }
}

