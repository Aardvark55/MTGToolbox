using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTGToolbox.Core
{
    public class DeckList
    {
        public int DeckId { get; set; }

        public int CardId { get; set; }

        public int Quantity { get; set; }

        public virtual Deck Deck { get; set; }
        public virtual Card Card { get; set; }
    }
}
