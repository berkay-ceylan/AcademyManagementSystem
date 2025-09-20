using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.DTOs
{
    public class CourseDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int InstructorId { get; set; }
        public string Description { get; set; }
        public int? Duration { get; set; }
    }
}
