namespace CsharpConcepts.Classes
{
    public static class GenericExample
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg1"></param>
        /// <returns>supplied Data type of arg1</returns>
        public static string GetDataType<T>(T arg1)
        {
            var dType = arg1.GetType();
            // var a = Convert.ChangeType(arg1, dType);
            return dType.Name;
        }
    }
}