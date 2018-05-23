using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceAutoRegistration.Providers
{
    /// <summary>
    /// Register services by associating interfaces and corresponding class.
    /// For example, if there is an IUserService interface and a UserService class in the scoped namespace,
    /// then this provider registers in DI this service with the help of a comand:
    /// services.AddScoped&lt;IUserService, UserService&gt;
    /// </summary>
    class InterfaceRegistrationProvider : RegistrationProviderBase
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

        private void Register(Func<Type, Type, IServiceCollection> func, List<Type> types)
        {
            foreach (var interfaceType in types.Where(t => t.IsInterface))
            {
                // class name is the name of the interface without the first letter I
                var className = interfaceType.Name.Substring(1);
                var implementation = types.FirstOrDefault(c => c.IsClass && className == c.Name);
                if (implementation != null)
                {
                    func(interfaceType, implementation);
                }
            }
        }
    }
}
