using Zip.CreditCalculation.Abstractions;

namespace Zip.CreditCalculation.Implementation
{
    internal class AvailableCreditCalculate : IAvailableCreditCalculate
    {
        private const int Coefficient = 100;

        public int Calculate(int points)
            => points switch
            {
                var p when p >= 1 && p <=5 => p * Coefficient,
                var p when p >= 6 => 600,
                _ => 0
            };
    }
}
