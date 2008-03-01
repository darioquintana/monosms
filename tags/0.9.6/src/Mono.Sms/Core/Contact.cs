namespace Mono.Sms.Core
{
    public class Contact
    {
        public Contact(string contactName, CelNumber number, string providerName)
        {
            this.name = contactName;
            this.providerName = providerName;
            this.number = number;
        }

        public Contact()
        {
            this.Number = new CelNumber();
            this.Name = string.Empty;
            this.ProviderName = string.Empty;
        }

        private string name;
        private string providerName;
        private CelNumber number;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ProviderName
        {
            get { return providerName; }
            set { providerName = value; }
        }

        public CelNumber Number
        {
            get { return number; }
            set { number = value; }
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            Contact contact = obj as Contact;
            if (contact == null) return false;
            return Equals(name, contact.name);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}