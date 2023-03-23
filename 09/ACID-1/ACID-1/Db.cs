using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACID_1
{
    public class Db
    {
        SqlConnection connDB;
        SqlTransaction connTransaction = null;
        string connectionString = "Data Source=127.0.0.1;Initial Catalog=xxx;Persist Security Info=True;User ID=sa;Password=@12tf56so;TrustServerCertificate=True";

        public SqlTransaction BeginTransaction()
        {
            connTransaction = connDB.BeginTransaction();
            return connTransaction;
        }

        public SqlTransaction BeginTransaction(System.Data.IsolationLevel theLevel)
        {
            connTransaction = connDB.BeginTransaction(theLevel);
            return connTransaction;
        }

        public void Commit(SqlTransaction theTransaction)
        {
            try
            {
                theTransaction.Commit();
            }
            catch (Exception exC)
            {
                Console.WriteLine("Commit Exception Type: {0}", exC.GetType());
                Console.WriteLine("  Message: {0}", exC.Message);
                try
                {
                    theTransaction.Rollback();
                }
                catch (Exception exR)
                {
                    Console.WriteLine("Rollback Exception Type: {0}", exR.GetType());
                    Console.WriteLine("  Message: {0}", exR.Message);
                }
            }
        }

        public void RollBack(SqlTransaction theTransaction)
        {
            try
            {
                theTransaction.Rollback();
            }
            catch (Exception exR)
            {
                Console.WriteLine("Rollback Exception Type: {0}", exR.GetType());
                Console.WriteLine("  Message: {0}", exR.Message);
            }
        }

        private void DbExec(SqlConnection connDB, string theCommand)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(theCommand, connDB);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error: " + ex.ToString());
                Console.WriteLine("- command: " + theCommand);
                Console.ReadLine();
                System.Environment.Exit(1);
            }
        }

        public int Read()
        {
            SqlCommand cmd = new SqlCommand("Select amount FROM Items WHERE itemName='Bad Jokes'", connDB);
            cmd.Transaction = connTransaction;
           try
            {
                SqlDataReader myReader = cmd.ExecuteReader();
                myReader.Read();
                int result = int.Parse(myReader["amount"].ToString());
                myReader.Close();
                return result;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return 0;
        }

        public bool Write(int newValue)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Items SET amount=" + newValue.ToString() + "  WHERE itemName='Bad Jokes'", connDB);
            cmd.Transaction = connTransaction;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                // Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public Db(bool doCreate)
        {
            connDB = new SqlConnection(connectionString);
            try
            {
                connDB.Open();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL connect error: " + ex.ToString());
                Console.ReadLine();
                System.Environment.Exit(1);
            }
            Console.WriteLine("Database connection opened");
            if (doCreate)
            {
                try
                {
                    DbExec(connDB, "DROP TABLE IF EXISTS \"Items\"");
                    DbExec(connDB, "CREATE TABLE \"Items\" ( \"itemName\" VARCHAR(50) NOT NULL DEFAULT NULL, \"amount\" INT NULL DEFAULT 0, PRIMARY KEY (\"itemName\") )");
                    DbExec(connDB, "INSERT INTO Items (itemName, amount) VALUES ('Bad Jokes', 50)");
                }
                catch
                {

                }
            }
        }

        public void Close()
        {
            connDB.Close();
        }
    }
}
