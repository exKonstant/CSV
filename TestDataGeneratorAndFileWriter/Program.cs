using Common.Entity;
using CSVManipulator.Writer;
using System;
using System.Threading.Tasks;

namespace TestDataGeneratorAndFileWriter
{
    class Program
    {
        static void Line()
        {
            Console.WriteLine(new string('-', 50));            
        }
        static async Task Main(string[] args)
        {
            string path = @"D:\test.csv";
            
            for (int i = 0; i < 4000; i++)
            {
                Console.WriteLine("Start generating data!");
                var strings = await EmployeeGenerator.GenerateStringsAsync(10000);
                Console.WriteLine("Data were generated successful!");

                Line();

                Console.WriteLine("Start writing data to the file!");

                var csvWriter = new CsvWriter(path);
                var writerResult = await csvWriter.WriteStringAsync(strings, false);

                switch (writerResult.IsFailure)
                {
                    case true:
                        Console.WriteLine(writerResult.Message);
                        break;
                    default:
                        Console.WriteLine("Data were written successful!");
                        break;
                }

                Line();
            }
                
            Console.ReadLine();
        }
    }
}
