using System;
using System.Collections.Generic;
using MTGToolbox.Core;

namespace MTGToolbox.Repository
{
    public interface ICardRepository
    {
        IEnumerable<ICard> GetCards();
        ICard GetCardById(int id);
        ICard GetCardByName(string cardName);

        void AddCard(ICard card);

        void Save();
    }
}
