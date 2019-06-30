using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGToolbox.Core
{
    public class Card : ICard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFile { get; set; }

        public virtual ICollection<DeckList> DeckList { get; } = new List<DeckList>();
        public virtual ICollection<SetCards> SetCards { get; } = new List<SetCards>();
    }
}
