using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DeclarativeVsImperative;
using FilterMapReduce;

namespace DeclarativeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            

            
            CustomerInformation();
            CustomerTotals();
            CustomersOver21();
        
            Console.ReadKey();
        }

        static void CustomerInformation()
        {
            var repo = new CustomerRepository();
            var informationImperative = repo.GetCustomerCondensedInformation();
            foreach (var condensed in informationImperative)
            {
                Console.WriteLine(condensed.Name);
            }
        }

        static void CustomerTotals()
        {
            var repo = new CustomerRepository();
            Console.WriteLine($"Total Sales: {repo.GetTotalSales()}");
        }

        static void CustomersOver21()
        {
            var repo = new CustomerRepository();
            Console.WriteLine($"Total customers over 21: {repo.GetCustomersOver21().Count}");
        }
        static void Anagrams()
        {
            var string1 = "heart";
            var string2 = "earth";

            Console.WriteLine($"{string1} and {string2} are anagrams: {AnagramChecker.CheckAnagramImperative(string1, string2)}");
            Console.WriteLine($"{string1} and {string2} are anagrams: {AnagramChecker.CheckAnagramDeclarative(string1, string2)}");
            Console.WriteLine($"{string1} and {string2} are anagrams: {string1.IsAnagramOf(string2)}");
        }
    }
}
