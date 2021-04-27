using Enigma1337.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Enigma1337
{
    public class ResourceDownloader : IResourceDownloader
    {

        /// <summary>
        /// Downloads the resources from website using WebClient.
        /// </summary>
        /// <param name="formattedUrls"> List of formatted urls</param>
        /// <remarks>
        /// Synchronously Download the resources based on the supplied formatted urls
        /// and saves to their respective local directories.
        /// </remarks>
        /// <returns> Returns nothing</returns>
        public void DownloadusingWebClient(List<string> formattedUrls)
        {
            int counter = 1;
            string fileName = string.Empty;
            WebClient webClient = new WebClient();
            try
            {
                ProgressBar.Start();
                foreach (var formattedUrl in formattedUrls)
                {
                    ProgressBar.Load(counter, formattedUrls.Count);
                    fileName = formattedUrl.Split('/').Last().Replace('?', '_');
                    Uri uri = new Uri(formattedUrl);
                    string localDirPath = Directory.CreateLocalDirectory(formattedUrl, fileName);
                    webClient.DownloadFile(uri, localDirPath);
                    counter++;
                }
                ProgressBar.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error from DownloadusingWebClient() while downloading the file: " + fileName);
                throw e;
            }    
        }


        /// <summary>
        /// Downloads the resources from website using HttpClient.
        /// </summary>
        /// <param name="formattedUrls"> List of formatted urls</param>
        /// <remarks>
        /// Asynchronously download the resources based on the supplied formatted urls
        /// and saves to their respective local directories.
        /// </remarks>
        /// <returns> Returns nothing</returns>
        public void DownloadUsingHttpClient(string formattedUrl)
        {
            string fileName = string.Empty;
            try
            {
                if (formattedUrl.Contains("http"))
                {
                    fileName = formattedUrl.Split('/').Last().Replace('?', '_');
                    string localDirPath = Directory.CreateLocalDirectory(formattedUrl, fileName);
                    using WebClient client = new WebClient();
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    client.DownloadFile(formattedUrl, localDirPath);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error from DownloadUsingHttpClient() while downloading the file: " + fileName);
                throw e;
            }
        }

    }
}
