using Common.Entity;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVManipulator.Reader
{
    public class CsvReader : ICsvReader
    {
        private readonly string _path;

        public CsvReader(string path)
        {
            _path = path;
        }

        private bool FileExists()
        {
            return File.Exists(_path);
        }

        private List<string> ReadStrings(int number, int stage)
        {
            if (!FileExists())
            {
                throw new FileNotFoundException();
            }                       
            return File.ReadLines(_path).Skip(stage * number).Take(number).ToList();
        }

        public List<Employee> ReadEmployees(int number, int stage)
        {
            var strings = ReadStrings(number, stage);

            var employees = new List<Employee>();

            foreach (var item in strings)
            {
                var items = item.Split(',');
                employees.Add(new Employee
                    {
                        FirstName = items[0],
                        LastName = items[1],
                        Company = items[2],
                        Email = items[3]
                    }
                );
            }
            return employees;
        }
    }
}
