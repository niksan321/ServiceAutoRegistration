using ServiceAutoRegistration.Providers;

namespace ServiceAutoRegistration
{
    public class AutoRegistrationOptions
    {
        /// <summary>
        /// Options for namespaces
        /// </summary>
        public NamespaceOptions Namespaces { get; set; } = new NamespaceOptions();

        /// <summary>
        /// Registration provider. Default - InterfaceRegistrationProvider
        /// </summary>
        public IRegistrationProvider Provider { get; set; } = new InterfaceRegistrationProvider();
    }
}