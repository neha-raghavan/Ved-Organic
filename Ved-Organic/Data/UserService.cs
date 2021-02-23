using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ved_Organic.Data
{
    public class UserService : IUserService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public UserService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;

        }
        public async Task<bool> Register(UserInfo user)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Name", user.Name, DbType.String);
                parameters.Add("Mobile", user.Mobile, DbType.String);
                parameters.Add("Email", user.Email, DbType.String);
                parameters.Add("Password", user.Password, DbType.String);
                parameters.Add("Street", user.Street, DbType.String);
                parameters.Add("Building", user.Building, DbType.String);
                parameters.Add("Area", user.Area, DbType.String);
                parameters.Add("City", user.City, DbType.String);
                parameters.Add("Country", user.Country, DbType.String);
                parameters.Add("POBOX", user.POBOX, DbType.String);
                parameters.Add("LandLine", user.LandLine, DbType.String);
                parameters.Add("Business", user.Business, DbType.Boolean);


                const string query = @"INSERT INTO UserRegistration
                         (Name,Mobile,Email,Password,Street,Building, Area, City,Country,POBox,  Landline ,Business     )
VALUES        ( @Name,@Mobile,@Email,@Password,@Street,@Building, @Area, @City,@Country,@POBox,  @Landline,@Business )";
                await conn.ExecuteAsync(query, new { user.Name, user.Mobile, user.Email, user.Password, user.Street, user.Building, user.Area, user.City, user.Country, user.POBOX, user.LandLine,user.Business}, commandType: CommandType.Text);
            }
            return true;
        }
    }
}
