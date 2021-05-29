using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Functions
{
    public static class DependencyInjectionUtility
    {
        public static void RegisterAsOptions<T>(this IServiceCollection services, string sectionName) where T : class
        {
            services.AddOptions<T>().Configure<IConfiguration>((settings, config) => { config.GetSection(sectionName).Bind(settings); });
        }
        public static Func<IServiceProvider, T> OptionsReaderFor<T>() where T : class, new()
        {
            return sp => sp.GetService<IOptions<T>>().Value;
        }
        public static void RegisterAppSettings(
            this IServiceCollection services,
            Func<IServiceProvider, SmtpSettings> smtpSettings)
        {
            services.MakeSettingsAvailableForUse(smtpSettings);
        }
        
        private static void MakeSettingsAvailableForUse<T>(this IServiceCollection services, Func<IServiceProvider, T> fetcher) where T : class
        {
            services.AddSingleton<T>(fetcher);
        }
    }
}