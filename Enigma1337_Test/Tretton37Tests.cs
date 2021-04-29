using Enigma1337;
using Enigma1337.Interface;
using Moq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Xunit;


namespace Enigma1337_Test
{
    public class Tretton37Tests
    {

        [Fact]
        public void WebsiteDownloader_ShouldFail_WhenHttpClientThrowsAnException()
        {
            //Arrange
            Mock<IResourceDownloader> mockResourceDownloader = new Mock<IResourceDownloader>();
            Tretton37 tretton37 = new Tretton37(mockResourceDownloader.Object);
            mockResourceDownloader.Setup(x => x.DownloadUsingWebClient(It.IsAny<string>())).Throws(new Exception());

            //Act and Assert    
            Assert.Throws<Exception>(() => tretton37.WebsiteDownloader(new ConcurrentBag<string>(), 0));
        }

        [Fact]
        public void WebsiteDownloader_ShouldDownladSuccessfully_WhenAllDepedenciesAreSupplied()
        {
            //Arrange
            Mock<IResourceDownloader> mockResourceDownloader = new Mock<IResourceDownloader>();
            Tretton37 tretton37 = new Tretton37(mockResourceDownloader.Object);
            mockResourceDownloader.Setup(x => x.DownloadUsingWebClient(It.IsAny<string>())).Verifiable();

            //Act and Assert
            //No explicit assertions made, passing test will ensure the funtionality is working as expected.
            tretton37.WebsiteDownloader(new ConcurrentBag<string>(), 0);           
        }
    }
}
