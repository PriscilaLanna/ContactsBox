namespace ContactsBox.Domain.Entities
{
    public class Telephone
    {
        public virtual int  Id { get; set; }
        public virtual int ContactId { get; set; }
        public virtual string Number { get; set; }
        public virtual int TypeId { get; set; }

        //public virtual Contact Contact { get; set; }
    }
}
