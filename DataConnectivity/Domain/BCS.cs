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

            return isSuccess;
          
        }
        public bool CreateProgram(string programCode, string description)
        {
            TestProgram programManager = new TestProgram();

            bool isSuccess = programManager.AddProgram(programCode, description);

            return isSuccess;
        }
        public string FindStudent(string studentId)
        {
            TestStudents studentManager = new TestStudents();
            string enrolledStudent = studentManager.GetStudent(studentId);

            return enrolledStudent;
        }
        public bool ModifyStudent(TestStudent student)
        {
            TestStudents enrolledStudent = new TestStudents();
            bool isModify = enrolledStudent.UpdateStudent(student);

            return isModify;
        }
        public bool RemoveStudent(string removeStudentId)
        {
            TestStudents removeStudent = new TestStudents();
            bool isRemoved = removeStudent.DeleteStudent(removeStudentId);
            return isRemoved;
        }

    }
}
