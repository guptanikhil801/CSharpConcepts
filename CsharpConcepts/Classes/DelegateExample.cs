namespace CsharpConcepts.Classes
{
    //Delegate should be declared directly inside namespace, it can be declared inside class
    //but it is advisable to define under namespace since it is a type like class, interface, struct
    public delegate int AddDelegate(int Num1, int Num2); // single cast Delegate

    //Multicast Delegate Return type must be void
    public delegate void MultiDelegate(int Num1, int Num2);// Multicast delegate
    
    internal class ArithmeticOperations
    {
        public int Add(int Num1, int Num2)
        {
            return Num1 + Num2;
        }

        public void Subtract(int Num1, int Num2)
        {
            Console.WriteLine(Num1 - Num2);
        }

        public void Multiply(int Num1, int Num2)
        {
            int mul = Num1 * Num2;
            Console.WriteLine(mul);
        }
    }

    internal class DelegateDriverClass
    {
        public void DriverForSingleCastDelegate()
        {
            ArithmeticOperations arithmeticOperations = new ArithmeticOperations();

            AddDelegate addDelegate = arithmeticOperations.Add;  // initialization of delegate
            //AddDelegate addDelegate = new AddDelegate(arithmeticOperations.Add);  // initialization way-2
            int additionWay1 = addDelegate(56, 4);                           // way-1
            int additionWay2 = addDelegate.Invoke(56, 4);                    // way-2
            Console.WriteLine("Result using Way 1:  " + additionWay1);
            Console.WriteLine("Result using Way 2 (invoke) : " + additionWay2);
        }

        public void DriverForMultiCastDelegate()
        {
            ArithmeticOperations arithmeticOperations = new ArithmeticOperations();
            MultiDelegate multiDelegate = new MultiDelegate(arithmeticOperations.Subtract);  // initialization of delegate
            multiDelegate += arithmeticOperations.Multiply;                                  // Adding another method
            multiDelegate.Invoke(56, 4);                                                // calling delegate
        }
    }
}