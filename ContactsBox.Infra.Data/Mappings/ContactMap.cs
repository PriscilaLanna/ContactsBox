using ContactsBox.Domain.Entities;
using FluentNHibernate.Mapping;

namespace ContactsBox.Infra.Data.Mappings
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Table("Contact");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Company);
            Map(x => x.Address);
        }
    }
}
