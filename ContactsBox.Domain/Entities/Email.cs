namespace ContactsBox.Domain.Entities
{
    public class Email
    {
        public virtual int  Id { get; set; }
        public virtual int  ContactId { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual int TypeId { get; set; }
    }
}
