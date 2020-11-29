using System.Threading.Tasks;
using RolePlayGame.Models;

namespace RolePlayGame.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExitsts(string username);
    }
}