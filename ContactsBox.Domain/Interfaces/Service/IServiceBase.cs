using System.Collections.Generic;

namespace ContactsBox.Domain.Interfaces.Service
{
    public interface IServiceBase<T> where T : class 
    {
        IEnumerable<T> Get();   
        T GetById(int Id);
        void Save(T obj);
        void Update(T obj);
        void Delete(int Id);
    }
}
