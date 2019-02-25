using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextParserServer.Models
{
    public class GetSentencesModel
    {
        public string Word { get; set; }
        public List<string> Sentences { get; set; }
        public List<int> Quantity { get; set; }
    }
}
