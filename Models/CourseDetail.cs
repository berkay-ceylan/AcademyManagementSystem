using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.Models
{
    public class CourseDetail : BaseEntity
    {
        public string Description { get; set; }
        public int? Duration { get; set; }

        public virtual Course Course { get; set; }

    }
}
