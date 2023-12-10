
using static System.Net.Mime.MediaTypeNames;

namespace CsharpConcepts.Classes;
public class LINQPracticeSet
{
    public static int[] GetEvenNumbers(int[] numbers)
    {
        // var evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();  Using Method Syntax
        var evenNumbers = from number in numbers where (number%2 == 0) select number;  //Using query Syntax
        return evenNumbers.ToArray();
    }

    /// <summary>
    /// Write a program in C# Sharp to find the +ve numbers from a list of numbers using two where
    /// conditions in LINQ Query
    /// </summary>
    /// <returns>Integer Array having only even numbers</returns>
    public static int[] GetEvenNumbersInARangeUsingTwoWhere(int[] numbers, int startRange, int endRange)
    {
        var evenNumbers = from number in numbers where (number % 2 == 0) 
                          && number >= startRange && number < endRange  select number;  //Using query Syntax
        return evenNumbers.ToArray();
    }

    /// <summary>
    /// find the number of an array and the square of each number using Linq
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static IEnumerable<dynamic> FindNumberAndReturnSquare(int[] numbers)
    {
        var result = from num in numbers let square = num*num select new { num, square };
        return result;
    }

    /// <summary>
    /// find a string that starts and ends with a specific character.
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<string> FindStringThatStartsAndEndsWithSpecificCharacter(string[] WordCollection, char start, char end)
    {
        var result = from collection in WordCollection
                     where collection.StartsWith(start) &&
                     collection.EndsWith(end)
                     select collection;
        return result;
    }
}

