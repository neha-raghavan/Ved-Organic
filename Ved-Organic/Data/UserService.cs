using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Ved_Organic.Data
{

    public class UserService
    {
        private string connectionString = " ";
        public UserService()
        {
            connectionString = @"Data Source=DESKTOP-2NF25G8\SQLEXPRESS01;Initial Catalog=Ved;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }

        }
        public void Register(PersonalDetail user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO PersonnelDetailsTran
                          (AccountID,Name, Phone1, Email, Password, Street, Building, Area1, City, Country, PBNo, Phone2,AddressType)
VALUES(1,@Name, @Phone1, @Email, @Password, @Street, @Building, @Area1, @City, @Country, @PBNo, @Phone2,@AddressType)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, user);
            }
        }
        public LoginResponse LoginDetails(string id, string pass)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string squery = @"select ur.Name as UserName,ur.Id as UserId,urs.permissionsString as PermissionString from UserRegistration as ur inner join UserRoles as urs on urs.id=ur.UserType where Email=@Id and Password=@Pass ";
                dbConnection.Open();
                return dbConnection.Query<LoginResponse>(squery, new { Id = id, Pass = pass }).FirstOrDefault();

            }
          
        }
    }
}