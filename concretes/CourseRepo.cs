using _51_entity_lab2.Contexts;
using _51_entity_lab2.Contracts;
using _51_entity_lab2.DTOs;
using _51_entity_lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.concretes
{
    public class CourseRepo : GenericRepo<Course>, ICourseRepo
    {
        private readonly AppDbContext _context;
        public CourseRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<Course> FindByTitle(string title)
        {
            return _context.Courses.Where(c => c.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public ICollection<Course> GetByCategoryId(int id)
        {
            return _context.Courses.Where(c => c.CategoryId == id).ToList();
        }

        public ICollection<Course> GetByInstructorId(int id)
        {
            return _context.Courses.Where(c => c.InstructorId == id).ToList();
        }

        public CourseDetailDTO GetDetailById(int id)
        {
            return GetDetails().FirstOrDefault(c => c.Id == id);
        }

        public ICollection<CourseDetailDTO> GetDetails()
        {
            return _context.Courses.Join(
                _context.CourseDetails,
                c => c.Id,
                cd => cd.Id,
                (c, cd) => new CourseDetailDTO { Id = c.Id, CategoryId = c.CategoryId, InstructorId = c.InstructorId, Title = c.Title, Description = cd.Description, Duration = cd.Duration }).ToList();
        }
    }
}
