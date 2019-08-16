using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SequentialGuidConsoleCoreApp
{
   public class DBHandler
    {
        public void CreateDB()
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=.;User ID=sa;Password=123;database=master");

            str = "CREATE DATABASE SequentialGuidDB ON PRIMARY " +
                "(NAME = SequentialGuidDB, " +
                "FILENAME = 'C:\\SequentialGuidDB.mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = SequentialGuidDB_Log, " +
                "FILENAME = 'C:\\SequentialGuidDB.ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                Console.Write("DataBase is Created Successfully", "MyProgram");
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.ToString(), "MyProgram");
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
    }
}
