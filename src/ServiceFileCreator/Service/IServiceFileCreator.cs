using ServiceFileCreator.Model;
using System.Threading.Tasks;

namespace ServiceFileCreator.Service
{
    internal interface IServiceFileCreator
    {
        internal Task UpdateOrCreateServiceInfoFileAsync(string repositoryRootPath, string serviceInfoFileName, ProjectType projectType);
    }
}
