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
        /// <param name="link"> Link obtained from the webpage</param>
        /// <remarks>
        /// Removes the unwanted leading slashes and append with https://tretton37.com/ 
        /// to form a proper resource url which we use to download.
        /// </remarks>
        /// <returns> Formatted url </returns>
        public static string Format(string link)
        { 
                string slashFormattedUrl, appendedUrl;
                if (link.StartsWith("/"))
                {
                    slashFormattedUrl = link.Remove(0, 1);
                    appendedUrl = $"https://tretton37.com/{slashFormattedUrl}";
                }

                else if (link.StartsWith("a"))
                {
                    appendedUrl = $"https://tretton37.com/{link}";
                }

                else if (link.StartsWith(".."))
                {
                    slashFormattedUrl = link.Remove(0, 1);
                    appendedUrl = $"https://tretton37.com/{slashFormattedUrl}";
                }

                else
                {
                    appendedUrl = link;
                }

            return appendedUrl;
        }
    }
}
