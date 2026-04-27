namespace CsharpConcepts.Classes
{
    internal class CopyConstructor
    {
        int Number;
        public CopyConstructor(int i)
        {
              this.Number= i;  
        }

        /// <summary>
        /// It is used to create multiple instances with the same values, in a copy
        /// constructor the constructor takes the same class as a parameter to it.
        /// </summary>
        /// <param name="obj"></param>
        public CopyConstructor(CopyConstructor obj)
        {
             this.Number = obj.Number;   
        }
    }
}
