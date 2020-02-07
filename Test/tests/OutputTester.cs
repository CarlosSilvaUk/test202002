using System.Collections.Generic;
using app.Output;

namespace tests
{
    public class OutputTester : IOutput
    {
        public OutputTester()
        {
            Lines = new List<string>();
        }

        public List<string> Lines { get; }

        public int LinesCount => Lines.Count;

        public void WriteLine(string text)
        {
            Lines.Add(text);
        }
    }
}