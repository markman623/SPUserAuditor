namespace SPUserAuditor
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBoxIncludeChild = new System.Windows.Forms.CheckBox();
            this.btnAuditUsers = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkUseDefaultCred = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top Site URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(115, 23);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(157, 20);
            this.txtUrl.TabIndex = 3;
            this.txtUrl.Text = "http://sharepoint2013v/sites/Pub/";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(442, 52);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(157, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(442, 91);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(157, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Include Child Sites?";
            // 
            // chkBoxIncludeChild
            // 
            this.chkBoxIncludeChild.AutoSize = true;
            this.chkBoxIncludeChild.Location = new System.Drawing.Point(183, 98);
            this.chkBoxIncludeChild.Name = "chkBoxIncludeChild";
            this.chkBoxIncludeChild.Size = new System.Drawing.Size(15, 14);
            this.chkBoxIncludeChild.TabIndex = 7;
            this.chkBoxIncludeChild.UseVisualStyleBackColor = true;
            // 
            // btnAuditUsers
            // 
            this.btnAuditUsers.Location = new System.Drawing.Point(267, 156);
            this.btnAuditUsers.Name = "btnAuditUsers";
            this.btnAuditUsers.Size = new System.Drawing.Size(75, 23);
            this.btnAuditUsers.TabIndex = 8;
            this.btnAuditUsers.Text = "Audit Users";
            this.btnAuditUsers.UseVisualStyleBackColor = true;
            this.btnAuditUsers.Click += new System.EventHandler(this.btnAuditUsers_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(115, 59);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(157, 20);
            this.txtFolderPath.TabIndex = 9;
            this.txtFolderPath.Text = "C:\\TestAudit";
            this.txtFolderPath.TextChanged += new System.EventHandler(this.txtFolderPath_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Folder path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Use default credentials?";
            // 
            // chkUseDefaultCred
            // 
            this.chkUseDefaultCred.AutoSize = true;
            this.chkUseDefaultCred.Checked = true;
            this.chkUseDefaultCred.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultCred.Location = new System.Drawing.Point(509, 23);
            this.chkUseDefaultCred.Name = "chkUseDefaultCred";
            this.chkUseDefaultCred.Size = new System.Drawing.Size(15, 14);
            this.chkUseDefaultCred.TabIndex = 12;
            this.chkUseDefaultCred.UseVisualStyleBackColor = true;
            this.chkUseDefaultCred.CheckedChanged += new System.EventHandler(this.chkUseDefaultCred_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(22, 145);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 260);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkUseDefaultCred);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.btnAuditUsers);
            this.Controls.Add(this.chkBoxIncludeChild);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "UserAuditor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkBoxIncludeChild;
        private System.Windows.Forms.Button btnAuditUsers;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkUseDefaultCred;
        private System.Windows.Forms.Label lblStatus;
    }
}

