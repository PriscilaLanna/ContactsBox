namespace ContactsBox.Domain.Entities
{
    public class Email
    {
        public int  Id { get; set; }
        public int  ContactId { get; set; }
        public string EmailAddress { get; set; }
        public int  TypeId { get; set; }
    }
}
