using Common.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.DatabaseWriter
{
    public interface IDbWriter
    {
        Task<Result> InsertAsync(Employee employee);
        Task<Result> InsertAsync(IEnumerable<Employee> employees);
    }
}