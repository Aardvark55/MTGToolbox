using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTGToolbox.Core
{
    public class DeckCard : IDeckCard
    {
        [ForeignKey("Deck")]
        public int DeckId { get; set; }

        [ForeignKey("Card")]
        public int CardId { get; set; }

        public Int16 Quantity { get; set; }

        public virtual Deck deck { get; set; }
        public virtual Card card { get; set; }
    }
}
