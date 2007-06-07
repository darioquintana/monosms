using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Mono.Sms.Core;
using Mono.Sms.Core.Provider;

namespace Mono.Sms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            AsignDelegateAtTextBox();
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
            AsignDelegateAtTextBox();

            LoadContacts();
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
            if (!ValidateSent()) return;

            toolStripProgressBar1.Visible = true;

            Enviar();
        }

        private void Enviar()
        {
            Sender sndr = new Sender();

            int codeArea = Convert.ToInt32(txtAreaCode.Text);
            int number = Convert.ToInt32(txtNumber.Text);

            //All it's ok, then Send the Message.

            CurrentProvider.Message = string.Concat("De ", txtFrom.Text, ": ", txtMessage.Text);
            CurrentProvider.CelNumber = new CelNumber(codeArea, number);
            Result res = sndr.Send(CurrentProvider);

            MessageBox.Show(string.Format(res.Message + " " + res.Error), "Mono.Sms", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            toolStripProgressBar1.Visible = false;
        }

        private bool ValidateSent()
        {
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
            return true;
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            int length = txtMessage.Text.Length + txtFrom.Text.Length;


            if (this.CurrentProvider == null)
            {
                MessageBox.Show("Selecciona arriba un proveedor de mensajes");
                return;
            }

            MaximumAllowed = CurrentProvider.NumberOfCharacters;

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
                MessageBox.Show("El contacto fue eliminado");

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
    }
}