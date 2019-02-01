using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SCD_Web_API.Models;

namespace SCD_Web_API.DataProvider
{
    public class UserDataProvider : IUserDataProvider
    {
        private readonly string connectionString = "Server=Enc-SQL-02;Database=Test_SCD-API;User=Test_API_Read;Password=Encore03;";
        private SqlConnection sqlConnection;

        public async Task AddPerson(People person)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@FN", person.FirstName);
                dp.Add("@LN", person.LastName);
                dp.Add("@E", person.EmailAddress);
                dp.Add("@PN", person.PhoneNumber);

                await sqlConnection.ExecuteAsync(
                    "spAddPerson",
                    dp,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeletePerson(int Id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@Id", Id);
                await sqlConnection.ExecuteAsync(
                    "spDeletePerson",
                    dp,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<People>> GetPeoples()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<People>(
                    "spGetPeople",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<People> GetPerson(int Id)
        {
            using (var sqlConnection= new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@Id", Id);
                return await sqlConnection.QuerySingleOrDefaultAsync<People>(
                    "spGetPerson",
                    dp,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public async Task UpdatePerson(People person)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@Id", person.Id);
                dp.Add("@Fn", person.FirstName);
                dp.Add("@Ln", person.LastName);
                dp.Add("@E", person.EmailAddress);
                dp.Add("@PN", person.PhoneNumber);
                await sqlConnection.ExecuteAsync(
                    "spUpdatePerson",
                    dp,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
