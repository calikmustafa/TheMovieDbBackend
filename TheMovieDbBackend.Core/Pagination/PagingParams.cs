using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovieDbBackend.Core.Pagination
{

    public class PagingParams
    {
        private const int MaxPageSize = 100;

        public int PageNumber { get; set; } = 1;

        public int Offset { get; set; } = 0;

        public int pageSizex = 10;

        public string? Searchtext { get; set; }

        public string Orderby { get; set; } = "Id";

        public bool OrderbyAsc { get; set; } = true;



        public int PageSize
        {
            get { return pageSizex; }
            set { pageSizex = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }
}
