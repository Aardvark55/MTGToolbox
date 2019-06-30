using System;
using System.Collections.Generic;
using System.Text;

namespace MTGToolbox.Core
{
    public interface IDeckList
    {
        int DeckId { get; set; }
        int CardId { get; set; }
        Int16 Quantity { get; set; }

        Deck Deck { get; set; }
        Card Card { get; set; }
    }
}
