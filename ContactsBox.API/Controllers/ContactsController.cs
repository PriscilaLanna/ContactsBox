using System.Collections.Generic;
using System.Net.Http;
using ContactsBox.Domain.Entities;
using ContactsBox.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

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
        /// <summary>
        /// Retorna todos contatos ativos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            var contact = _contactService.Get();
            return contact;
        }

        // GET: Retorna o contato pelo id
        /// <summary>
        /// Retorna o contato pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            var contact = _contactService.GetById(id);

            return contact;
        }

        // POST: Cadastra um contato
        /// <summary>
        /// Cadastra um contato
        /// </summary>
        /// <param name="contact"></param>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contactService.Save(contact);
                    return new HttpResponseMessage(System.Net.HttpStatusCode.Created);
                }
                catch (System.Exception ex)
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }

        // PUT: Atualiza o contato
        /// <summary>
        /// Atualiza o contato
        /// </summary>       
        /// <param name="contact"></param>
        [HttpPut("{id}")]
        public HttpResponseMessage Put([FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contactService.Update(contact);
                    return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                }
                catch (System.Exception ex)
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }

        // DELETE: Desativa o contato
        /// <summary>
        /// Desativa o contato
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _contactService.Delete(id);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch (System.Exception ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
