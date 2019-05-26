using Common;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSVManipulator.Writer
{
    public class CsvWriter : ICsvWriter
    {
        private readonly string _path;

        public CsvWriter(string path)
        {
            _path = path;
        }

        public async Task<Result> WriteStringAsync(IEnumerable<string> strings, bool overwriteText)
        {
            if (strings == null)
            {
                return Result.Fail("Invalid strings");
            }

            if (overwriteText)
            {
                await File.WriteAllLinesAsync(_path, strings);
            }
            else
            {
                await File.AppendAllLinesAsync(_path, strings);
            }
            return Result.Ok();
        }

        public async Task<Result> WriteStringAsync(string str, bool overwriteText)
        {
            if (str == null)
            {
                return Result.Fail("Invalid string");
            }

            if (overwriteText)
            {
                await File.WriteAllTextAsync(_path, str);
            }
            else
            {
                await File.AppendAllTextAsync(_path, str);
            }
            return Result.Ok();
        }
    }
}
