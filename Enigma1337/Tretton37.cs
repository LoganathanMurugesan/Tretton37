using Enigma1337.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enigma1337
{
    public class Tretton37
    {
        private readonly IResourceDownloader _resourceDownloader;
        public Tretton37(IResourceDownloader resourceDownloader)
        {
            _resourceDownloader = resourceDownloader;
        }
        /// <summary>
        /// Tretton37Downloader process the end to end flow.
        /// </summary>
        /// <param>/param>
        /// <remarks>
        /// Delegates the tasks including directory creation, urls extraction
        /// downloading the files and saving them to a local directory.
        /// </remarks>
        /// <returns>Returns nothing</returns>
        public void WebsiteDownloader()
        {
            ProgressBar.ProcessStarts();
            List<string> Urls = new List<string>();
            //Intiates a parallel call between two independent tasks - directory creation and
            //url extration across the webpages.
            Parallel.Invoke(
                () => { Directory.CreateDirectory(); },
                () => { Urls = ResourceUrlProvider.GetUrls().Result; }
                );
            //Downloads the files using the urls extracted.
            Task.WaitAll(_resourceDownloader.DownloadUsingHttpClient(Urls));

        }
    }
}
