using System;
using System.Collections.Generic;

namespace Enigma1337
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryCreator.CreateDirectory();
            List<string> unformattedUrls = HtmlLinkExtractor.ExtractLinksFromWebsite();
            List<string> formattedUrls = LinkFormatter.Format(unformattedUrls);
            ResourceDownloader.Download(formattedUrls);

        }
    }
}
