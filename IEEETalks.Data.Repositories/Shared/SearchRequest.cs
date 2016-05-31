using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEEETalks.Data.Repositories.Shared
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
