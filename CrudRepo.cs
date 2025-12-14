using System;
using System.Collections.Generic;
using MySqlConnector;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    internal class CrudRepo
    {
        string _connectionString = @"Server=localhost;Database=mydb;User=root;Password=root;";
        
        public CrudRepo()
        { 
        
        }


        public void Create ()
        {

        }
        public async void Read()
        {
            MySqlConnection connection = new MySqlConnection (_connectionString);
            
            await connection.OpenAsync();
            
            MySqlCommand command = new MySqlCommand(
                "SELECT * FROM my", connection);

            MySqlDataReader reader = await command.ExecuteReaderAsync();

        }
        public void Update() 
        { 
            
        }
        public void Delete()
        {

        }
    }
}
