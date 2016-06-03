namespace IEEETalks.Common
{
    public class SearchRequest
    {
        public int Offset { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

        public SearchRequest()
        {
            // Defaults
            PageSize = 10;
        }
    }
}
