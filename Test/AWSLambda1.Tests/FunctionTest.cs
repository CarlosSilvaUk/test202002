using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using AWSLambda1;

namespace AWSLambda1.Tests
{
    public class FunctionTest
    {
        [Theory]
        [InlineData(-10, 0)]
        [InlineData(1001, 15.02)]
        public void TestCases(decimal amount, decimal interestPaid)
        {

            // Invoke the lambda function and confirm the string was upper cased.
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
