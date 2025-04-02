using ServiceFileCreator.Model;
using System.IO;

namespace ServiceFileCreator
{
    public static class DefaultNameAndPath
    {
        public static string RepositoryRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName;

        public const string ServiceInfoFileDefaultName = "service_info.json";
        public const ProjectType DefaultProjectType = ProjectType.DotnetProject;
    }
}
