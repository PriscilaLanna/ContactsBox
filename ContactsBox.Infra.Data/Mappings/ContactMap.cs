using ContactsBox.Domain.Entities;
using FluentNHibernate.Mapping;

namespace ContactsBox.Infra.Data.Mappings
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Table("Contact") ;
            Id(x => x.Id, "Id").GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Company);
            Map(x => x.Address);
            Map(x => x.Ativo);         
            HasMany(x => x.Telephones).Cascade.All().LazyLoad().KeyColumn("Id");
            HasMany(x => x.Emails).Cascade.All().LazyLoad().KeyColumn("ContactId");
        }
    }
}
