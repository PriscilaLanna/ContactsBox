using ContactsBox.Infra.CrossCuttting.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsBox.API.Configurations
{
    public static class BootStrapperConfiguration
    {
        public static void AddDI(this IServiceCollection services)
        {
            BootStrapper.RegisterServices(services);
        }
    }
}
