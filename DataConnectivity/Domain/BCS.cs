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
        public bool EnrollStudent(Student acceptedStudent, string programCode)
        {
            Students students = new Students();
            bool success = students.AddStudent(acceptedStudent, programCode);

            return success;

        }
        public bool CreateProgram(string programCode, string description)
        {
            Programs programs = new Programs();

            bool success = programs.AddProgram(programCode, description);

            return success;
        }
        public Program FindStudent(string studentId)
        {
            Students students = new Students();
            Program enrolledStudent = students.GetStudent(studentId);
            

            return enrolledStudent;
        }
        public bool ModifyStudent(Program student)
        {
            Students enrolledStudent = new Students();
            bool isModify = enrolledStudent.UpdateStudent(student);
            return isModify;


        }
        public bool RemoveStudent(string removeStudentId)
        {
            Students removeStudent = new Students();
            bool success = removeStudent.DeleteStudent(removeStudentId);
            return success;
        }
        public List<Program> FindProgram(string findProgramCode)
        {
            Programs findProgram = new Programs();
            List<Program> activeProgram =  findProgram.GetProgram(findProgramCode);
           
            return activeProgram;
        }

    }
}
