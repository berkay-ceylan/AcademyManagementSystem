using _51_entity_lab2.DTOs;
using _51_entity_lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.Contracts
{
    public interface ICourseRepo : IGenericRepo<Course>
    {
        ICollection<Course> GetByCategoryId(int id);
        ICollection<Course> FindByTitle(string title);
        ICollection<Course> GetByInstructorId(int id);
        ICollection<CourseDetailDTO> GetDetails();
        CourseDetailDTO GetDetailById(int id);
    }
}
