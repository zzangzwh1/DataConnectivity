using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using System.Data;
using DataConnectivity.Domain;
using DataConnectivity.TechService;


namespace DataConnectivity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Programs
            #region Demonstration AddProgram
            /*       Console.WriteLine("--- ADD STUDENT ---");
                   string addProgramCode = "Demo";
                   string addProgramDescription = "This is Demo!!!";
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

            /*            Console.WriteLine("------------- GET PROGRAM -------------");
                        string getPrgoramCode = "Demo";
                        DataPrograms.GetProgram(getPrgoramCode);*/

            #endregion
            Console.WriteLine();
            #region Demonstration AddStudent

            /*            Console.WriteLine("------------- ADD Student -------------");
                        string addStudentID = "99";
                        string addFirtName = "Demo";
                        string addlastName = "Demo";
                        string addEmail = "";
                        string addProgramCodes = "Demo";

                        bool isStudentAdd = DataStudents.AddStudent(addStudentID, addFirtName, addlastName, addEmail, addProgramCodes);

                        if (isStudentAdd)
                        {
                            Console.WriteLine($"Student is Success Fully Added!");
                        }
                        else
                        {
                            Console.WriteLine($"Error Occurred - Failed!");
                        }
            */
            #endregion

            #region Update Student

            /*         Console.WriteLine("------------- Update Student -------------");

                     string updateStudentID = "99";
                     string updateFirtName = "Mike";
                     string updateLastName = "CHOi";
                     string updateEmail = "wcho2@nait.ca";


                     bool isStudentUpdated = DataStudents.UpdateStudent(IsStringEmptyOrNull(updateStudentID), IsStringEmptyOrNull(updateFirtName), IsStringEmptyOrNull(updateLastName), IsStringEmptyOrNull(updateEmail));
                     if (isStudentUpdated)
                     {
                         Console.WriteLine("Students are successfully Updated!");
                     }
                     else
                     {
                         Console.WriteLine("Failed!");
                     }*/
            #endregion

            #region Delete Student

            Console.WriteLine("------------- Delete Student -------------");

            /*     string deleteStudentId = "99";
                 bool isStudentDelete = DataStudents.DeleteStudent(deleteStudentId);
                 if (isStudentDelete)
                 {
                     Console.WriteLine("Students are successfully Deleted!");
                 }
                 else
                 {
                     Console.WriteLine("Failed!");
                 }*/
            #endregion

            #region GetStudent

            Console.WriteLine($"------------- Get Student -------------");
            /*        string getStudentId = "9";

                    string getStudent = DataStudents.GetStudent(getStudentId);

                    Console.WriteLine(getStudent);
        */

            #endregion

            Console.WriteLine("");
            #region GetStudentsByProgram
            /*
                        Console.WriteLine("------------- GetStudentsByProgram -------------");

                        string getStudentByProgramCode = "BAIST";

                        DataStudents.GetStudentsByProgram(getStudentByProgramCode);*/

            #endregion




            #region NorthWind GetCustomersByCountry
            /*    Console.WriteLine("");
         Console.WriteLine("------------- N O R T H W I N  D ------------- ");
         //Demonstrtion North Wind
          Console.WriteLine("Sample Result for United Kingdom");
                 Console.WriteLine("--------- GetCustomersByCountry --------");

                 string testGetCustomersByCountry = "UK";
                 NorthWind.GetCustomersByCountry(testGetCustomersByCountry);*/

            #endregion

            Console.WriteLine("");
            Console.WriteLine("-");

            #region NorthWind GetCategory
            /*            Console.WriteLine("Sample Result for Dairy Products");
                        Console.WriteLine("--------- GetCategory --------");
                        int testGetCategory = 4;
                        NorthWind.GetCategory(testGetCategory);*/
            #endregion

            #region Northwind GetProductsByCategory
            /*      Console.WriteLine("");
                  Console.WriteLine("-");
                  Console.WriteLine("--------- GetProductsByCategory --------");
                  string testGetProductsByCategory = "Dairy Products";
                  NorthWind.GetProductsByCategory(testGetProductsByCategory);
      */
            #endregion



            //Domain.TestStudent t = new Domain.TestStudent();
            Console.WriteLine("");
            Console.WriteLine($"-------------------------- TEST --------------------------------");
            BCS requestDirector = new BCS();

            #region CreateProgram
            Console.WriteLine("");
            Console.WriteLine($"-------------------------- Create Program --------------------------------");
            string createProgramProgramCode = "Demo14";
            string createProgramDescription = "DEMO 14";

            bool isCreatedProgram = requestDirector.CreateProgram(createProgramProgramCode, createProgramDescription);

            if (isCreatedProgram)
                Console.WriteLine("Program is Successfullay Createded");
            else
                Console.WriteLine("FAILED!!!");
            #endregion


            #region EnrollStudent
            Console.WriteLine("");
            Console.WriteLine($"-------------------------- Enroll Student --------------------------------");
            Students accepetedStudent = new()
            {
                StudentId = "103",
                FirstName = "M",
                lastName = "S",
                Email = ""

            };
            string enrollStudentProgramCode = "BAIST";


            bool isEnrolledStudent = requestDirector.EnrollStudent(accepetedStudent, enrollStudentProgramCode);

            if (isEnrolledStudent)
                Console.WriteLine("Students Are Successfullay Added");
            else
                Console.WriteLine("FAILED!!!");
            #endregion

            #region FindsStudent
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Find Student --------------------------");
            string findStudentId = "103";
            Programs enrolledStudent = requestDirector.FindStudent(findStudentId);

            Console.WriteLine();
            Console.WriteLine($"{enrolledStudent.EnrollStudents.StudentId} \t\t {enrolledStudent.EnrollStudents.FirstName} \t\t{enrolledStudent.EnrollStudents.lastName} \t\t{enrolledStudent.EnrollStudents.Email} \t\t\t{enrolledStudent.ProgramCode}");

            #endregion

            #region ModifyStudent
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Modify Student --------------------------");

            Students enrolledSuudentUpdate = new()
            {
                FirstName = "Mary",
                lastName = "Cho",
                Email = "wcho2@nait.ca",
                StudentId = "101"
            };
            bool isModified = requestDirector.ModifyStudent(enrolledSuudentUpdate);

            if (isModified)
                Console.WriteLine($"Student is successfully Updated! ");
            else
                Console.WriteLine($"Failed!! ");

            #endregion


            #region RemoveStudent 
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Remove Student --------------------------");

            string removeStudentId = "20";
            bool isRemoved = requestDirector.RemoveStudent(removeStudentId);
            if (isRemoved)
                Console.WriteLine($"Student is successfully Removed! ");
            else
                Console.WriteLine($"Failed!! ");

            #endregion

            #region FindsProgram
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Finds Program --------------------------");


            string findProgramCode = "BAIST";
            List<Programs> activeProgram = requestDirector.FindProgram(findProgramCode);
  
            foreach (var values in activeProgram)
            {
                Console.Write($"{values.EnrollStudents.StudentId} \t\t\t {values.EnrollStudents.FirstName} \t\t\t {values.EnrollStudents.lastName} \t\t\t {values.EnrollStudents.Email} \t\t\t {values.ProgramCode} ");
                Console.WriteLine();
            }


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