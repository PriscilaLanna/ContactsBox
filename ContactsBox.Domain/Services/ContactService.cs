using ContactsBox.Domain.Entities;
using ContactsBox.Domain.Interfaces.Repository;
using ContactsBox.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace ContactsBox.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void Delete(int Id)
        {
            _contactRepository.Delete(Id);
        }

        public IEnumerable<Contact> Get()
        {
            return _contactRepository.Get();
        }
        
        public Contact GetById(int Id)
        {
            return _contactRepository.GetById(Id);
        }

        public void Save(Contact obj)
        {
            _contactRepository.Save(obj);
        }

        public void Update(Contact obj)
        {
            _contactRepository.Update(obj);
        }
    }
}
