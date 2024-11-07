using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubtsova_zad2
{
    class PhoneBook
    {

        List<Contact> contacts = new List<Contact>();

        //Поиск контактов, возвращает индекс контакта
        public int SearchContact(string name)
        {
            foreach (var contact in contacts)
            {
                if (contact.Name.ToLower() == name.ToLower())
                {
                    return contacts.IndexOf(contact);
                }
            }
            return -1;
        }

        //Изменение контакта
        public string ChangeContact(string name, string phone, int index)
        {
            Contact contact = new Contact(name, phone);
            if (contacts.Contains(contact))
                return "Данный контакт уже существует";
            else
            {
                contacts[index] = contact;
                return "Контакт изменен";
            }
        }

        //Добавление контактов
        public string AddContact(string name, string number)
        {

            Contact contact = new Contact(name, number);
            if (contacts.Contains(contact))
                return "Данный контакт уже существует";
            else
            {
                contacts.Add(contact);
                return "Контакт добавлен";
            }
        }

        //Удаление контактов
        public void DeleteContact(string con)
        {
            string[] parts = con.Split(';');
            contacts = contacts
                .Where(contact => (contact.Name != parts[0].Trim() && contact.Phone != parts[1].Trim()))
                .ToList();
        }

        //Получение списка контактов
        public List<Contact> GetAllContacts()
        {
            return contacts;
        }
    }
}
