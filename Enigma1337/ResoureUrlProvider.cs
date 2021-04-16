﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enigma1337
{
    public static class ResoureUrlProvider
    {
        /// <summary>
        /// Get the website routes
        /// </summary>
        /// <param></param>
        /// <remarks>
        /// Extract and format all the routes used in the website
        /// </remarks>
        /// <returns> List of website routes </returns>
        public static List<string> GetWebsiteRoutes()
        {
            var websiteRoutes = HtmlLinkExtractor.ExtractUrlsFromWebsite(Constants.RouteRegex);
            var routes = websiteRoutes.FindAll(x => x.Contains(Constants.Website)).Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();
            return routes;
        }

        /// <summary>
        /// Get the resource urls
        /// </summary>
        /// <param></param>
        /// <remarks>
        /// Extract and format the resource based urls from a particular webpage
        /// </remarks>
        /// <returns> List of formatted urls </returns>
        public static List<string> GetWebpageUrls( string websiteRoute)
        {
            List<string> formattedUrls = HtmlLinkExtractor.ExtractUrlsFromWebsite(Constants.LinkRegex, websiteRoute);
            return formattedUrls;
        }
    }
}
