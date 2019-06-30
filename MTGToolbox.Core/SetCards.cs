using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTGToolbox.Core
{
    public class SetCards : ISetCards
    {
        public SetCards(ISet set, ICard card, string rarity)
        {
            SetId = set.Id;
            CardId = card.Id;
            Rarity = rarity;
        }

        [ForeignKey("Set")]
        public int SetId { get; set; }

        [ForeignKey("Card")]
        public int CardId { get; set; }

        public string Rarity { get; set; }

        public virtual Set Set { get; set; }
        public virtual Card Card { get; set; }
    }
}
