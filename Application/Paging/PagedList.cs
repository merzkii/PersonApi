using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Paging
{

    public class PagedList<T>
    {
        public PagedList(List<T> list, int totalCount)
        {
            List = list;
            TotalCount = totalCount;
        }
        public List<T> List { get; set; }
        public int TotalCount { get; set; }
    }
}
