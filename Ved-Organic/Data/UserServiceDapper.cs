using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Ved_Organic.Data
{
   
    public class UserServiceDapper
    {
        private string connectionString = " ";
        public UserServiceDapper()
        {
            connectionString = @"Server=DESKTOP-2NF25G8;Initial catalog=Ved_Organic;User ID=sa;Password=hcs1237;Trusted_Connection=True;";
        }
       public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }

        }
        public void Register(UserInfo user)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO UserRegistration
                          (Name, Mobile, Email, Password, Street, Building, Area, City, Country, POBox, Landline, Business)
VALUES(@Name, @Mobile, @Email, @Password, @Street, @Building, @Area, @City, @Country, @POBox, @Landline, @Business)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, user);
            }
        }
    }
}
