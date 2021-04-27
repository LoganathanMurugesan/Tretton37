using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enigma1337.Interface
{
    public interface IResourceDownloader
    {
        void DownloadusingWebClient(List<string> formattedUrls);
        void DownloadUsingHttpClient(string formattedUrl);
    }
}
