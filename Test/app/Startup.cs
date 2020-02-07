using System;
using System.Collections.Generic;
using System.Text;
using app.Output;

namespace app
{
    public class Startup
    {
        private readonly IOutput _output;

        public Startup(IOutput output)
        {
            _output = output;
        }

        public void Run()
        {
            _output.WriteLine("DONE");
        }
    }
}
