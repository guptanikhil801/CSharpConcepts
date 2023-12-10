using System.Collections;

namespace CsharpConcepts.Classes
{
    internal static class CollectionExamples
    {
        public static void ArrayListExample()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add("Nikhil");
            arrayList.Add(90);
            arrayList.Add(937.03m);

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}