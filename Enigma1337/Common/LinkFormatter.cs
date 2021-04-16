using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma1337
{
    public static class LinkFormatter
    {
        /// <summary>
        /// Format the links to proper url
        /// </summary>
        /// <param name="links"> List of links obtained from the webpage</param>
        /// <remarks>
        /// Removes the unwanted leading slashes and append with https://tretton37.com/ 
        /// to form a proper resource url which we use to download.
        /// </remarks>
        /// <returns> List of formatted url </returns>
        public static List<string> Format(List<string> links)
        {
            List<string> formattedUrlList = new List<string>();
 
            foreach (var url in links)
            {
                string slashFormattedUrl, appendedUrl;
                if (url.StartsWith("/"))
                {
                    slashFormattedUrl = url.Remove(0, 1);
                    appendedUrl = $"https://tretton37.com/{slashFormattedUrl}";
                }

                else if (url.StartsWith("a"))
                {
                    appendedUrl = $"https://tretton37.com/{url}";
                }

                else if (url.StartsWith(".."))
                {
                    slashFormattedUrl = url.Remove(0, 1);
                    appendedUrl = $"https://tretton37.com/{slashFormattedUrl}";
                }

                else
                {
                    appendedUrl = url;
                }

                formattedUrlList.Add(appendedUrl);
            }

            return formattedUrlList;
        }
    }
}
