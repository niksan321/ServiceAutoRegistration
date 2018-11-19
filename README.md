# ServiceAutoRegistration
Allows you to automatically register services in the Asp.Net Core DI container. Autoregistration occurs by searching for services in a given namespace.

### Installing
* You can use nuget to install package `Install-Package ServiceAutoRegistration`.
* Or you can use dotnet cli `dotnet add package ServiceAutoRegistration`.

### Two registration modes are supported
* registration of all founded services by class
* registration of all founded services by interfaces and corresponding class

#### Registration by interfaces and class (default behavior)
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

#### AutoRegistrationOptions
Also, you can determine exactly how you should compare namespaces when searching for services by setting the `CompareType` property.
It can have the following meanings:
* Equal (Default)
* Contain
* StartsWith
* EndsWith

This code registers all services that contain `Services` in the namespace.
```sh
public void ConfigureServices(IServiceCollection services)
{
	services.AutoRegisterServices(options =>
	{
		options.Namespaces.Scoped = "Services";
		options.Namespaces.CompareType = NamespaceCompareType.Contain;
	});
}
```
