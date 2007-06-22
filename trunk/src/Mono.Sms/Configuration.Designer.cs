namespace Mono.Sms
{
    partial class frmConfiguration
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtParticular = new System.Windows.Forms.RadioButton();
            this.rbtISP = new System.Windows.Forms.RadioButton();
            this.cboISP = new System.Windows.Forms.ComboBox();
            this.txtSmtp = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(452, 105);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(533, 105);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtParticular);
            this.groupBox1.Controls.Add(this.rbtISP);
            this.groupBox1.Controls.Add(this.cboISP);
            this.groupBox1.Controls.Add(this.txtSmtp);
            this.groupBox1.Location = new System.Drawing.Point(308, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 87);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Servidor Smtp";
            // 
            // rbtParticular
            // 
            //this.rbtParticular.AutoSize = true;
            this.rbtParticular.Location = new System.Drawing.Point(29, 54);
            this.rbtParticular.Name = "rbtParticular";
            this.rbtParticular.Size = new System.Drawing.Size(69, 17);
            this.rbtParticular.TabIndex = 3;
            this.rbtParticular.TabStop = true;
            this.rbtParticular.Text = "Particular";
            this.rbtParticular.UseVisualStyleBackColor = true;
            this.rbtParticular.CheckedChanged += new System.EventHandler(this.rbtParticular_CheckedChanged);
            // 
            // rbtISP
            // 
            //this.rbtISP.AutoSize = true;
            this.rbtISP.Location = new System.Drawing.Point(29, 27);
            this.rbtISP.Name = "rbtISP";
            this.rbtISP.Size = new System.Drawing.Size(42, 17);
            this.rbtISP.TabIndex = 3;
            this.rbtISP.TabStop = true;
            this.rbtISP.Text = "ISP";
            this.rbtISP.UseVisualStyleBackColor = true;
            this.rbtISP.CheckedChanged += new System.EventHandler(this.rbtISP_CheckedChanged);
            // 
            // cboISP
            // 
            this.cboISP.FormattingEnabled = true;
            this.cboISP.Location = new System.Drawing.Point(107, 26);
            this.cboISP.Name = "cboISP";
            this.cboISP.Size = new System.Drawing.Size(193, 21);
            this.cboISP.TabIndex = 2;
            this.cboISP.SelectedIndexChanged += new System.EventHandler(this.cboISP_SelectedIndexChanged);
            // 
            // txtSmtp
            // 
            this.txtSmtp.Location = new System.Drawing.Point(107, 53);
            this.txtSmtp.Name = "txtSmtp";
            this.txtSmtp.Size = new System.Drawing.Size(193, 20);
            this.txtSmtp.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtMail);
            this.groupBox2.Controls.Add(this.txtUserName);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 87);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuario";
            // 
            // label2
            // 
            //this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "e-mail";
            // 
            // label1
            // 
            //this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(79, 50);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(193, 20);
            this.txtMail.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(79, 20);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(193, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // frmConfiguration
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(648, 135);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuración de Mono.Sms";
            this.Load += new System.EventHandler(this.frmConfiguration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSmtp;
        private System.Windows.Forms.RadioButton rbtParticular;
        private System.Windows.Forms.RadioButton rbtISP;
        private System.Windows.Forms.ComboBox cboISP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMail;
    }
}