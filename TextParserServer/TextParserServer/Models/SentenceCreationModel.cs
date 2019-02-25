using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextParserServer.Models
{
    public class SentenceCreationModel
    {
        public List<string> sentences { get; set; }
        public List<int> quantity { get; set; }
    }
}
