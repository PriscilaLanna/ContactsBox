using AutoMapper;
using ContactsBox.Domain.Entities;
using ContactsBox.Presentation.MVC.ViewModels;

namespace ContactsBox.Presentation.MVC.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Contact, ContactViewModel>();
            CreateMap<Telephone, TelephoneViewModel>();
            CreateMap<Email, EmailViewModel>();            
        }
    }
}
