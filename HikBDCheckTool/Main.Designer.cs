namespace HikBDCheckTool
{
	partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.cbHttps = new System.Windows.Forms.CheckBox();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetUserList = new System.Windows.Forms.Button();
            this.txtNewPW = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSetPassword = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSelectedUser = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExportXLS = new System.Windows.Forms.Button();
            this.labNetMask = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnScanAllNet = new System.Windows.Forms.Button();
            this.txbOutTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClaer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera IP Address:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(118, 6);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(135, 21);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "192.168.2.95";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Http(s) port:";
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(118, 64);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(135, 21);
            this.nudPort.TabIndex = 3;
            this.nudPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // cbHttps
            // 
            this.cbHttps.Location = new System.Drawing.Point(118, 88);
            this.cbHttps.Name = "cbHttps";
            this.cbHttps.Size = new System.Drawing.Size(135, 33);
            this.cbHttps.TabIndex = 4;
            this.cbHttps.Text = "Camera requires https (SSL) connection";
            this.cbHttps.UseVisualStyleBackColor = true;
            // 
            // lbUsers
            // 
            this.lbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.ItemHeight = 12;
            this.lbUsers.Location = new System.Drawing.Point(12, 172);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(116, 184);
            this.lbUsers.TabIndex = 6;
            this.lbUsers.SelectedValueChanged += new System.EventHandler(this.lbUsers_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Users:";
            // 
            // btnGetUserList
            // 
            this.btnGetUserList.Location = new System.Drawing.Point(259, 6);
            this.btnGetUserList.Name = "btnGetUserList";
            this.btnGetUserList.Size = new System.Drawing.Size(102, 21);
            this.btnGetUserList.TabIndex = 5;
            this.btnGetUserList.Text = "Get User List";
            this.btnGetUserList.UseVisualStyleBackColor = true;
            this.btnGetUserList.Click += new System.EventHandler(this.btnGetUserList_Click);
            // 
            // txtNewPW
            // 
            this.txtNewPW.Location = new System.Drawing.Point(221, 191);
            this.txtNewPW.Name = "txtNewPW";
            this.txtNewPW.Size = new System.Drawing.Size(137, 21);
            this.txtNewPW.TabIndex = 7;
            this.txtNewPW.Text = "12345abc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "New Password:";
            // 
            // btnSetPassword
            // 
            this.btnSetPassword.Location = new System.Drawing.Point(134, 281);
            this.btnSetPassword.Name = "btnSetPassword";
            this.btnSetPassword.Size = new System.Drawing.Size(227, 32);
            this.btnSetPassword.TabIndex = 9;
            this.btnSetPassword.Text = "Set password for selected user";
            this.btnSetPassword.UseVisualStyleBackColor = true;
            this.btnSetPassword.Click += new System.EventHandler(this.btnSetPassword_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Selected User:";
            // 
            // lblSelectedUser
            // 
            this.lblSelectedUser.AutoSize = true;
            this.lblSelectedUser.Location = new System.Drawing.Point(218, 176);
            this.lblSelectedUser.Name = "lblSelectedUser";
            this.lblSelectedUser.Size = new System.Drawing.Size(23, 12);
            this.lblSelectedUser.TabIndex = 11;
            this.lblSelectedUser.Text = "N/A";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 121);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(349, 31);
            this.lblStatus.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(134, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 55);
            this.label6.TabIndex = 13;
            this.label6.Text = "Newer firmwares require a password length of 8-16 characters including at least t" +
    "wo of: \r\n[number, lowercase, uppercase, special character].";
            // 
            // btnExportXLS
            // 
            this.btnExportXLS.Enabled = false;
            this.btnExportXLS.Location = new System.Drawing.Point(259, 64);
            this.btnExportXLS.Name = "btnExportXLS";
            this.btnExportXLS.Size = new System.Drawing.Size(102, 21);
            this.btnExportXLS.TabIndex = 14;
            this.btnExportXLS.Text = "Export";
            this.btnExportXLS.UseVisualStyleBackColor = true;
            this.btnExportXLS.Click += new System.EventHandler(this.btnExportXLS_Click);
            // 
            // labNetMask
            // 
            this.labNetMask.AutoSize = true;
            this.labNetMask.Location = new System.Drawing.Point(50, 37);
            this.labNetMask.Name = "labNetMask";
            this.labNetMask.Size = new System.Drawing.Size(59, 12);
            this.labNetMask.TabIndex = 15;
            this.labNetMask.Text = "Net Mask:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(116, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "255.255.255.0/24";
            // 
            // btnScanAllNet
            // 
            this.btnScanAllNet.Location = new System.Drawing.Point(259, 33);
            this.btnScanAllNet.Name = "btnScanAllNet";
            this.btnScanAllNet.Size = new System.Drawing.Size(99, 23);
            this.btnScanAllNet.TabIndex = 17;
            this.btnScanAllNet.Text = "Scan Net";
            this.btnScanAllNet.UseVisualStyleBackColor = true;
            this.btnScanAllNet.Click += new System.EventHandler(this.BtnScanAllNet_Click);
            // 
            // txbOutTime
            // 
            this.txbOutTime.Location = new System.Drawing.Point(318, 88);
            this.txbOutTime.Name = "txbOutTime";
            this.txbOutTime.Size = new System.Drawing.Size(24, 21);
            this.txbOutTime.TabIndex = 18;
            this.txbOutTime.Text = "5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "Time Out";
            // 
            // btnClaer
            // 
            this.btnClaer.Location = new System.Drawing.Point(134, 319);
            this.btnClaer.Name = "btnClaer";
            this.btnClaer.Size = new System.Drawing.Size(227, 26);
            this.btnClaer.TabIndex = 20;
            this.btnClaer.Text = "Clear";
            this.btnClaer.UseVisualStyleBackColor = true;
            this.btnClaer.Click += new System.EventHandler(this.btnClaer_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 369);
            this.Controls.Add(this.btnClaer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txbOutTime);
            this.Controls.Add(this.btnScanAllNet);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labNetMask);
            this.Controls.Add(this.btnExportXLS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSelectedUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSetPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewPW);
            this.Controls.Add(this.btnGetUserList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.cbHttps);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Hikvision Password Reset";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nudPort;
		private System.Windows.Forms.CheckBox cbHttps;
		private System.Windows.Forms.ListBox lbUsers;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnGetUserList;
		private System.Windows.Forms.TextBox txtNewPW;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnSetPassword;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblSelectedUser;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExportXLS;
        private System.Windows.Forms.Label labNetMask;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnScanAllNet;
        private System.Windows.Forms.TextBox txbOutTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClaer;
    }
}

