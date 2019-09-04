using System;
using System.Collections.Generic;
using System.Text;

namespace MTGToolbox.Core
{
    public class Set
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<SetCards> SetCards { get; set; }
    }
}
