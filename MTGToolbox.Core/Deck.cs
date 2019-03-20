using System;
using System.Collections.Generic;
using System.Text;

namespace MTGToolbox.Core
{
    public class Deck : IDeck
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DeckCard> DeckCards { get; set; }
    }
}
