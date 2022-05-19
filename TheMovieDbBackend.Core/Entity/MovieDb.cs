using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovieDbBackend.Core.Entity
{
    public class MovieDb
    {
        public int Id { get; set; }
        public string? Page { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
        public decimal? Rate { get; set; }
        public string? Name { get; set; }
        public decimal? Views  { get; set; }
        public DateTime? MovieRd { get; set; }
        public bool? MovieCancel { get; set; }



    }
}
