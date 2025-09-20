using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.Models
{
    public class Student : BaseEntity
    {

        public Student()
        {
            Enrollments = new List<Enrollment>();
        }
        private string _firstname;

		public string Firstname
		{
			get { return _firstname; }
			set { _firstname = value; }
		}

		private string _lastname;

		public string Lastname
		{
			get { return _lastname; }
			set { _lastname = value; }
		}

		public string Fullname => _firstname + " " + _lastname;

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
