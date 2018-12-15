using ContactsBox.Domain.Entities;
using FluentNHibernate.Mapping;

namespace ContactsBox.Infra.Data.Mappings
{
    public class TelephoneMap : ClassMap<Telephone>
    {
        public TelephoneMap()
        {
            Table("Telephone");
            Id(x => x.Id);
            Map(x => x.ContactId);
            Map(x => x.Number);
            Map(x => x.TypeId);
        }
    }
}
