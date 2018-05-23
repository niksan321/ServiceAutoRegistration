using Microsoft.Extensions.DependencyInjection;

namespace ServiceAutoRegistration.Providers
{
    public interface IRegistrationProvider
    {
        IServiceCollection Register(IServiceCollection services, NamespaceOptions namespaces);
    }
}
