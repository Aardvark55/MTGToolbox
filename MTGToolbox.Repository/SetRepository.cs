using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTGToolbox.Core;

namespace MTGToolbox.Repository
{
    public class SetRepository : ISetRepository, IDisposable
    {
        private MTGToolboxContext context;
        private bool disposed = false;

        public SetRepository(MTGToolboxContext context)
        {
            this.context = context;
        }

        public IEnumerable<ISet> GetSets()
        {
            return context.Sets.ToList();
        }

        public void AddSet(ISet set)
        {
            if (!(context.Sets.Any(s => s.Code == set.Code)))
            {
                context.Sets.Add(set);
            }
        }

        public ISet GetSetByCode(string setCode)
        {
            return context.Sets.Find(setCode);
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
