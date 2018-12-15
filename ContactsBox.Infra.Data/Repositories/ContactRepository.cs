using ContactsBox.Domain.Entities;
using ContactsBox.Domain.Interfaces.Repository;
using ContactsBox.Infra.Data.Context;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ContactsBox.Infra.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly INHibernateContext _context;
        public ContactRepository(INHibernateContext context)
        {
            _context = context;
        }

        public void Delete(int Id)
        {
            using (var session = _context.OpenSession())
            {
                var contact = session.Get<Contact>(Id);
                if (contact != null)
                {
                    contact.Ativo = false;
                    session.Update(contact);
                }
            }
        }

        public IEnumerable<Contact> Get()
        {
            using (var session = _context.OpenSession())
            {
                return session.Query<Contact>().Where(x => x.Ativo).ToList();
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
                return query.ToList();
            }
        }

        public Contact GetById(int Id)
        {
            using (var session = _context.OpenSession())
            {
                return session.Query<Contact>()
                    .Where(x => x.Id == Id)
                    .FirstOrDefault();
            }
        }

        public void Save(Contact obj)
        {
            using (var session = _context.OpenSession())
            {
                session.Save(obj);
            }
        }

        public void Update(Contact obj)
        {
            using (var session = _context.OpenSession())
            {
                session.Update(obj);
            }
        }        
    }
}

