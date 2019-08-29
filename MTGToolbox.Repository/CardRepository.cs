using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTGToolbox.Core;

namespace MTGToolbox.Repository
{
    public class CardRepository : ICardRepository, IDisposable
    {
        private MTGToolboxContext context;
        private bool disposed = false;

        public CardRepository(MTGToolboxContext context)
        {
            this.context = context;
        }

        public IEnumerable<ICard> GetCards()
        {
            return context.Cards.ToList();
        }

        public ICard GetCardById(int id)
        {
            return context.Cards.Find(id);
        }

        public ICard GetCardByName(string name)
        {
            return context.Cards.Find(name);
        }

        public void AddCard(ICard card)
        {
            if (!(context.Cards.Any(c => c.Name == card.Name)))
            {
                context.Cards.Add((Card)card);
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
