using ContactsBox.API.Controllers;
using ContactsBox.Domain.Entities;
using ContactsBox.Domain.Interfaces.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ContactsBox.Teste
{
    [TestClass]
    public class ContactAPITest
    {
        private readonly IContactService _contactService;

        public ContactAPITest(IContactService contactService)
        {
            _contactService = _contactService;
        }

        [TestMethod]
        public void Add()
        {
        }

        [TestMethod]
        public void Update()
        {
        }

        [TestMethod]
        public void GetAll()
        {
            var data = new List<Contact>
            {
                new Contact { Id=1, Name = "Contact A", Ativo=true ,
                    Telephones = new List<Telephone>{  new Telephone{ Id=1, ContactId=1, Number="11987446845",TypeId=1 } },
                    Emails = new List<Email>{ new Email { Id=1, ContactId=1, EmailAddress="contacta@teste.com" } } },
               new Contact { Id=2, Name = "Contact B", Ativo=false ,
                    Telephones = new List<Telephone>{  new Telephone{ Id=1, ContactId=2, Number="1144546845",TypeId=1 } },
                    Emails = new List<Email>{ new Email { Id=1, ContactId=2, EmailAddress="contactb@teste.com" } } },
                new Contact { Id=3, Name = "Contact C", Ativo=true ,
                    Telephones = new List<Telephone>{  new Telephone{ Id=1, ContactId=3, Number="11983226845",TypeId=1 } },
                    Emails = new List<Email>{ new Email { Id=1, ContactId=3, EmailAddress="contactc@teste.com" } } },
            }.AsQueryable();


            var service = new ContactsController(_contactService);
            var Contacts = service.Get();
                       
            Assert.AreEqual(2, Contacts.Count());
            Assert.AreEqual("Contact A", Contacts.ToArray()[0].Name);
            Assert.AreEqual("Contact C", Contacts.ToArray()[1].Name);
        }

        [TestMethod]
        public void GetById() { }

        [TestMethod]
        public void Delete() {
          
        }
    }
}
