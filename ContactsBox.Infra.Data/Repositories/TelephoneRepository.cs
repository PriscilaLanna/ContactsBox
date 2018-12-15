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
    public class TelephoneRepository : ITelephoneRepository
    {
        private readonly INHibernateContext _context;
        public TelephoneRepository(INHibernateContext context)
        {
            _context = context;
        }

        public void Delete(int Id)
        {
            using (var session = _context.OpenSession())
            {
                var email = session.Get<Telephone>(Id);
                if (email != null)
                {
                    session.Delete(email);
                }
            }
        }       

        public IEnumerable<Telephone> Get()
        {
            using (var session = _context.OpenSession())
            {
                return session.Query<Telephone>().ToList();
            }
        }

        public IEnumerable<Telephone> GetAll(Expression<Func<Telephone, bool>> predicate, params Expression<Func<Telephone, Object>>[] includes)
        {
            using (var session = _context.OpenSession())
            {
                var query = session.Query<Telephone>().Where(predicate);

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

        public Telephone GetById(int Id)
        {
            using (var session = _context.OpenSession())
            {
                return session.Query<Telephone>()
                    .Where(x => x.Id == Id)                   
                    .FirstOrDefault();
            }
        }

        public void Save(Telephone obj)
        {
            using (var session = _context.OpenSession())
            {
                session.Save(obj);
            }
        }

        public void Update(Telephone obj)
        {
            using (var session = _context.OpenSession())
            {
                session.Update(obj);
            }
        }
    }
}
