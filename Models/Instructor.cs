using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.Models
{
    public class Instructor : BaseEntity
    {
        public Instructor()
        {
            courses = new List<Course>();
        }
        public string Name { get; set; }

        public virtual ICollection<Course> courses  { get; set; }


    }
}
