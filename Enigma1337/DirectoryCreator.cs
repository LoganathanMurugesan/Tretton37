using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Enigma1337
{
    public static class DirectoryCreator
    {
        /// <summary>
        /// Creates local directories
        /// </summary>
        /// <param> No parameters</param>
        /// <remarks>
        /// Creates the directories of same structure as of the website's file structure
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
                    if (Directory.Exists(directoryPath.Value))
                        return;

                    DirectoryInfo directory = Directory.CreateDirectory(directoryPath.Value);
                    Console.WriteLine($"Created the directory {directoryPath.Value}");

                }

            }
            catch (Exception)
            {
                Console.WriteLine("Failed to create a directory"); ;
            }
        }
    }
}
