using System.Collections.Generic;
using System.Windows.Forms;
using Mono.Sms.Core.Provider;
using System.Collections;

namespace Mono.Sms.Core.UI
{
    internal class ComboBoxProviders : ComboBox
    {
        private bool providersLoaded;

        public ComboBoxProviders()
        {
            //Configure the combox at start

            providersLoaded = false; //the combox hasn't providers already loaded.
            Text = "[Elija un proveedor para enviar mensajes]";
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnDropDown(System.EventArgs e)
        {

            if (e != null) base.OnDropDown(e);

            if (! ProvidersLoaded)
            {
                LoadProviders();
            }
        }

        private bool ProvidersLoaded
        {
            get { return providersLoaded; }
            set { providersLoaded = value; }
        }

        private void LoadProviders()
        {
            IList<IProvider> providers;
            providers = IoC.Instance.GetAllProviders();

            DataSource = providers;

            DisplayMember = "Name";
            ValueMember = "Name";

            ProvidersLoaded = true; //now the providers are loaded.
        }

        public bool SetProvider(string providerName)
        {
            if (providerName == string.Empty) return false;

            OnDropDown(null);
            IEnumerator ie = Items.GetEnumerator();
            int i = 0;

            ie.Reset();
            while (ie.MoveNext())
            {
                IProvider current = (IProvider) ie.Current;

                if (current.Name == providerName)
                {
                    SelectedIndex = i;
                    return true;
                }

                i++;
            }
            return false;
        }
    }
}