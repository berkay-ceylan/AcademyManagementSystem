using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.Models
{
    public class Course : BaseEntity
    {
        public Course()
        {
            Enrollments = new List<Enrollment>();
        }
        public string Title { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int InstructorId  { get; set; }
        public virtual Instructor Instructor { get; set; }

        public virtual CourseDetail Coursedetails { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
