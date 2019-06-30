﻿using System;
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

        public IEnumerable<IDeck> GetDecks()
        {
            return context.Decks.ToList();
        }

        public IDeck GetDeckById(int id)
        {
            IDeck deck = context.Decks.Include(d => d.DeckList).ThenInclude(dc => dc.Card).Single();

            return deck;
        }

        public IDeck GetDeckByName(string name)
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
