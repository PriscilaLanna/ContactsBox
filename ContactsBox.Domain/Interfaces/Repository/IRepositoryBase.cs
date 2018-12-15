using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ContactsBox.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<T> where T : class
    {      
        IEnumerable<T> Get();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includes);
        T GetById(int Id);
        void Save(T obj);
        void Update(T obj);
        void Delete(int Id);      
    }
}
