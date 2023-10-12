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
            string createProgramProgramCode = "Demo14";
            string createProgramDescription = "DEMO 14";

            bool confirmation = requestDirector.CreateProgram(createProgramProgramCode, createProgramDescription);

            if (confirmation)
                Console.WriteLine("Program is Successfullay Createded");
            else
                Console.WriteLine("FAILED!!!");
            #endregion


            #region EnrollStudent
            Console.WriteLine("");
            Console.WriteLine($"-------------------------- Enroll Student --------------------------------");
            string accepetedStudentStudentId = "103";
            string accepetedStudentFirstName = "Mike";
            string accepetedStudentLastName = "cho";
            string accepetedStudentEmail = "wcho2@nait.ca";

            Student accepetedStudent = new()
            {
                StudentId = accepetedStudentStudentId,
                FirstName = accepetedStudentFirstName,
                lastName = accepetedStudentLastName,
                Email = accepetedStudentEmail

            };

            string enrollStudentProgramCode = "BAIST";

            bool enrollCirformation = requestDirector.EnrollStudent(accepetedStudent, enrollStudentProgramCode);

            if (enrollCirformation)
                Console.WriteLine("Students Are Successfullay Added");
            else
                Console.WriteLine("FAILED!!!");
            #endregion

            #region FindsStudent
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Find Student --------------------------");
            string findStudentId = "103";

            Domain.Program enrolledStudent = requestDirector.FindStudent(findStudentId);




            Console.WriteLine();
            foreach (var studentValues in enrolledStudent.EnrolledStudents)
            {

                Console.WriteLine($"{studentValues.StudentId} \t\t {studentValues.FirstName} \t\t{studentValues.lastName} \t\t{studentValues.Email} \t\t\t{enrolledStudent.ProgramCode}");
            }


            #endregion

            #region ModifyStudent
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Modify Student --------------------------");


            string modifyFindStudentId = "103";
            enrolledStudent = new Domain.Program();

            enrolledStudent = requestDirector.FindStudent(modifyFindStudentId);
            Console.WriteLine();
            foreach (var beforeModify in enrolledStudent.EnrolledStudents)
            {
                Console.WriteLine($"{beforeModify.StudentId} \t\t {beforeModify.FirstName} \t\t{beforeModify.lastName} \t\t{beforeModify.Email} \t\t\t{enrolledStudent.ProgramCode}");
            }



            //Programs modifyEnrolledStudent = requestDirector.FindStudent(modifyFindStudentId);


            string? enrolledSuudentUpdateFirstName = "MARY";
            string? enrolledSuudentUpdateLastName = "CHeei";
            string? enrolledSuudentUpdateEmail = "wcho2@nait.ca";

            foreach (var modifyValues in enrolledStudent.EnrolledStudents)
            {
                modifyValues.FirstName = IsStringEmptyOrNull(enrolledSuudentUpdateFirstName);
                modifyValues.lastName = IsStringEmptyOrNull(enrolledSuudentUpdateLastName);
                modifyValues.Email = IsStringEmptyOrNull(enrolledSuudentUpdateEmail);
                modifyValues.StudentId = IsStringEmptyOrNull(modifyFindStudentId);

            }


            bool isModified = requestDirector.ModifyStudent(enrolledStudent);

            if (isModified)
                Console.WriteLine($"Student is successfully Updated! ");
            else
                Console.WriteLine($"Failed!! ");

            #endregion


            #region RemoveStudent 
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Remove Student --------------------------");

            string removeStudentId = "9";
            enrolledStudent = new Domain.Program();
            enrolledStudent = requestDirector.FindStudent(removeStudentId);
            Console.WriteLine();

            foreach (var beforeDelete in enrolledStudent.EnrolledStudents)
            {
                Console.WriteLine($"{beforeDelete.StudentId} \t\t {beforeDelete.FirstName} \t\t{beforeDelete.lastName} \t\t{beforeDelete.Email} \t\t\t{enrolledStudent.ProgramCode}");
            }

            bool removeConfirmation = requestDirector.RemoveStudent(removeStudentId);
            if (removeConfirmation)
                Console.WriteLine($"Student is successfully Removed! ");
            else
                Console.WriteLine($"Failed!! ");

            #endregion

            #region FindsProgram
            Console.WriteLine("");
            Console.WriteLine("\"-------------------------- Finds Program --------------------------");


            string findProgramCode = "BAIST";
            Domain.Program activeProgram = requestDirector.FindProgram(findProgramCode);

            foreach(var programs in activeProgram.EnrolledStudents)
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