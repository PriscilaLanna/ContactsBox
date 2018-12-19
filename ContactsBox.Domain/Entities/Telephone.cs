using System.ComponentModel.DataAnnotations;

namespace ContactsBox.Domain.Entities
{
    public class Telephone
    {
        public virtual int  Id { get; set; }
        public virtual int ContactId { get; set; }
        [Required(ErrorMessage = "Telefone é obrigatório")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefone em formato inválido.")]
        public virtual string Number { get; set; }
        [Required]
        public virtual int TypeId { get; set; }

        //public virtual Contact Contact { get; set; }
    }
}
