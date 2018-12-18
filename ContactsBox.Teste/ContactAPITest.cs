using ContactsBox.API.Controllers;
using ContactsBox.Domain.Entities;
using ContactsBox.Domain.Interfaces.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ContactsBox.Teste
{
    [TestClass]
    public class ContactAPITest
    {
        Mock<IContactService> _mock;
        ContactsController _target;

        [TestMethod]
        public void GetAll()
        {
            _mock = new Mock<IContactService>();
            _target = new ContactsController(_mock.Object);

            var contacts = new List<Contact>
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

            _mock.Setup(x => x.Get()).Returns(contacts);
            var obtido = _target.Get();

            Assert.AreEqual(2, obtido.Count());
            Assert.AreEqual("Contact A", obtido.ToArray()[0].Name);
            Assert.AreEqual("Contact C", obtido.ToArray()[1].Name);

        }

        [TestMethod]
        public void GetById() { }

        [TestMethod]
        public void Delete() {
          
        }
    }
}
