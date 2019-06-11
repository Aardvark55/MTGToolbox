using MTGToolbox.Core;
using Microsoft.EntityFrameworkCore;

namespace MTGToolbox.Repository
{
    public class MTGToolboxContext : DbContext
    {
        public MTGToolboxContext(DbContextOptions<MTGToolboxContext> options) : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<DeckCard> DeckCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeckCard>().HasKey(dc => new { dc.DeckId, dc.CardId });
            modelBuilder.Entity<DeckCard>().HasOne(dc => dc.card).WithMany(d => d.DeckCards).HasForeignKey(dc => dc.CardId);
            modelBuilder.Entity<DeckCard>().HasOne(dc => dc.deck).WithMany(d => d.DeckCards).HasForeignKey(dc => dc.DeckId);
        }
    }
}
