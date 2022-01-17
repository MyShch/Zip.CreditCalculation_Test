namespace Zip.CreditCalculation.Abstractions
{
    /// <summary>
    /// Maximum points depending on age
    /// </summary>
    internal interface IAgePointsCalculation 
    {
        public int MaxPointsByAge(int age, int points);
    }
}
