using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zip.CreditCalculation.Abstractions;
using Zip.Data.Models;

namespace Zip.CreditCalculation.Implementation
{
    public class CreditCalculator : ICreditCalculator
    {
        #region Private Properties

        private readonly IAgePointsCalculation _agePointsCalculation;
        private readonly IAvailableCreditCalculate _availableCreditCalculate;
        private readonly IBureauPointsCalculate _bureauPointsCalculate;
        private readonly ICompletedPaymentsPointsCalculate _completedPaymentsPoints;
        private readonly IMissedPaymentsPointsCalculate _missedPaymentsPointsCalculate;

        #endregion //Private Properties

        public CreditCalculator()
        {
            //could use DI
            _agePointsCalculation = new AgePointsCalculation();
            _availableCreditCalculate = new AvailableCreditCalculate();
            _bureauPointsCalculate = new BureauPointsCalculate();
            _completedPaymentsPoints = new CompletedPaymentsPointsCalculate();
            _missedPaymentsPointsCalculate = new MissedPaymentsPointsCalculate();
        }

        public async Task<decimal> CalculateCredit(Customer customer)
        {
            var points = await CalculatePoints(customer);

            var result = _availableCreditCalculate.Calculate(points);

            return result;
        }


        #region Private Methods

        private async Task<int> CalculatePoints(Customer customer)
        {
            // tasks use for future if we would getting data from external services
            var bureauPoints = _bureauPointsCalculate.GetPointsAsync(customer.BureauScore);
            var missedPoints = _missedPaymentsPointsCalculate.GetPointsAsync(customer.MissedPaymentCount);
            var completedPoints = _completedPaymentsPoints.GetPointsAsync(customer.CompletedPaymentCount);

            var tasks = new List<Task<int>> { bureauPoints, missedPoints, completedPoints };

            await Task.WhenAll(tasks);

            var sumPoints = tasks.Sum(x => x.Result);
            var maxPointByAge = _agePointsCalculation.MaxPointsByAge(customer.AgeInYears, sumPoints);

            return maxPointByAge;
        }

        #endregion // Private Methods
    }
}
