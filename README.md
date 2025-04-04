# AdamServices.Extensions.ServiceFileCreator
[![.NET Publish Nuget Package And Release](https://github.com/Adam-Software/AdamServices.Extensions.ServiceFileCreator/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Adam-Software/AdamServices.Extensions.ServiceFileCreator/actions/workflows/dotnet.yml)


Utility for creating service files used by AdamServices.Utilities.Managment , serving as an extension for Microsoft Dependency Injection (DI), and used to standardize the type definition of service files across all projects built within the Managment project.

### Install

.NET CLI
```cmd
dotnet add package AdamServices.Extensions.ServiceFileCreator
```

Package Manager
```cmd
NuGet\Install-Package AdamServices.Extensions.ServiceFileCreator
```

### Update the configuration of the DI project

* Add ServiceFileCreator initialization to the service configurations
  ```C#
  .ConfigureServices((context, services) =>
  {
      services.AddAdamServiceFileCreator();
  })
  ```

* After building the hostbuilder, call the ServiceFileCreator in this way:
  ```C#
  host.UseAdamServiceFileCreator();
  ```

* Set the `DOTNET_ENVIRONMENT` environment variable of the project to the value of `Development`
  ```json
  "environmentVariables": {
  "DOTNET_ENVIRONMENT": "Development"
  }
  ```
