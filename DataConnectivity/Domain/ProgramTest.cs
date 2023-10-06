
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnectivity.Domain
{
    internal class ProgramTest
    {
        /*  private string _programCode = "";
          private string _description = "";*/
       // private readonly TestStudent _students;

        public string ProgramCode { set; get; }
        public string Description { set; get; }
        /*     public string ProgramCode
             {
                 get => _programCode;
                 set => _description = value;


             }
             public string Description
             {
                 get => _description;
                 set => _description = value;

             }*/
        public TestStudent EnrollStudents { set; get; }
        public ProgramTest()         
        {
        }
     /*   {
            set;
            get;
        }*/
       
    }
}
