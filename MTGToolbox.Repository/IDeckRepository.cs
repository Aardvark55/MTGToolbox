using System;
using System.Collections.Generic;
using MTGToolbox.Core;

namespace MTGToolbox.Repository
{
    public interface IDeckRepository
    {
        IEnumerable<Deck> GetDecks();
        Deck GetDeckById(int id);
        Deck GetDeckByName(string deckName);

    }
}
