using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma1337
{
    public static class HtmlLinkExtractor
    {
        /// <summary>
        /// Extracts the links from the loaded webpage
        /// </summary>
        /// <param> No parameters</param>
        /// <remarks>
        /// As of now, script tags and link tags are being scrutinized to get the links using regex.
        /// </remarks>
        /// <returns> List of links extracted for the particualr page</returns>
        public static List<string> ExtractLinksFromWebsite()
        {
            List<string> _hrefList = new List<string>();
            var web = new HtmlWeb();
            var doc = web.Load("https://tretton37.com/");
            var nodes = doc.DocumentNode.SelectNodes("//link[@href]|//script[@src]");

            foreach (var node in nodes)
            {
                string _formattedHref;
                if (node.OriginalName == "link")
                    _formattedHref = node.Attributes["href"].Value;
                else
                    _formattedHref = node.Attributes["src"].Value;

                _hrefList.Add(_formattedHref);
            }

            return _hrefList;
        }
    }
}
