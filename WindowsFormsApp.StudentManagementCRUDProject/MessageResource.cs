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

        public static string CreateStudentFail { get; } = "Create student Fail";

        public static string DeleteConfirm { get; } = "Are you Sure to delete?";

        public static string DeleteSuccess { get; } = "Delete Student Successful!";
        public static string DeleteFail { get; } = "Delete Student Fail";


        public static string UpdateSuccess { get; } = "Update Student Successful!";

        public static string UpdateFail { get; } = "Update Student Fail";
    }

}
