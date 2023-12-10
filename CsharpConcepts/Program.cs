using CsharpConcepts;
using CsharpConcepts.Classes;

var evenNumbers = LINQPracticeSet.GetEvenNumbersInARangeUsingTwoWhere(new int[] { 67, 9, 70, 6, 7 },1,10);
for (int i = 0; i < evenNumbers.Length; i++)
{
    Console.WriteLine(evenNumbers[i]);
}
Console.ReadKey();