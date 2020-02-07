using System;

namespace app.Output
{
    internal class ConsoleOutput : IOutput
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}