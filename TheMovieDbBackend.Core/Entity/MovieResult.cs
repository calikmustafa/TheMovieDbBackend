using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovieDbBackend.Core.Entity
{
    public class MovieResult
    {
        public string Description { get; set; }
        public int FavoriteCount { get; set; }
        public int Id { get; set; }
        public int ItemCount { get; set; }
        public string Iso6391 { get; set; }
        public string ListType { get; set; }
        public string Name { get; set; }
        public string? PosterPath { get; set; }
        
    }
}
