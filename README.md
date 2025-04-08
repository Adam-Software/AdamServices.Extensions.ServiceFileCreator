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

An example can be viewed in the [test](https://github.com/Adam-Software/AdamServices.Extensions.ServiceFileCreator/blob/master/src/ServiceFileCreator.TestApp/Program.cs) project.

### Create service file

After launching the application, the `service_info.json` file will appear in the root directory of the repository. In this case, the project should have the following 
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

### Description of the service file

Fields are filled in automatically:
```
"services": {
  "name": "FindRobot",
  "version": "1.0.1.2",
  "projectType": "DotnetProject",
},
```
  
`name` - it is automatically substituted from the assembly name, or changed to the assembly name if the name in the field does not match it. To change this field, you should change the project name.
  
`version` - It is automatically substituted from the build version, or changed to the build version if the entry in the field does not match it. To change this field, you should change the project version.
```
<PropertyGroup>
  ...
  <Version>0.1.1</Version>
  ...
  </PropertyGroup>
```

`projectType` - It is filled in automatically. Default value: DotnetProject

The remaining fields of the service file are filled in manually, depending on the technical specifications of the project.
  
  

  



