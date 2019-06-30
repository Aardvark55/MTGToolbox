using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MTGToolbox.Repository
{
    class UnitOfWork : IDisposable
    {
        private MTGToolboxContext context;
        private ICardRepository cardRepository;
        private IDeckRepository deckRepository;
        private bool disposed = false;

        public UnitOfWork(DbContextOptions<MTGToolboxContext> options)
        {
            context = new MTGToolboxContext(options);
        }

        public ICardRepository CardRepository
        {
            get
            {
                if (this.cardRepository == null)
                {
                    this.cardRepository = new CardRepository(context);
                }
                return cardRepository;
            }
        }

        public IDeckRepository DeckRepository
        {
            get
            {
                if (this.deckRepository == null)
                {
                    this.deckRepository = new DeckRepository(context);
                }
                return deckRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
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
