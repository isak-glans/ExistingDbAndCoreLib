using System;
using System.Collections.Generic;

namespace ExistingDbAndCoreLib.DAL
{
    public partial class Schools
    {
        public Schools()
        {
            Students = new HashSet<Students>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}
