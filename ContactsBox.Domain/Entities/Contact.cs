using System.Collections.Generic;

namespace ContactsBox.Domain.Entities
{
    public class Contact
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Company { get; set; }
        public virtual string Address { get; set; }
        public virtual bool Ativo { get; set; }

        public virtual IList<Telephone> Telephones { get; set; }
        public virtual IList<Email> Emails { get; set; }
    }
}
