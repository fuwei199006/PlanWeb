using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Contract;

namespace Framework.Extention
{
    public static class PageLinqExtensions
    {
        public static PagedList<T> ToPagedList<T>
            (
                this IQueryable<T> allItems,
                int pageIndex,
                int pageSize
            )
        {
            if (pageIndex < 1)
                pageIndex = 1;
            var itemIndex = (pageIndex - 1) * pageSize;
            var pageOfItems = allItems.Skip(itemIndex).Take(pageSize).ToList();
            var totalItemCount = allItems.Count();
            return new PagedList<T>(pageOfItems, pageIndex, pageSize, totalItemCount);
        }
    }
}
