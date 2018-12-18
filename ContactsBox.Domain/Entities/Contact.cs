using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactsBox.Domain.Entities
{   
    public class Contact
    {
        public Contact()
        {
            Telephones = new List<Telephone>();
            Emails = new List<Email>();
        }
             
        public virtual int Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
        public virtual string Company { get; set; }
        public virtual string Address { get; set; }
        public virtual bool Ativo { get; set; }

        public virtual IList<Telephone> Telephones { get; set; }
        public virtual IList<Email> Emails { get; set; }
    }
}
