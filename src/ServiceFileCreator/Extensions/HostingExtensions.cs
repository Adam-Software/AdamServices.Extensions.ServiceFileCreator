using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceFileCreator.Model;
using ServiceFileCreator.Service;
using System;


namespace ServiceFileCreator.Extensions
{
    public static class HostingExtensions
    {
        public static void UseAdamServiceFileCreator(this IHost host, string repositoryRootPath = default, string serviceInfoFileName = default, ProjectType projectType = ProjectType.None)
        {
            IServiceProvider serviceProvider = host.Services;

            IHostEnvironment hostEnvironment = serviceProvider.GetService<IHostEnvironment>();
            bool isDevelopment = hostEnvironment.IsDevelopment();

            if (isDevelopment)
            {
                if (string.IsNullOrEmpty(repositoryRootPath))
                    repositoryRootPath = DefaultNameAndPath.RepositoryRootPath;

                if (string.IsNullOrEmpty(serviceInfoFileName))
                    serviceInfoFileName = DefaultNameAndPath.ServiceInfoFileDefaultName;

                if (projectType == ProjectType.None)
                    projectType = DefaultNameAndPath.DefaultProjectType;

                IServiceFileCreator serviceInfoCreatorService = serviceProvider.GetService<IServiceFileCreator>();
                serviceInfoCreatorService.UpdateOrCreateServiceInfoFileAsync(repositoryRootPath: repositoryRootPath, serviceInfoFileName: serviceInfoFileName, projectType: projectType);
            }

        }
    }
}
