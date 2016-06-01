using System.Collections.Generic;

namespace IEEETalks.Common
{
    public class ListResponse<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecords { get; set; }
    }
}
