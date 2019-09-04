using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGToolbox.Core
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFile { get; set; }

        public ICollection<DeckList> DeckList { get; set;  }
        public ICollection<SetCards> SetCards { get; set; }
    }
}
