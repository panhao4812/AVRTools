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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hidRawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lEDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.button1 = new System.Windows.Forms.Button();
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
            this.fileToolStripMenuItem,
            this.matrixToolStripMenuItem,
            this.uploadToolStripMenuItem,
            this.testKeyToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(834, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.Open_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // matrixToolStripMenuItem
            // 
            this.matrixToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iSOToolStripMenuItem});
            this.matrixToolStripMenuItem.Name = "matrixToolStripMenuItem";
            this.matrixToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.matrixToolStripMenuItem.Text = "Matrix";
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
            this.iSOToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.iSOToolStripMenuItem.Text = "ISO";
            // 
            // iSO60ToolStripMenuItem
            // 
            this.iSO60ToolStripMenuItem.Name = "iSO60ToolStripMenuItem";
            this.iSO60ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.iSO60ToolStripMenuItem.Text = "61";
            this.iSO60ToolStripMenuItem.Click += new System.EventHandler(this.ISO61_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem2.Text = "63";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ISO63_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem3.Text = "64";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ISO64_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem4.Text = "68";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.ISO68_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem5.Text = "84";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.ISO84_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem1.Text = "87";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ISO87_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem6.Text = "100";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.ISO100_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem7.Text = "104";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.ISO104_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem8.Text = "108";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.ISO108_Click);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gBKToolStripMenuItem});
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.uploadToolStripMenuItem.Text = "Upload";
            // 
            // gBKToolStripMenuItem
            // 
            this.gBKToolStripMenuItem.Name = "gBKToolStripMenuItem";
            this.gBKToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.gBKToolStripMenuItem.Text = "Matrix";
            this.gBKToolStripMenuItem.Click += new System.EventHandler(this.Upload_Click);
            // 
            // testKeyToolStripMenuItem
            // 
            this.testKeyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oNToolStripMenuItem});
            this.testKeyToolStripMenuItem.Name = "testKeyToolStripMenuItem";
            this.testKeyToolStripMenuItem.Size = new System.Drawing.Size(76, 21);
            this.testKeyToolStripMenuItem.Text = "TestKey";
            // 
            // oNToolStripMenuItem
            // 
            this.oNToolStripMenuItem.Name = "oNToolStripMenuItem";
            this.oNToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.oNToolStripMenuItem.Text = "ON";
            this.oNToolStripMenuItem.Click += new System.EventHandler(this.TestKey_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hidRawToolStripMenuItem,
            this.lEDToolStripMenuItem,
            this.rGBToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // hidRawToolStripMenuItem
            // 
            this.hidRawToolStripMenuItem.Name = "hidRawToolStripMenuItem";
            this.hidRawToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hidRawToolStripMenuItem.Text = "HidRaw";
            // 
            // lEDToolStripMenuItem
            // 
            this.lEDToolStripMenuItem.Name = "lEDToolStripMenuItem";
            this.lEDToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.lEDToolStripMenuItem.Text = "LED";
            // 
            // rGBToolStripMenuItem
            // 
            this.rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            this.rGBToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.rGBToolStripMenuItem.Text = "RGB";
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.hELPToolStripMenuItem.Text = "HELP";
            // 
            // SelectKeysPanel
            // 
            this.SelectKeysPanel.Controls.Add(this.US);
            this.SelectKeysPanel.Controls.Add(this.Macro);
            this.SelectKeysPanel.Controls.Add(this.IOPage);
            this.SelectKeysPanel.Controls.Add(this.ConsolePage);
            this.SelectKeysPanel.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectKeysPanel.Location = new System.Drawing.Point(0, 273);
            this.SelectKeysPanel.Margin = new System.Windows.Forms.Padding(2);
            this.SelectKeysPanel.Name = "SelectKeysPanel";
            this.SelectKeysPanel.SelectedIndex = 0;
            this.SelectKeysPanel.Size = new System.Drawing.Size(838, 250);
            this.SelectKeysPanel.TabIndex = 5;
            // 
            // US
            // 
            this.US.Location = new System.Drawing.Point(4, 26);
            this.US.Margin = new System.Windows.Forms.Padding(2);
            this.US.Name = "US";
            this.US.Padding = new System.Windows.Forms.Padding(2);
            this.US.Size = new System.Drawing.Size(830, 220);
            this.US.TabIndex = 0;
            this.US.Text = "US";
            this.US.UseVisualStyleBackColor = true;
            // 
            // Macro
            // 
            this.Macro.Location = new System.Drawing.Point(4, 26);
            this.Macro.Margin = new System.Windows.Forms.Padding(2);
            this.Macro.Name = "Macro";
            this.Macro.Padding = new System.Windows.Forms.Padding(2);
            this.Macro.Size = new System.Drawing.Size(830, 220);
            this.Macro.TabIndex = 1;
            this.Macro.Text = "Macro";
            this.Macro.UseVisualStyleBackColor = true;
            // 
            // IOPage
            // 
            this.IOPage.Location = new System.Drawing.Point(4, 26);
            this.IOPage.Margin = new System.Windows.Forms.Padding(2);
            this.IOPage.Name = "IOPage";
            this.IOPage.Padding = new System.Windows.Forms.Padding(2);
            this.IOPage.Size = new System.Drawing.Size(830, 220);
            this.IOPage.TabIndex = 2;
            this.IOPage.Text = "IO";
            this.IOPage.UseVisualStyleBackColor = true;
            // 
            // ConsolePage
            // 
            this.ConsolePage.Controls.Add(this.ConsoleBox);
            this.ConsolePage.Location = new System.Drawing.Point(4, 26);
            this.ConsolePage.Margin = new System.Windows.Forms.Padding(2);
            this.ConsolePage.Name = "ConsolePage";
            this.ConsolePage.Padding = new System.Windows.Forms.Padding(2);
            this.ConsolePage.Size = new System.Drawing.Size(830, 220);
            this.ConsolePage.TabIndex = 3;
            this.ConsolePage.Text = "Console";
            this.ConsolePage.UseVisualStyleBackColor = true;
            // 
            // ConsoleBox
            // 
            this.ConsoleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleBox.Location = new System.Drawing.Point(2, 2);
            this.ConsoleBox.Margin = new System.Windows.Forms.Padding(2);
            this.ConsoleBox.Multiline = true;
            this.ConsoleBox.Name = "ConsoleBox";
            this.ConsoleBox.Size = new System.Drawing.Size(826, 216);
            this.ConsoleBox.TabIndex = 0;
            // 
            // Schematic
            // 
            this.Schematic.Location = new System.Drawing.Point(4, 26);
            this.Schematic.Margin = new System.Windows.Forms.Padding(2);
            this.Schematic.Name = "Schematic";
            this.Schematic.Padding = new System.Windows.Forms.Padding(2);
            this.Schematic.Size = new System.Drawing.Size(830, 220);
            this.Schematic.TabIndex = 2;
            this.Schematic.Text = "Schematic";
            this.Schematic.UseVisualStyleBackColor = true;
            // 
            // Layer2
            // 
            this.Layer2.Location = new System.Drawing.Point(4, 26);
            this.Layer2.Margin = new System.Windows.Forms.Padding(2);
            this.Layer2.Name = "Layer2";
            this.Layer2.Padding = new System.Windows.Forms.Padding(2);
            this.Layer2.Size = new System.Drawing.Size(830, 220);
            this.Layer2.TabIndex = 1;
            this.Layer2.Text = "Layer2";
            this.Layer2.UseVisualStyleBackColor = true;
            // 
            // Layer1
            // 
            this.Layer1.Location = new System.Drawing.Point(4, 26);
            this.Layer1.Margin = new System.Windows.Forms.Padding(2);
            this.Layer1.Name = "Layer1";
            this.Layer1.Padding = new System.Windows.Forms.Padding(2);
            this.Layer1.Size = new System.Drawing.Size(830, 220);
            this.Layer1.TabIndex = 0;
            this.Layer1.Text = "Layer1";
            this.Layer1.UseVisualStyleBackColor = true;
            // 
            // MatrixPanel
            // 
            this.MatrixPanel.Controls.Add(this.Layer1);
            this.MatrixPanel.Controls.Add(this.Layer2);
            this.MatrixPanel.Controls.Add(this.Schematic);
            this.MatrixPanel.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatrixPanel.Location = new System.Drawing.Point(0, 25);
            this.MatrixPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MatrixPanel.Name = "MatrixPanel";
            this.MatrixPanel.SelectedIndex = 0;
            this.MatrixPanel.Size = new System.Drawing.Size(838, 250);
            this.MatrixPanel.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(386, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AVRKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 523);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MatrixPanel);
            this.Controls.Add(this.SelectKeysPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testKeyToolStripMenuItem;
        private System.Windows.Forms.TabControl SelectKeysPanel;
        private System.Windows.Forms.TabPage US;
        private System.Windows.Forms.TabPage Macro;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem gBKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lEDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.TabPage Schematic;
        private System.Windows.Forms.TabPage Layer2;
        private System.Windows.Forms.TabPage Layer1;
        private System.Windows.Forms.TabControl MatrixPanel;
        private System.Windows.Forms.TabPage IOPage;
        private System.Windows.Forms.TabPage ConsolePage;
        private System.Windows.Forms.TextBox ConsoleBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button button1;
    }
}

