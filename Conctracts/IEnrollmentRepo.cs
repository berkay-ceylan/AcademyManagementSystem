using _51_entity_lab2.DTOs;
using _51_entity_lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.Contracts
{
    public interface IEnrollmentRepo
    {
        void Add(Enrollment enrollment);
        void Update(Enrollment enrollment);
        void Delete(Enrollment enrollment);
        ICollection<EnrollmentDetailDTO> GetAll();
        ICollection<EnrollmentDetailDTO> GetByStudentId(int studentId);
        ICollection<EnrollmentDetailDTO> GetByCourseId(int courseId);
        bool Save();
    }
}
