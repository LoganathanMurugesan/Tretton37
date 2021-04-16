using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Enigma1337
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> totalUrls = new List<string>();
            List<string> distinctUrls = new List<string>();
            DirectoryCreator.CreateDirectory();
            List<string> routes = ResoureUrlProvider.GetWebsiteRoutes();
            foreach (var route in routes)
            {
                List<string> formattedUrls = ResoureUrlProvider.GetWebpageUrls(route);
                totalUrls.AddRange(formattedUrls);
                distinctUrls = totalUrls.Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();
            }   
            ResourceDownloader.Download(distinctUrls);
            Console.ReadLine();
        }
    }
}
