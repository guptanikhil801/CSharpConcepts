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
        var result = numbers.Select(x => new { number = x, square = x * x });
        return result;
    }
    #endregion

    #region Select Many Operator
    public static List<string> GetAllSkillsOfAllEmployes()
    {
        var employees = MockDataProvider.GetMockEmployees();
        var skillSetOfEmployees = employees.SelectMany(x => x.SkillSet)
                                          .Distinct().ToList();
        return skillSetOfEmployees;
    }

    public static List<string> GetAllSkillsOfSingleEmployee(int employeeId)
    {
        var employees = MockDataProvider.GetMockEmployees();
        var skillsetOfEmployee = employees.Where(x => x.EmployeeId == employeeId)
                                          .SelectMany(x => x.SkillSet).ToList();
        return skillsetOfEmployee;
    }

    #endregion

    #region Sorting Operators

    public static List<Employee> GetEmployeeListSortedBySalary()
    {
        var allEmployees = MockDataProvider.GetMockEmployees();
        var sortedEmployees = allEmployees.OrderBy(x => x.Salary).ToList();
        return sortedEmployees;
    }

    public static List<Employee> EmployeesHavingSalaryMoreThan50kSortedBySalary()
    {
        var allEmployees = MockDataProvider.GetMockEmployees();
        var sortedEmployees = allEmployees.Where(emp => emp.Salary > 50000)
                                          .OrderBy(x => x.Salary).ToList();
        return sortedEmployees;
    }

    public static List<Employee> GetEmployeeListSortedBySalaryDescending()
    {
        var allEmployees = MockDataProvider.GetMockEmployees();
        var sortedEmployees = allEmployees.OrderByDescending(x => x.Salary).ToList();
        return sortedEmployees;
    }

    public static List<Employee> EmployeesHavingSalaryMoreThan50kSortedBySalaryDescending()
    {
        var allEmployees = MockDataProvider.GetMockEmployees();
        var sortedEmployees = allEmployees.Where(emp => emp.Salary > 50000)
                                          .OrderByDescending(x => x.Salary).ToList();
        return sortedEmployees;
    }

    public static List<Employee> GetEmployeesSortedByFirstNameLastNameThenSalary()
    {
        var allEmployees = MockDataProvider.GetMockEmployees();
        var sortedEmployees = allEmployees.OrderBy(x => x.FirstName)
                                          .ThenBy(x => x.LastName)
                                          .ThenBy(x => x.Salary).ToList();
        return sortedEmployees;
    }

    public static List<Employee> GetEmployeesSortedByFirstNameLastNameThenSalaryDescending()
    {
        var allEmployees = MockDataProvider.GetMockEmployees();
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
        var evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();
        return evenNumbers.ToArray();
    }

    /// <summary>
    /// It returns the Even numbers from a list of numbers in a range using two where
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

    public static int MostFrequentNumber(List<int> numbers)
    {
        return numbers.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count()).OrderByDescending(x => x.Value).FirstOrDefault().Key;
    }

    public static Dictionary<int, List<Student>> GroupAndSortStudents()
    {
        return MockDataProvider.GetMockStudents().GroupBy(x => x.Class)
             .ToDictionary(x => x.Key, y => y.OrderByDescending(s => s.Percentage).ToList());
    }

    public static Dictionary<(int CustomerId, int Year), List<Order>> GroupOrdersByCustomerAndYear()
    {
        return MockDataProvider.GetMockOrders().GroupBy(x => (x.CustomerId, x.OrderDate.Year))
              .ToDictionary(x => x.Key, y => y.ToList());
    }

    public static Dictionary<string, Dictionary<string, List<Employee>>> NestedGroupingDeptThenRole()
    {
        return MockDataProvider.GetMockEmployees().GroupBy(x => x.Department)
            .ToDictionary(x => x.Key, y => y
                .GroupBy(x => x.Role)
                .ToDictionary(x => x.Key, y => y.ToList())
            );
    }
    #endregion

    #region Quantifier Operators (All,Any & Contains)

    public static bool CheckAllEmployeesEarnMoreThan40k()
    {
        return MockDataProvider.GetMockEmployees().All(emp => emp.Salary > 15000);
    }

    public static List<Employee> GetAllEmployeesWhoHasDjangoAsSkill()
    {
        return MockDataProvider.GetMockEmployees().Where(x => x.SkillSet.Any(x => x == "Django"))
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
        return MockDataProvider.GetMockEmployees().SelectMany(x => x.SkillSet)
                                 .Distinct()
                                 .OrderBy(x => x).ToList();
    }

    public static List<int> GetAllDistinctIDsCombiningEmployeesAndStudents()
    {
        return MockDataProvider.GetMockEmployees().Select(x => x.EmployeeId)
                                 .Union(MockDataProvider.GetMockStudents()
                                 .Select(x => x.StudentId)).ToList();
    }

    public static List<int> GetCommonIdsCombiningEmployeesAndStudents()
    {
        return MockDataProvider.GetMockEmployees().Select(x => x.EmployeeId)
                                 .Intersect(MockDataProvider.GetMockStudents()
                                 .Select(z => z.StudentId)).ToList();
    }

    public static List<int> GetUniqueIdsFromEmployeesThatIsNotAvailableInStudents()
    {
        return MockDataProvider.GetMockEmployees().Select(x => x.EmployeeId)
                                 .Except(MockDataProvider.GetMockStudents()
                                 .Select(y => y.StudentId)).ToList();
    }

    #endregion

    #region Partioning Operators(Take, TakeWhile, Skip, SkipWhile)
    public static List<Employee> GetTopTwoEmployee()
    {
        return MockDataProvider.GetMockEmployees().Take(2).ToList();
    }

    /// <summary>
    /// Wherever TakeWhile's method gets failed, its stops there, it doesnt check further.
    /// </summary>
    /// <returns></returns>
    public static List<int> GetEmployeesSalaryWhoEarnsAtleast50K()
    {
        return MockDataProvider.GetMockEmployees().TakeWhile(x => x.Salary > 49999)
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

}

