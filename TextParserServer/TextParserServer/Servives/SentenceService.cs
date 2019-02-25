using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextParserServer.Entity;
using TextParserServer.Helpers;
using TextParserServer.Interfaces;
using TextParserServer.Models;

namespace TextParserServer.Servives
{
    public class SentenceService : ISentenceService
    {
        private readonly ApplicationContext _context;

        public SentenceService(ApplicationContext context)
        {
            _context = context;
        }

        public bool AddSentencesToDb(GetSentencesModel data)
        {            
            try
            {
                var word = new Word();
                word.WordName = data.Word;
                _context.Words.Add(word);
                _context.SaveChanges();

                var newList = Reverse(data.Sentences);

                for (var i = 0; i < newList.Count; i++)
                {
                    var sentence = new Sentence();
                    sentence.Text = newList[i];
                    sentence.WordId = word.Id;
                    sentence.DateOfInsert = DateTime.Now;
                    sentence.Quantity = data.Quantity[i];

                    _context.Sentences.Add(sentence);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<string> Reverse(List<string> s)
        {
            var newList = new List<string>();
            for (int i = 0; i < s.Count; i++)
            {
                char[] charArray = s[i].ToCharArray();
                Array.Reverse(charArray);
                newList.Add(new string(charArray));
            }
            return newList;
        }

        public PageModel<IEnumerable<SentencesArrayModel>> GetSentences(PageParameters parameters)
        {
            var sentences = _context.Sentences
                .OrderByDescending(s => s.DateOfInsert)
                .Include(s => s.Word)
                .Select(s => new SentencesArrayModel
                {
                    Text = s.Text,
                    Word = s.Word.WordName,
                    DateOfAdded = s.DateOfInsert,
                    Quantity = s.Quantity,
                });


            var sentencesAmount = sentences.Count();
            var sentencesResult = PaginationHelper<SentencesArrayModel>
                .GetPageValues(sentences, parameters.PageCount, parameters.Page)
                .ToList();

            return new PageModel<IEnumerable<SentencesArrayModel>>()
            { EntityAmount = sentencesAmount, Entities = sentencesResult };
        }
    }
}
