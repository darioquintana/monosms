using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Mono.Sms.Core.UI
{
    public class ContactsListView : ListView 
    {
        public ContactsListView():base()
        {
            
        }
        
        public Contact GetSelectedContact()
        {
            ListView.SelectedListViewItemCollection items;
            items = this.SelectedItems;

            if (items.Count == 0) return null;

            Contact contact = new Contact();
            contact.Name = items[0].Text;
            contact.Number = new CelNumber(items[0].SubItems[1].Text,items[0].SubItems[2].Text);
            contact.ProviderName = items[0].SubItems[3].Text;

            return contact;
        }

        public void AddContactItem(Contact contact)
        {
            ListViewItem lvi = new ListViewItem(contact.Name);
            lvi.ImageIndex = 0;
            lvi.SubItems.Add(contact.Number.CodeArea.ToString());
            lvi.SubItems.Add(contact.Number.Number.ToString());
            lvi.SubItems.Add(contact.ProviderName);

            this.Items.Add(lvi);
        }

    }
}
