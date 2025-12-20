using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsSessionsEx
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Section { get; set; }
    }

    public class UGStudent : Student
    {
        public string CoreSubject {  get; set; }
    }


    public class PGStudent : UGStudent
    {
 

        public string UGDegree { get; set; }
       
    }

}