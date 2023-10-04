using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnectivity.TechService;

namespace DataConnectivity.Domain
{
    internal class BCS
    {
        public bool EnrollStudent(TestStudent acceptedStudent, string programCode)
        {
            TestStudents studentManager = new TestStudents();
            bool isSuccess = studentManager.AddStudent(acceptedStudent, programCode);

            return isSuccess ? true : false;
          
        }
    }
}
