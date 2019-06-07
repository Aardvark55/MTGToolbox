﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MTGToolbox.Core
{
    public interface IDeck
    {
        int Id { get; set; }
        string Name { get; set; }

        ICollection<DeckCard> DeckCards { get; set; }
    }
}