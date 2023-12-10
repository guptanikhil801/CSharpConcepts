namespace CsharpConcepts.Classes
{
    internal class Parent
    {
        public void MethodHiding()
        {
            Console.WriteLine("parent implementation of MethodHiding");
        }

        public virtual void MethodOverriding()
        {
            Console.WriteLine("parent implementation MethodOverriding");
        }
    }

    internal class Child : Parent
    {
        public new void MethodHiding()
        {
            Console.WriteLine("Child implementation");
        }

        public override void MethodOverriding()
        {
            Console.WriteLine("Child implementation MethodOverriding");
        }
    }
}