using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.DTOs
{
    public class EnrollmentDetailDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime? EnrolledOn { get; set; }
        public decimal? Price { get; set; }
    }
}
