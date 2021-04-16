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
            Stopwatch stopwatch = new Stopwatch();
            ConcurrentDictionary<string, List<string>> keyValuePairs = new ConcurrentDictionary<string, List<string>>();
            stopwatch.Start();
            DirectoryCreator.CreateDirectory();
            List<string> formattedUrls = new List<string>();
            List<string> routes = ResoureUrlProvider.GetWebsiteRoutes();
            Parallel.ForEach(routes, route =>
            {
               keyValuePairs.TryAdd("Route", ResoureUrlProvider.GetWebpageUrls(route));
            });
            var distinctUrls = keyValuePairs.Values.First().Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();
            ResourceDownloader.Download(distinctUrls);
            stopwatch.Stop();
            Console.WriteLine("TotalTime: " + stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
