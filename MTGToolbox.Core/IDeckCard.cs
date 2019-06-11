using System;
using System.Collections.Generic;
using System.Text;

namespace MTGToolbox.Core
{
    public interface IDeckCard
    {
        int DeckId { get; set; }
        int CardId { get; set; }
        Int16 Quantity { get; set; }

        Deck deck { get; set; }
        Card card { get; set; }
    }
}
