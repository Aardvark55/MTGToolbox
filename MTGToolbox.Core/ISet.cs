using System;
using System.Collections.Generic;
using System.Text;

namespace MTGToolbox.Core
{
    public interface ISet
    {
        int Id { get; set; }
        string Name { get; set; }
        string Code { get; set; }

        ICollection<ISetCards> SetCards { get; }
    }
}
