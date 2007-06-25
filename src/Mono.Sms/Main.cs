using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Mono.Sms.Core;
using Mono.Sms.Core.Cfg;
using Mono.Sms.Core.Provider;

namespace Mono.Sms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            //Set Images:
            this.btnSend.Image = MonoSmsResources.GetImage("mensaje.png");
            this.btnAddContact.Image = MonoSmsResources.GetImage("nuevocontacto.png");
            this.btnEditContact.Image = MonoSmsResources.GetImage("editar.png");
            this.btnRemoveContact.Image = MonoSmsResources.GetImage("borrar.png");
            this.toolStripButtonHistorial.Image = MonoSmsResources.GetImage("historial.png");
            this.toolStripButtonConfiguraciones.Image = MonoSmsResources.GetImage("configuracion.png");
            this.salirToolStripMenuItem.Image = MonoSmsResources.GetImage("salir.png");
            this.configuracionesToolStripMenuItem.Image = MonoSmsResources.GetImage("configuracion.png");

        }

        private IProvider currentProvider;
        private int MaximumAllowed = 100;

        public IProvider CurrentProvider
        {
            get { return currentProvider; }
            set { currentProvider = value; }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtFrom.Text = Settings.Instance.UserName;

            ControlsVisibility(false);

            AsignDelegateAtTextBox();

            LoadContacts();
        }

        private void ControlsVisibility(bool _bool)
        {
            this.txtFrom.Visible = _bool;
            this.txtMessage.Visible = _bool;
            this.btnSend.Visible = _bool;
            this.btnClean.Visible = _bool;
            this.txtAreaCode.Visible = _bool;
            this.txtNumber.Visible = _bool;
            lblQuince.Visible = _bool;
            lblZero.Visible = _bool;
            lblEmpresa.Visible = _bool;
            lblCount.Visible = _bool;
            lblDe.Visible = _bool;
        }

        private void AsignDelegateAtTextBox()
        {
            foreach (Control control in this.gbMensaje.Controls)
            {
                TextBox tb = control as TextBox;

                if (tb != null)
                {
                    tb.Enter += TextBox_Enter;
                    tb.Leave += TextBox_Leave;
                }
            }
        }

        private void LoadContacts()
        {
            List<Contact> list = Agenda.Contacts;

            lv.Items.Clear();

            foreach (Contact contact in list)
            {
                lv.AddContactItem(contact);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CauseValidation(false);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            GroupBoxEnabled(false);
            Cursor = Cursors.WaitCursor;

            if (!ValidateSent())
            {
                GroupBoxEnabled(true);
                Cursor = Cursors.Arrow;
                return;
            }

            toolStripProgressBar1.Visible = true;

            Enviar();

            GroupBoxEnabled(true);
            Cursor = Cursors.Arrow;
        }


        void GroupBoxEnabled(bool _enabled)
        {
            this.gbMensaje.Enabled = _enabled;
            this.gbContactos.Enabled = _enabled;
            
        }

        private void Enviar()
        {
            Sender sndr = new Sender();

            string codeArea = txtAreaCode.Text;
            string number = txtNumber.Text;

            //All it's ok, then Send the Message.

            CurrentProvider.Message = string.Concat("De ", txtFrom.Text, ": ", txtMessage.Text);
            CurrentProvider.CelNumber = new CelNumber(codeArea, number);
            Result res = sndr.Send(CurrentProvider);

            if (res.IsError)
            {
                MessageBox.Show(string.Format("{0}.\r\n{1}", res.Message, res.Error), "Mono.Sms", MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(string.Format("{0}.\r\n{1}",res.Message,res.Error), "Mono.Sms", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }


            toolStripProgressBar1.Visible = false;
        }

        private bool ValidateSent()
        {
            int codigoArea;
            int numeroCelular;

            if (int.TryParse(txtAreaCode.Text, out codigoArea))
            {
                if (codigoArea == 0)
                {
                    MessageBox.Show("Debe ingresar un código de area", "Mono.Sms", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un código de area", "Mono.Sms", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }

            if (int.TryParse(txtNumber.Text, out numeroCelular))
            {
                if (numeroCelular == 0)
                {
                    MessageBox.Show("Debe ingresar un número de celular", "Mono.Sms", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un código de area", "Mono.Sms", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }


            if (Convert.ToInt32(lblCount.Text) < 0) //Check max length of message
            {
                MessageBox.Show(
                    string.Format(
                        "El mensaje ha superado {0} caracteres, la longitud máxima admitida por el provedor {1}",
                        CurrentProvider.NumberOfCharacters, CurrentProvider.Name));
                return false;
            }


            //Message and From no empty
            if (txtFrom.Text.Trim() == string.Empty && txtMessage.Text.Trim() == string.Empty)
            {
                return false;
            }

            if (this.CurrentProvider == null)
            {
                MessageBox.Show("Selecciona arriba un proveedor de mensajes");
                return false;
            }

            return true;
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (this.CurrentProvider == null) return;

            MaximumAllowed = CurrentProvider.NumberOfCharacters;

            int length = txtMessage.Text.Length + txtFrom.Text.Length;

            lblCount.Text = (MaximumAllowed - length).ToString();

            if ((Convert.ToInt32(lblCount.Text)) < 0)
            {
                lblCount.ForeColor = Color.Red;
            }
            else
            {
                lblCount.ForeColor = Color.Blue;
            }
        }


        private void CauseValidation(bool value)
        {
            CausesValidation = value;

            foreach (Control c in Controls)
            {
                c.CausesValidation = value;
            }
        }

        private void cmbProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentProvider = cmbProviders.SelectedItem as IProvider;

            ControlsVisibility(true);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtMessage.Text = string.Empty;
            txtMessage.Focus();
        }

        private void btnChView_Click(object sender, EventArgs e)
        {
            switch (lv.View)
            {
                case View.Details:
                    lv.View = View.LargeIcon;
                    break;

                case View.LargeIcon:
                    lv.View = View.Details;
                    break;
            }
        }


        private void btnAddContact_Click(object sender, EventArgs e)
        {
            Contacts frm = new Contacts();
            frm.Operation = Operation.Add;
            frm.ContactsEventHandler += delegate(Contact contact, Operation op)
                                            {
                                                Agenda.AddContact(contact);
                                                LoadContacts();
                                            };

            frm.ShowDialog();
        }

        private void btnRemoveContact_Click(object sender, EventArgs e)
        {
            if (Agenda.RemoveContact(lv.GetSelectedContact()))
                MessageBox.Show("El contacto fue eliminado","Mono.Sms",MessageBoxButtons.OK,MessageBoxIcon.Information);

            LoadContacts();
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            Contact oldContact = lv.GetSelectedContact();
            if (oldContact == null) return;

            Contacts frm = new Contacts();
            frm.Operation = Operation.Edit;
            frm.ContactsEventHandler += delegate(Contact contact, Operation op)
                                            {
                                                Agenda.UpdateContact(oldContact, contact);
                                                LoadContacts();
                                            };
            frm.Contact = oldContact;
            frm.ShowDialog();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox sender_cast = (TextBox) sender;

            sender_cast.BackColor = Color.Azure;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox sender_cast = (TextBox) sender;

            sender_cast.BackColor = SystemColors.Window;
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            Contact contact = lv.GetSelectedContact();

            if (contact == null) return;

            txtAreaCode.Text = contact.Number.CodeArea.ToString();
            txtNumber.Text = contact.Number.Number.ToString();

            if (!cmbProviders.SetProvider(contact.ProviderName))
            {
                MessageBox.Show(
                    "El proveedor de este contacto no corresponde a ninguno disponible, seleccione alguno de la lista");
                if (cmbProviders != null || cmbProviders.Items.Count > 0)
                {
                    cmbProviders.SelectedIndex = 0; //move to the first.
                }
            }
        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Historial frm = new Historial();
            frm.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmConfiguration frm = new frmConfiguration();
            frm.ShowDialog();
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguration frm = new frmConfiguration();
            frm.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Instance.SaveState();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe frm = new AcercaDe();
            frm.ShowDialog();
        }
    }
}