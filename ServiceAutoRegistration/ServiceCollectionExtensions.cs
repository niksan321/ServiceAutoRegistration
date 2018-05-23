using System;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceAutoRegistration
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds automatic search and registration services in the specified namespaces.
        /// </summary>
        public static IServiceCollection AutoRegisterServices(this IServiceCollection services, Action<AutoRegistrationOptions> configureOptions)
        {
            var options = GetOptions(configureOptions);
            var provider = options.Provider;
            return provider.Register(services, options.Namespaces);
        }

        private static AutoRegistrationOptions GetOptions(Action<AutoRegistrationOptions> configure)
        {
            var options = new AutoRegistrationOptions();
            configure(options);
            return options;
        }
    }
}
