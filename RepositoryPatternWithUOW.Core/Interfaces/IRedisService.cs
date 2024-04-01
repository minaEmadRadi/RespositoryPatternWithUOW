using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IRedisService
    {
        Task SetStringAsync(string key, string value);
        Task<string> GetStringAsync(string key);
    }

}
