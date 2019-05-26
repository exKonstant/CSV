using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSVManipulator.Writer
{
    public interface ICsvWriter
    {
        Task<Result> WriteStringAsync(IEnumerable<string> strings, bool overwriteText);
        Task<Result> WriteStringAsync(string str, bool overwriteText);
    }
}