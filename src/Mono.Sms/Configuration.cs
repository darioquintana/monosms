using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mono.Sms.Core;
using Mono.Sms.Core.Cfg;

namespace Mono.Sms
{
    public partial class frmConfiguration : Form
    {
        //fields
        private Settings settings;
        private SmtpServers smtpServers;

        public frmConfiguration()
        {
            InitializeComponent();
        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            settings = Settings.Instance;

            this.txtMail.Text = settings.UserEmail;
            this.txtUserName.Text = settings.UserName;
            this.txtSmtp.Text = settings.SmtpServer;

            smtpServers = new SmtpServers();

            foreach (KeyValuePair<string, string> pair in smtpServers)
            {
                cboISP.Items.Add(pair);
            }

            cboISP.DisplayMember = "Key";
            cboISP.ValueMember = "Value";

            if (smtpServers.ContainsValue(settings.SmtpServer))
            {
                foreach (KeyValuePair<string, string> pair in smtpServers)
                {
                    if (pair.Value == settings.SmtpServer)
                    {
                        txtSmtp.Text = pair.Value;
                        cboISP.Text = pair.Key;

                        rbtISP.Checked = true;
                        txtSmtp.ReadOnly = true;
                        txtSmtp.Text = settings.SmtpServer;

                        return;
                    }
                }

                cboISP.Text = string.Empty;
                txtSmtp.ReadOnly = false;
                txtSmtp.Text = settings.SmtpServer;

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            settings.UserEmail = this.txtMail.Text;
            settings.UserName = this.txtUserName.Text;
            settings.SmtpServer = this.txtSmtp.Text;
                       
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboISP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string smtpName = cboISP.Text;

            txtSmtp.Text = smtpServers[smtpName];
            rbtISP.Checked = true;
            txtSmtp.ReadOnly = true;
          

        }

        private void rbtISP_CheckedChanged(object sender, EventArgs e)
        {
            
            txtSmtp.ReadOnly = true;

        }

        private void rbtParticular_CheckedChanged(object sender, EventArgs e)
        {
            txtSmtp.ReadOnly = false;
        }
    }
}