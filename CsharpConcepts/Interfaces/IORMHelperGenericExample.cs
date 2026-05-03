using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpConcepts.Interfaces
{
    public interface IORMHelperGenericExample<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
    }
}
