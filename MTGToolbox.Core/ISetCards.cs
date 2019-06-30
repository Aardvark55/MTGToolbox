using System;
using System.Collections.Generic;
using System.Text;

namespace MTGToolbox.Core
{
    public interface ISetCards
    {
        int SetId { get; set; }
        int CardId { get; set; }
        string Rarity { get; set; }

        Set Set { get; set; }
        Card Card { get; set; }
    }
}
