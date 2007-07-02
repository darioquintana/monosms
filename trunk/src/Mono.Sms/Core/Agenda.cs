using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Mono.Sms.Core
{
    public class Agenda
    {
    	const string pathFile = "files/contacts.monosms";
    
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
                StreamWriter sw = new StreamWriter(pathFile);
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
            	Console.WriteLine("Read Agenda");
            	//Si no existe una agenda, la creo.
            	if(!File.Exists(pathFile))
            	{
            	
            		Console.WriteLine("No existe el archivo");
            		if(!Directory.Exists("files"))
            		{
            			Console.WriteLine("no existe el directorio");
            			Directory.CreateDirectory("files");
            			Console.WriteLine("creé el directorio");
            		}
            		
            		//Hack: De esta manera no funciona bien en linux
            		//File.CreateText(pathFile);
            		
            		//Tengo que usar esto:
            		StreamWriter sw = new StreamWriter(pathFile);
                	sw.Write("");
                	sw.Flush();
                	sw.Close();
                	//
            		
            		Console.WriteLine("Creé el archivo de texto {0}",pathFile);
            	}
            	   
                StreamReader sr = new StreamReader(pathFile);
                Console.WriteLine("StreamReader de {0}",pathFile);

                List<Contact> returnList = new List<Contact>();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    returnList.Add(GetContactFromLine(line));
                }

                sr.Close();
                Console.WriteLine("Cerré el archivo");
                

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