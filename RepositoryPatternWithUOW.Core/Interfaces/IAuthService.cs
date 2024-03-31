
using RepositoryPatternWithUOW.Core.Models;

using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IAuthService
    {
        Task<string> GenerateJwtTokenAsync(Customer user);     
    }
}
