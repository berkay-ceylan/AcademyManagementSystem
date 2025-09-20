using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.Models
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Courses = new List<Course>();
        }
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; } 


    }
}
