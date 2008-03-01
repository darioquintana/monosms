using System;
using System.Windows.Forms;
using Mono.Sms.Core;

namespace Mono.Sms
{
    public partial class Contacts : Form
    {
        private Contact contact;
        private Operation operation;

        public Contact Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public Operation Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public Contacts()
        {
            InitializeComponent();

            //if (Contact == null)
            //{Contact = new Contact();}
        }


        private void Contacts_Load(object sender, EventArgs e)
        {
            if (Contact != null)
            {
                txtAreaCode.Text = contact.Number.CodeArea.ToString();
                txtNumber.Text = contact.Number.Number.ToString();
                txtName.Text = contact.Name.ToString();

                cmbProviders.SetProvider(contact.ProviderName);
            }
        }


        public delegate void ContactsHandler(Contact contact, Operation op);

        public event ContactsHandler ContactsEventHandler;


        private void btnOk_Click(object sender, EventArgs e)
        {
            Contact newContact = GetContact();
            if (newContact != null)
            {
                ContactsEventHandler(GetContact(), this.Operation);
                this.Close();
            }
        }

        private Contact GetContact()
        {
            if (cmbProviders.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona arriba un proveedor de mensajes", "Mono.Sms", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return null;
            }

            Contact _contact = new Contact();

            _contact.Name = txtName.Text;
            _contact.Number = new CelNumber(txtAreaCode.Text, txtNumber.Text);
            _contact.ProviderName = cmbProviders.Text;

            return _contact;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}