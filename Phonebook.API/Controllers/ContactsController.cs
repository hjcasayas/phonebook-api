using Phonebook.Data.Models;
using Phonebook.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace Phonebook.API.Controllers
{
    [RoutePrefix("api/contacts")]
    public class ContactsController : ApiController
    {
        private readonly IContactData db;

        public ContactsController(IContactData db)
        {
            this.db = db;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetContacts()
        {
            var contacts = db.GetContacts();

            if (contacts.Count() <= 0) {
                return NotFound();
            }
            return Ok<IEnumerable<Contact>>(contacts);

        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetContactById(int id) {
            var contact = db.GetContactById(id);

            if (contact == null) {
                return NotFound();
            }

            return Ok<Contact>(contact);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult AddContact(Contact contact) {
            var existingContact = db.GetContactById(contact.ContactId);
            if (existingContact != null) {
                return Conflict();
            }
           
            db.AddContact(contact);
            return Ok();
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult UpdateContact(Contact contact) {
            var existingContact = db.GetContactById(contact.ContactId);
            if (existingContact == null) {
                return NotFound();
            }
            db.UpdateContact(contact);
            return Ok();
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult DeleteContact(int id) { 
            var existingContact = db.GetContactById(id);
            if (existingContact == null) {
                return NotFound();
            }
            db.DeleteContact(existingContact);
            return Ok();
            
        }
    }
}