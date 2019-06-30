using System;
using System.Collections.Generic;
using System.Text;

namespace MTGToolbox.Core
{
    public class Set : ISet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<SetCards> SetCards { get; } = new List<SetCards>();
    }
}
