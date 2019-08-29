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

        public virtual ICollection<IDeckList> DeckList { get; } = new List<IDeckList>();
        public virtual ICollection<ISetCards> SetCards { get; } = new List<ISetCards>();
    }
}
