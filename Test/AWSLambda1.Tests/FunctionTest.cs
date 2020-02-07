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

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(1, 0.01)]
        [InlineData(999, 0.01)]
        [InlineData(1000, 0.015)]
        [InlineData(4999, 0.015)]
        [InlineData(5000, 0.02)]
        [InlineData(9999, 0.02)]
        [InlineData(10000, 0.025)]
        [InlineData(49999, 0.025)]
        [InlineData(50000, 0.03)]
        [InlineData(500000, 0.03)]
        public void CalculateInterestRateTestCases(decimal amount, double rate)
        {
            var function = new Function();
            Assert.Equal(rate, function.CalculateInterestRate(amount));
        }
    }
}
