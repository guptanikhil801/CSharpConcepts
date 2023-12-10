
namespace CsharpConcepts.Classes;
public class LINQPracticeSet
{
    public static int[] GetEvenNumbers(int[] numbers)
    {
        // var evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();  Using Method Syntax
        var evenNumbers = from number in numbers where (number%2 == 0) select number;  //Using query Syntax
        return evenNumbers.ToArray();
    }

    public static int[] GetEvenNumbersInARangeUsingTwoWhere(int[] numbers, int startRange, int endRange)
    {
        var evenNumbers = from number in numbers where (number % 2 == 0) && number >= startRange && number < endRange  select number;  //Using query Syntax
        return evenNumbers.ToArray();
    }
}

