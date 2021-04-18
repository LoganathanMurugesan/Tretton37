using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Enigma1337
{
    public static class Directory
    {
        static string baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

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
                { "assets", baseDirectory+ @"\assets"},
                { "css",    baseDirectory+ @"\assets\css"},
                { "fonts",  baseDirectory+ @"\assets\fonts"},
                { "i",      baseDirectory+ @"\assets\i"},
                { "js",     baseDirectory+ @"\assets\js"}

            };
            string currentDirectory = string.Empty;

            try
            {                
                foreach (var directoryPath in DirectoryPaths)
                {
                    if (System.IO.Directory.Exists(directoryPath.Value))
                        return;
                    currentDirectory = directoryPath.Value;
                    System.IO.Directory.CreateDirectory(directoryPath.Value);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error from CreateDirectory() while creating the directory: " + currentDirectory);
                throw e;
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
            string targetDirectory = string.Empty;
            try
            {                
                var temp1 = formattedUrl.Split('/').Last();
                var temp2 = formattedUrl.Replace('/' + temp1, "");
                string remoteFoldername = temp2.Split('/').Last();

                if (fileType.Contains(".js") || fileType.Contains(".txt"))
                    targetDirectory = $"{baseDirectory}\\assets\\js\\{fileType}";
                else
                    targetDirectory = $"{baseDirectory}\\assets\\{remoteFoldername}\\{fileType}";

                return targetDirectory;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error from DirectoryFinder() while finding the directory: " + targetDirectory);
                throw e;
            }            
        }

    }
}
