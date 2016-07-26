namespace IEEETalks.Host.API.Models
{
    public class PagedRequest
    {
        public virtual int PageSize => 20;
        public int CurrentPage { get; set; }

        public bool HasMore(int totalRecords) => PageSize*(CurrentPage + 1) < totalRecords;
    }
}
