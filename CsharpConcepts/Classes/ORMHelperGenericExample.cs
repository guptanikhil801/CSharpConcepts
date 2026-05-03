using CsharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpConcepts.Classes
{
    public class ORMHelperGenericExample<T> : IORMHelperGenericExample<T> where T : class
    {
        private readonly List<T> data = new List<T>();
        public void Add(T entity)
        {
            data.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return data;
        }

    }
}
