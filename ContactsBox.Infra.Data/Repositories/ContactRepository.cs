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
            _telephoneRepository = telephoneRepository;
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
                using (var transaction = session.BeginTransaction())
                {
                    //String hql = "INSERT INTO Contacts (Name, Company, Address, Ativo)";
                    //var query = session.CreateQuery(hql);
                    //query.SetParameter("Name", contact.Name);
                    //query.SetParameter("Company", contact.Company);
                    //query.SetParameter("Address", contact.Address);
                    //query.SetParameter("Ativo", true);

                    //int result = query.ExecuteUpdate();

                    //foreach (var telephone in contact.Telephones)
                    //{
                    //    String hql2 = "INSERT INTO Telephone Values(:ContactId, :Number, :TypeId)";
                    //    var queryTelephone = session.CreateQuery(hql2);
                    //    queryTelephone.SetParameter("ContactId", telephone.ContactId);
                    //    queryTelephone.SetParameter("Number", telephone.Number);
                    //    queryTelephone.SetParameter("TypeId", telephone.TypeId);                     

                    //    queryTelephone.ExecuteUpdate();
                    //}

                    //foreach (var email in contact.Emails)
                    //{
                    //    String hql3 = "INSERT INTO Email Values(:ContactId, :EmailAddress, :TypeId)";
                    //    var queryEmail = session.CreateQuery(hql3);
                    //    queryEmail.SetParameter("ContactId", email.ContactId);
                    //    queryEmail.SetParameter("EmailAddress", email.EmailAddress);
                    //    queryEmail.SetParameter("TypeId", email.TypeId);

                    //    queryEmail.ExecuteUpdate();
                    //}

                    try
                    {
                        session.Save(contact);
                    }
                    catch(Exception ex)
                    {
                        if (ex.Message.Contains("INSERT INTO Telephone (ContactId, Number, TypeId) VALUES (?, ?, ?); select SCOPE_IDENTITY()]"))
                        {
                            foreach (var telephone in contact.Telephones)
                            {
                                telephone.ContactId = contact.Id;
                                _telephoneRepository.Save(telephone);
                            }

                            foreach (var email in contact.Emails)
                            {
                                email.ContactId = contact.Id;
                                _emailRepository.Save(email);
                            }
                        }
                        else throw;
                    }

                    transaction.Commit();
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
                            if (!contact.Telephones.Contains(item))                            
                                _telephoneRepository.Save(item);                              
                        }

                        //Delete Telephones
                        foreach (var item in contact.Telephones)
                        {                            
                            if (!obj.Telephones.Contains(item))                            
                                _telephoneRepository.Delete(item.Id);
                        }

                        //Add Emails
                        foreach (var item in obj.Emails)
                        {
                            if (!contact.Emails.Contains(item))
                                _emailRepository.Save(item);
                        }

                        //Delete Emails
                        foreach (var item in contact.Emails)
                        {
                            if (!obj.Emails.Contains(item))
                                _emailRepository.Delete(item.Id);
                        }

                        transaction.Commit();
                    }

                    session.Update(contact);
                }
            }
        }        
    }
}

