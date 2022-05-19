using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovieDbBackend.Core.Entity
{
    public class ProductComponies
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string? Logo_Path { get; set; }
        public string Origin_Country { get; set; }
    }
}
