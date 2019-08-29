using System;
using System.Collections.Generic;
using System.Text;

namespace MTGToolbox.Core
{
    public interface ICard
    {
        int Id { get; set; }
        string Name { get; set; }
        string ImageFile { get; set; }

        ICollection<IDeckList> DeckList { get; }
        ICollection<ISetCards> SetCards { get; }
    }
}
