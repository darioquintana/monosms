using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Mono.Sms.Core
{
    public class Agenda
    {
        private static List<Contact> list = new List<Contact>();

        public static List<Contact> Contacts
        {
            get { return ReadAgenda(); }
        }

        public static void AddContact(Contact contact)
        {
            list.Add(contact);

            WriteAgenda(list);
        }

        public static bool RemoveContact(Contact contact)
        {
            bool ret = list.Remove(contact);
            WriteAgenda(list);
            return ret;
        }

        public static bool UpdateContact(Contact oldContact, Contact newContact)
        {
            if (list.Contains(oldContact))
            {
                list.Remove(oldContact);
                list.Add(newContact);
                WriteAgenda(list);
                return true;
            }
            return false;
        }

        private static void WriteAgenda(List<Contact> _list)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Contact c in _list)
            {
                sb.AppendLine(
                    string.Format("{0},{1},{2},{3}", c.Name, c.Number.CodeArea, c.Number.Number, c.ProviderName));
            }
            try
            {
                StreamWriter sw = new StreamWriter("files/contacts.monosms");
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<Contact> ReadAgenda()
        {
            try
            {
                StreamReader sr = new StreamReader("files/contacts.monosms");

                List<Contact> returnList = new List<Contact>();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    returnList.Add(GetContactFromLine(line));
                }

                sr.Close();

                list = returnList;

                return returnList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Contact GetContactFromLine(string line)
        {
            string[] a = line.Split(',');

            return new Contact(a[0], new CelNumber(a[1], a[2]), a[3]);
        }
    }
}