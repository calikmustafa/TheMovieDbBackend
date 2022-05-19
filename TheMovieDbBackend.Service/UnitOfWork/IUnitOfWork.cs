using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovieDbBackend.Service.AuthService;
using TheMovieDbBackend.Service;
using TheMovieDbBackend.Core.Entity;
using TheMovieDbBackend.Service.BaseRepository;

namespace TheMovieDbBackend.Service
{
    public interface IUnitOfWork:IDisposable
    {
        IMovieRepository MovieRepository { get; }
        IAuthRepository AuthRepository { get; }
        IBaseRepository<MovieDb> MovieDbRepository { get; }
        Task<bool> SaveAll();
    }
}
