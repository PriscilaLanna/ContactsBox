using ContactsBox.Domain.Interfaces.Repository;
using ContactsBox.Domain.Interfaces.Service;
using ContactsBox.Domain.Services;
using ContactsBox.Infra.Data.Context;
using ContactsBox.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsBox.Infra.CrossCuttting.IoC
{
    public  class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Context
            services.AddScoped<INHibernateContext, NHibernateContext>();

            //Repository
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ITelephoneRepository, TelephoneRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();

            //Service
            services.AddScoped<IContactService, ContactService>();
        }
    }
}
