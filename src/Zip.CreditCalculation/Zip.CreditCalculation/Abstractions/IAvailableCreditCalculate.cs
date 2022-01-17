namespace Zip.CreditCalculation.Abstractions
{
    /// <summary>
    /// When we tally up all of the points for a customer (over the above data inputs)
    /// we then assign an available amount of credit for them to use at Zip.
    /// </summary>
    internal interface IAvailableCreditCalculate  
    {
        int Calculate(int points);
    }
}
