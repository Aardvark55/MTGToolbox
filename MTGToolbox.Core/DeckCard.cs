using System;
using System.Collections.Generic;
using System.Text;

namespace MTGToolbox.Core
{
    public class DeckCard : IDeckCard
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public int CardId { get; set; }
        public int Quantity { get; set; }

        public virtual Deck deck { get; set; }
        public virtual Card card { get; set; }
    }
}
