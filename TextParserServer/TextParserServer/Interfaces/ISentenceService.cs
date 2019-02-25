using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextParserServer.Models;

namespace TextParserServer.Interfaces
{
    public interface ISentenceService
    {
        PageModel<IEnumerable<SentencesArrayModel>> GetSentences(PageParameters parameters);
        bool AddSentencesToDb(GetSentencesModel data);
    }
}
