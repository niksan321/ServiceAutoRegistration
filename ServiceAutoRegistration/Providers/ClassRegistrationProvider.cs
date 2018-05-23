using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceAutoRegistration.Providers
{

    /// <summary>
    /// Register services by class.
    /// For example, if there is a UserService class in the scoped namespace,
    /// then this provider registers in DI this service with the help of a comand:
    /// services.AddScoped&lt;UserService&gt;
    /// </summary>
    public class ClassRegistrationProvider : RegistrationProviderBase
    {
        protected override void RegisterScoped()
        {
            var types = GetTypes(Namespaces.Scoped);
            Register(Services.AddScoped, types);
        }

        protected override void RegisterTransient()
        {
            var types = GetTypes(Namespaces.Transient);
            Register(Services.AddTransient, types);
        }

        protected override void RegisterSingleton()
        {
            var types = GetTypes(Namespaces.Singleton);
            Register(Services.AddSingleton, types);
        }

        private void Register(Func<Type, IServiceCollection> func, List<Type> types)
        {
            foreach (var classType in types.Where(t => t.IsClass))
            {
                func(classType);
            }
        }
    }
}
