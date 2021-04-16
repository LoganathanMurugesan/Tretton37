using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Enigma1337
{
    public static class ResourceDownloader
    {

        /// <summary>
        /// Downloads the resources from website.
        /// </summary>
        /// <param name="formattedUrls"> List of formatted urls</param>
        /// <remarks>
        /// Download the resources based on the supplied formatted urls
        /// and saves to their respective local directories.
        /// </remarks>
        /// <returns> Returns nothing</returns>
        public static void Download(List<string> formattedUrls)
        {
            int counter = 1;
            WebClient webClient = new WebClient();
            ProgressBar.Start();
            foreach (var formattedUrl in formattedUrls)
            {
                ProgressBar.Load(counter, formattedUrls.Count);
                var filename = formattedUrl.Split('/').Last().Replace('?', '_');
                webClient.DownloadFile(formattedUrl, DirectoryFinder(formattedUrl, filename));
                counter++;
            }
            ProgressBar.Stop();
            
        }


        private static string DirectoryFinder(string formattedUrl, string fileType)
        {
            var temp1 = formattedUrl.Split('/').Last();
            var temp2 = formattedUrl.Replace('/' + temp1, "");
            var remoteFoldername = temp2.Split('/').Last();

            string targetDirectory;
            switch (remoteFoldername)
            {
                case "css":
                    targetDirectory = $"C:\\Users\\Loganathan_M3\\Downloads\\assets\\css\\{fileType}";
                    break;
                case "fonts":
                    targetDirectory = $"C:\\Users\\Loganathan_M3\\Downloads\\assets\\fonts\\{fileType}";
                    break;
                case "i":
                    targetDirectory = $"C:\\Users\\Loganathan_M3\\Downloads\\assets\\i\\{fileType}";
                    break;
                case "js":
                    targetDirectory = $"C:\\Users\\Loganathan_M3\\Downloads\\assets\\js\\{fileType}";
                    break;
                default:
                    if (fileType.Contains(".css"))
                        targetDirectory = $"C:\\Users\\Loganathan_M3\\Downloads\\assets\\css\\{fileType}";
                    if (fileType.Contains(".js"))
                        targetDirectory = $"C:\\Users\\Loganathan_M3\\Downloads\\assets\\js\\{fileType}";
                    targetDirectory = $"C:\\Users\\Loganathan_M3\\Downloads\\assets\\js\\{fileType}";
                    break;
            }


            return targetDirectory;
        }
    }
}
