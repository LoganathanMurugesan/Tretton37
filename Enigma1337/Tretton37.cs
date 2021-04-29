using Enigma1337.Interface;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Enigma1337.Extension;
using System.Linq;
using System;
using System.Threading.Tasks;

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
        /// Recursively call itself unitl all the resources are downloaded.
        /// </remarks>
        /// <returns>Returns nothing</returns>
        public void WebsiteDownloader(ConcurrentBag<string> resourceUrlList, int iteration)
        {
            try
            {
                if (resourceUrlList.Count == 0)
                {
                    ProgressBar.Start();
                    resourceUrlList = new ConcurrentBag<string>();
                    var routesOfTheWebsite = HtmlLinkExtractor.ExtractLinkFromWebsite(Constants.RouteRegex);
                    var fullQualifiedWebsiteRoutes = routesOfTheWebsite.Where(x => x.StartsWith(Constants.Website)).Distinct().ToList();
                    //Adds the fully qualified website routes list to concurrent list after appending .html
                    resourceUrlList.AddMultipleItems_WithHtmlExtension(fullQualifiedWebsiteRoutes);

                    Parallel.ForEach(fullQualifiedWebsiteRoutes, route =>
                    {
                        var resourceUlrs = HtmlLinkExtractor.ExtractLinkFromWebsite(Constants.LinkRegex, route);
                        resourceUrlList.AddMultipleItems(resourceUlrs);
                    });

                }
                
                var distinctResult = resourceUrlList.Distinct().ToList();
                ProgressBar.Load(iteration, distinctResult.Count);
                _resourceDownloader.DownloadUsingWebClient(distinctResult[iteration]);
                iteration++;
                if (iteration >= distinctResult.Count)
                {
                    ProgressBar.Stop();
                    return;
                }
                WebsiteDownloader(resourceUrlList, iteration);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error from the WebsiteDownloader().");
                throw e;
            }
            
        }
    }
}
