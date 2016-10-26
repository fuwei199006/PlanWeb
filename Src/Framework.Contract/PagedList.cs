using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Contract
{
    public class PagedList<T>:List<T>,IPagedList
    {
        public int CurrentPageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }

        public PagedList(IList<T> items, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            CurrentPageIndex = pageIndex;
            TotalItemCount = items.Count;
            this.AddRange(items.Skip(pageSize*(pageIndex - 1)).Take(pageSize));
        }
        //todo：需要修改
        public PagedList(IQueryable<T> items, int pageIndex, int pageSize,int totalCount)
        {
            PageSize = pageSize;
            CurrentPageIndex = pageIndex;
            TotalItemCount = totalCount;
            this.AddRange(items);
        }
        public PagedList(IList<T> items, int pageIndex, int pageSize,int totalCount)
        {
            PageSize = pageSize;
            CurrentPageIndex = pageIndex;
            TotalItemCount = totalCount;
            this.AddRange(items.Skip(pageSize * (pageIndex - 1)).Take(pageSize));
        }

        public int ExtraCount { get; set; }
        public int TotalPageCount { get { return (int)Math.Ceiling(TotalItemCount / (double)PageSize); } }
        public int StartRecordIndex { get { return (CurrentPageIndex - 1) * PageSize + 1; } }
        public int EndRecordIndex { get { return TotalItemCount > CurrentPageIndex * PageSize ? CurrentPageIndex * PageSize : TotalItemCount; } }
    }
}