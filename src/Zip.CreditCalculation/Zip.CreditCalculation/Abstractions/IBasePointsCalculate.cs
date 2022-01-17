using System.Threading.Tasks;

namespace Zip.CreditCalculation.Abstractions
{
    internal interface IBasePointsCalculate
    {
        int GetPoints(int value);

        /// <summary>
        /// This method for asynchronous call to another check service
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<int> GetPointsAsync(int value);
    }
}
