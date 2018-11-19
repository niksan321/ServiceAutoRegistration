namespace ServiceAutoRegistration
{
    public class NamespaceOptions
    {
        /// <summary>
        /// The namespace in which to search for Scoped services
        /// </summary>
        public string Scoped { get; set; }

        /// <summary>
        ///The namespace in which to search for Transient services
        /// </summary>
        public string Transient { get; set; }

        /// <summary>
        /// The namespace in which to search for Singleton services
        /// </summary>
        public string Singleton { get; set; }

        /// <summary>
        /// Defines how to compare namespaces. Default is "Equal"
        /// </summary>
        public NamespaceCompareType CompareType { get; set; } = NamespaceCompareType.Equal;

        public bool HasScoped => !string.IsNullOrWhiteSpace(Scoped);
        public bool HasTransient => !string.IsNullOrWhiteSpace(Transient);
        public bool HasSingleton => !string.IsNullOrWhiteSpace(Singleton);
    }
}
