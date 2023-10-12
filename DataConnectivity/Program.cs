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
            foreach (var student in enrolledStudent.EnrolledStudents)
            {

                Console.WriteLine($"{student.StudentId} \t\t {student.FirstName} \t\t{student.lastName} \t\t{student.Email} \t\t{enrolledStudent.ProgramCode}");
            }


            #endregion

            #region ModifyStudent
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Modify Student --------------------------");


            studentId = "105";
            enrolledStudent = new Domain.Program();

            enrolledStudent = requestDirector.FindStudent(studentId);
            Console.WriteLine();
            foreach (var beforeModify in enrolledStudent.EnrolledStudents)
            {
                Console.WriteLine($"{beforeModify.StudentId} \t\t {beforeModify.FirstName} \t\t{beforeModify.lastName} \t\t{beforeModify.Email} \t\t{enrolledStudent.ProgramCode}");
            }



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

            ///Test User Interface (Console)
            ///--------------------
            ///Enrolls Students
            ///get Values from User Interface

            /*
             string studentId = string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;
            string email = string.Empty;
            string programCode = string.Empty;
            string? consoleLine = string.Empty;
            Console.WriteLine($"Enter Student ID : ");
            if((consoleLine = Console.ReadLine()) != null)
            {
                studentId = consoleLine;
            }
            Console.WriteLine("Enter First Name : ");
            if((consoleLine = Console.ReadLine()) != null)
            {
                firstName = consoleLine;
            }
            Console.WriteLine("Enter Last Name : ");
            if ((consoleLine = Console.ReadLine()) != null)
                lastName = consoleLine;           

            Console.WriteLine("Enter Email : ");
            if ((consoleLine = Console.ReadLine()) != null)
                email = consoleLine;

            Console.WriteLine("Enter Program Code : ");
            if ((consoleLine = Console.ReadLine()) != null)
                programCode = consoleLine;


            // process
            bool confirmation;
            Students acceptedStudent = new()
            {
                StudentId = studentId,
                FirstName = firstName,
                lastName = lastName,
                Email = email            
            
            };
            BCS ReuqestDirector = new();
            confirmation = requestDirector.EnrollStudent(acceptedStudent, programCode);
            Console.WriteLine(confirmation);
            
             */


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