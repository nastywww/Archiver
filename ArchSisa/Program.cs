using System;
using System.Threading.Tasks;
using ArchSisa.Core;
using ArchSisa.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ArchSisa
{
    class Program
    {
        private static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IArchiver, Archiver>();
            serviceCollection.AddSingleton<IArgumentParser, ArgumentParser>();
            serviceCollection.AddSingleton<ICompresser, Compresser>();
            serviceCollection.AddSingleton<IDecompresser, Decompresser>();

            return serviceCollection.BuildServiceProvider();
        }

        private static async Task Main(string[] args)
        {
            var serviceProvider = GetServiceProvider();

            var archiver = serviceProvider.GetRequiredService<IArchiver>();

            await archiver.Archive(args);
        }

    }
}
