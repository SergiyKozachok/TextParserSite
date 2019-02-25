using Microsoft.EntityFrameworkCore;
using TextParserServer.Entity;

namespace TextParserServer
{
    public class ApplicationContext : DbContext
    {
        
        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Word> Words { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                    : base(options)
        { }

    }
}
