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
    public class EnrollmentRepo : IEnrollmentRepo
    {
        private readonly AppDbContext _context;

        public EnrollmentRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Enrollment enrollment)
        {
            _context.Add(enrollment);
        }

        public void Delete(Enrollment enrollment)
        {
            _context.Remove(enrollment);
        }

        public ICollection<EnrollmentDetailDTO> GetAll()
        {
            return _context.Enrollments.Join(_context.Student, e => e.StudentId, s => s.Id, (e, s) => new { en = e, st = s })
            .Join(
                _context.Courses,
                e => e.en.CourseId,
                c => c.Id,
                (e, c) => new EnrollmentDetailDTO
                {
                    StudentId = e.en.StudentId,
                    CourseId = c.Id,
                    StudentName = e.st.Fullname,
                    CourseName = c.Title,
                    EnrolledOn = e.en.EnrolledOn,
                    Price = e.en.Price,



                }


            ).ToList();
        }

        public ICollection<EnrollmentDetailDTO> GetByCourseId(int courseId)
        {
           return GetAll().Where(x=> x.CourseId == courseId).ToList();
        }

        public ICollection<EnrollmentDetailDTO> GetByStudentId(int studentId)
        {
            return GetAll().Where(x=> x.StudentId == studentId).ToList();
        }

        public bool Save()
        {
           return _context.SaveChanges() > 0 ? true : false;
        }

        public void Update(Enrollment enrollment)
        {
            _context.Update(enrollment);
        }
    }
}
