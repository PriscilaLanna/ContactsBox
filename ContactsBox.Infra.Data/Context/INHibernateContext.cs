using NHibernate;

namespace ContactsBox.Infra.Data.Context
{
    public interface INHibernateContext
    {
        ISession OpenSession();
    }
}