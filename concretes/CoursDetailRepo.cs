using _51_entity_lab2.Contexts;
using _51_entity_lab2.Contracts;
using _51_entity_lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.concretes
{
    public class CoursDetailRepo : GenericRepo<CourseDetail>, ICourseDetailRepo
    {
        public CoursDetailRepo(AppDbContext context) : base(context)
        {
        }
    }
}