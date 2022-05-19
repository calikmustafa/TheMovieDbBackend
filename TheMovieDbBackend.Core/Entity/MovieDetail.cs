using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovieDbBackend.Core.Entity
{
    public class MovieDetail
    {
        public bool Adult { get; set; }
        public string? Backdrop_Path { get; set; }
        //public  Object? Belongs_To_Collection { get; set; }
        public int Budget { get; set; }
        public Genres[] Genres { get; set; }
        public string? HomePage { get; set; }
        public int Id { get; set; }
        public string? Imdb_Id { get; set; }
        public string Original_Language { get; set; }
        public string Original_Title { get; set; }
        public string? Overview { get; set; }
        public decimal Popularity { get; set; }
        public string? Poster_Path { get; set; }
        
        public ProductComponies[] Production_Companies { get; set; }
        public ProductionCountries[] Production_Countries { get; set; }
        public string Release_Date { get; set; }
        public int Revenue { get; set; }
        public int? RunTime { get; set; }
        public SpokenLanguages[] Spoken_Languages { get; set; }
        public string Status { get; set; }
        public string? Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public decimal Vote_Average { get; set; }
        public int Vote_Count { get; set; }

    }
}
