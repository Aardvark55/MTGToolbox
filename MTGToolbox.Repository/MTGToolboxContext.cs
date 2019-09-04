using MTGToolbox.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace MTGToolbox.Repository
{
    public class MTGToolboxContext : DbContext
    {
        public MTGToolboxContext(DbContextOptions<MTGToolboxContext> options) : base(options)
        {

        }

        public static readonly LoggerFactory loggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<DeckList> DeckLists { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<SetCards> SetCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeckList>().HasKey(dl => new { dl.DeckId, dl.CardId });
            modelBuilder.Entity<DeckList>().HasOne(dl => dl.Card).WithMany(c => c.DeckList).HasForeignKey(dl => dl.CardId);
            modelBuilder.Entity<DeckList>().HasOne(dl => dl.Deck).WithMany(d => d.DeckList).HasForeignKey(dl => dl.DeckId);

            modelBuilder.Entity<SetCards>().HasKey(sc => new { sc.SetId, sc.CardId });
            modelBuilder.Entity<SetCards>().HasOne(sc => sc.Card).WithMany(s => s.SetCards).HasForeignKey(sc => sc.CardId);
            modelBuilder.Entity<SetCards>().HasOne(sc => sc.Set).WithMany(s => s.SetCards).HasForeignKey(sc => sc.SetId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}
