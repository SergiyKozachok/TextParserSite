using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextParserServer.Models
{
    public class PageParameters
    {
        private const int DEFAULT_PAGE = 1;
        private const int MAX_PAGE_COUNT = 15;
        public int Page { get; set; } = DEFAULT_PAGE;
        private int _pageCount = MAX_PAGE_COUNT;
        public int PageCount
        {
            get => _pageCount;
            set => _pageCount = (value > MAX_PAGE_COUNT) ? MAX_PAGE_COUNT : value;
        }
    }
}
