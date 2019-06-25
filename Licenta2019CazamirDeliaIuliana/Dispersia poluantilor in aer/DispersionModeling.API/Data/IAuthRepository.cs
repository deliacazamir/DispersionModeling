using System.Threading.Tasks;
using DispersionModeling.API.Models;

namespace DispersionModeling.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}