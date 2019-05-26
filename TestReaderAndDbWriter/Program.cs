using Common.DatabaseWriter;
using Common.Entity;
using CSVManipulator.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestReaderAndDbWriter
{
    class Program
    {
        static void Line()
        {
            Console.WriteLine(new string('-', 50));
        }
        static async Task Main(string[] args)
        {
            string path = @"C:\Users\Atem\Desktop\testfinal1.csv";
            string conStr = "Server=KOMAR;Database=EmployeeDB;Trusted_Connection=True;";

            var csvReader = new CsvReader(path);
            IEnumerable<Employee> employees;

            var stage = 0;
            var number = 50000;

            do
            {
                Console.WriteLine("Start reading data!");
                employees = csvReader.ReadEmployees(number, stage++);
                Console.WriteLine("Data were read successful!");

                Line();

                Console.WriteLine("Start writing data to the database!");
                var databaseWriter = new DbWriter(conStr);
                var databaseResult = await databaseWriter.InsertAsync(employees);

                switch (databaseResult.IsFailure)
                {
                    case true:
                        Console.WriteLine(databaseResult.Message);
                        break;
                    default:
                        Console.WriteLine("Data were written successful!");
                        break;
                }

                Line();

            } while (employees.Any());

            Console.ReadLine();
        }
    }
}
