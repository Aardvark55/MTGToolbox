using System;
using System.Collections.Generic;
using MTGToolbox.Core;

namespace MTGToolbox.Repository
{
    public interface ISetRepository
    {
        IEnumerable<Set> GetSets();

        Set GetSetByCode(string setCode);

        void AddSet(Set set);
        void Save();
    }
}
