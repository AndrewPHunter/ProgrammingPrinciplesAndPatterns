using System;
using DeclarativeVsImperative;
using FilterMapReduce;

namespace Declarative
{
    class Program
    {
        static void Main(string[] args)
        {
            var string1 = "heart";
            var string2 = "earth";
            var repo = new CustomerRepository();

            Console.WriteLine($"{string1} and {string2} are anagrams: {AnagramChecker.CheckAnagramImperative(string1, string2)}");
            Console.WriteLine($"{string1} and {string2} are anagrams: {AnagramChecker.CheckAnagramDeclarative(string1, string2)}");
            Console.WriteLine($"{string1} and {string2} are anagrams: {string1.IsAnagramOf(string2)}");
            Console.ReadKey();
        }
    }
}
