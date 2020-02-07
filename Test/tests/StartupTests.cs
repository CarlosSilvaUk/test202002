using app;
using Xunit;

namespace tests
{
    public class StartupTests
    {
        private readonly OutputTester _out;

        public StartupTests()
        {
            _out = new OutputTester();
        }

        [Fact]
        public void TestCase1()
        {
            var app = new Startup(_out);
            app.Run();

            Assert.Equal(1, _out.LinesCount);
            Assert.Equal("DONE", _out.Lines[0]);
        }
    }
}
