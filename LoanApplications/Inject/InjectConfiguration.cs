using AutoMapper;
using LoanApplications.Profiles;
using LoanApplications.Services;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.DependencyInjection;

namespace LoanApplications.Inject
{
    public class InjectConfiguration : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            var services = new ServiceCollection();
            RegisterServices(services);
            var serviceProvider = services.BuildServiceProvider(true);

            context
                .AddBindingRule<InjectAttribute>()
                .Bind(new InjectBindingProvider(serviceProvider));

            var registry = context.Config.GetService<IExtensionRegistry>();
            var filter = new ScopeCleanupFilter();
            registry.RegisterExtension(typeof(IFunctionInvocationFilter), filter);
            registry.RegisterExtension(typeof(IFunctionExceptionFilter), filter);
        }
        private void RegisterServices(IServiceCollection services)
        { 
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<LoanProfile>();
            });

            services.AddSingleton<IMapper>((serviceProvider) => { return config.CreateMapper(); });
            //Resolve the dependencies for the API references which all the queries.
            services.AddSingleton<IAdminService, AdminService>();

        }
    }
}
