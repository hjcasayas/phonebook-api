using Phonebook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Data.Services
{
    public class SqlContactData : IContactData
    {
        private readonly PhonebookDbContext db;

        public SqlContactData(PhonebookDbContext db)
        {
            this.db = db;
        }
        public void AddContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public void DeleteContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact GetContactById(int id)
        {
            return db.Contacts.FirstOrDefault(c => c.ContactId == id);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return db.Contacts.OrderBy(c => c.FirstName);
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
