using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace todolist
{
    class DatabaseConnection
    {
        // data
        private MySqlConnection conn;

        // default constructor
        public DatabaseConnection()
        {
            this.conn = new MySqlConnection("server=localhost;userid=root; password = !nspiration; database=independent");
        }
        public void OpenConnection()
        {
            this.conn.Open();
        }

        public void CloseConnection()
        {
            this.conn.Close();
        }

        public MySqlConnection GetConn()
        {
            return this.conn;
        }
    }
}
