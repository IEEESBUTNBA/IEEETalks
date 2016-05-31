using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEEETalks.Data.Repositories.Shared
{
    public class ListResponse<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecords { get; set; }
    }
}
