using System;
using System.Collections.Generic;
using MTGToolbox.Core;

namespace MTGToolbox.Repository
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetCards();
        Card GetCardById(int id);
        Card GetCardByName(string cardName);
    }
}
