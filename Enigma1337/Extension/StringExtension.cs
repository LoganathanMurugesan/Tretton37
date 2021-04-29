using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Enigma1337.Extension
{
    //Extending the ConcurrentBag<string> to add List<string> to it.
    public static class StringExtension
    {

        public static ConcurrentBag<string> AddMultipleItems(this ConcurrentBag<string> concurrentBag, List<string> stringList)
        {
            if (concurrentBag != null && stringList != null)
            {
                foreach (var item in stringList)
                {
                    concurrentBag.Add(item);
                }
            }

            return concurrentBag;

        }

        public static ConcurrentBag<string> AddMultipleItems_WithHtmlExtension(this ConcurrentBag<string> concurrentBag, List<string> stringList)
        {
            if (concurrentBag != null && stringList != null)
            {
                foreach (var item in stringList)
                {
                    var appendedUrl = item + ".html";
                    if (appendedUrl == "https://tretton37.com/.html")
                    {
                        appendedUrl = "https://tretton37.com/index.html";
                    }
                    concurrentBag.Add(appendedUrl);
                }
            }

            return concurrentBag;

        }
    }
}
