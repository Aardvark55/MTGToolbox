using System;
using System.Collections.Generic;
using System.Text;

namespace MTGToolbox.Core
{
    public interface IDeckCard
    {
        int Id { get; set; }
        int DeckId { get; set; }
        int CardId { get; set; }
        int Quantity { get; set; }

        Deck deck { get; set; }
        Card card { get; set; }
    }
}
