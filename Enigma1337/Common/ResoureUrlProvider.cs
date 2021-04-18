using System;
using System.Collections.Generic;
using System.Linq;
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
            List<string> formattedUrls = new List<string>();
            // Get a list of all routes from the target website
            List<string> routes = await GetWebsiteRoutes();
            //Fetch the URLs from each route in the list
            Parallel.ForEach(routes, route =>
            {                
                formattedUrls.AddRange(GetWebpageUrls(route).Result);
            });
            var distinctUrls = formattedUrls.Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();
            distinctUrls.RemoveAll(x => x == null || x == Constants.Website);
            return distinctUrls;
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
            var websiteRoutes = await HtmlLinkExtractor.ExtractUrlsFromWebsite(Constants.RouteRegex);
            var routes = websiteRoutes.FindAll(x => x.Contains(Constants.Website)).Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();
            return routes;
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
            List<string> formattedUrls = await HtmlLinkExtractor.ExtractUrlsFromWebsite(Constants.LinkRegex, websiteRoute);
            return formattedUrls;
        }
    }
}
