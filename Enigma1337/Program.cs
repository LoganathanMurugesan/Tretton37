using Enigma1337.Handlers;
using Enigma1337.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enigma1337
{
    class Program
    {
        //Entry point to the application
        static void Main()
        {
            //Enabling the DI to inject the resource downloader dependency at run time.
            var serviceProvider = new ServiceCollection()
                    .AddSingleton<IResourceDownloader, ResourceDownloader>()
                    .BuildServiceProvider();

            //Handles the exception globally for a error logging and graceful termination
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler.HandleTheUnhandled;

            //Entry to the application's process
            Tretton37 tretton37 = new Tretton37(serviceProvider.GetRequiredService<IResourceDownloader>());
            tretton37.WebsiteDownloader();
        }
    }
}
