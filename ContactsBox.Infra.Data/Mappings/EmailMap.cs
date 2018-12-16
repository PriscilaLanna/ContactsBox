using ContactsBox.Domain.Entities;
using FluentNHibernate.Mapping;

namespace ContactsBox.Infra.Data.Mappings
{
    public class EmailMap : ClassMap<Email>
    {
        public EmailMap()
        {
            Table("Email");
            Id(x => x.Id );
            Map(x => x.ContactId);
            Map(x => x.EmailAddress);
            Map(x => x.TypeId);
            References(x => x.Contact).Cascade.All().LazyLoad().Column("ContactId");
        }
    }
}
