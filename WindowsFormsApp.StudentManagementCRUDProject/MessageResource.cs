using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.StudentManagementCRUDProject
{
    public class MessageResource
    {
        public static string FillData { get; } = "Please fill out all fields.";
        public static string ValidAge { get; } = "Please fill out all fields.";
        public static string ValidFee { get; } = "Please fill out all fields.";

        public static string CreateStudentSuccess { get; } = "Create Student Successful!";

        public static string CreateStudentFail { get; } = "Create student Fail", "Error!";

    }

}
