using Bogus;
using FizzWare.NBuilder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Entity
{
    public static class EmployeeGenerator
    {
        private static IEnumerable<Employee> GenerateEntities(int count)
        {
            var faker = new Faker();
            return Builder<Employee>.CreateListOfSize(count)
                .All()
                .With(e => e.FirstName = faker.Name.FirstName())
                .With(e => e.LastName = faker.Name.LastName())
                .With(e => e.Company = faker.Company.CompanyName(1))
                .With(e => e.Email = faker.Internet.Email())
                .Build();            
        }

        public static async Task<IEnumerable<Employee>> GenerateEntitiesAsync(int count)
        {
            return await Task.Run(() => GenerateEntities(count));
        }
        public static async Task<IEnumerable<string>> GenerateStringsAsync(int count)
        {
            var employees = await GenerateEntitiesAsync(count);

            var strings = new List<string>();

            foreach (var employee in employees)
            {
                string str = employee.FirstName + "," + employee.LastName + "," + employee.Company + "," + employee.Email;
                strings.Add(str);
            }
            return strings;
        }
    }
}
