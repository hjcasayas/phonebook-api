using Phonebook.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Data.Services
{
    public class PhonebookDbContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}
