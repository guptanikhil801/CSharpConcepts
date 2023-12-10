using System.Data;
using System.Data.SqlClient;

namespace CsharpConcepts.Classes
{
    internal class DataAdaptorExample
    {
        private readonly string ConnString = "server=(localdb)\\MSSQLLocalDB; database=PracticeDb; Integrated Security=true";

        public void GetData()
        {
            SqlDataAdapter adaptor = new SqlDataAdapter("select * from employee", ConnString);
            DataSet ds = new DataSet();

            adaptor.Fill(ds);
            //ds.
            //adaptor.in
        }
    }
}