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
            var types = Assembly.GetEntryAssembly()
                                .GetTypes()
                                .Where(t => t.Namespace != null);
            switch (Namespaces.CompreType)
            {
                case NamespaceCompreType.Equal:
                    return types.Where(t => t.Namespace == @namespace).ToList();
                case NamespaceCompreType.Contain:
                    return types.Where(t => t.Namespace.Contains(@namespace)).ToList();
                case NamespaceCompreType.StartsWith:
                    return types.Where(t => t.Namespace.StartsWith(@namespace)).ToList();
                case NamespaceCompreType.EndsWith:
                    return types.Where(t => t.Namespace.EndsWith(@namespace)).ToList();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
