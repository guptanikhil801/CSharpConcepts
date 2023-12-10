namespace CsharpConcepts.Classes
{
    public delegate int AddDelegate(int Num1, int Num2); // single cast Delegate

    internal class DelegateExample
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
        public delegate void MultiDelegate(int Num1, int Num2);              //Multicast Delegate Return type must be void

        public void DriverForSingleCastDelegate()
        {
            DelegateExample delegateExample = new DelegateExample();
            AddDelegate addDelegate = new AddDelegate(delegateExample.Add);  // initialization of delegate
            int additionWay1 = addDelegate(56, 4);                           // way-1
            int additionWay2 = addDelegate.Invoke(56, 4);                    // way-2
            Console.WriteLine("Result using Way 1:  " + additionWay1);
            Console.WriteLine("Result using Way 2 (invoke) : " + additionWay2);
        }

        public void DriverForMultiCastDelegate()
        {
            DelegateExample delegateExample = new DelegateExample();
            MultiDelegate multiDelegate = new MultiDelegate(delegateExample.Subtract);  // initialization of delegate
            multiDelegate += delegateExample.Multiply;                                  // Adding another method
            multiDelegate.Invoke(56, 4);                                                // calling delegate
        }
    }
}