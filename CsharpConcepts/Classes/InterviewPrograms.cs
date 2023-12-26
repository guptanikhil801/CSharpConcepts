namespace CsharpConcepts.Classes
{
    public class InterviewPrograms
    {
        /// <summary>
        /// count the occurence of a character in a given string without using loop
        /// </summary>
        /// <param name="word">given string</param>
        /// <param name="c">character to count</param>
        /// <returns>count of character</returns>
        public static int CountCharacterOccurenceWithoutUsingLoop(string word, char c)
        {
            var occurence = word.Split(c).Length - 1;
            return occurence;
        }

        public static int CountCharacterOccurenceUsingLinq(string word, char c)
        {
            var occurence = word.Count(x => x.Equals(c));
            return occurence;
        }
    }
}
