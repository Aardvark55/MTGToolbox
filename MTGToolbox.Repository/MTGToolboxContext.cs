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

        public DbSet<ICard> Cards { get; set; }
        public DbSet<IDeck> Decks { get; set; }
        public DbSet<IDeckList> DeckLists { get; set; }
        public DbSet<ISet> Sets { get; set; }
        public DbSet<ISetCards> SetLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeckList>().HasKey(dl => new { dl.DeckId, dl.CardId });
            modelBuilder.Entity<DeckList>().HasOne(dl => dl.Card).WithMany(d => d.DeckList).HasForeignKey(dl => dl.CardId);
            modelBuilder.Entity<DeckList>().HasOne(dl => dl.Deck).WithMany(d => d.DeckList).HasForeignKey(dl => dl.DeckId);

            modelBuilder.Entity<SetCards>().HasKey(sl => new { sl.SetId, sl.CardId });
            modelBuilder.Entity<SetCards>().HasOne(sl => sl.Card).WithMany(s => s.SetCards).HasForeignKey(sl => sl.CardId);
            modelBuilder.Entity<SetCards>().HasOne(sl => sl.Set).WithMany(s => s.SetCards).HasForeignKey(sl => sl.SetId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}
