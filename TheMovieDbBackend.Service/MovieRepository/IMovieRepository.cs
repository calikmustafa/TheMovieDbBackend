using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovieDbBackend.Core.Entity;
using TheMovieDbBackend.Service.BaseRepository;

namespace TheMovieDbBackend.Service
{
    public interface IMovieRepository:IBaseRepository<Movie>
    {
        string GetAllMovieByPageSizeAndMovieId(int movieId,int pageSize);
        string GetAllMovieDetailByMovieId(int movieId);
    }
}
