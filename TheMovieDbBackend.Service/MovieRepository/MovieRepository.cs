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
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(TheMovieDbContext context) : base(context)
        {
        }

        public string GetAllMovieDetailByMovieId(int movieId)
        {
        //https://api.themoviedb.org/3/movie/500?api_key=f8bc783ea9e0ec83cda9a27d22f0a958
            var apiKey = "f8bc783ea9e0ec83cda9a27d22f0a958";
            var baseUrl = "https://api.themoviedb.org/3/";
            var getDetailMovieUrl = baseUrl + "movie/" + movieId + "?api_key=" + apiKey;
            return getDetailMovieUrl;
        }

        public string GetAllMovieByPageSizeAndMovieId(int movieId,int pageSize)
        {
            var apiKey = "f8bc783ea9e0ec83cda9a27d22f0a958";
            var baseUrl = "https://api.themoviedb.org/3/";

            var getListMovie = baseUrl+"movie/"+movieId+"/"+ "lists?api_key=" + apiKey+ "&page="+pageSize;

            return getListMovie;
        

        }
    }
}
