using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovieDbBackend.Core.Entity;
using TheMovieDbBackend.Service.BaseRepository;

namespace TheMovieDbBackend.Service.AuthService
{
    public interface IAuthRepository:IBaseRepository<User>
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string email, string password);
        Task<bool> UserExist(string mail);
    }
}
