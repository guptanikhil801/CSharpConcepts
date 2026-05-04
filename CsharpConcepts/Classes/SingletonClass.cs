using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpConcepts.Classes
{
    public sealed class SingletonClass
    {
        private static SingletonClass instance = null;
        private SingletonClass() { }

        public static SingletonClass GetInstance()
        {
            if(instance == null)
            {
                instance = new SingletonClass();
            }
            return instance;
        }
        public void SampleMethod(SingletonClass instance)
        {
            Console.WriteLine("sample singleton method");
        }
    }
}
