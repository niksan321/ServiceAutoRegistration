# ServiceAutoRegistration
Allows you to automatically register services in the Asp.Net Core DI container. Autoregistration occurs by searching for services in a given namespace.

### Installing
* You can use nuget to install package `Install-Package ServiceAutoRegistration`.
* Or you can use dotnet cli `dotnet add package ServiceAutoRegistration`.

### Two registration modes are supported
* registration of all founded services by class
* registration of all founded services by class and corresponding interfaces
 
#### Registration by class and interfaces (default behavior)
This code search for all classes in `Api.Services.Singleton` namespace and register its by executing `services.AddSingleton(IService, Service)` for all founded classes. And also search for all classes in `Api.Services` namespace and register its by executing `services.AddScoped(IService, Service)` for all founded classes.
```sh
public void ConfigureServices(IServiceCollection services)
{
	services.AutoRegisterServices(options =>
	{
		options.Namespaces.Scoped = "Api.Services";
		options.Namespaces.Singleton = "Api.Services.Singleton";
	});
}
```

#### Registration by class
This code search for all classes in `Api.Services` namespace and register its by executing `services.AddScoped(Service)` for all founded classes.
```sh
public void ConfigureServices(IServiceCollection services)
{
	services.AutoRegisterServices(options =>
	{
		options.Namespaces.Scoped = "Api.Services";
		options.Provider = new ClassRegistrationProvider();
	});
}
```