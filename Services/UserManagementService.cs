using Soteria.Server.Authentication;
using Soteria.Server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Soteria.Server.Services
{
    public class UserManagementService : IUserManagementService
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Edu\\source\\repos\\Soteria\\api\\Database\\SecretDB.mdf;Integrated Security=True;Connect Timeout=30";

        public bool IsValidUser(string userName, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string queryString = $"SELECT 'true' FROM [User] where Username = '{userName}' AND Password = '{password}'";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    var isLoginSuccesfull = Convert.ToBoolean(result);
                    return isLoginSuccesfull;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
