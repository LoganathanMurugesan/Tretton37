﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma1337
{
    public static class ProgressBar
    {
        //starts the progress bar and sets the console colors
        public static void Start()
        {
            Console.WriteLine("Dowmload Progress");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        //keeps progressing when the downloading the resources
        public static void Load(int counter, int totalUrls)
        {
            var value = ((double)counter / totalUrls) * 100;
            var percentage = Convert.ToInt32(Math.Round(value, 0));
            string str = percentage.ToString() + "% ";
            Console.SetCursorPosition(counter, 1);
            Console.Write(" " + str.Replace(str, str));
        }

        //stops the progress bar and reset the console colors
        public static void Stop()
        {
            Console.ResetColor();
        }


    }
}