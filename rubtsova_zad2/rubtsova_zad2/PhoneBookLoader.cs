using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubtsova_zad2
{
    static class PhoneBookLoader
    {
        static List<Contact> contacts = new List<Contact>();

        //Загрузка данных из файла
        public static void Load(PhoneBook phoneBook, string fileName)
        {
            StreamReader sr = File.OpenText(fileName);
            while (!sr.EndOfStream)
            {

                string[] s = sr.ReadLine().Split(';');
                phoneBook.AddContact(s[0], s[1]);
            }
            sr.Close();
        }

        //Запись данных в файл
        public static void Save(PhoneBook phoneBook, string fileName)
        {
            StreamWriter sr = File.CreateText(fileName);
            foreach (var contact in phoneBook.GetAllContacts())
            {
                sr.WriteLine($"{contact.Name};{contact.Phone}");
            }
            sr.Close();
        }

    }
}
