using System;
using System.Collections.Generic;
using MTGToolbox.Core;

namespace MTGToolbox.Repository
{
    public interface ISetRepository
    {
        IEnumerable<ISet> GetSets();

        ISet GetSetByCode(string setCode);

        void AddSet(ISet set);
        void Save();
    }
}
