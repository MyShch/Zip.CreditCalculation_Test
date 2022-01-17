using System;
using System.Threading.Tasks;
using Zip.Common.Exceptions;
using Zip.CreditCalculation.Abstractions;

namespace Zip.CreditCalculation.Implementation
{
    internal class BureauPointsCalculate : IBureauPointsCalculate
    {
        public int GetPoints(int value)
           => value switch
           {
               var p when p >= 0 && p <= 450 => throw new LowBureauScoreException(),
               var p when p > 450 && p <= 700 => 1,
               var p when p > 700 && p <= 850 => 2,
               var p when p > 850 && p <= 1000 => 3,
               _ => throw new ArgumentException("Bureau Score is not valid")
            };

        public Task<int> GetPointsAsync(int value)
            => Task.FromResult(GetPoints(value));
    }
}
