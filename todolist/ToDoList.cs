using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace todolist
{
    class ToDoList
    {
        // data
        private DatabaseConnection db;

        // default constructor
        public ToDoList()
        {
            this.db = new DatabaseConnection();
        }

        private void CreateTable()
        {
            MySqlCommand CreateCmd = new MySqlCommand();
            CreateCmd.Connection = this.db.GetConn();
            CreateCmd.CommandText = "CREATE TABLE tasks(task_id INT PRIMARY KEY AUTO_INCREMENT, name VARCHAR(50) UNIQUE)";
            CreateCmd.Prepare();

            CreateCmd.ExecuteNonQuery();
            Console.ReadKey();
        }

        private void Insert()
        {
            MySqlCommand InsertCmd = new MySqlCommand();
            InsertCmd.Connection = this.db.GetConn();
            InsertCmd.CommandText = "INSERT INTO tasks(name) VALUES(@name)";
            InsertCmd.Prepare();

            Console.WriteLine("\nEnter task to insert...");
            string input = Console.ReadLine();
            InsertCmd.Parameters.AddWithValue("@name", input);
            InsertCmd.ExecuteNonQuery();
            Console.ReadKey();
        }

        private void Delete()
        {
            MySqlCommand DeleteCmd = new MySqlCommand();
            DeleteCmd.Connection = this.db.GetConn();
            DeleteCmd.CommandText = "DELETE FROM tasks WHERE name = @name";
            DeleteCmd.Prepare();

            Console.WriteLine("\nEnter task to delete...");
            string input = Console.ReadLine();
            DeleteCmd.Parameters.AddWithValue("@name", input);
            DeleteCmd.ExecuteNonQuery();
            Console.ReadKey();
        }

        private void DropTable()
        {
            MySqlCommand DropCmd = new MySqlCommand();
            DropCmd.Connection = this.db.GetConn();
            DropCmd.CommandText = "DROP TABLE tasks;";
            DropCmd.Prepare();

            DropCmd.ExecuteNonQuery();
            Console.ReadKey();
        }

        public void Run()
        {
            // open connection
            this.db.OpenConnection();

            // create table
            this.CreateTable();

            while (true)
            {
                Console.WriteLine("\nPick one of the following...\ninsert \ndelete \nquit\n");
                string input = Console.ReadLine();

                if (input.Equals("insert")) this.Insert();

                else if (input.Equals("delete")) this.Delete();

                else if (input.Equals("quit")) break;

            }

            // drop table
            this.DropTable();    


            // close connection
            if (this.db.GetConn() != null)  this.db.CloseConnection();
        }
    }
}
