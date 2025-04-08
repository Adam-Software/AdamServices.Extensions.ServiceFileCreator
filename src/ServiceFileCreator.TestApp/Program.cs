using Microsoft.Extensions.Hosting;
using ServiceFileCreator.Extensions;

namespace ServiceFileCreator.TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jsonFilesPath  = Path.Combine(DefaultNameAndPath.RepositoryRootPath, "config");

            IHost host = Host.CreateDefaultBuilder(args)

                  .ConfigureServices((context, services) =>
                  {
                      services.AddAdamServiceFileCreator();
                  })
                  .Build();

            host.UseAdamServiceFileCreator(repositoryRootPath: jsonFilesPath);
            host.RunAsync();
        }
    }
}
