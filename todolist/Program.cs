using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace todolist
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = @"server=localhost;userid=root;
            password=!nspiration;database=independent";

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                // create table
                MySqlCommand CreateCmd = new MySqlCommand();
                CreateCmd.Connection = conn;
                CreateCmd.CommandText = "CREATE TABLE tasks(task_id INT PRIMARY KEY AUTO_INCREMENT, name VARCHAR(50) UNIQUE)";
                CreateCmd.Prepare();

                CreateCmd.ExecuteNonQuery();
                Console.ReadKey();


                // insert element
                MySqlCommand InsertCmd = new MySqlCommand();
                InsertCmd.Connection = conn;
                InsertCmd.CommandText = "INSERT INTO tasks(name) VALUES(@name)";
                InsertCmd.Prepare();

                InsertCmd.Parameters.AddWithValue("@name", "Walk the dog");
                InsertCmd.ExecuteNonQuery();
                Console.ReadKey();


                // delete element
                MySqlCommand DeleteCmd = new MySqlCommand();
                DeleteCmd.Connection = conn;
                DeleteCmd.CommandText = "DELETE FROM tasks WHERE name = @name";
                DeleteCmd.Prepare();

                DeleteCmd.Parameters.AddWithValue("@name", "Walk the dog");
                DeleteCmd.ExecuteNonQuery();
                Console.ReadKey();


                // drop table
                MySqlCommand DropCmd = new MySqlCommand();
                DropCmd.Connection = conn;
                DropCmd.CommandText = "DROP TABLE tasks;";
                DropCmd.Prepare();

                DropCmd.ExecuteNonQuery();
                Console.ReadKey();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                Console.ReadKey();
            }
            finally
            {

                if (conn != null)
                {
                    conn.Close();
                }

            }
        }
    }
}
