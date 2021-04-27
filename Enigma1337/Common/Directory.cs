using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Enigma1337
{
    public static class Directory
    {
        static string baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";

        /// <summary>
        /// creates local directories
        /// </summary>
        /// <param name="formattedUrl" name="fileType></param>
        /// <remarks>
        /// creates and retain the online folder structure.
        /// </remarks>
        /// <returns>Returns the local directory that matches</returns>
        public static string CreateLocalDirectory(string url, string fileName)
        {
            StringBuilder path = new StringBuilder(baseDirectory);
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    List<string> newList = new List<string>();
                    var list = url.Split("/");
                    if (url.Contains("https"))
                        newList = list.Skip(2).SkipLast(1).ToList();
                    else
                        newList = list.ToList();
                    foreach (var item in newList)
                    {
                        path.Append(item + '\\');
                        System.IO.Directory.CreateDirectory(path.ToString());
                    }
                }

                return path.Append(fileName).ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error from DirectoryFinder() while finding the directory");
                throw e;
            }            
        }

    }
}
