using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextParserServer.Entity
{
    public class Word
    {
        public int Id { get; set; }
        public string WordName { get; set; }

        public virtual ICollection<Sentence> Sentences { get; set; }
    }
}
