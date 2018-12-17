using System.Collections.Generic;

namespace ContactsBox.Presentation.MVC.ViewModels
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            Telephones = new List<TelephoneViewModel>();
            Emails = new List<EmailViewModel>();
        }

        public  int Id { get; set; }
        public  string Name { get; set; }
        public  string Company { get; set; }
        public  string Address { get; set; }
        public  bool Ativo { get; set; }

        public  IList<TelephoneViewModel> Telephones { get; set; }
        public  IList<EmailViewModel> Emails { get; set; }

    }
}
