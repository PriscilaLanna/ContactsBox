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
    public class EmailRepository : IEmailRepository
    {
        private readonly INHibernateContext _context;
        public EmailRepository(INHibernateContext context)
        {
            _context = context;
        }

        public void Delete(int Id)
        {
            using (var session = _context.OpenSession())
            {
                var email = session.Get<Email>(Id);
                if (email != null)
                {                   
                    session.Delete(email);
                }
            }
        }       

        public IEnumerable<Email> Get()
        {
            using (var session = _context.OpenSession())
            {
                return session.Query<Email>().ToList();
            }
        }

        public IEnumerable<Email> GetAll(Expression<Func<Email, bool>> predicate, params Expression<Func<Email, Object>>[] includes)
        {
            using (var session = _context.OpenSession())
            {
                var query = session.Query<Email>().Where(predicate);

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

        public Email GetById(int Id)
        {
            using (var session = _context.OpenSession())
            {
                return session.Query<Email>()
                    .Where(x => x.Id == Id)                   
                    .FirstOrDefault();
            }
        }

        public void Save(Email obj)
        {
            using (var session = _context.OpenSession())
            {
                session.Save(obj);
            }
        }

        public void Update(Email obj)
        {
            using (var session = _context.OpenSession())
            {
                session.Update(obj);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
