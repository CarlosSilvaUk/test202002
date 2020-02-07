using app.Accounts;
using Xunit;

namespace tests.Accounts
{
    public class AccountTests
    {

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
            var account = new Account(amount);
            Assert.Equal(rate, account.CalculateInterestRate());
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(1001, 15.02)]
        public void CalculateInterestPaidTestCases(decimal amount, decimal paid)
        {
            var account = new Account(amount);
            Assert.Equal(paid, account.CalculateInterestPaid());
        }
    }
}
