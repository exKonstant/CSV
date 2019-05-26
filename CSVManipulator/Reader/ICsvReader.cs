using Common.Entity;
using System.Collections.Generic;

namespace CSVManipulator.Reader
{
    public interface ICsvReader
    {
        List<Employee> ReadEmployees(int number, int stage);
    }
}