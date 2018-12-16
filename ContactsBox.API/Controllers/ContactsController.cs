using System.Collections.Generic;
using ContactsBox.Domain.Entities;
using ContactsBox.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContactsBox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: api/Contacts
        [HttpGet]      
        public IEnumerable<Contact> Get()
        {
            var contact = _contactService.Get();

            return contact;
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]       
        public Contact Get(int id)
        {
            var contact = _contactService.GetById(id);

            return contact;
        }

        // POST: api/Contacts
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
