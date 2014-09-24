using System.Collections;
using System.Collections.Generic;

namespace PerfectMedia
{
    public class PagedList<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _list;
        public bool HasMoreResults { get; private set; }
        public int Count { get; private set; }

        public PagedList(IEnumerable<T> list, int page, int pageSize, int count)
        {
            _list = list;
            HasMoreResults = CalculateHasMoreResult(page, pageSize, count);
            Count = count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static bool CalculateHasMoreResult(int page, int pageSize, int count)
        {
            return (page + 1) * pageSize >= count;
        }
    }
}
