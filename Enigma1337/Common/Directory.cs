using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Enigma1337
{
    public static class Directory
    {
        /// <summary>
        /// Creates local directories
        /// </summary>
        /// <param> No parameters</param>
        /// <remarks>
        ///  Iif not exists, Creates the directories of same structure as of the website's file structure
        /// </remarks>
        /// <returns>Returns nothing</returns>
        public static void CreateDirectory()
        {
            Dictionary<string, string> DirectoryPaths = new Dictionary<string, string>()
            {
                { "assets", "C:\\Users\\Loganathan_M3\\Downloads\\assets" },
                { "css",    "C:\\Users\\Loganathan_M3\\Downloads\\assets\\css" },
                { "fonts",  "C:\\Users\\Loganathan_M3\\Downloads\\assets\\fonts" },
                { "i",      "C:\\Users\\Loganathan_M3\\Downloads\\assets\\i" },
                { "js",     "C:\\Users\\Loganathan_M3\\Downloads\\assets\\js" }

            };

            try
            {
                foreach (var directoryPath in DirectoryPaths)
                {
                    if (System.IO.Directory.Exists(directoryPath.Value))
                        return;

                    DirectoryInfo directory = System.IO.Directory.CreateDirectory(directoryPath.Value);
                    Console.WriteLine($"Created the directory {directoryPath.Value}");

                }

            }
            catch (Exception)
            {
                Console.WriteLine("Failed to create a directory"); ;
            }
        }


        /// <summary>
        /// Finds local directories
        /// </summary>
        /// <param name="formattedUrl" name="fileType></param>
        /// <remarks>
        /// Finds the local directory based on the filetype and remote folder name.
        /// </remarks>
        /// <returns>Returns the local directory that matches</returns>
        public static string DirectoryFinder(string formattedUrl, string fileType)
        {
            var temp1 = formattedUrl.Split('/').Last();
            var temp2 = formattedUrl.Replace('/' + temp1, "");
            var remoteFoldername = temp2.Split('/').Last();

            string targetDirectory;
            if (fileType.Contains(".js") || fileType.Contains(".txt"))
                targetDirectory = $"{Constants.BaseDirPath}\\js\\{fileType}";
            else
                targetDirectory = $"{Constants.BaseDirPath}\\{remoteFoldername}\\{fileType}";
            return targetDirectory;
        }

    }
}
