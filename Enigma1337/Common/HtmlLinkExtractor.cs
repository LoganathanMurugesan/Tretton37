using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma1337
{
    public static class HtmlLinkExtractor
    {
        /// <summary>
        /// Extracts the Urls from the loaded webpage
        /// </summary>
        /// <param name="regex"> </param>
        /// <remarks>
        /// Script tags, link tags and anchor tags are scrutinized to get the Urls using regex.
        /// </remarks>
        /// <returns> List of urls extracted for the particualr page</returns>
        public static List<string> ExtractUrlsFromWebsite(string regex, string websiteRoute = "https://tretton37.com/")
        {
            List<string> formattedUrlList = new List<string>();
            var web = new HtmlWeb();
            var doc = web.Load(websiteRoute);
            var nodes = doc.DocumentNode.SelectNodes(regex);

            foreach (var node in nodes)
            {
                string formattedHref;
                if (node.OriginalName == "link" || node.OriginalName == "a")
                    formattedHref = node.Attributes["href"].Value;
                else
                    formattedHref = node.Attributes["src"].Value;

                 var formattedUrl = LinkFormatter.Format(formattedHref);

                formattedUrlList.Add(formattedUrl);
            }

            return formattedUrlList;
        }
    }
}
