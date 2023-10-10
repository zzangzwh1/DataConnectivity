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
        public bool EnrollStudent(Students acceptedStudent, string programCode)
        {
            StudentManager students = new StudentManager();
            bool isSuccess = students.AddStudent(acceptedStudent, programCode);

            return isSuccess;

        }
        public bool CreateProgram(string programCode, string description)
        {
            ProgramManager programs = new ProgramManager();

            bool isSuccess = programs.AddProgram(programCode, description);

            return isSuccess;
        }
        public Programs FindStudent(string studentId)
        {
            StudentManager students = new StudentManager();
            Programs enrolledStudent = students.GetStudent(studentId);

            return enrolledStudent;
        }
        public bool ModifyStudent(Students student)
        {
            StudentManager enrolledStudent = new StudentManager();
            bool isModify = enrolledStudent.UpdateStudent(student);

            return isModify;
        }
        public bool RemoveStudent(string removeStudentId)
        {
            StudentManager removeStudent = new StudentManager();
            bool isRemoved = removeStudent.DeleteStudent(removeStudentId);
            return isRemoved;
        }
        public List<Programs> FindProgram(string findProgramCode)
        {
            ProgramManager findProgram = new ProgramManager();
            List<Programs> activeProgram =  findProgram.GetProgram(findProgramCode);
            return activeProgram;
        }

    }
}
