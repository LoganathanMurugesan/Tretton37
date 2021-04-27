using Enigma1337.Interface;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Enigma1337.Extension;
using System.Linq;
using System;

namespace Enigma1337
{
    public class Tretton37
    {
        private readonly IResourceDownloader _resourceDownloader;
        public Tretton37(IResourceDownloader resourceDownloader)
        {
            _resourceDownloader = resourceDownloader;
        }
        /// <summary>
        /// Tretton37Downloader process the end to end flow.
        /// </summary>
        /// <param>/param>
        /// <remarks>
        /// Delegates the tasks including directory creation, urls extraction
        /// downloading the files and saving them to a local directory.
        /// </remarks>
        /// <returns>Returns nothing</returns>
        public void WebsiteDownloader(ConcurrentBag<string> dequeuedUrls, int iteration)
        {
            List<string> dequeuedUrl;
            try
            {
                if (dequeuedUrls.Count == 0)
                {
                    dequeuedUrls = new ConcurrentBag<string>();
                    dequeuedUrl = new List<string>();

                    var routesOfTheWebsite = HtmlLinkExtractor.ExtractUrlsFromWebsite("//a[@href]");
                    var fullQualifiedWebsiteRoutes = routesOfTheWebsite.Where(x => x.StartsWith("https://tretton37.com/")).Distinct().ToList();
                    dequeuedUrls.AddMultipleItems_WithHtmlExtension(fullQualifiedWebsiteRoutes);

                    //Parallel.ForEach(fullQualifiedWebsiteRoutes, route =>
                    //{
                    //    var resourceUlrs = ExtractUrlsFromWebsite("//link[@href]|//script[@src]", route);
                    //    dequeuedUrls.AddMultipleItems(resourceUlrs);
                    //});

                    foreach (var route in fullQualifiedWebsiteRoutes)
                    {
                        var resourceUlrs = HtmlLinkExtractor.ExtractUrlsFromWebsite("//link[@href]|//script[@src]", route);
                        dequeuedUrls.AddMultipleItems(resourceUlrs);
                    }

                }

                var result = dequeuedUrls;
                var distinctResult = result.Distinct().ToList();
                _resourceDownloader.DownloadUsingHttpClient(distinctResult[iteration]);
                iteration++;
                if (iteration >= distinctResult.Count)
                    return;
                Console.WriteLine("Dowloading itertation: " + iteration);
                WebsiteDownloader(dequeuedUrls, iteration);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error from the WebsiteDownloader().");
                throw e;
            }
            
        }
    }
}
