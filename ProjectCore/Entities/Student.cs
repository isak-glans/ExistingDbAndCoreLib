using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public int? SchoolId { get; set; }

        public virtual School School { get; set; }
    }
}
