using System;
using System.Threading.Tasks;
using Zip.CreditCalculation.Abstractions;

namespace Zip.CreditCalculation.Implementation
{
    internal class CompletedPaymentsPointsCalculate : ICompletedPaymentsPointsCalculate
    {
        public int GetPoints(int value)
         => value switch
         {
             var p when p == 0 => 0,
             var p when p == 1 => 2,
             var p when p == 2 => 3,
             var p when p >= 3 => 4,
             _ => throw new ArgumentException("The value should be more than 0")
         };

        public Task<int> GetPointsAsync(int value)
            => Task.FromResult(GetPoints(value));
    }
}
