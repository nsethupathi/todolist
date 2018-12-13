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
        MySqlConnection connectionstring = new MySqlConnection("server=localhost;user id=root;database=independent");

        public void OpenConnection()
        {
            connectionstring.Open();
        }
        // need to push

        public void CloseConnection()
        {
            connectionstring.Close();
        }
    }
}
