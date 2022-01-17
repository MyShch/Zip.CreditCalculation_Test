using System;
using Zip.Common.Exceptions;
using Zip.CreditCalculation.Abstractions;

namespace Zip.CreditCalculation.Implementation
{
    internal class AgePointsCalculation : IAgePointsCalculation
    {
        public int MaxPointsByAge(int age, int points)
        {
            var maxPoints = MaxPoints(age);

            if (maxPoints >= points)
                return points;
            else
                return maxPoints;
        }

        private int MaxPoints(int age)
            => age switch
            {
                var a when a >= 18 && a <= 25 => 3,
                var a when a >= 26 && a <= 35 => 4,
                var a when a >= 36 && a <= 50 => 5,
                var a when a >= 51 => 6,
                var a when a < 18 && a > 0 => throw new YoungAgeException(),
                _ => throw new ArgumentException($"The value({age}) should be more than 0")
            };
    }
}
