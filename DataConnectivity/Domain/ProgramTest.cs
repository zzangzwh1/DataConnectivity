
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataConnectivity.Domain
{
    internal class ProgramTest
    {
        /*  private string _programCode = "";
          private string _description = "";*/
        // private readonly TestStudent _students;

        public string ProgramCode { set; get; } = string.Empty;
        public string Description { set; get; } = string.Empty;
     
        private readonly TestStudent _enrollStudents;
        public TestStudent EnrollStudents
        {
            get
            {
                return _enrollStudents;
            }
        }
        public ProgramTest(TestStudent students)
        {
            this._enrollStudents = students;
        }
        public ProgramTest()
        {

        }


    }
}
