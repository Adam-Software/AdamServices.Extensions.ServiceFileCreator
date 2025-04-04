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

### Create service file

* After launching the application, the `service_info.json` file will appear in the root directory of the repository. In this case, the project should have the following 
  ```
  RepositoryName == AdamServices.SolutionName (e.g. AdamServices.FindRobot)
  |
  | -- src
  |     |
  |     |-- SolutionName (e.g. FindRobot)
  |           |
  |           | --  SolutionName.csproj (e.g. FindRobot)
  |
  | -- AdamServices.SolutionName (e.g. AdamServices.FindRobot)
  | -- service_info.json << here it is, the service file
  | -- other files (README, LICENSE, git files, etc)
  ``` 
