using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma1337.Handlers
{
    public static class GlobalExceptionHandler
    {
        public static void HandleTheUnhandled(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Environment.Exit(0);
        }
    }
}
