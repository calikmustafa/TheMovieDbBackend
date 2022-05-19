namespace TheMovieDbBackend.Core.Pagination
{
    public class PaginationHeader
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public string SearchText { get; set; }
        public string OrderBy { get; set; }
        public bool OrderbyAsc { get; set; }




        public PaginationHeader(int pageNumner, int pageSize, int totalItems, int totalPages, string searchText, string orderby, bool orderbyasc)
        {
            this.PageNumber = pageNumner;
            this.PageSize = pageSize;
            this.TotalItems = totalItems;
            this.TotalPages = totalPages;
            this.SearchText = searchText;
            this.OrderBy = orderby;
            this.OrderbyAsc = orderbyasc;

        }
    }
}
