using ContactsBox.Domain.Entities;
using ContactsBox.Domain.Interfaces.Repository;
using ContactsBox.Infra.Data.Context;
using NHibernate.Linq;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ContactsBox.Infra.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly INHibernateContext _context;
        private readonly ITelephoneRepository _telephoneRepository;
        private readonly IEmailRepository _emailRepository;

        public ContactRepository(INHibernateContext context, ITelephoneRepository telephoneRepository, IEmailRepository emailRepository)
        {
            _context = context;
            _telephoneRepository = telephoneRepository;
            _emailRepository = emailRepository;
        }

        public void Delete(int Id)
        {
            using (var session = _context.OpenSession())
            {
                var contact = session.Get<Contact>(Id);
                if (contact != null)
                {
                    contact.Ativo = false;

                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(contact);
                        transaction.Commit();
                    }

                    session.Update(contact);
                }
            }
        }

        public IEnumerable<Contact> Get()
        {
            using (var session = _context.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var contacts = session.Query<Contact>()
                        .Where(x => x.Ativo)
                        .FetchMany(x => x.Telephones)
                        .ToFuture();

                    session.Query<Contact>()
                        .Where(x => x.Ativo)
                        .FetchMany(x => x.Emails)
                        .ToFuture();

                    tran.Commit();

                    return contacts.ToList().OrderBy(x => x.Name);
                }
            }

        }

        public IEnumerable<Contact> GetAll(Expression<Func<Contact, bool>> predicate, params Expression<Func<Contact, Object>>[] includes)
        {
            using (var session = _context.OpenSession())
            {
                var query = session.Query<Contact>().Where(predicate);

                if (includes != null)
                {
                    foreach (var fetchPath in includes)
                    {
                        query = query.Fetch(fetchPath);
                    }
                }
                return query.ToList().OrderBy(x => x.Name);
            }
        }

        public Contact GetById(int Id)
        {
            using (var session = _context.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var contacts = session.Query<Contact>()
                        .Where(x => x.Ativo && x.Id == Id)
                        .FetchMany(x => x.Telephones)
                        .ToFuture();

                    session.Query<Contact>()
                        //.Where(x => x.Ativo)
                        .FetchMany(x => x.Emails)
                        .ToFuture();

                    tran.Commit();

                    return contacts.FirstOrDefault();
                }
            }
        }

        public void Save(Contact contact)
        {
            using (var session = _context.OpenSession())
            {              
                try
                {
                    var contactAux = new Contact
                    {
                        Name = contact.Name,
                        Company = contact.Company,
                        Address = contact.Address,
                        Ativo = contact.Ativo
                    };

                    session.Save(contactAux);

                    using (var transaction = session.BeginTransaction())
                    {
                        foreach (var item in contact.Telephones)
                        {
                            item.ContactId = contactAux.Id;
                            _telephoneRepository.Save(item);
                        }

                        foreach (var item in contact.Emails)
                        {
                            item.ContactId = contactAux.Id;
                            _emailRepository.Save(item);
                        }

                        transaction.Commit();

                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void Update(Contact obj)
        {
            using (var session = _context.OpenSession())
            {
                var contact = session.Get<Contact>(obj.Id);

                if (contact != null)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        //Contact
                        contact.Name = obj.Name;
                        contact.Company = obj.Company;
                        contact.Address = obj.Address;

                        session.Save(contact);

                        //Add Telephones
                        foreach (var item in obj.Telephones)
                        {
                            if (!contact.Telephones.Any(x => x.Number == item.Number))
                            {
                                _telephoneRepository.Save(item);
                            }
                        }

                        //Delete Telephones
                        foreach (var item in contact.Telephones)
                        {
                            if (!obj.Telephones.Any(x => x.Number == item.Number))
                                _telephoneRepository.Delete(item.Id);
                        }

                        //Add Emails
                        foreach (var item in obj.Emails)
                        {
                            if (!contact.Emails.Any(x => x.EmailAddress == item.EmailAddress))
                                _emailRepository.Save(item);
                        }

                        //Delete Emails
                        foreach (var item in contact.Emails)
                        {
                            if (!obj.Emails.Any(x => x.EmailAddress == item.EmailAddress))
                                _emailRepository.Delete(item.Id);
                        }

                        transaction.Commit();
                    }                  
                }
            }
        }
    }
}

