using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpConcepts.Classes
{
    internal class ArrayAndDictionaryConcepts
    {
        public static Dictionary<int, int> FindDuplicates(int[] numbers)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var item in numbers)
            {
                dict.TryGetValue(item, out int value);
                dict[item] = value + 1;
            }
            foreach (var pair in dict)
                Console.WriteLine("Value {0} occurred {1} times.", pair.Key, pair.Value);
            Console.ReadKey();
            return dict;
        }
    }
}