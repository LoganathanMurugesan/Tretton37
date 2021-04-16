using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Enigma1337
{
    public static class ResourceDownloader
    {

        //Testing the resource downloading.
        //To do - find and download the file to its respective directory.
        public static void Download(List<string> formattedUrls)
        {
            Console.WriteLine("Started downloading");
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://tretton37.com//assets/js/video.js", "C:\\Users\\Loganathan_M3\\Downloads\\assets\\testfile");
            Console.WriteLine("Completed downloading");
            Console.ReadLine();
        }
    }
}
