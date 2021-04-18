using Enigma1337.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enigma1337
{
    class Program
    {
        static void Main()
        {
            //Enabling the DI to inject the resource downloader dependency at run time.
            var serviceProvider = new ServiceCollection()
                    .AddSingleton<IResourceDownloader, ResourceDownloader>()
                    .BuildServiceProvider();
            
            Tretton37Downloader(serviceProvider);   
        }


        /// <summary>
        /// Tretton37Downloader process the end to end flow.
        /// </summary>
        /// <param name="serviceProvider">To inject the dependencies</param>
        /// <remarks>
        /// Delegates the tasks including directory creation, urls extraction
        /// downloading the files and saving them to a local directory.
        /// </remarks>
        /// <returns>Returns nothing</returns>
        static void Tretton37Downloader(IServiceProvider serviceProvider)
        {
            ProgressBar.ProcessStarts();
            List<string> Urls = new List<string>();
            //Intiates a parallel call between two independent tasks - directory creation and
            //url extration across the webpages.
            Parallel.Invoke(
                () => { Directory.CreateDirectory();},
                () => { Urls = ResourceUrlProvider.GetUrls().Result;}
                );
            //Downloads the files using the urls extracted.
            Task.WaitAll(serviceProvider.GetService<IResourceDownloader>().DownloadUsingHttpClient(Urls));

        }

    }
}
