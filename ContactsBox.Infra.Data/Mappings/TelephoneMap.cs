using ContactsBox.Domain.Entities;
using FluentNHibernate.Mapping;

namespace ContactsBox.Infra.Data.Mappings
{
    public class TelephoneMap : ClassMap<Telephone>
    {
        public TelephoneMap()
        {
            Table("Telephone");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ContactId);
            Map(x => x.Number);
            Map(x => x.TypeId);
            //CompositeId()
            //.KeyReference(x => x.Id, "Id")
            //.KeyProperty(x => x.ContactId, "ContactId");
         //  References(x => x.Contact).Column("Id").Not.Nullable();

            //References(x => x.Contact).Column("ContactId"); //luiz

        }
    }
}
