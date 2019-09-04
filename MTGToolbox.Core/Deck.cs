using System;
using System.Collections.Generic;
using System.Text;

namespace MTGToolbox.Core
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DeckList> DeckList { get; } = new List<DeckList>();
    }
}
