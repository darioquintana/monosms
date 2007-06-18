using Mono.Sms.Core.UI;

namespace Mono.Sms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.gbMensaje = new System.Windows.Forms.GroupBox();
            this.lblQuince = new System.Windows.Forms.Label();
            this.lblZero = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblDe = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.gbContactos = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnEditContact = new System.Windows.Forms.Button();
            this.btnChView = new System.Windows.Forms.Button();
            this.btnRemoveContact = new System.Windows.Forms.Button();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Barra = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.imageListToolBar = new System.Windows.Forms.ImageList(this.components);
            this.lv = new Mono.Sms.Core.UI.ContactsListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.cmbProviders = new Mono.Sms.Core.UI.ComboBoxProviders();
            this.txtAreaCode = new Mono.Sms.Core.UI.TextBoxOnyNumbers();
            this.txtNumber = new Mono.Sms.Core.UI.TextBoxOnyNumbers();
            this.gbMensaje.SuspendLayout();
            this.gbContactos.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.Barra.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(67, 241);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(223, 39);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Enviar mensaje";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClean
            // 
            this.btnClean.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClean.Location = new System.Drawing.Point(293, 103);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(51, 22);
            this.btnClean.TabIndex = 6;
            this.btnClean.Text = "Limpiar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMessage.Location = new System.Drawing.Point(67, 103);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(223, 132);
            this.txtMessage.TabIndex = 4;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // gbMensaje
            // 
            this.gbMensaje.Controls.Add(this.cmbProviders);
            this.gbMensaje.Controls.Add(this.lblQuince);
            this.gbMensaje.Controls.Add(this.lblZero);
            this.gbMensaje.Controls.Add(this.txtAreaCode);
            this.gbMensaje.Controls.Add(this.txtNumber);
            this.gbMensaje.Controls.Add(this.lblCount);
            this.gbMensaje.Controls.Add(this.lblEmpresa);
            this.gbMensaje.Controls.Add(this.lblDe);
            this.gbMensaje.Controls.Add(this.btnSend);
            this.gbMensaje.Controls.Add(this.btnClean);
            this.gbMensaje.Controls.Add(this.txtMessage);
            this.gbMensaje.Controls.Add(this.txtFrom);
            this.gbMensaje.Location = new System.Drawing.Point(12, 57);
            this.gbMensaje.Name = "gbMensaje";
            this.gbMensaje.Size = new System.Drawing.Size(355, 287);
            this.gbMensaje.TabIndex = 5;
            this.gbMensaje.TabStop = false;
            this.gbMensaje.Text = "Mensaje";
            // 
            // lblQuince
            // 
            this.lblQuince.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuince.Location = new System.Drawing.Point(149, 52);
            this.lblQuince.Name = "lblQuince";
            this.lblQuince.Size = new System.Drawing.Size(27, 16);
            this.lblQuince.TabIndex = 10;
            this.lblQuince.Text = "15";
            this.lblQuince.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblZero
            // 
            this.lblZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZero.Location = new System.Drawing.Point(50, 52);
            this.lblZero.Name = "lblZero";
            this.lblZero.Size = new System.Drawing.Size(15, 16);
            this.lblZero.TabIndex = 9;
            this.lblZero.Text = "0";
            this.lblZero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.Azure;
            this.lblCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCount.Location = new System.Drawing.Point(296, 222);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(33, 13);
            this.lblCount.TabIndex = 8;
            this.lblCount.Text = "0";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.Location = new System.Drawing.Point(11, 23);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(50, 16);
            this.lblEmpresa.TabIndex = 5;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // lblDe
            // 
            this.lblDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDe.Location = new System.Drawing.Point(37, 78);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(24, 16);
            this.lblDe.TabIndex = 5;
            this.lblDe.Text = "De:";
            // 
            // txtFrom
            // 
            this.txtFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrom.Location = new System.Drawing.Point(67, 76);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(223, 21);
            this.txtFrom.TabIndex = 3;
            this.txtFrom.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // gbContactos
            // 
            this.gbContactos.Controls.Add(this.txtSearch);
            this.gbContactos.Controls.Add(this.lv);
            this.gbContactos.Controls.Add(this.btnEditContact);
            this.gbContactos.Controls.Add(this.btnChView);
            this.gbContactos.Controls.Add(this.btnRemoveContact);
            this.gbContactos.Controls.Add(this.btnAddContact);
            this.gbContactos.Location = new System.Drawing.Point(373, 57);
            this.gbContactos.Name = "gbContactos";
            this.gbContactos.Size = new System.Drawing.Size(357, 287);
            this.gbContactos.TabIndex = 6;
            this.gbContactos.TabStop = false;
            this.gbContactos.Text = "Contactos";
            // 
            // txtSearch
            // 
            this.txtSearch.Enabled = false;
            this.txtSearch.ForeColor = System.Drawing.Color.Silver;
            this.txtSearch.Location = new System.Drawing.Point(6, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(139, 20);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.Text = "Escribe para buscar...";
            this.txtSearch.Visible = false;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "contact.png");
            // 
            // btnEditContact
            // 
            this.btnEditContact.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditContact.Image = ((System.Drawing.Image)(resources.GetObject("btnEditContact.Image")));
            this.btnEditContact.Location = new System.Drawing.Point(198, 250);
            this.btnEditContact.Name = "btnEditContact";
            this.btnEditContact.Size = new System.Drawing.Size(67, 30);
            this.btnEditContact.TabIndex = 5;
            this.btnEditContact.Text = "Editar";
            this.btnEditContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditContact.UseVisualStyleBackColor = true;
            this.btnEditContact.Click += new System.EventHandler(this.btnEditContact_Click);
            // 
            // btnChView
            // 
            this.btnChView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChView.Location = new System.Drawing.Point(310, 18);
            this.btnChView.Name = "btnChView";
            this.btnChView.Size = new System.Drawing.Size(41, 22);
            this.btnChView.TabIndex = 5;
            this.btnChView.UseVisualStyleBackColor = true;
            this.btnChView.Click += new System.EventHandler(this.btnChView_Click);
            // 
            // btnRemoveContact
            // 
            this.btnRemoveContact.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveContact.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveContact.Image")));
            this.btnRemoveContact.Location = new System.Drawing.Point(271, 250);
            this.btnRemoveContact.Name = "btnRemoveContact";
            this.btnRemoveContact.Size = new System.Drawing.Size(80, 30);
            this.btnRemoveContact.TabIndex = 5;
            this.btnRemoveContact.Text = "Eliminar";
            this.btnRemoveContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveContact.UseVisualStyleBackColor = true;
            this.btnRemoveContact.Click += new System.EventHandler(this.btnRemoveContact_Click);
            // 
            // btnAddContact
            // 
            this.btnAddContact.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddContact.Image = ((System.Drawing.Image)(resources.GetObject("btnAddContact.Image")));
            this.btnAddContact.Location = new System.Drawing.Point(6, 250);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(117, 30);
            this.btnAddContact.TabIndex = 5;
            this.btnAddContact.Text = "Nuevo Contacto";
            this.btnAddContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip.Location = new System.Drawing.Point(0, 349);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(742, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.toolStripProgressBar1.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salirToolStripMenuItem.Image")));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("opcionesToolStripMenuItem.Image")));
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.opcionesToolStripMenuItem.Text = "Configuraciones...";
            this.opcionesToolStripMenuItem.Click += new System.EventHandler(this.opcionesToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // Barra
            // 
            this.Barra.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Barra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.Barra.Location = new System.Drawing.Point(0, 24);
            this.Barra.Name = "Barra";
            this.Barra.Size = new System.Drawing.Size(742, 29);
            this.Barra.TabIndex = 9;
            this.Barra.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(71, 26);
            this.toolStripButton1.Text = "Historial";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(110, 26);
            this.toolStripButton2.Text = "Configuraciones";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // imageListToolBar
            // 
            this.imageListToolBar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListToolBar.ImageSize = new System.Drawing.Size(22, 22);
            this.imageListToolBar.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv.LargeImageList = this.imageList;
            this.lv.Location = new System.Drawing.Point(6, 42);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(345, 206);
            this.lv.SmallImageList = this.imageList;
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Contacto";
            this.columnHeader1.Width = 108;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Código";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Código";
            this.columnHeader3.Width = 67;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Proveedor";
            this.columnHeader4.Width = 70;
            // 
            // cmbProviders
            // 
            this.cmbProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProviders.FormattingEnabled = true;
            this.cmbProviders.Location = new System.Drawing.Point(67, 21);
            this.cmbProviders.Name = "cmbProviders";
            this.cmbProviders.Size = new System.Drawing.Size(223, 21);
            this.cmbProviders.TabIndex = 11;
            this.cmbProviders.SelectedIndexChanged += new System.EventHandler(this.cmbProviders_SelectedIndexChanged);
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaCode.Location = new System.Drawing.Point(67, 50);
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(65, 21);
            this.txtAreaCode.TabIndex = 1;
            this.txtAreaCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumber
            // 
            this.txtNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumber.Location = new System.Drawing.Point(176, 50);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(114, 21);
            this.txtNumber.TabIndex = 2;
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Main
            // 
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(742, 371);
            this.Controls.Add(this.Barra);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gbContactos);
            this.Controls.Add(this.gbMensaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mono.Sms - Preview Version";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.gbMensaje.ResumeLayout(false);
            this.gbMensaje.PerformLayout();
            this.gbContactos.ResumeLayout(false);
            this.gbContactos.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Barra.ResumeLayout(false);
            this.Barra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClean;
        private TextBoxOnyNumbers txtAreaCode;
        private TextBoxOnyNumbers txtNumber;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.GroupBox gbMensaje;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.GroupBox gbContactos;
        private ContactsListView lv;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnEditContact;
        private System.Windows.Forms.Button btnRemoveContact;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnChView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblQuince;
        private System.Windows.Forms.Label lblZero;
        private System.Windows.Forms.ToolStrip Barra;
        private System.Windows.Forms.ImageList imageListToolBar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TextBox txtSearch;
        private ComboBoxProviders cmbProviders;
    }
}

