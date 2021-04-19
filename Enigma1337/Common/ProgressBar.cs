using System;


namespace Enigma1337
{
    public static class ProgressBar
    {
        //starts the progress bar and sets the console colors
        public static void Start()
        {            
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        //keeps progressing when the downloading the resources
        public static void Load(int counter, int totalUrls)
        {
            try
            {
                var value = ((double)counter / totalUrls) * 100;
                var percentage = Convert.ToInt32(Math.Round(value, 0));
                string str = percentage.ToString() + "% ";
                Console.SetCursorPosition(counter, 1);
                Console.WriteLine(" " + str.Replace(str, str));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error from progress bar");
                throw e;
            }

        }

        //stops the progress bar and reset the console colors
        public static void Stop()
        {
            Console.ResetColor();
            Console.WriteLine("Files downloaded and successfully saved under assests in your downloads folder");
        }

        //Indicates the start of the progress.
        public static void ProcessStarts()
        {
            Console.WriteLine(" Download Progress");
        }


    }
}
