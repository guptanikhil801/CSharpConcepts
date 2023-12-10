namespace CsharpConcepts.Classes
{
    /// <summary>
    /// Both keywords are usefull to return multiple value, keyword must be used in method definition and while calling
    /// </summary>
    public static class RefAndOut
    {
        public static void RefRunnerMethod()
        {
            int mul = 1; // iniatialization is required in case of ref
            int addition = 0;
            MultiplicationUsingRef(10, 5, ref mul, ref addition);
            Console.WriteLine("ref example : ");
            Console.WriteLine("Multiplication : " + mul);
            Console.WriteLine("Addition : " + addition);
        }

        public static void OutRunnerMethod()
        {
            int mul; //iniatialization is not required
            int addition;
            MultiplicationUsingOut(10, 5, out mul, out addition);
            Console.WriteLine("Out example : ");
            Console.WriteLine("Multiplication : " + mul);
            Console.WriteLine("Addition : " + addition);
            Console.ReadKey();
        }

        private static void MultiplicationUsingRef(int num1, int num2, ref int mul, ref int addition)
        {
            mul = num1 * num2;
            addition = num1 + num2;
        }

        private static void MultiplicationUsingOut(int num1, int num2, out int mul, out int addition)
        {
            mul = num1 * num2;
            addition = num1 + num2;
        }
    }
}