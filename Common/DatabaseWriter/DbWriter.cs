using Common.Entity;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Common.DatabaseWriter
{
    public class DbWriter : IDbWriter
    {
        private readonly string _conString;
        private IDbConnection Db => new SqlConnection(_conString);

        public DbWriter(string connectionString)
        {
            _conString = connectionString;
        }
        public async Task<Result> InsertAsync(Employee employee)
        {
            using (Db)
            {
                var sqlQuery = "INSERT INTO Employee (FirstName, LastName, Company, Email) VALUES(@FirstName, @LastName, @Company, @Email)";
                await Db.ExecuteAsync(sqlQuery, employee);
            }
            return Result.Ok();
        }

        public async Task<Result> InsertAsync(IEnumerable<Employee> employees)
        {                    
            using (SqlBulkCopy copy = new SqlBulkCopy(_conString))
            {
                copy.DestinationTableName = "Employee";
                DataTable table = new DataTable("Employee");
                table.Columns.Add("FirstName", typeof(string));
                table.Columns.Add("LastName", typeof(string));
                table.Columns.Add("Company", typeof(string));
                table.Columns.Add("Email", typeof(string));
                foreach (var item in employees)
                {
                    table.Rows.Add(item.FirstName, item.LastName, item.Company, item.Email);
                }

                await copy.WriteToServerAsync(table);
            }
            return Result.Ok();
        }       
    }
}
