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

        // GET: Retorna todos contatos ativos
        [HttpGet]      
        public IEnumerable<Contact> Get()
        {
            var contact = _contactService.Get();
            return contact;
        }

        // GET: Retorna o contato pelo id
        [HttpGet("{id}")]       
        public Contact Get(int id)
        {
            var contact = _contactService.GetById(id);

            return contact;
        }

        // POST: Cadastra um contato
        [HttpPost]
        public void Post([FromBody] Contact contact)
        {
            _contactService.Save(contact);
        }

        // PUT: Atualiza o contato
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contact contact)
        {
            _contactService.Update(contact);
        }

        // DELETE: Desativa o contato
        [HttpDelete("DeleteContact/{id}")]
        public void Delete(int id)
        {
            _contactService.Delete(id);
        }
    }
}
