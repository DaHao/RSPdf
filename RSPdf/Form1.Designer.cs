namespace RSPdf
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtEMLPath = new System.Windows.Forms.TextBox();
            this.btnEML = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMSG = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSmtpReset = new System.Windows.Forms.Button();
            this.btnSmtpOK = new System.Windows.Forms.Button();
            this.txtUserPw = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtUserAcc = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.chkSmtpSSL = new System.Windows.Forms.CheckBox();
            this.txtSmtpPort = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtSmtpHost = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(148, 66);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(69, 23);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "Clear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(229, 66);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(69, 23);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(67, 66);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(69, 23);
            this.btnSend.TabIndex = 21;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtEMLPath
            // 
            this.txtEMLPath.Location = new System.Drawing.Point(12, 12);
            this.txtEMLPath.Name = "txtEMLPath";
            this.txtEMLPath.Size = new System.Drawing.Size(267, 22);
            this.txtEMLPath.TabIndex = 17;
            // 
            // btnEML
            // 
            this.btnEML.Location = new System.Drawing.Point(285, 10);
            this.btnEML.Name = "btnEML";
            this.btnEML.Size = new System.Drawing.Size(80, 23);
            this.btnEML.TabIndex = 18;
            this.btnEML.Text = "選擇檔案";
            this.btnEML.UseVisualStyleBackColor = true;
            this.btnEML.Click += new System.EventHandler(this.btnEML_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 95);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(353, 277);
            this.tabControl1.TabIndex = 24;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMSG);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(345, 251);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "系統訊息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtMSG
            // 
            this.txtMSG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMSG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMSG.Location = new System.Drawing.Point(3, 3);
            this.txtMSG.Name = "txtMSG";
            this.txtMSG.Size = new System.Drawing.Size(339, 245);
            this.txtMSG.TabIndex = 0;
            this.txtMSG.Text = "";
            this.txtMSG.TextChanged += new System.EventHandler(this.txtMSG_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSmtpReset);
            this.tabPage2.Controls.Add(this.btnSmtpOK);
            this.tabPage2.Controls.Add(this.txtUserPw);
            this.tabPage2.Controls.Add(this.Label4);
            this.tabPage2.Controls.Add(this.txtUserAcc);
            this.tabPage2.Controls.Add(this.Label3);
            this.tabPage2.Controls.Add(this.chkSmtpSSL);
            this.tabPage2.Controls.Add(this.txtSmtpPort);
            this.tabPage2.Controls.Add(this.Label2);
            this.tabPage2.Controls.Add(this.txtSmtpHost);
            this.tabPage2.Controls.Add(this.Label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(345, 251);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SMTP設定";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSmtpReset
            // 
            this.btnSmtpReset.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSmtpReset.Location = new System.Drawing.Point(184, 201);
            this.btnSmtpReset.Name = "btnSmtpReset";
            this.btnSmtpReset.Size = new System.Drawing.Size(69, 23);
            this.btnSmtpReset.TabIndex = 37;
            this.btnSmtpReset.Text = "Reset";
            this.btnSmtpReset.UseVisualStyleBackColor = true;
            this.btnSmtpReset.Click += new System.EventHandler(this.btnSmtpReset_Click);
            // 
            // btnSmtpOK
            // 
            this.btnSmtpOK.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSmtpOK.Location = new System.Drawing.Point(88, 201);
            this.btnSmtpOK.Name = "btnSmtpOK";
            this.btnSmtpOK.Size = new System.Drawing.Size(75, 23);
            this.btnSmtpOK.TabIndex = 36;
            this.btnSmtpOK.Text = "Save";
            this.btnSmtpOK.UseVisualStyleBackColor = true;
            this.btnSmtpOK.Click += new System.EventHandler(this.btnSmtpOK_Click);
            // 
            // txtUserPw
            // 
            this.txtUserPw.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtUserPw.Location = new System.Drawing.Point(102, 157);
            this.txtUserPw.Name = "txtUserPw";
            this.txtUserPw.PasswordChar = '*';
            this.txtUserPw.Size = new System.Drawing.Size(218, 22);
            this.txtUserPw.TabIndex = 35;
            this.txtUserPw.UseSystemPasswordChar = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label4.Location = new System.Drawing.Point(50, 162);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(46, 13);
            this.Label4.TabIndex = 34;
            this.Label4.Text = "密碼：";
            // 
            // txtUserAcc
            // 
            this.txtUserAcc.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtUserAcc.Location = new System.Drawing.Point(102, 126);
            this.txtUserAcc.Name = "txtUserAcc";
            this.txtUserAcc.Size = new System.Drawing.Size(218, 22);
            this.txtUserAcc.TabIndex = 33;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label3.Location = new System.Drawing.Point(11, 131);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(85, 13);
            this.Label3.TabIndex = 32;
            this.Label3.Text = "使用者帳號：";
            // 
            // chkSmtpSSL
            // 
            this.chkSmtpSSL.AutoSize = true;
            this.chkSmtpSSL.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkSmtpSSL.Location = new System.Drawing.Point(9, 105);
            this.chkSmtpSSL.Name = "chkSmtpSSL";
            this.chkSmtpSSL.Size = new System.Drawing.Size(99, 17);
            this.chkSmtpSSL.TabIndex = 31;
            this.chkSmtpSSL.Text = "是否使用SSL";
            this.chkSmtpSSL.UseVisualStyleBackColor = true;
            this.chkSmtpSSL.Visible = false;
            // 
            // txtSmtpPort
            // 
            this.txtSmtpPort.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSmtpPort.Location = new System.Drawing.Point(103, 57);
            this.txtSmtpPort.Name = "txtSmtpPort";
            this.txtSmtpPort.Size = new System.Drawing.Size(38, 23);
            this.txtSmtpPort.TabIndex = 30;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label2.Location = new System.Drawing.Point(25, 62);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(72, 13);
            this.Label2.TabIndex = 29;
            this.Label2.Text = "連接埠號：";
            // 
            // txtSmtpHost
            // 
            this.txtSmtpHost.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSmtpHost.Location = new System.Drawing.Point(103, 26);
            this.txtSmtpHost.Name = "txtSmtpHost";
            this.txtSmtpHost.Size = new System.Drawing.Size(217, 22);
            this.txtSmtpHost.TabIndex = 28;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label1.Location = new System.Drawing.Point(6, 31);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(91, 13);
            this.Label1.TabIndex = 27;
            this.Label1.Text = "SMTP伺服器：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 384);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtEMLPath);
            this.Controls.Add(this.btnEML);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnSend;
        internal System.Windows.Forms.TextBox txtEMLPath;
        internal System.Windows.Forms.Button btnEML;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.Button btnSmtpReset;
        internal System.Windows.Forms.Button btnSmtpOK;
        internal System.Windows.Forms.TextBox txtUserPw;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtUserAcc;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.CheckBox chkSmtpSSL;
        internal System.Windows.Forms.TextBox txtSmtpPort;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtSmtpHost;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.RichTextBox txtMSG;
    }
}

