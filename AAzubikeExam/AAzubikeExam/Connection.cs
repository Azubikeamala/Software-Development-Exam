using System;

namespace AAzubikeExam
{
   
    public static class Data
    {
       
        private static readonly string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                                    Initial Catalog=Northwind;
                                                    Integrated Security=True";

   
        public static string ConnectionString => connStr;
    }
}
