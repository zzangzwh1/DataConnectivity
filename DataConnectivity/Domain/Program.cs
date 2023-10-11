
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataConnectivity.Domain
{
    internal class Program
    {
 

        public string? ProgramCode { set; get; } = string.Empty;
        public string? Description { set; get; } = string.Empty;

        private readonly List<Student> _EnrolledStudents;
        public List<Student> EnrolledStudents
        {
            get
            {
                return _EnrolledStudents;
            }
        }

        public Program()
        {
            _EnrolledStudents = new ();
        }


    }
}
