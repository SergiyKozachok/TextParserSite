using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextParserServer.Models
{
    public class SentencesArrayModel
    {
        public string Word { get; set; }
        public string Text { get; set; }
        public DateTime DateOfAdded { get; set; }
        public int Quantity { get; set; }
    }
}
