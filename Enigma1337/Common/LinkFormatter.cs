

using System;

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
            try
            {
                if (link.StartsWith("/.."))
                    slashFormattedUrl = link.Remove(0, 4);
                else if (link.StartsWith("../"))
                    slashFormattedUrl = link.Remove(0, 3);
                else if (link.StartsWith("a"))
                    slashFormattedUrl = link;
                else if (link.StartsWith("//"))
                    slashFormattedUrl = link.Remove(0, 2);
                else if (link.StartsWith("/"))
                    slashFormattedUrl = link.Remove(0, 1);
                else
                    slashFormattedUrl = string.Empty;

                appendedUrl = Constants.Website + slashFormattedUrl;
                return appendedUrl;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error from Format() while formatting the link: " + link);
                throw e;
            } 
            
        }
    }
}
