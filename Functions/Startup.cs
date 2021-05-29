using Functions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            RegisterSettings(builder.Services);
            builder.Services.RegisterAppSettings(
                DependencyInjectionUtility.OptionsReaderFor<SmtpSettings>());
        }
        private static void RegisterSettings(IServiceCollection services)
        {
            services.RegisterAsOptions<SmtpSettings>("Smtp");
        }
    }
}