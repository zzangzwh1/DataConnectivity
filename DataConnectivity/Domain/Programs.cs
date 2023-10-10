
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataConnectivity.Domain
{
    internal class Programs
    {
 

        public string? ProgramCode { set; get; } = string.Empty;
        public string? Description { set; get; } = string.Empty;
     
        private readonly Students _enrollStudents;
        public Students EnrollStudents
        {
            get
            {
                return _enrollStudents;
            }
        }
        public Programs(Students students)
        {
            this._enrollStudents = students;
        }
        public Programs()
        {

        }


    }
}
