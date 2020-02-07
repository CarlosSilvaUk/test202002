using System;
using Xunit;
using Amazon.Lambda.TestUtilities;

namespace AWSLambda1.Tests
{
    public class FunctionTest
    {
        [Theory]
        [InlineData(-10, 0)]
        [InlineData(1001, 15.02)]
        public void TestCases(decimal amount, decimal interestPaid)
        {
            var function = new Function();
            var context = new TestLambdaContext();
            var response = function.FunctionHandler(amount.ToString(), context);
            if (!decimal.TryParse(response, out var result))
            {
                throw new Exception("Invalid response!");
            }
            Assert.Equal(interestPaid, result);
        }
    }
}
