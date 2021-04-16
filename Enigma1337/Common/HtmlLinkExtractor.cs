using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma1337
{
    public static class HtmlLinkExtractor
    {
        /// <summary>
        /// Extracts the routes and links from the loaded webpage
        /// </summary>
        /// <param name="regex"> </param>
        /// <remarks>
        /// As of now, script tags and link tags are being scrutinized to get the links using regex.
        /// </remarks>
        /// <returns> List of routes and links extracted for the particualr page</returns>
        public static List<string> ExtractLinksFromWebsite(string regex, string websiteRoute = "https://tretton37.com/")
        {
            List<string> _hrefList = new List<string>();
            var web = new HtmlWeb();
            var doc = web.Load(websiteRoute);
            var nodes = doc.DocumentNode.SelectNodes(regex);

            foreach (var node in nodes)
            {
                string _formattedHref;
                if (node.OriginalName == "link" || node.OriginalName == "a")
                    _formattedHref = node.Attributes["href"].Value;
                else
                    _formattedHref = node.Attributes["src"].Value;

                _hrefList.Add(_formattedHref);
            }

            return _hrefList;
        }
    }
}
