using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceFileCreator.Model;
using ServiceFileCreator.Utilites;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace ServiceFileCreator.Service
{
    internal class ServiceFileCreator : IServiceFileCreator
    {
        #region Services

        private readonly ILogger<ServiceFileCreator> mLogger;

        #endregion

        public ServiceFileCreator(IServiceProvider serviceProvider) 
        {
            mLogger = serviceProvider.GetService<ILogger<ServiceFileCreator>>();
            mLogger.LogInformation("ServiceFileCreator ~");
        }

        public async Task UpdateOrCreateServiceInfoFileAsync(string repositoryRootPath, string serviceInfoFileName, ProjectType projectType)
        {
            try
            {
                ServiceInfo serviceInfo = await JsonUtilites.ReadJsonFileAsync<ServiceInfo>(repositoryRootPath, serviceInfoFileName);
                Assembly entryAssembly = Assembly.GetEntryAssembly();

                string appVersion = entryAssembly.GetName().Version.ToString();
                string appName = entryAssembly.GetName().Name;

                if (!serviceInfo.Services.Version.Equals(appVersion))
                {
                    mLogger.LogWarning("Version in {file_name} changed!", serviceInfoFileName);
                    mLogger.LogWarning("Old value: {oldValue}, new value: {newValue}", serviceInfo.Services.Version, appVersion);

                    serviceInfo.Services.Version = appVersion;
                }

                if (!serviceInfo.Services.Name.Equals(appName))
                {
                    mLogger.LogWarning("Name in {file_name} changed!", serviceInfoFileName);
                    mLogger.LogWarning("Old value: {oldValue}, new value: {newValue}", serviceInfo.Services.Name, appName);

                    serviceInfo.Services.Name = appName;
                }

                if (serviceInfo.Services.ProjectType != projectType)
                {
                    mLogger.LogWarning("ProjectType in {file_name} changed!", serviceInfoFileName);
                    mLogger.LogWarning("Old value: {oldValue}, new value: {newValue}", serviceInfo.Services.ProjectType, projectType);

                    serviceInfo.Services.ProjectType = projectType;
                }

                mLogger.LogInformation("Path for save: {path}", Path.Combine(repositoryRootPath, serviceInfoFileName));

                await JsonUtilites.SaveJsonFilesAsync(serviceInfo, repositoryRootPath, serviceInfoFileName);
            }
            catch (Exception ex)
            {
                mLogger.LogError("{error}", ex.Message);
            }
        }
    }
}
