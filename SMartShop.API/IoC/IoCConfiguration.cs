using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMartShop.Infra.CrossCutting.IoC;

namespace SMartShop.API.IoC
{
    public static class IoCConfiguration
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            Bootstraper.RegisterServices(services, configuration);
            Bootstraper.RegisterServices(services, ApiModule.GetSingleTypes());
            Bootstraper.RegisterServices(services, ApiModule.GetTypes(), true);
        }
    }
}
