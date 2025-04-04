using Microsoft.Extensions.Hosting;
using ServiceFileCreator.Extensions;

namespace ServiceFileCreator.TestApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)

                  .ConfigureServices((context, services) =>
                  {
                      services.AddAdamServiceFileCreator();
                  })
                  .Build();

            host.UseAdamServiceFileCreator();
            await host.RunAsync();
        }
    }
}
