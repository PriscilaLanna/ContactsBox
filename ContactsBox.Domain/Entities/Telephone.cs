namespace ContactsBox.Domain.Entities
{
    public class Telephone
    {
        public int  Id { get; set; }
        public int  ContactId { get; set; }
        public string Number { get; set; }
        public int  TypeId { get; set; }
    }
}
