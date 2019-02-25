using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextParserServer.Entity
{
    public class Sentence
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public string Text { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfInsert { get; set; }

        public virtual Word Word { get; set; }
    }
}
