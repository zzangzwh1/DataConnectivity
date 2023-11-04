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
            string createProgramProgramCode = "Demo114";
            string createProgramDescription = "Demo114";

            bool confirmation = requestDirector.CreateProgram(createProgramProgramCode, createProgramDescription);

            if (confirmation)
                Console.WriteLine("Program is Successfullay Createded");
            else
                Console.WriteLine("FAILED!!!");
            #endregion


            #region EnrollStudent
            Console.WriteLine("");
            Console.WriteLine($"-------------------------- Enroll Student --------------------------------");
            string accepetedStudentStudentId = "7";
            string accepetedStudentFirstName = "Jade";
            string accepetedStudentLastName = "james";
            string accepetedStudentEmail = "wcho2@nait.ca";

            Student accepetedStudent = new()
            {
                StudentId = accepetedStudentStudentId,
                FirstName = accepetedStudentFirstName,
                lastName = accepetedStudentLastName,
                Email = accepetedStudentEmail

            };

            string enrollStudentProgramCode = "BAIST";

            confirmation = requestDirector.EnrollStudent(accepetedStudent, enrollStudentProgramCode);

            if (confirmation)
                Console.WriteLine("Students Are Successfullay Added");
            else
                Console.WriteLine("FAILED!!!");
            #endregion

            #region FindsStudent
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Find Student --------------------------");
            string studentId = "105";

            Domain.Program enrolledStudent = requestDirector.FindStudent(studentId);


            Console.WriteLine();


            #endregion

            #region ModifyStudent
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Modify Student --------------------------");


            studentId = "105";
            enrolledStudent = new Domain.Program();

            enrolledStudent = requestDirector.FindStudent(studentId);
            Console.WriteLine();



            //Programs modifyEnrolledStudent = requestDirector.FindStudent(modifyFindStudentId);


            string? enrolledSuudentUpdateFirstName = "Mike";
            string? enrolledSuudentUpdateLastName = "Smith";
            string? enrolledSuudentUpdateEmail = "wcho2@nait.ca";

            foreach (var modifyValues in enrolledStudent.EnrolledStudents)
            {
                modifyValues.FirstName = IsStringEmptyOrNull(enrolledSuudentUpdateFirstName);
                modifyValues.lastName = IsStringEmptyOrNull(enrolledSuudentUpdateLastName);
                modifyValues.Email = IsStringEmptyOrNull(enrolledSuudentUpdateEmail);
                modifyValues.StudentId = IsStringEmptyOrNull(studentId);

            }


            confirmation = requestDirector.ModifyStudent(enrolledStudent);

            if (confirmation)
                Console.WriteLine($"Student is successfully Updated! ");
            else
                Console.WriteLine($"Failed!! ");

            #endregion


            #region RemoveStudent 
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Remove Student --------------------------");

            studentId = "12";
            enrolledStudent = new Domain.Program();
            enrolledStudent = requestDirector.FindStudent(studentId);
            Console.WriteLine();

            foreach (var beforeDelete in enrolledStudent.EnrolledStudents)
            {
                Console.WriteLine($"{beforeDelete.StudentId} \t\t {beforeDelete.FirstName} \t\t{beforeDelete.lastName} \t\t{beforeDelete.Email} \t\t\t{enrolledStudent.ProgramCode}");
            }

            confirmation = requestDirector.RemoveStudent(studentId);
            if (confirmation)
                Console.WriteLine($"Student is successfully Removed! ");
            else
                Console.WriteLine($"Failed!! ");

            #endregion

            #region FindsProgram
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Finds Program --------------------------");


            string programCode = "BAIST";
            Domain.Program activeProgram = requestDirector.FindProgram(programCode);

            foreach (var programs in activeProgram.EnrolledStudents)
            {
                Console.WriteLine($"{programs.StudentId} \t\t\t {programs.FirstName} \t\t\t {programs.lastName} \t\t\t {programs.Email} \t\t\t{activeProgram.ProgramCode}");
            }



            #endregion




            #region For Inserting Value Mannually



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