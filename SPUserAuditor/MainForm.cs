using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPUserAuditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAuditUsers_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }

            lblStatus.Text = "Audit in progress...";
            UserAuditor ua = new UserAuditor(this.txtUrl.Text, this.txtFolderPath.Text, this.chkBoxIncludeChild.Checked);
            if (!this.chkUseDefaultCred.Checked)
            {
                ua.SetCredentials(this.txtUserName.Text, this.txtPassword.Text);
            }

            ua.StartUserAudit();

            lblStatus.Text = "";
        }

        private void chkUseDefaultCred_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseDefaultCred.Checked)
            {
                this.txtUserName.Enabled = false;
                this.txtPassword.Enabled = false;
            }
            else
            {
                this.txtUserName.Enabled = true;
                this.txtPassword.Enabled = true;
            }
        }

        private Boolean validateForm()
        {
            if (string.IsNullOrWhiteSpace(txtUrl.Text) || string.IsNullOrWhiteSpace(txtFolderPath.Text))
            {
                return false;
            }
            return true;
        }

        private void txtFolderPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
