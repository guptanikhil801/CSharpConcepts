
namespace CsharpConcepts.Classes
{
    public class HashSetPrograms
    {
        /// <summary>
        /// will return longest non repitive string length
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static int GetLongestSubstringLength(string word)
        {
            int length = 0;
            HashSet<char> chars = new HashSet<char>();
            for (int i = 0; i < word.Length - 1; i++)
            {
                int count = 1;
                chars.Add(word[i]);
                for (int j = i + 1; j < word.Length; j++)
                {
                    if (chars.Add(word[j]))
                    {
                        count++;
                    }
                    else
                    {
                        length = count > length ? count : length;
                    }
                }
            }
            return length;
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
