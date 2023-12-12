
using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CsharpConcepts.Classes;
public class LINQPracticeSet
{
    public static int[] GetEvenNumbers(int[] numbers)
    {
        // var evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();  Using Method Syntax
        var evenNumbers = from number in numbers where (number % 2 == 0) select number;  //Using query Syntax
        return evenNumbers.ToArray();
    }

    /// <summary>
    /// Write a program in C# Sharp to find the +ve numbers from a list of numbers using two where
    /// conditions in LINQ Query
    /// </summary>
    /// <returns>Integer Array having only even numbers</returns>
    public static int[] GetEvenNumbersInARangeUsingTwoWhere(int[] numbers, int startRange, int endRange)
    {
        var evenNumbers = from number in numbers
                          where (number % 2 == 0)
                          && number >= startRange && number < endRange
                          select number;  //Using query Syntax
        return evenNumbers.ToArray();
    }

    /// <summary>
    /// find the number of an array and the square of each number using Linq
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static IEnumerable<dynamic> FindNumberAndReturnSquare(int[] numbers)
    {
        var result = from num in numbers let square = num * num select new { num, square };
        return result;
    }

    /// <summary>
    /// find a string that starts and ends with a specific character.
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<string> StringThatStartsAndEndsWithSpecificCharacter(string[] WordCollection, char start, char end)
    {
        var result = from collection in WordCollection
                     where collection.StartsWith(start) &&
                     collection.EndsWith(end)
                     select collection;
        return result;
    }

    public static IEnumerable<string> StringThatStartsAndEndsWithSpecificCharacterMethodSyntax(string[] WordCollection, char start, char end)
    {
        var result = WordCollection.Where( x=> x.StartsWith(start) && x.EndsWith(end));
        return result;
    }

    /// <summary>
    /// display the number and frequency of a given number from an array
    /// </summary>
    /// <param name="numbers">list of numbers</param>
    /// <returns>number with frequency</returns>
    public static Dictionary<int, int> FrequencyOfGivenNumbers(int[] numbers)
    {
        Dictionary<int, int> numberWithFrequency = new Dictionary<int, int>();
        var result = from number in numbers group number by number into y select y;
        foreach (var group in result)
        {
            numberWithFrequency.Add(group.Key, group.Count());
        }
        return numberWithFrequency;
    }

    /// <summary>
    /// display the characters and frequency of each character in a given string
    /// </summary>
    /// <param name="word"></param>
    /// <returns>char with frequency</returns>
    public static Dictionary<char, int> FrequencyOfEachCharacters(string word)
    {
        Dictionary<char, int> charWithFrequency = new Dictionary<char, int>();
        var result = from singleChar in word group singleChar by singleChar into data select data;
        foreach (var group in result)
        {
            charWithFrequency.Add(group.Key, group.Count());
        }
        return charWithFrequency;
    }

    public static Dictionary<char, int> FrequencyOfEachCharactersMethodSyntax(string word)
    {
        Dictionary<char, int> charWithFrequency = new Dictionary<char, int>();
        var result = word.GroupBy(x => x).ToDictionary( group => group.Key, group => group.Count());
        return result;
    }

    public static IEnumerable<dynamic> NumberWithFrequencyAndMultiplication(int[] numbers)
    {
        var result = from number in numbers
                     group number by number into data
                     select new { Number = data.Key, Frequency = data.Count(), Multiplication = data.Key * data.Count() };
        return result;
    }

    public static IEnumerable<dynamic> NumberWithFrequencyAndMultiplicationUsingMethods(int[] numbers)
    {
        var result = numbers
            .GroupBy(number => number)
            .Select(data => new
            {
                Number = data.Key,
                Frequency = data.Count(),
                Multiplication = data.Key * data.Count()
            }); ;
        return result;
    }
}

