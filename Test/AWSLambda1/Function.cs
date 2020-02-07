using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambda1
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            if (!decimal.TryParse(input, out var amount))
            {
                throw new ArgumentException("Not a number");
            }

            var paid = CalculateInterestPaid(amount);

            return paid.ToString("0.00");
        }

        public double CalculateInterestRate(decimal amount)
        {
            if (amount >= 50000) return 0.03;
            if (amount >= 10000) return 0.025;
            if (amount >= 5000) return 0.02;
            if (amount >= 1000) return 0.015;
            if (amount >= 0) return 0.01;
            return 0.0;
        }

        public decimal CalculateInterestPaid(decimal amount)
        {
            return Math.Round(amount * (decimal)CalculateInterestRate(amount), 2);
        }
    }
}
