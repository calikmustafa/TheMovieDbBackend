using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovieDbBackend.Core.Entity;
using TheMovieDbBackend.Service.AuthService;
using TheMovieDbBackend.Service.BaseRepository;
using TheMovieDbBackend.Service;

namespace TheMovieDbBackend.Service
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly TheMovieDbContext _context = new();
        // repository getters
        #region RepositoryGetter

        IAuthRepository authRepository;
        IMovieRepository movieRepository;
        IBaseRepository<MovieDb> movieDbRepository;
        #endregion

        #region RepositorySetter
        public IAuthRepository AuthRepository
        {
            get
            {
                if (authRepository == null)
                {
                    this.authRepository = new AuthRepository(_context);
                }
                return this.authRepository;
            }
        }

        public IMovieRepository MovieRepository
        {
            get
            {
                if (movieRepository == null)
                {
                    this.movieRepository = new MovieRepository(_context);
                }
                return this.movieRepository;
            }
        }

        public IBaseRepository<MovieDb> MovieDbRepository
        {
            get
            {
                if (movieDbRepository == null)
                {
                    this.movieDbRepository = new BaseRepository<MovieDb>(_context);
                }
                return this.movieDbRepository;
            }
        }
        #endregion

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

    }
}
