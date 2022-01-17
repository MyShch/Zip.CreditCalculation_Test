using System;
using Zip.Common.Exceptions;
using Zip.CreditCalculation.Abstractions;
using Zip.CreditCalculation.Implementation;
using Zip.Data.Models;
 
namespace Zip.Credit
{
    class Program
    { 
        static void Main(string[] args)
        {
            var customer = new Customer(
                bureauScore: 100,
                missedPaymentCount: 1,
                completedPaymentCount: 4,
                ageInYears: 29);

            ICreditCalculator creditCalculator = new CreditCalculator();

            decimal credit = 0;
            try
            {
                credit = creditCalculator.CalculateCredit(customer).GetAwaiter().GetResult(); 
            }
            catch(LowBureauScoreException ex)
            {
                Console.WriteLine(ex.Message);
            } 
           
            Console.WriteLine($"Credit: {credit}");
            Console.ReadKey();
        }
    }
}
