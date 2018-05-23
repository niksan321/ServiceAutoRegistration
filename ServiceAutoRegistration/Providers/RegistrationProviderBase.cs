using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceAutoRegistration.Providers
{
    public abstract class RegistrationProviderBase : IRegistrationProvider
    {
        protected IServiceCollection Services;
        protected NamespaceOptions Namespaces;

        protected abstract void RegisterScoped();
        protected abstract void RegisterTransient();
        protected abstract void RegisterSingleton();

        public IServiceCollection Register(IServiceCollection services, NamespaceOptions namespaces)
        {
            Services = services;
            Namespaces = namespaces;

            if (namespaces.HasScoped) RegisterScoped();
            if (namespaces.HasTransient) RegisterTransient();
            if (namespaces.HasSingleton) RegisterSingleton();

            return Services;
        }

        protected List<Type> GetTypes(string @namespace)
        {
            return Assembly.GetEntryAssembly()
                           .GetTypes()
                           .Where(t => t.Namespace != null && t.Namespace == @namespace)
                           .ToList();
        }
    }
}
