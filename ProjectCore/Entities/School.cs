using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.Entities
{
    public class School
    {
        public School()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
