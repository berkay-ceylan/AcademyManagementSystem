using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.Models
{
    public class Enrollment
    {

        public int StudentId { get; set; }

        public virtual Student Student  { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public DateTime? EnrolledOn { get; set; }

        public decimal? Price { get; set; }


    }
}
