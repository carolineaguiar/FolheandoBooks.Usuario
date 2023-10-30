using FolheandoBooks.Usuario.Model;
using Microsoft.AspNetCore.Identity;

namespace FolheandoBooks.Usuario.Service
{
    public interface IUserService
    {
        Task<string> GenerateJwtTokenAsync(string email, string password);
        Task<bool> ValidateUserAsync(string email, string password);
        Task<IdentityResult> RegisterAsync(Register model);
    }
}
