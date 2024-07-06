using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.StudentManagementCRUDProject
{
    public class CourseModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Courses { get; set; }
        public string Program {  get; set; }
        public decimal Fee { get; set; }


    }
}
