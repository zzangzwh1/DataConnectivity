using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using System.Data;


namespace DataConnectivity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Programs
            #region Demonstration AddProgram
            /*   Console.WriteLine("--- ADD STUDENT ---");
             string addProgramCode = "TAgSTgggsffsdffs;sdkf;lskfl;sdkf;lsdkf;lskfl;sdkf;lsdkfl;sdk;lfs!";
                string addProgramDescription = "This is Baist!";
                bool isAddedProgram = Programs.AddProgram(addProgramCode, addProgramDescription);

                if (isAddedProgram)
                {
                    Console.WriteLine($"Program is Success Fully Added!");
                }
                else
                {
                    Console.WriteLine($"Error Occurreed - Failed!");
                }*/
            #endregion

            #region Demonstration GetProgram

            Console.WriteLine("------------- GET PROGRAM -------------");
            string getPrgoramCode = "BAISThbb";
            Programs.GetProgram(getPrgoramCode);

            #endregion
            Console.WriteLine();
            #region Demonstration AddStudent

            Console.WriteLine("------------- ADD Student -------------");
            string addStudentID = "12";
            string addFirtName = "MCH";
            string addlastName = "c";
            string addEmail = "";
            string addProgramCode = "BAIST";

            bool isStudentAdd = Students.AddStudent(addStudentID, addFirtName, addlastName, addEmail,addProgramCode);

            if (isStudentAdd)
            {
                Console.WriteLine($"Student is Success Fully Added!");
            }
            else
            {
                Console.WriteLine($"Error Occurred - Failed!");
            }

            #endregion

            #region Update Student

            Console.WriteLine("------------- Update Student -------------");

            string updateStudentID = "9";
            string updateFirtName = "Mike";
            string updateLastName = "CHOi";
            string updateEmail = "wcho2@nait.ca";
           

            bool isStudentUpdated = Students.UpdateStudent(IsStringEmptyOrNull(updateStudentID), IsStringEmptyOrNull(updateFirtName), IsStringEmptyOrNull(updateLastName), IsStringEmptyOrNull(updateEmail));
            if (isStudentUpdated)
            {
                Console.WriteLine("Students are successfully Updated!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
            #endregion

            #region Delete Student

            Console.WriteLine("------------- Delete Student -------------");

            string deleteStudentId = "10";
            bool isStudentDelete = Students.DeleteStudent(deleteStudentId);
            if (isStudentDelete)
            {
                Console.WriteLine("Students are successfully Deleted!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
            #endregion

            #region GetStudent

            Console.WriteLine($"------------- Get Student -------------");
            string getStudentId = "3";

            string getStudent = Students.GetStudent(getStudentId);

            Console.WriteLine(getStudent);


            #endregion

            Console.WriteLine("");
            #region GetStudentsByProgram

            Console.WriteLine("------------- GetStudentsByProgram -------------");

            string getStudentByProgramCode = "BAIST";

            Students.GetStudentsByProgram(getStudentByProgramCode);

            #endregion

            Console.ReadLine();
        }
        private static string? IsStringEmptyOrNull(string? str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            return str;
        }
    }
}