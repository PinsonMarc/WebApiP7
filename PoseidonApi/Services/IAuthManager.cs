using Dot.Net.PoseidonApi.Entities;
using PoseidonApi.Model.Identity;
using System.Threading.Tasks;

namespace PoseidonApi.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserDTO userDTO);
        Task<string> CreateToken();
        Task<string> CreateRefreshToken();
        Task<TokenRequest> VerifyRefreshToken(TokenRequest request);
    }
}
