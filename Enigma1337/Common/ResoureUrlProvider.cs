using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Enigma1337
{
    public static class ResourceUrlProvider
    {

        /// <summary>
        /// Get the total urls from all the webpages of the website
        /// </summary>
        /// <param></param>
        /// <remarks>
        /// Gathers urls from all the webpages of the website and removes 
        /// duplicate/null if any
        /// </remarks>
        /// <returns> List of all urls </returns>
        public async static Task<List<string>> GetUrls()
        {
              object _obj = new object();
            try
            {
                List<string> formattedUrls = new List<string>();
                // Get a list of all routes from the target website
                List<string> routes = await GetWebsiteRoutes();
                //Fetch the URLs from each route in the list
                Parallel.ForEach(routes, route =>
                {
                    var urls = GetWebpageUrls(route).Result;
                    //since List<T> is not threadsafe and we are using it inside a parallel process, 
                    //lock is implemented to ensure the thread safety. Monitor is used instead of lock for
                    //explicitly releasing the lock on the object once the process is completed.
                    Monitor.Enter(_obj);
                    try
                    {
                        formattedUrls.AddRange(urls);
                    }
                    finally
                    {
                        Monitor.Exit(_obj);
                    }
                });
                var distinctUrls = formattedUrls.Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();
                distinctUrls.RemoveAll(x => x == null || x == Constants.Website);
                return distinctUrls;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error from GetUrls() while extracting the urls from the website");
                throw e;
            } 
        }
        
        /// <summary>
        /// Get the website routes
        /// </summary>
        /// <param></param>
        /// <remarks>
        /// Extract and format all the routes used in the website
        /// </remarks>
        /// <returns> List of website routes </returns>
        public async static Task<List<string>> GetWebsiteRoutes()
        {
            try
            {
                var websiteRoutes = await HtmlLinkExtractor.ExtractUrlsFromWebsite(Constants.RouteRegex);
                var routes = websiteRoutes.FindAll(x => x.Contains(Constants.Website)).Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();
                return routes;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error from GetWebsiteRoutes() while extracting routes from the website");
                throw e;
            }
        }

        /// <summary>
        /// Get the resource urls
        /// </summary>
        /// <param name="websiteRoute"></param>
        /// <remarks>
        /// Extract and format the resource based urls from a particular webpage
        /// </remarks>
        /// <returns> List of formatted urls </returns>
        public async static Task<List<string>> GetWebpageUrls(string websiteRoute)
        {
            try
            {
                List<string> formattedUrls = await HtmlLinkExtractor.ExtractUrlsFromWebsite(Constants.LinkRegex, websiteRoute);
                return formattedUrls;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error from GetWebpageUrls() while extracting the urls from the particular webpage");
                throw e;
            }            
            
        }
    }
}
