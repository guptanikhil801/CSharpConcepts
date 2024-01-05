using CsharpConcepts.Classes.Models;

namespace CsharpConcepts.Classes;
public class LINQPracticeSet
{
    #region Select Operator
    public static List<int> SelectOnlyEmployeeIds(List<Employee> employees)
    {
        var evenNumbers = employees.Select(x => x.EmployeeId).ToList();
        return evenNumbers;
    }

    public static IEnumerable<dynamic> SelectEmployeeIdsAndName(List<Employee> employees)
    {
        var evenNumbers = employees.Select(x => new { Id = x.EmployeeId, x.FirstName });
        return evenNumbers;
    }

    /// <summary>
    /// find the number of an array and the square of each number using Linq
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static IEnumerable<dynamic> FindNumberAndReturnSquare(int[] numbers)
    {
        // var result = from num in numbers let square = num * num select new { num, square };
        var result = numbers.Select(x => new { number = x, square = x * x });
        return result;
    }
    #endregion

    #region Select Many Operator
    public static List<string> GetAllSkillsOfAllEmployee()
    {
        var employees = GetMockEmployees();
        var skillsetOfEmployee = employees.SelectMany(x => x.SkillSet)
                                          .Distinct().ToList();
        return skillsetOfEmployee;
    }

    public static List<string> GetAllSkillsOfSingleEmployee(int employeeId)
    {
        var employees = GetMockEmployees();
        var skillsetOfEmployee = employees.Where(x => x.EmployeeId == employeeId)
                                          .SelectMany(x => x.SkillSet).ToList();
        return skillsetOfEmployee;
    }

    #endregion

    #region Sorting Operators

    public static List<Employee> GetEmployeeListSortedBySalary()
    {
        var allEmployees = GetMockEmployees();
        var sortedEmployees = allEmployees.OrderBy(x => x.Salary).ToList();
        return sortedEmployees;
    }

    public static List<Employee> EmployeesHavingSalaryMoreThan50kSortedBySalary()
    {
        var allEmployees = GetMockEmployees();
        var sortedEmployees = allEmployees.Where(emp => emp.Salary > 50000)
                                          .OrderBy(x => x.Salary).ToList();
        return sortedEmployees;
    }

    public static List<Employee> GetEmployeeListSortedBySalaryDescending()
    {
        var allEmployees = GetMockEmployees();
        var sortedEmployees = allEmployees.OrderByDescending(x => x.Salary).ToList();
        return sortedEmployees;
    }

    public static List<Employee> EmployeesHavingSalaryMoreThan50kSortedBySalaryDescending()
    {
        var allEmployees = GetMockEmployees();
        var sortedEmployees = allEmployees.Where(emp => emp.Salary > 50000)
                                          .OrderByDescending(x => x.Salary).ToList();
        return sortedEmployees;
    }

    public static List<Employee> GetEmployeesSortedByFirstNameLastNameThenSalary()
    {
        var allEmployees = GetMockEmployees();
        var sortedEmployees = allEmployees.OrderBy(x => x.FirstName)
                                          .ThenBy(x => x.LastName)
                                          .ThenBy(x => x.Salary).ToList();
        return sortedEmployees;
    }

    public static List<Employee> GetEmployeesSortedByFirstNameLastNameThenSalaryDescending()
    {
        var allEmployees = GetMockEmployees();
        var sortedEmployees = allEmployees.OrderBy(x => x.FirstName)
                                          .ThenBy(x => x.LastName)
                                          .ThenByDescending(x => x.Salary).ToList();
        return sortedEmployees;
    }

    public static int[] ShowTopNthRecords(int[] numbers, int count)
    {
        return numbers.OrderByDescending(x => x).Distinct().Take(count).ToArray();
    }

    #endregion

    #region Where Operator

    public static int[] GetEvenNumbers(int[] numbers)
    {
        //var evenNumbers = from number in numbers where (number % 2 == 0) select number;  //Using query Syntax
        var evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();
        return evenNumbers.ToArray();
    }

    /// <summary>
    /// Write a program in C# Sharp to find the +ve numbers from a list of numbers using two where
    /// conditions in LINQ Query
    /// </summary>
    /// <returns>Integer Array having only even numbers</returns>
    public static int[] GetEvenNumbersInARangeUsingTwoWhere(int[] numbers, int startRange, int endRange)
    {
        var evenNumbers = numbers.Where(x => (x % 2 == 0) && (x >= startRange) && (x <= endRange));
        return evenNumbers.ToArray();
    }

    public static IEnumerable<string> StringThatStartsAndEndsWithSpecificCharacterMethodSyntax(string[] WordCollection, char start, char end)
    {
        var result = WordCollection.Where(x => x.StartsWith(start) && x.EndsWith(end));
        return result;
    }
    #endregion

    #region OfType Operator
    public static List<int> GetOnlyIntTypeFromACollection()
    {
        var dataSet = new List<object>() { 1, "Nik", 2, "Gupta" };
        var result = dataSet.OfType<int>().ToList();
        return result;
    }

    public static List<string> GetStringTypeHavingLengthMoreThan3()
    {
        var dataSet = new List<object>() { 1, "Nik", 2, "Gupta" };
        var result = dataSet.OfType<string>().Where(data => data.Length > 3).ToList();
        return result;
    }
    #endregion

    #region Group By Operator
    public static Dictionary<char, int> FrequencyOfEachCharactersMethodSyntax(string word)
    {
        var result = word.GroupBy(x => x).ToDictionary(group => group.Key, group => group.Count());
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
    #endregion

    #region Quantifier Operators (All,Any & Contains)

    public static bool CheckAllEmployeesEarnMoreThan40k()
    {
        return GetMockEmployees().All(emp => emp.Salary > 15000);
    }

    public static List<Employee> GetAllEmployeesWhoHasDjangoAsSkill()
    {
        return GetMockEmployees().Where(x => x.SkillSet.Any(x => x == "Django"))
                                 .Select(y => y).ToList();
    }

    public static bool CheckIfGivenNumberExist()
    {
        var numbers = new int[] { 12, 13, 6, 90, 2 };
        return numbers.Contains(13);
    }
    #endregion

    #region Set Operators (Distinct, Except, Intersect, Union)
    public static List<string> GetDistinctSkills()
    {
        return GetMockEmployees().SelectMany(x => x.SkillSet)
                                 .Distinct()
                                 .OrderBy(x => x).ToList();
    }

    public static List<int> GetAllDistinctIDsCombiningEmployeesAndStudents()
    {
        return GetMockEmployees().Select(x => x.EmployeeId)
                                 .Union(GetMockStudents()
                                 .Select(x => x.StudentId)).ToList();
    }

    public static List<int> GetCommonIdsCombiningEmployeesAndStudents()
    {
        return GetMockEmployees().Select(x => x.EmployeeId)
                                 .Intersect(GetMockStudents()
                                 .Select(z => z.StudentId)).ToList();
    }

    public static List<int> GetUniqueIdsFromEmployeesThatIsNotAvailableInStudents()
    {
        return GetMockEmployees().Select(x => x.EmployeeId)
                                 .Except(GetMockStudents()
                                 .Select(y => y.StudentId)).ToList();
    }

    #endregion

    #region Partioning Operators(Take, TakeWhile, Skip, SkipWhile)
    public static List<Employee> GetTopTwoEmployee()
    {
        return GetMockEmployees().Take(2).ToList();
    }

    /// <summary>
    /// Wherever TakeWhile's method gets failed, its stops there, it doesnt check further.
    /// </summary>
    /// <returns></returns>
    public static List<int> GetEmployeesSalaryWhoEarnsAtleast50K()
    {
        return GetMockEmployees().TakeWhile(x => x.Salary > 49999)
                                 .Select(y => y.EmployeeId).ToList();
    }
    #endregion

    #region Query syntax
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

    public static IEnumerable<dynamic> NumberWithFrequencyAndMultiplication(int[] numbers)
    {
        var result = from number in numbers
                     group number by number into data
                     select new { Number = data.Key, Frequency = data.Count(), Multiplication = data.Key * data.Count() };
        return result;
    }

    #endregion

    #region private methods
    private static List<Employee> GetMockEmployees()
    {
        // returning mock data for the Employee class
        return new List<Employee>
        {
            new () { EmployeeId = 1, FirstName = "Kai", LastName = "Gray", Salary = 50000, SkillSet = new[] { "C#", "ASP.NET", "SQL" } },
            new () { EmployeeId = 2, FirstName = "Ava", LastName = "Dean", Salary = 60000, SkillSet = new[] { "Java", "Spring", "Hibernate" } },
            new () { EmployeeId = 3, FirstName = "Bob", LastName = "Reed", Salary = 55000, SkillSet = new[] { "JavaScript", "React", "Node.js" } },
            new () { EmployeeId = 4, FirstName = "Max", LastName = "Hale", Salary = 70000, SkillSet = new[] { "Python", "Django", "MongoDB" } },
            new () { EmployeeId = 5, FirstName = "Leo", LastName = "Ross", Salary = 48000, SkillSet = new[] { "HTML", "CSS", "Angular" } },
            new () { EmployeeId = 6, FirstName = "Max", LastName = "Hale", Salary = 18000, SkillSet = new[] { "Python", "Django", "MongoDB" } },
        };
    }

    private static List<Student> GetMockStudents()
    {
        return new List<Student>
        {
            new () { StudentId = 1, FirstName = "Tom", LastName = "Gray", Subjects = new [] { "Math", "Science", "Computer Science" } },
            new () { StudentId = 2, FirstName = "Amy", LastName = "Ryan", Subjects = new [] { "History", "Physics", "Spanish" } },
            new () { StudentId = 3, FirstName = "Jay", LastName = "Ford", Subjects = new [] { "English", "Biology", "Chemistry" } },
            new () { StudentId = 4, FirstName = "Eva", LastName = "Hill", Subjects = new [] { "Art", "Music", "Physical Education" } },
            new () { StudentId = 7, FirstName = "Joe", LastName = "King", Subjects = new [] { "Geography", "Literature", "French" } },
            new () { StudentId = 8, FirstName = "Sue", LastName = "Dunn", Subjects = new [] { "Economics", "Psychology", "Sociology" } }
        };
    }
    #endregion

}

