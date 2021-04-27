using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public static List<string> ExtractUrlsFromWebsite(string regex, string websiteRoute = Constants.Website)
        {
            List<string> formattedUrlList = new List<string>();
            try
            {
                string formattedHref;
                var web = new HtmlWeb();
                var doc = web.Load(websiteRoute);
                var nodes = doc.DocumentNode.SelectNodes(regex);

                //Extracts the urls based on the original name of the node
                foreach (var node in nodes)
                {

                    if (node.OriginalName == "link" || node.OriginalName == "a")
                        formattedHref = node.Attributes["href"].Value;
                    else
                        formattedHref = node.Attributes["src"].Value;

                    var formattedUrl = LinkFormatter.Format(formattedHref);

                    formattedUrlList.Add(formattedUrl);

                }
            }
            catch (Exception e)
            {
                throw e;                
            }       

            return formattedUrlList;
        }
    }
}
