using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovieDbBackend.Core.Entity;
using TheMovieDbBackend.Library.Criptography;
using TheMovieDbBackend.Service.BaseRepository;

namespace TheMovieDbBackend.Service.AuthService
{
    public class AuthRepository : BaseRepository<User>, IAuthRepository
    {
        public AuthRepository(TheMovieDbContext context) : base(context)
        {
        }
        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;

            PasswordWorker.CreatePassWordHash(password, out passwordHash, out passwordSalt);
            user.UserPasswordHash = passwordHash;
            user.UserPasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);

            return user;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserEmail == email);

            if (user == null)
                return null;

            if (!PasswordWorker.VerifyPasswordHash(password, user.UserPasswordHash, user.UserPasswordSalt))
                return null;

            return user;

        }

        public async Task<bool> UserExist(string mail)
        {
            if (await _context.Users.AnyAsync(x => x.UserEmail == mail))
            {
                return true;
            }
            return false;
        }
    }
}
