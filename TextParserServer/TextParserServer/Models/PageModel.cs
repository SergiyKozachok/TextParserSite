using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextParserServer.Models
{
    public class PageModel<T> where T : IEnumerable
    {
        public int EntityAmount { get; set; }
        public T Entities { get; set; }
    }
}
