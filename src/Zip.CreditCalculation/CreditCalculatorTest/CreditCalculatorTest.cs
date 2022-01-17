using System.Threading.Tasks;
using Xunit;
using Zip.Common.Exceptions;
using Zip.CreditCalculation.Implementation;
using Zip.Data.Models;

namespace CreditCalculatorTest
{
    public class CreditCalculatorTest
    {
        [Theory]
        [InlineData(750, 1, 4, 29, 400)]
        [InlineData(905, 2, 5, 55, 400)]
        [InlineData(503, 0, 1, 37, 300)]
        [InlineData(817, 2, 2, 41, 200)]
        public void CalculateCredit_Success(int bureauScore, int missedPaymentCount,
            int completedPaymentCount, int ageInYears, int expected)
        {
            //Arrange

            var customer = new Customer(
              bureauScore: bureauScore,
              missedPaymentCount: missedPaymentCount,
              completedPaymentCount: completedPaymentCount,
              ageInYears: ageInYears);

            var creditCalculator = new CreditCalculator();

            //Act

            var result = creditCalculator.CalculateCredit(customer).GetAwaiter().GetResult();

            //Assert

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task CalculateCredit_ThrowException()
        {
            //Arrange
            var customer = new Customer(
              bureauScore: 300,
              missedPaymentCount: 1,
              completedPaymentCount: 2,
              ageInYears: 21);

            var creditCalculator = new CreditCalculator();

            //Act

            var ex = await Assert.ThrowsAsync<LowBureauScoreException>(() => creditCalculator.CalculateCredit(customer));

            //Assert

            Assert.Equal("Low Bureau Score (not allowed to use Zip)", ex.Message);           
        }
    }
}
