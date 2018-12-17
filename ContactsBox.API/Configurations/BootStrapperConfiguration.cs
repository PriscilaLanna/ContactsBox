using ContactsBox.Infra.CrossCuttting.IoC;
using Microsoft.Extensions.DependencyInjection;

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
