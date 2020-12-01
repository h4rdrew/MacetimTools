namespace MacetimTools
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lb_h4S = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_ND = new System.Windows.Forms.GroupBox();
            this.cbx_NetworkName = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_custom = new System.Windows.Forms.Label();
            this.cb_Custom = new System.Windows.Forms.CheckBox();
            this.cb_DisableDevice = new System.Windows.Forms.CheckBox();
            this.lb_networkname = new System.Windows.Forms.Label();
            this.cbx_DeviceList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_Custom = new System.Windows.Forms.TextBox();
            this.gb_SPG = new System.Windows.Forms.GroupBox();
            this.pb_Firewall = new System.Windows.Forms.PictureBox();
            this.rbtn_FirewallFriends = new System.Windows.Forms.RadioButton();
            this.rbtn_Firewall = new System.Windows.Forms.RadioButton();
            this.rbtn_StopProcess = new System.Windows.Forms.RadioButton();
            this.gb_DCH = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbx_IPList = new System.Windows.Forms.ListBox();
            this.txb_IP = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gb_IPRules = new System.Windows.Forms.GroupBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.lb_Name = new System.Windows.Forms.Label();
            this.txb_Name = new System.Windows.Forms.TextBox();
            this.lb_IP = new System.Windows.Forms.Label();
            this.lb_gta5_directory = new System.Windows.Forms.Label();
            this.txb_GTADirectory = new System.Windows.Forms.TextBox();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.secondNumeric = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.minuteNumeric = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.hourNumeric = new System.Windows.Forms.NumericUpDown();
            this.button6 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_version = new System.Windows.Forms.Label();
            this.btn_CkUpdates = new System.Windows.Forms.Button();
            this.timerSP = new System.Windows.Forms.Timer(this.components);
            this.timerDD = new System.Windows.Forms.Timer(this.components);
            this.timerNM = new System.Windows.Forms.Timer(this.components);
            this.gb_ND.SuspendLayout();
            this.gb_SPG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Firewall)).BeginInit();
            this.gb_DCH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_IPRules.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minuteNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_h4S
            // 
            this.lb_h4S.AutoSize = true;
            this.lb_h4S.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_h4S.ForeColor = System.Drawing.Color.Yellow;
            this.lb_h4S.Location = new System.Drawing.Point(614, 360);
            this.lb_h4S.Name = "lb_h4S";
            this.lb_h4S.Size = new System.Drawing.Size(161, 24);
            this.lb_h4S.TabIndex = 14;
            this.lb_h4S.Text = "h4rdrew Studios";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Press ALT + F12 in game";
            // 
            // gb_ND
            // 
            this.gb_ND.Controls.Add(this.cbx_NetworkName);
            this.gb_ND.Controls.Add(this.label10);
            this.gb_ND.Controls.Add(this.lb_custom);
            this.gb_ND.Controls.Add(this.cb_Custom);
            this.gb_ND.Controls.Add(this.cb_DisableDevice);
            this.gb_ND.Controls.Add(this.lb_networkname);
            this.gb_ND.Controls.Add(this.cbx_DeviceList);
            this.gb_ND.Controls.Add(this.label4);
            this.gb_ND.Controls.Add(this.txb_Custom);
            this.gb_ND.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.gb_ND.ForeColor = System.Drawing.Color.Yellow;
            this.gb_ND.Location = new System.Drawing.Point(9, 140);
            this.gb_ND.Name = "gb_ND";
            this.gb_ND.Size = new System.Drawing.Size(227, 198);
            this.gb_ND.TabIndex = 17;
            this.gb_ND.TabStop = false;
            this.gb_ND.Text = "Network Disable";
            // 
            // cbx_NetworkName
            // 
            this.cbx_NetworkName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_NetworkName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_NetworkName.FormattingEnabled = true;
            this.cbx_NetworkName.Location = new System.Drawing.Point(6, 48);
            this.cbx_NetworkName.Name = "cbx_NetworkName";
            this.cbx_NetworkName.Size = new System.Drawing.Size(210, 21);
            this.cbx_NetworkName.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(223, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "------------------------------------------------------------------------";
            // 
            // lb_custom
            // 
            this.lb_custom.AutoSize = true;
            this.lb_custom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_custom.Location = new System.Drawing.Point(22, 72);
            this.lb_custom.Name = "lb_custom";
            this.lb_custom.Size = new System.Drawing.Size(42, 13);
            this.lb_custom.TabIndex = 24;
            this.lb_custom.Text = "Custom";
            // 
            // cb_Custom
            // 
            this.cb_Custom.AutoSize = true;
            this.cb_Custom.BackColor = System.Drawing.Color.Black;
            this.cb_Custom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Custom.Location = new System.Drawing.Point(6, 72);
            this.cb_Custom.Name = "cb_Custom";
            this.cb_Custom.Size = new System.Drawing.Size(15, 14);
            this.cb_Custom.TabIndex = 23;
            this.cb_Custom.UseVisualStyleBackColor = false;
            this.cb_Custom.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cb_DisableDevice
            // 
            this.cb_DisableDevice.AutoSize = true;
            this.cb_DisableDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_DisableDevice.Location = new System.Drawing.Point(5, 125);
            this.cb_DisableDevice.Name = "cb_DisableDevice";
            this.cb_DisableDevice.Size = new System.Drawing.Size(110, 17);
            this.cb_DisableDevice.TabIndex = 8;
            this.cb_DisableDevice.Text = "Disable by device";
            this.cb_DisableDevice.UseVisualStyleBackColor = true;
            this.cb_DisableDevice.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // lb_networkname
            // 
            this.lb_networkname.AutoSize = true;
            this.lb_networkname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_networkname.ForeColor = System.Drawing.Color.Yellow;
            this.lb_networkname.Location = new System.Drawing.Point(7, 29);
            this.lb_networkname.Name = "lb_networkname";
            this.lb_networkname.Size = new System.Drawing.Size(97, 16);
            this.lb_networkname.TabIndex = 6;
            this.lb_networkname.Text = "Network name:";
            // 
            // cbx_DeviceList
            // 
            this.cbx_DeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_DeviceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_DeviceList.FormattingEnabled = true;
            this.cbx_DeviceList.Location = new System.Drawing.Point(6, 143);
            this.cbx_DeviceList.Name = "cbx_DeviceList";
            this.cbx_DeviceList.Size = new System.Drawing.Size(211, 21);
            this.cbx_DeviceList.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(6, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Press ALT + F9 in game";
            // 
            // txb_Custom
            // 
            this.txb_Custom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_Custom.Location = new System.Drawing.Point(6, 88);
            this.txb_Custom.Name = "txb_Custom";
            this.txb_Custom.Size = new System.Drawing.Size(210, 21);
            this.txb_Custom.TabIndex = 5;
            // 
            // gb_SPG
            // 
            this.gb_SPG.Controls.Add(this.pb_Firewall);
            this.gb_SPG.Controls.Add(this.rbtn_FirewallFriends);
            this.gb_SPG.Controls.Add(this.label1);
            this.gb_SPG.Controls.Add(this.rbtn_Firewall);
            this.gb_SPG.Controls.Add(this.rbtn_StopProcess);
            this.gb_SPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_SPG.ForeColor = System.Drawing.Color.Yellow;
            this.gb_SPG.Location = new System.Drawing.Point(8, 12);
            this.gb_SPG.Name = "gb_SPG";
            this.gb_SPG.Size = new System.Drawing.Size(227, 122);
            this.gb_SPG.TabIndex = 16;
            this.gb_SPG.TabStop = false;
            this.gb_SPG.Text = "Solo Public Game";
            // 
            // pb_Firewall
            // 
            this.pb_Firewall.Image = global::MacetimTools.Properties.Resources.check;
            this.pb_Firewall.Location = new System.Drawing.Point(122, 71);
            this.pb_Firewall.Name = "pb_Firewall";
            this.pb_Firewall.Size = new System.Drawing.Size(20, 20);
            this.pb_Firewall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Firewall.TabIndex = 23;
            this.pb_Firewall.TabStop = false;
            this.pb_Firewall.Visible = false;
            // 
            // rbtn_FirewallFriends
            // 
            this.rbtn_FirewallFriends.AutoSize = true;
            this.rbtn_FirewallFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_FirewallFriends.ForeColor = System.Drawing.Color.Yellow;
            this.rbtn_FirewallFriends.Location = new System.Drawing.Point(6, 74);
            this.rbtn_FirewallFriends.Name = "rbtn_FirewallFriends";
            this.rbtn_FirewallFriends.Size = new System.Drawing.Size(110, 17);
            this.rbtn_FirewallFriends.TabIndex = 22;
            this.rbtn_FirewallFriends.TabStop = true;
            this.rbtn_FirewallFriends.Text = "Firewall w/Friends";
            this.rbtn_FirewallFriends.UseVisualStyleBackColor = true;
            this.rbtn_FirewallFriends.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rbtn_Firewall
            // 
            this.rbtn_Firewall.AutoSize = true;
            this.rbtn_Firewall.Enabled = false;
            this.rbtn_Firewall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_Firewall.ForeColor = System.Drawing.Color.Yellow;
            this.rbtn_Firewall.Location = new System.Drawing.Point(6, 51);
            this.rbtn_Firewall.Name = "rbtn_Firewall";
            this.rbtn_Firewall.Size = new System.Drawing.Size(60, 17);
            this.rbtn_Firewall.TabIndex = 21;
            this.rbtn_Firewall.TabStop = true;
            this.rbtn_Firewall.Text = "Firewall";
            this.rbtn_Firewall.UseVisualStyleBackColor = true;
            this.rbtn_Firewall.Visible = false;
            this.rbtn_Firewall.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbtn_StopProcess
            // 
            this.rbtn_StopProcess.AutoSize = true;
            this.rbtn_StopProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_StopProcess.ForeColor = System.Drawing.Color.Yellow;
            this.rbtn_StopProcess.Location = new System.Drawing.Point(6, 28);
            this.rbtn_StopProcess.Name = "rbtn_StopProcess";
            this.rbtn_StopProcess.Size = new System.Drawing.Size(87, 17);
            this.rbtn_StopProcess.TabIndex = 20;
            this.rbtn_StopProcess.TabStop = true;
            this.rbtn_StopProcess.Text = "Stop process";
            this.rbtn_StopProcess.UseVisualStyleBackColor = true;
            this.rbtn_StopProcess.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // gb_DCH
            // 
            this.gb_DCH.Controls.Add(this.pictureBox1);
            this.gb_DCH.Controls.Add(this.label7);
            this.gb_DCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.gb_DCH.ForeColor = System.Drawing.Color.Yellow;
            this.gb_DCH.Location = new System.Drawing.Point(548, 12);
            this.gb_DCH.Name = "gb_DCH";
            this.gb_DCH.Size = new System.Drawing.Size(227, 326);
            this.gb_DCH.TabIndex = 18;
            this.gb_DCH.TabStop = false;
            this.gb_DCH.Text = "Digital Casino Heist";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 264);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(13, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Press ALT + F1 in game";
            // 
            // lbx_IPList
            // 
            this.lbx_IPList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_IPList.FormattingEnabled = true;
            this.lbx_IPList.Location = new System.Drawing.Point(6, 119);
            this.lbx_IPList.Name = "lbx_IPList";
            this.lbx_IPList.Size = new System.Drawing.Size(221, 199);
            this.lbx_IPList.TabIndex = 20;
            // 
            // txb_IP
            // 
            this.txb_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_IP.Location = new System.Drawing.Point(6, 84);
            this.txb_IP.Name = "txb_IP";
            this.txb_IP.Size = new System.Drawing.Size(101, 20);
            this.txb_IP.TabIndex = 21;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "more.png");
            this.imageList1.Images.SetKeyName(1, "search.png");
            this.imageList1.Images.SetKeyName(2, "trash.png");
            this.imageList1.Images.SetKeyName(3, "play.png");
            // 
            // gb_IPRules
            // 
            this.gb_IPRules.BackColor = System.Drawing.Color.Transparent;
            this.gb_IPRules.Controls.Add(this.btn_search);
            this.gb_IPRules.Controls.Add(this.lb_Name);
            this.gb_IPRules.Controls.Add(this.txb_Name);
            this.gb_IPRules.Controls.Add(this.lb_IP);
            this.gb_IPRules.Controls.Add(this.lb_gta5_directory);
            this.gb_IPRules.Controls.Add(this.txb_GTADirectory);
            this.gb_IPRules.Controls.Add(this.txb_IP);
            this.gb_IPRules.Controls.Add(this.btn_del);
            this.gb_IPRules.Controls.Add(this.lbx_IPList);
            this.gb_IPRules.Controls.Add(this.btn_add);
            this.gb_IPRules.Enabled = false;
            this.gb_IPRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb_IPRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_IPRules.ForeColor = System.Drawing.Color.Yellow;
            this.gb_IPRules.Location = new System.Drawing.Point(242, 12);
            this.gb_IPRules.Name = "gb_IPRules";
            this.gb_IPRules.Size = new System.Drawing.Size(300, 326);
            this.gb_IPRules.TabIndex = 24;
            this.gb_IPRules.TabStop = false;
            this.gb_IPRules.Text = "IP Rules";
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.Transparent;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ForeColor = System.Drawing.Color.Black;
            this.btn_search.ImageIndex = 1;
            this.btn_search.ImageList = this.imageList1;
            this.btn_search.Location = new System.Drawing.Point(235, 42);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(25, 25);
            this.btn_search.TabIndex = 29;
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.button3_Click);
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Name.Location = new System.Drawing.Point(110, 68);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(84, 13);
            this.lb_Name.TabIndex = 28;
            this.lb_Name.Text = "Name (optional):";
            // 
            // txb_Name
            // 
            this.txb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_Name.Location = new System.Drawing.Point(113, 84);
            this.txb_Name.Name = "txb_Name";
            this.txb_Name.Size = new System.Drawing.Size(114, 20);
            this.txb_Name.TabIndex = 27;
            // 
            // lb_IP
            // 
            this.lb_IP.AutoSize = true;
            this.lb_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_IP.Location = new System.Drawing.Point(3, 68);
            this.lb_IP.Name = "lb_IP";
            this.lb_IP.Size = new System.Drawing.Size(20, 13);
            this.lb_IP.TabIndex = 26;
            this.lb_IP.Text = "IP:";
            // 
            // lb_gta5_directory
            // 
            this.lb_gta5_directory.AutoSize = true;
            this.lb_gta5_directory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_gta5_directory.Location = new System.Drawing.Point(3, 29);
            this.lb_gta5_directory.Name = "lb_gta5_directory";
            this.lb_gta5_directory.Size = new System.Drawing.Size(101, 13);
            this.lb_gta5_directory.TabIndex = 25;
            this.lb_gta5_directory.Text = "GTA5.exe directory:";
            // 
            // txb_GTADirectory
            // 
            this.txb_GTADirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_GTADirectory.Location = new System.Drawing.Point(6, 45);
            this.txb_GTADirectory.Name = "txb_GTADirectory";
            this.txb_GTADirectory.Size = new System.Drawing.Size(221, 20);
            this.txb_GTADirectory.TabIndex = 24;
            // 
            // btn_del
            // 
            this.btn_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del.ForeColor = System.Drawing.Color.Black;
            this.btn_del.ImageIndex = 2;
            this.btn_del.ImageList = this.imageList1;
            this.btn_del.Location = new System.Drawing.Point(235, 119);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(25, 25);
            this.btn_del.TabIndex = 23;
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.Black;
            this.btn_add.ImageIndex = 0;
            this.btn_add.ImageList = this.imageList1;
            this.btn_add.Location = new System.Drawing.Point(235, 81);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(25, 25);
            this.btn_add.TabIndex = 22;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.secondNumeric);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.minuteNumeric);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.hourNumeric);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.textBox6);
            this.groupBox5.Controls.Add(this.textBox5);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox5.Location = new System.Drawing.Point(12, 404);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(766, 203);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Timer";
            // 
            // secondNumeric
            // 
            this.secondNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondNumeric.Location = new System.Drawing.Point(89, 52);
            this.secondNumeric.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.secondNumeric.Name = "secondNumeric";
            this.secondNumeric.Size = new System.Drawing.Size(35, 24);
            this.secondNumeric.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Yellow;
            this.label16.Location = new System.Drawing.Point(98, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 16);
            this.label16.TabIndex = 35;
            this.label16.Text = "S";
            // 
            // minuteNumeric
            // 
            this.minuteNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minuteNumeric.Location = new System.Drawing.Point(48, 52);
            this.minuteNumeric.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minuteNumeric.Name = "minuteNumeric";
            this.minuteNumeric.Size = new System.Drawing.Size(35, 24);
            this.minuteNumeric.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Yellow;
            this.label15.Location = new System.Drawing.Point(56, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 16);
            this.label15.TabIndex = 33;
            this.label15.Text = "M";
            // 
            // hourNumeric
            // 
            this.hourNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hourNumeric.Location = new System.Drawing.Point(7, 52);
            this.hourNumeric.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.hourNumeric.Name = "hourNumeric";
            this.hourNumeric.Size = new System.Drawing.Size(35, 24);
            this.hourNumeric.TabIndex = 32;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.ImageIndex = 3;
            this.button6.ImageList = this.imageList1;
            this.button6.Location = new System.Drawing.Point(259, 130);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(25, 25);
            this.button6.TabIndex = 31;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(229, 158);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 24);
            this.label14.TabIndex = 30;
            this.label14.Text = "00:00:00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Yellow;
            this.label13.Location = new System.Drawing.Point(16, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 16);
            this.label13.TabIndex = 29;
            this.label13.Text = "H";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Yellow;
            this.label12.Location = new System.Drawing.Point(161, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 16);
            this.label12.TabIndex = 27;
            this.label12.Text = "Text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(161, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Title";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(6, 114);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(149, 82);
            this.textBox6.TabIndex = 25;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(7, 82);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(148, 26);
            this.textBox5.TabIndex = 24;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.ImageIndex = 0;
            this.button5.ImageList = this.imageList1;
            this.button5.Location = new System.Drawing.Point(130, 51);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 23;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lb_version
            // 
            this.lb_version.AutoSize = true;
            this.lb_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_version.ForeColor = System.Drawing.Color.Yellow;
            this.lb_version.Location = new System.Drawing.Point(78, 360);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(78, 24);
            this.lb_version.TabIndex = 26;
            this.lb_version.Text = "version";
            // 
            // btn_CkUpdates
            // 
            this.btn_CkUpdates.Location = new System.Drawing.Point(8, 344);
            this.btn_CkUpdates.Name = "btn_CkUpdates";
            this.btn_CkUpdates.Size = new System.Drawing.Size(64, 40);
            this.btn_CkUpdates.TabIndex = 27;
            this.btn_CkUpdates.Text = "Check for Updates";
            this.btn_CkUpdates.UseVisualStyleBackColor = true;
            this.btn_CkUpdates.Click += new System.EventHandler(this.button7_Click);
            // 
            // timerSP
            // 
            this.timerSP.Interval = 1000;
            this.timerSP.Tick += new System.EventHandler(this.timerSP_Tick);
            // 
            // timerDD
            // 
            this.timerDD.Interval = 1000;
            this.timerDD.Tick += new System.EventHandler(this.timerDD_Tick);
            // 
            // timerNM
            // 
            this.timerNM.Interval = 1000;
            this.timerNM.Tick += new System.EventHandler(this.timerNM_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(788, 397);
            this.Controls.Add(this.btn_CkUpdates);
            this.Controls.Add(this.lb_version);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gb_IPRules);
            this.Controls.Add(this.lb_h4S);
            this.Controls.Add(this.gb_ND);
            this.Controls.Add(this.gb_SPG);
            this.Controls.Add(this.gb_DCH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MacetimTools ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gb_ND.ResumeLayout(false);
            this.gb_ND.PerformLayout();
            this.gb_SPG.ResumeLayout(false);
            this.gb_SPG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Firewall)).EndInit();
            this.gb_DCH.ResumeLayout(false);
            this.gb_DCH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_IPRules.ResumeLayout(false);
            this.gb_IPRules.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minuteNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_h4S;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_ND;
        private System.Windows.Forms.Label lb_networkname;
        private System.Windows.Forms.TextBox txb_Custom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_SPG;
        private System.Windows.Forms.GroupBox gb_DCH;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbx_DeviceList;
        private System.Windows.Forms.CheckBox cb_DisableDevice;
        private System.Windows.Forms.RadioButton rbtn_StopProcess;
        private System.Windows.Forms.RadioButton rbtn_Firewall;
        private System.Windows.Forms.RadioButton rbtn_FirewallFriends;
        private System.Windows.Forms.ListBox lbx_IPList;
        private System.Windows.Forms.TextBox txb_IP;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.GroupBox gb_IPRules;
        private System.Windows.Forms.PictureBox pb_Firewall;
        private System.Windows.Forms.TextBox txb_GTADirectory;
        private System.Windows.Forms.Label lb_IP;
        private System.Windows.Forms.Label lb_gta5_directory;
        private System.Windows.Forms.CheckBox cb_Custom;
        private System.Windows.Forms.Label lb_custom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbx_NetworkName;
        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.TextBox txb_Name;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown secondNumeric;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown minuteNumeric;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown hourNumeric;
        private System.Windows.Forms.Label lb_version;
        private System.Windows.Forms.Button btn_CkUpdates;
        private System.Windows.Forms.Timer timerSP;
        private System.Windows.Forms.Timer timerDD;
        private System.Windows.Forms.Timer timerNM;
    }
}

