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

        Deck Deck { get; set; }
        Card Card { get; set; }
    }
}
