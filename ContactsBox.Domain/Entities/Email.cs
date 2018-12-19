using System.ComponentModel.DataAnnotations;

namespace ContactsBox.Domain.Entities
{
    public class Email
    {
        public virtual int  Id { get; set; }
        public virtual int  ContactId { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public virtual string EmailAddress { get; set; }
        public virtual int TypeId { get; set; }

        //public virtual Contact Contact { get; set; }
    }
}
