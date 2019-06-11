using System;
using System.Collections.Generic;
using System.Linq;
using MTGToolbox.Core;
using Microsoft.EntityFrameworkCore;

namespace MTGToolbox.Repository
{
    public class DeckRepository : IDeckRepository, IDisposable
    {
        private MTGToolboxContext context;
        private bool disposed = false;

        public DeckRepository(MTGToolboxContext context)
        {
            this.context = context;
        }

        public IEnumerable<Deck> GetDecks()
        {
            return context.Decks.ToList();
        }

        public Deck GetDeckById(int id)
        {
            //Deck deck = context.Decks.Find(id);

            //context.Entry(deck).Reference(d => d.DeckCards).Load();

            Deck deck = context.Decks.Include(d => d.DeckCards).ThenInclude(dc => dc.Card);

            return deck;
        }

        public Deck GetDeckByName(string name)
        {
            return context.Decks.Find(name);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
