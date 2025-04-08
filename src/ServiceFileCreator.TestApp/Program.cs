using Microsoft.Extensions.Hosting;
using ServiceFileCreator.Extensions;
using System.IO;

namespace ServiceFileCreator.TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Save in current dirrectory for building on CI
            // This should not be the case for use in real projects.
            string jsonSavePath = Directory.GetCurrentDirectory();

            IHost host = Host.CreateDefaultBuilder(args)

                  .ConfigureServices((context, services) =>
                  {
                      services.AddAdamServiceFileCreator();
                  })
                  .Build();

            host.UseAdamServiceFileCreator(repositoryRootPath:jsonSavePath);
            host.RunAsync();
        }
    }
}
