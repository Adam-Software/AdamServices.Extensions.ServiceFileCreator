# AdamServices.Extensions.ServiceFileCreator
[![.NET Publish Nuget Package And Release](https://github.com/Adam-Software/AdamServices.Extensions.ServiceFileCreator/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Adam-Software/AdamServices.Extensions.ServiceFileCreator/actions/workflows/dotnet.yml)    
![GitHub License](https://img.shields.io/github/license/Adam-Software/AdamServices.Extensions.ServiceFileCreator)
![GitHub Release](https://img.shields.io/github/v/release/Adam-Software/AdamServices.Extensions.ServiceFileCreator)
![NuGet Version](https://img.shields.io/nuget/v/AdamServices.Extensions.ServiceFileCreator)






Library for creating service files `service_info.json` used by AdamServices.Utilities.Managment , serving as an extension for Microsoft Dependency Injection (DI), and used to standardize the type definition of service files across all projects built within the Managment project.

A fresh sample of the `service_info.json` file can be downloaded from files attached to the latest release. If you do not want or cannot use this library for certain reasons, you can edit the fields filled in by default and put the service file in the root of the repository.

## For users

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
```xml
<PropertyGroup>
  ...
  <Version>0.1.1</Version>
  ...
</PropertyGroup>
```

`projectType` - It is filled in automatically. Default value: DotnetProject

The remaining fields of the service file are filled in manually, depending on the technical specifications of the project.

## For developers

### Publishing releases

To publish a release, you need to:

* Upgrade the version in the project configuration and commit the changes
  ```xml
  <PropertyGroup>
    ...
    <Version>1.0.1</Version>
    ...
  </PropertyGroup>
  ```
  Version format X.X.X
* Mark the commit with a tag of the format: v.X.X.X
  e.g. version 1.0.1 tag v.1.0.1
* Push commits and tags. The release will be published automatically.

Important!

* Technically, it doesn't matter which version is specified in the project configuration, the version number is taken from the tag. They may differ, for example, as a result of an error or carelessness. Preference should be given to the version specified in the tag.
* The trigger for publishing a release is a xxx format tag. From any branch.

### What's going on at CI?

* Building a library with a project and a test application to which the library is linked via a link to the project
* Packaging the library in a nuget package
* Launching a test application that creates a file, services_info.json with fields filled in by default
* Publishing packages on nuget and github package
* Publication of the release to which the following are attached: source codes, nuget package version, services_info.json file with fields filled in by default
  



