namespace Zip.CreditCalculation.Abstractions
{
    /// <summary>
    /// We consider the number of payments a customer has missed in the past as the next data point
    /// </summary>
    internal interface IMissedPaymentsPointsCalculate : IBasePointsCalculate
    {
    }
}
