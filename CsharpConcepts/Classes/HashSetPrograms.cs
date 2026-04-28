
namespace CsharpConcepts.Classes
{
    public class HashSetPrograms
    {
        /// <summary>
        /// returns longest non repitive string length
        /// </summary>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        public static int GetLongestSubstringLength(string stringToCheck)
        {
            int longestSubstringLength = 0;
            for (int i = 0; i < stringToCheck.Length - 1; i++)
            {
                HashSet<char> chars = new HashSet<char>();
                for (int j = i; j < stringToCheck.Length; j++)
                {
                    if (chars.Add(stringToCheck[j]))
                    {
                        longestSubstringLength = chars.Count > longestSubstringLength ? chars.Count : longestSubstringLength;
                    }
                    else
                        break;
                }
            }
            return longestSubstringLength;
        }

        /// <summary>
        /// checks if in give array there is a pair available which sums to target
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool CheckSum(int[] numbers, int target)
        {
            HashSet<int> seenNumbers = new HashSet<int>();

            foreach (int num in numbers)
            {
                int complement = target - num;

                if (seenNumbers.Contains(complement))
                {
                    // Pair found
                    return true;
                }

                // Add the current number to the HashSet
                seenNumbers.Add(num);
            }

            // No pair found
            return false;
        }
    }
}
