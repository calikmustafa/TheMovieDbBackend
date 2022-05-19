
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovieDbBackend.Core.Entity
{
    public class Movie
    {
        public int Id { get; set; }
        public int Page { get; set; }
        
      
        public MovieResult[]? Results { get; set; }
        
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }


    }
}
