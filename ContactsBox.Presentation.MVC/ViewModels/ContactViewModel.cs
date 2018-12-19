using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactsBox.Presentation.MVC.ViewModels
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            Telephones = new List<TelephoneViewModel>();
            Emails = new List<EmailViewModel>();
            TelephonesRemove = new List<TelephoneViewModel>();
            EmailsRemove = new List<EmailViewModel>();
        }

        public  int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public  string Name { get; set; }
        public  string Company { get; set; }
        public  string Address { get; set; }
        public  bool Ativo { get; set; }
        [Required(ErrorMessage = "O tefone é obrigatório")]
        public  IList<TelephoneViewModel> Telephones { get; set; }

        public IList<TelephoneViewModel> TelephonesRemove { get; set; }
        public  IList<EmailViewModel> Emails { get; set; }
        public IList<EmailViewModel> EmailsRemove { get; set; }
        

    }
}
