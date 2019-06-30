using System;
using System.Collections.Generic;
using MTGToolbox.Core;

namespace MTGToolbox.Repository
{
    public interface IDeckRepository
    {
        IEnumerable<IDeck> GetDecks();
        IDeck GetDeckById(int id);
        IDeck GetDeckByName(string deckName);

    }
}
