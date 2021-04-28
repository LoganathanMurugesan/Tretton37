using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enigma1337.Interface
{
    public interface IResourceDownloader
    {
        void DownloadUsingHttpClient(string formattedUrl);
    }
}
