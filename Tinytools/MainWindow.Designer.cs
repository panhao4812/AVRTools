namespace Tinytools
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBuploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usbUploadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CMD = new System.Windows.Forms.Button();
            this.cd = new System.Windows.Forms.Button();
            this.flash = new System.Windows.Forms.Button();
            this.eeprom = new System.Windows.Forms.Button();
            this.fuse = new System.Windows.Forms.Button();
            this.flash_box = new System.Windows.Forms.TextBox();
            this.eeprom_box = new System.Windows.Forms.TextBox();
            this.cd_box = new System.Windows.Forms.TextBox();
            this.SEND = new System.Windows.Forms.Button();
            this.Main_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lfuse_box = new System.Windows.Forms.TextBox();
            this.hfuse_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.efuse_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.path_flash = new System.Windows.Forms.Button();
            this.path_cd = new System.Windows.Forms.Button();
            this.path_eeprom = new System.Windows.Forms.Button();
            this.c_box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.b_box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.p_box = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.p_box2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.verify = new System.Windows.Forms.Button();
            this.lock_box = new System.Windows.Forms.TextBox();
            this.lockbit = new System.Windows.Forms.Label();
            this.m_path_flash = new System.Windows.Forms.Button();
            this.m_flash_box = new System.Windows.Forms.TextBox();
            this.m_flash = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pstools_box = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.usbpcap = new System.Windows.Forms.Button();
            this.usbpcap_cd = new System.Windows.Forms.Button();
            this.BLFlash = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.VID_box = new System.Windows.Forms.TextBox();
            this.BLFlash_button = new System.Windows.Forms.Button();
            this.BLFlash_box = new System.Windows.Forms.TextBox();
            this.PID_box = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.avrdudeHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.uSBuploadToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.avrdudeHelpToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // uSBuploadToolStripMenuItem
            // 
            this.uSBuploadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usbUploadToolStripMenuItem1});
            this.uSBuploadToolStripMenuItem.Name = "uSBuploadToolStripMenuItem";
            this.uSBuploadToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.uSBuploadToolStripMenuItem.Text = "Tools";
            // 
            // usbUploadToolStripMenuItem1
            // 
            this.usbUploadToolStripMenuItem1.Name = "usbUploadToolStripMenuItem1";
            this.usbUploadToolStripMenuItem1.Size = new System.Drawing.Size(198, 26);
            this.usbUploadToolStripMenuItem1.Text = "UsbUploadTool";
            this.usbUploadToolStripMenuItem1.Click += new System.EventHandler(this.usbUploadToolStripMenuItem1_Click);
            // 
            // CMD
            // 
            this.CMD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMD.ForeColor = System.Drawing.Color.DarkOrange;
            this.CMD.Location = new System.Drawing.Point(516, 80);
            this.CMD.Name = "CMD";
            this.CMD.Size = new System.Drawing.Size(97, 40);
            this.CMD.TabIndex = 6;
            this.CMD.Text = "CMD";
            this.CMD.UseVisualStyleBackColor = true;
            this.CMD.Click += new System.EventHandler(this.CMD_Click);
            // 
            // cd
            // 
            this.cd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cd.ForeColor = System.Drawing.Color.DarkOrange;
            this.cd.Location = new System.Drawing.Point(516, 126);
            this.cd.Name = "cd";
            this.cd.Size = new System.Drawing.Size(97, 30);
            this.cd.TabIndex = 8;
            this.cd.Text = "CD";
            this.cd.UseVisualStyleBackColor = true;
            this.cd.Click += new System.EventHandler(this.cd_Click);
            // 
            // flash
            // 
            this.flash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flash.ForeColor = System.Drawing.Color.CadetBlue;
            this.flash.Location = new System.Drawing.Point(516, 217);
            this.flash.Name = "flash";
            this.flash.Size = new System.Drawing.Size(97, 30);
            this.flash.TabIndex = 11;
            this.flash.Text = "Flash";
            this.flash.UseVisualStyleBackColor = true;
            this.flash.Click += new System.EventHandler(this.flash_Click);
            // 
            // eeprom
            // 
            this.eeprom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eeprom.ForeColor = System.Drawing.Color.CadetBlue;
            this.eeprom.Location = new System.Drawing.Point(516, 253);
            this.eeprom.Name = "eeprom";
            this.eeprom.Size = new System.Drawing.Size(97, 30);
            this.eeprom.TabIndex = 12;
            this.eeprom.Text = "eeprom";
            this.eeprom.UseVisualStyleBackColor = true;
            this.eeprom.Click += new System.EventHandler(this.eeprom_Click);
            // 
            // fuse
            // 
            this.fuse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fuse.ForeColor = System.Drawing.Color.CadetBlue;
            this.fuse.Location = new System.Drawing.Point(516, 180);
            this.fuse.Name = "fuse";
            this.fuse.Size = new System.Drawing.Size(97, 30);
            this.fuse.TabIndex = 13;
            this.fuse.Text = "Fuse";
            this.fuse.UseVisualStyleBackColor = true;
            this.fuse.Click += new System.EventHandler(this.fuse_Click);
            // 
            // flash_box
            // 
            this.flash_box.BackColor = System.Drawing.SystemColors.Menu;
            this.flash_box.ForeColor = System.Drawing.Color.CadetBlue;
            this.flash_box.Location = new System.Drawing.Point(118, 216);
            this.flash_box.Multiline = true;
            this.flash_box.Name = "flash_box";
            this.flash_box.Size = new System.Drawing.Size(392, 30);
            this.flash_box.TabIndex = 18;
            // 
            // eeprom_box
            // 
            this.eeprom_box.BackColor = System.Drawing.SystemColors.Menu;
            this.eeprom_box.ForeColor = System.Drawing.Color.CadetBlue;
            this.eeprom_box.Location = new System.Drawing.Point(118, 252);
            this.eeprom_box.Multiline = true;
            this.eeprom_box.Name = "eeprom_box";
            this.eeprom_box.Size = new System.Drawing.Size(392, 30);
            this.eeprom_box.TabIndex = 19;
            // 
            // cd_box
            // 
            this.cd_box.BackColor = System.Drawing.SystemColors.Menu;
            this.cd_box.ForeColor = System.Drawing.Color.DarkOrange;
            this.cd_box.Location = new System.Drawing.Point(118, 126);
            this.cd_box.Multiline = true;
            this.cd_box.Name = "cd_box";
            this.cd_box.Size = new System.Drawing.Size(392, 30);
            this.cd_box.TabIndex = 14;
            // 
            // SEND
            // 
            this.SEND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SEND.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.SEND.Location = new System.Drawing.Point(516, 31);
            this.SEND.Name = "SEND";
            this.SEND.Size = new System.Drawing.Size(97, 40);
            this.SEND.TabIndex = 0;
            this.SEND.Text = "Send";
            this.SEND.UseVisualStyleBackColor = true;
            this.SEND.Click += new System.EventHandler(this.SEND_Click);
            // 
            // Main_box
            // 
            this.Main_box.Location = new System.Drawing.Point(12, 31);
            this.Main_box.Multiline = true;
            this.Main_box.Name = "Main_box";
            this.Main_box.Size = new System.Drawing.Size(498, 89);
            this.Main_box.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.CadetBlue;
            this.label1.Location = new System.Drawing.Point(132, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "lfuse";
            // 
            // lfuse_box
            // 
            this.lfuse_box.BackColor = System.Drawing.SystemColors.Menu;
            this.lfuse_box.ForeColor = System.Drawing.Color.CadetBlue;
            this.lfuse_box.Location = new System.Drawing.Point(183, 180);
            this.lfuse_box.Multiline = true;
            this.lfuse_box.Name = "lfuse_box";
            this.lfuse_box.Size = new System.Drawing.Size(70, 30);
            this.lfuse_box.TabIndex = 28;
            // 
            // hfuse_box
            // 
            this.hfuse_box.BackColor = System.Drawing.SystemColors.Menu;
            this.hfuse_box.ForeColor = System.Drawing.Color.CadetBlue;
            this.hfuse_box.Location = new System.Drawing.Point(312, 180);
            this.hfuse_box.Multiline = true;
            this.hfuse_box.Name = "hfuse_box";
            this.hfuse_box.Size = new System.Drawing.Size(70, 30);
            this.hfuse_box.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.CadetBlue;
            this.label2.Location = new System.Drawing.Point(262, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "hfuse";
            // 
            // efuse_box
            // 
            this.efuse_box.BackColor = System.Drawing.SystemColors.Menu;
            this.efuse_box.ForeColor = System.Drawing.Color.CadetBlue;
            this.efuse_box.Location = new System.Drawing.Point(440, 180);
            this.efuse_box.Multiline = true;
            this.efuse_box.Name = "efuse_box";
            this.efuse_box.Size = new System.Drawing.Size(70, 30);
            this.efuse_box.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.CadetBlue;
            this.label3.Location = new System.Drawing.Point(390, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "efuse";
            // 
            // path_flash
            // 
            this.path_flash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.path_flash.ForeColor = System.Drawing.Color.CadetBlue;
            this.path_flash.Location = new System.Drawing.Point(12, 216);
            this.path_flash.Name = "path_flash";
            this.path_flash.Size = new System.Drawing.Size(97, 30);
            this.path_flash.TabIndex = 23;
            this.path_flash.Text = "path";
            this.path_flash.UseVisualStyleBackColor = true;
            this.path_flash.Click += new System.EventHandler(this.path_flash_Click);
            // 
            // path_cd
            // 
            this.path_cd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.path_cd.ForeColor = System.Drawing.Color.DarkOrange;
            this.path_cd.Location = new System.Drawing.Point(12, 126);
            this.path_cd.Name = "path_cd";
            this.path_cd.Size = new System.Drawing.Size(97, 30);
            this.path_cd.TabIndex = 34;
            this.path_cd.Text = "path";
            this.path_cd.UseVisualStyleBackColor = true;
            this.path_cd.Click += new System.EventHandler(this.path_cd_Click);
            // 
            // path_eeprom
            // 
            this.path_eeprom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.path_eeprom.ForeColor = System.Drawing.Color.CadetBlue;
            this.path_eeprom.Location = new System.Drawing.Point(12, 252);
            this.path_eeprom.Name = "path_eeprom";
            this.path_eeprom.Size = new System.Drawing.Size(97, 30);
            this.path_eeprom.TabIndex = 22;
            this.path_eeprom.Text = "path";
            this.path_eeprom.UseVisualStyleBackColor = true;
            this.path_eeprom.Click += new System.EventHandler(this.path_eeprom_Click);
            // 
            // c_box
            // 
            this.c_box.BackColor = System.Drawing.SystemColors.Menu;
            this.c_box.ForeColor = System.Drawing.Color.CadetBlue;
            this.c_box.Location = new System.Drawing.Point(41, 289);
            this.c_box.Multiline = true;
            this.c_box.Name = "c_box";
            this.c_box.Size = new System.Drawing.Size(90, 30);
            this.c_box.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.CadetBlue;
            this.label4.Location = new System.Drawing.Point(12, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 35;
            this.label4.Text = "-c";
            // 
            // b_box
            // 
            this.b_box.BackColor = System.Drawing.SystemColors.Menu;
            this.b_box.ForeColor = System.Drawing.Color.CadetBlue;
            this.b_box.Location = new System.Drawing.Point(295, 289);
            this.b_box.Multiline = true;
            this.b_box.Name = "b_box";
            this.b_box.Size = new System.Drawing.Size(90, 30);
            this.b_box.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.CadetBlue;
            this.label5.Location = new System.Drawing.Point(266, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 37;
            this.label5.Text = "-b";
            // 
            // p_box
            // 
            this.p_box.BackColor = System.Drawing.SystemColors.Menu;
            this.p_box.ForeColor = System.Drawing.Color.CadetBlue;
            this.p_box.Location = new System.Drawing.Point(168, 289);
            this.p_box.Multiline = true;
            this.p_box.Name = "p_box";
            this.p_box.Size = new System.Drawing.Size(90, 30);
            this.p_box.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.CadetBlue;
            this.label6.Location = new System.Drawing.Point(139, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 39;
            this.label6.Text = "-p";
            // 
            // p_box2
            // 
            this.p_box2.BackColor = System.Drawing.SystemColors.Menu;
            this.p_box2.ForeColor = System.Drawing.Color.CadetBlue;
            this.p_box2.Location = new System.Drawing.Point(420, 289);
            this.p_box2.Multiline = true;
            this.p_box2.Name = "p_box2";
            this.p_box2.Size = new System.Drawing.Size(90, 30);
            this.p_box2.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.CadetBlue;
            this.label7.Location = new System.Drawing.Point(391, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "-P";
            // 
            // verify
            // 
            this.verify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verify.ForeColor = System.Drawing.Color.CadetBlue;
            this.verify.Location = new System.Drawing.Point(516, 289);
            this.verify.Name = "verify";
            this.verify.Size = new System.Drawing.Size(97, 30);
            this.verify.TabIndex = 43;
            this.verify.Text = "Verify";
            this.verify.UseVisualStyleBackColor = true;
            this.verify.Click += new System.EventHandler(this.verify_Click);
            // 
            // lock_box
            // 
            this.lock_box.BackColor = System.Drawing.SystemColors.Menu;
            this.lock_box.ForeColor = System.Drawing.Color.CadetBlue;
            this.lock_box.Location = new System.Drawing.Point(53, 180);
            this.lock_box.Multiline = true;
            this.lock_box.Name = "lock_box";
            this.lock_box.Size = new System.Drawing.Size(70, 30);
            this.lock_box.TabIndex = 45;
            // 
            // lockbit
            // 
            this.lockbit.AutoSize = true;
            this.lockbit.ForeColor = System.Drawing.Color.CadetBlue;
            this.lockbit.Location = new System.Drawing.Point(8, 188);
            this.lockbit.Name = "lockbit";
            this.lockbit.Size = new System.Drawing.Size(39, 15);
            this.lockbit.TabIndex = 44;
            this.lockbit.Text = "lock";
            // 
            // m_path_flash
            // 
            this.m_path_flash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_path_flash.ForeColor = System.Drawing.Color.MediumOrchid;
            this.m_path_flash.Location = new System.Drawing.Point(12, 339);
            this.m_path_flash.Name = "m_path_flash";
            this.m_path_flash.Size = new System.Drawing.Size(97, 30);
            this.m_path_flash.TabIndex = 48;
            this.m_path_flash.Text = "path";
            this.m_path_flash.UseVisualStyleBackColor = true;
            this.m_path_flash.Click += new System.EventHandler(this.m_path_flash_Click);
            // 
            // m_flash_box
            // 
            this.m_flash_box.BackColor = System.Drawing.SystemColors.Menu;
            this.m_flash_box.ForeColor = System.Drawing.Color.MediumOrchid;
            this.m_flash_box.Location = new System.Drawing.Point(118, 339);
            this.m_flash_box.Multiline = true;
            this.m_flash_box.Name = "m_flash_box";
            this.m_flash_box.Size = new System.Drawing.Size(392, 30);
            this.m_flash_box.TabIndex = 47;
            // 
            // m_flash
            // 
            this.m_flash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_flash.ForeColor = System.Drawing.Color.MediumOrchid;
            this.m_flash.Location = new System.Drawing.Point(516, 340);
            this.m_flash.Name = "m_flash";
            this.m_flash.Size = new System.Drawing.Size(97, 30);
            this.m_flash.TabIndex = 46;
            this.m_flash.Text = "Flash";
            this.m_flash.UseVisualStyleBackColor = true;
            this.m_flash.Click += new System.EventHandler(this.m_flash_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.MediumOrchid;
            this.label8.Location = new System.Drawing.Point(9, 322);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(607, 15);
            this.label8.TabIndex = 52;
            this.label8.Text = "--------------------------------micronucleus-------------------------------";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkCyan;
            this.label9.Location = new System.Drawing.Point(9, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(607, 15);
            this.label9.TabIndex = 53;
            this.label9.Text = "----------------------------------avrdude----------------------------------";
            // 
            // pstools_box
            // 
            this.pstools_box.BackColor = System.Drawing.SystemColors.Menu;
            this.pstools_box.ForeColor = System.Drawing.Color.RoyalBlue;
            this.pstools_box.Location = new System.Drawing.Point(118, 390);
            this.pstools_box.Multiline = true;
            this.pstools_box.Name = "pstools_box";
            this.pstools_box.Size = new System.Drawing.Size(392, 30);
            this.pstools_box.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.SlateBlue;
            this.label10.Location = new System.Drawing.Point(9, 372);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(607, 15);
            this.label10.TabIndex = 55;
            this.label10.Text = "----------------------------------pstools----------------------------------";
            // 
            // usbpcap
            // 
            this.usbpcap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usbpcap.ForeColor = System.Drawing.Color.RoyalBlue;
            this.usbpcap.Location = new System.Drawing.Point(12, 390);
            this.usbpcap.Name = "usbpcap";
            this.usbpcap.Size = new System.Drawing.Size(97, 30);
            this.usbpcap.TabIndex = 57;
            this.usbpcap.Text = "path";
            this.usbpcap.UseVisualStyleBackColor = true;
            this.usbpcap.Click += new System.EventHandler(this.usbpcap_Click);
            // 
            // usbpcap_cd
            // 
            this.usbpcap_cd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usbpcap_cd.ForeColor = System.Drawing.Color.RoyalBlue;
            this.usbpcap_cd.Location = new System.Drawing.Point(516, 390);
            this.usbpcap_cd.Name = "usbpcap_cd";
            this.usbpcap_cd.Size = new System.Drawing.Size(97, 30);
            this.usbpcap_cd.TabIndex = 63;
            this.usbpcap_cd.Text = "PSTools";
            this.usbpcap_cd.UseVisualStyleBackColor = true;
            this.usbpcap_cd.Click += new System.EventHandler(this.usbpcap_cd_Click);
            // 
            // BLFlash
            // 
            this.BLFlash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLFlash.ForeColor = System.Drawing.Color.SteelBlue;
            this.BLFlash.Location = new System.Drawing.Point(516, 441);
            this.BLFlash.Name = "BLFlash";
            this.BLFlash.Size = new System.Drawing.Size(97, 30);
            this.BLFlash.TabIndex = 66;
            this.BLFlash.Text = "Flash";
            this.BLFlash.UseVisualStyleBackColor = true;
            this.BLFlash.Click += new System.EventHandler(this.BLFlash_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.SteelBlue;
            this.label11.Location = new System.Drawing.Point(9, 423);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(607, 15);
            this.label11.TabIndex = 65;
            this.label11.Text = "--------------------------------HidBootFlash-------------------------------";
            // 
            // VID_box
            // 
            this.VID_box.BackColor = System.Drawing.SystemColors.Menu;
            this.VID_box.ForeColor = System.Drawing.Color.SteelBlue;
            this.VID_box.Location = new System.Drawing.Point(359, 441);
            this.VID_box.Multiline = true;
            this.VID_box.Name = "VID_box";
            this.VID_box.Size = new System.Drawing.Size(55, 30);
            this.VID_box.TabIndex = 64;
            // 
            // BLFlash_button
            // 
            this.BLFlash_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLFlash_button.ForeColor = System.Drawing.Color.SteelBlue;
            this.BLFlash_button.Location = new System.Drawing.Point(12, 441);
            this.BLFlash_button.Name = "BLFlash_button";
            this.BLFlash_button.Size = new System.Drawing.Size(97, 30);
            this.BLFlash_button.TabIndex = 70;
            this.BLFlash_button.Text = "path";
            this.BLFlash_button.UseVisualStyleBackColor = true;
            this.BLFlash_button.Click += new System.EventHandler(this.BLFlash_button_Click);
            // 
            // BLFlash_box
            // 
            this.BLFlash_box.BackColor = System.Drawing.SystemColors.Menu;
            this.BLFlash_box.ForeColor = System.Drawing.Color.SteelBlue;
            this.BLFlash_box.Location = new System.Drawing.Point(118, 441);
            this.BLFlash_box.Multiline = true;
            this.BLFlash_box.Name = "BLFlash_box";
            this.BLFlash_box.Size = new System.Drawing.Size(198, 30);
            this.BLFlash_box.TabIndex = 68;
            // 
            // PID_box
            // 
            this.PID_box.BackColor = System.Drawing.SystemColors.Menu;
            this.PID_box.ForeColor = System.Drawing.Color.SteelBlue;
            this.PID_box.Location = new System.Drawing.Point(455, 441);
            this.PID_box.Multiline = true;
            this.PID_box.Name = "PID_box";
            this.PID_box.Size = new System.Drawing.Size(55, 30);
            this.PID_box.TabIndex = 71;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.SteelBlue;
            this.label12.Location = new System.Drawing.Point(420, 449);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 15);
            this.label12.TabIndex = 72;
            this.label12.Text = "PID";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.SteelBlue;
            this.label13.Location = new System.Drawing.Point(322, 449);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 15);
            this.label13.TabIndex = 73;
            this.label13.Text = "VID";
            // 
            // avrdudeHelpToolStripMenuItem
            // 
            this.avrdudeHelpToolStripMenuItem.Name = "avrdudeHelpToolStripMenuItem";
            this.avrdudeHelpToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.avrdudeHelpToolStripMenuItem.Text = "avrdude Help";
            this.avrdudeHelpToolStripMenuItem.Click += new System.EventHandler(this.avrdudeHelpToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 483);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.PID_box);
            this.Controls.Add(this.BLFlash_button);
            this.Controls.Add(this.BLFlash_box);
            this.Controls.Add(this.BLFlash);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.VID_box);
            this.Controls.Add(this.usbpcap_cd);
            this.Controls.Add(this.usbpcap);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pstools_box);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_path_flash);
            this.Controls.Add(this.m_flash_box);
            this.Controls.Add(this.m_flash);
            this.Controls.Add(this.lock_box);
            this.Controls.Add(this.lockbit);
            this.Controls.Add(this.verify);
            this.Controls.Add(this.p_box2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.p_box);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.b_box);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.c_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.path_cd);
            this.Controls.Add(this.efuse_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hfuse_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lfuse_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.path_flash);
            this.Controls.Add(this.path_eeprom);
            this.Controls.Add(this.eeprom_box);
            this.Controls.Add(this.flash_box);
            this.Controls.Add(this.cd_box);
            this.Controls.Add(this.fuse);
            this.Controls.Add(this.eeprom);
            this.Controls.Add(this.flash);
            this.Controls.Add(this.cd);
            this.Controls.Add(this.CMD);
            this.Controls.Add(this.Main_box);
            this.Controls.Add(this.SEND);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "TinyTools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.Button CMD;
        private System.Windows.Forms.Button cd;
        private System.Windows.Forms.Button flash;
        private System.Windows.Forms.Button eeprom;
        private System.Windows.Forms.Button fuse;
        private System.Windows.Forms.TextBox flash_box;
        private System.Windows.Forms.TextBox eeprom_box;
        private System.Windows.Forms.TextBox cd_box;
        private System.Windows.Forms.Button SEND;
        private System.Windows.Forms.TextBox Main_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lfuse_box;
        private System.Windows.Forms.TextBox hfuse_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox efuse_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button path_flash;
        private System.Windows.Forms.Button path_cd;
        private System.Windows.Forms.Button path_eeprom;
        private System.Windows.Forms.TextBox c_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox b_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox p_box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox p_box2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button verify;
        private System.Windows.Forms.TextBox lock_box;
        private System.Windows.Forms.Label lockbit;
        private System.Windows.Forms.Button m_path_flash;
        private System.Windows.Forms.TextBox m_flash_box;
        private System.Windows.Forms.Button m_flash;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox pstools_box;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button usbpcap;
        private System.Windows.Forms.Button usbpcap_cd;
        private System.Windows.Forms.Button BLFlash;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox VID_box;
        private System.Windows.Forms.Button BLFlash_button;
        private System.Windows.Forms.TextBox BLFlash_box;
        private System.Windows.Forms.TextBox PID_box;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem uSBuploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usbUploadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem avrdudeHelpToolStripMenuItem;
    }
}