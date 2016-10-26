using System.Collections.Generic;
using System.Linq;
using Framework.Contract;

namespace Framework.Extention
{
    public static class PageLinqExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> allItems, int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
                pageIndex = 1;
            var itemIndex = (pageIndex - 1) * pageSize;
            var pageOfItems = allItems.Skip(itemIndex).Take(pageSize).AsQueryable();
            return new PagedList<T>(pageOfItems, pageIndex, pageSize,allItems.Count());
        }

        public static PagedList<T> ToPagedList<T>(this IList<T> allItems, int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
                pageIndex = 1;
            var itemIndex = (pageIndex - 1) * pageSize;
            var pageOfItems = allItems.Skip(itemIndex).Take(pageSize).ToList();
            var totalItemCount = allItems.Count();
            return new PagedList<T>(pageOfItems, pageIndex, pageSize, totalItemCount);
        }

        public static PagedList<T> ToPagedList<T>(this IList<T> items, int pageIndex, int pageSize, int totalCount)
        {
            return  new PagedList<T>(items,pageIndex,pageSize,totalCount);
        } 
    }
}
