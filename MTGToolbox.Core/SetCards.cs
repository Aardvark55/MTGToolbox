using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTGToolbox.Core
{
    public class SetCards
    {
        public SetCards(Set set, Card card, string rarity, string imageFile)
        {
            SetId = set.Id;
            CardId = card.Id;
            Rarity = rarity;
            ImageFile = imageFile;
        }

        public SetCards() { }

        public int SetId { get; set; }

        public int CardId { get; set; }

        public string Rarity { get; set; }

        public string ImageFile { get; set; }

        public virtual Set Set { get; set; }
        public virtual Card Card { get; set; }
    }
}
