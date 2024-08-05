using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.StudentManagementCRUDProject
{
    public class Query
    {
        public static string GetCreateBlogQuery { get; } =
            @"INSERT INTO UserRegistration(Username,Email,Password,Phonenumber) VALUES(@Username,@Email,@Password,@Phonenumber)";

        public static string GetSelectBlogQuery { get; } =
            @"SELECT * FROM UserRegistration WHERE email = @email and password = @password";

        public static string GetAllBlogQuery { get; } =
            @"SELECT [StudentID]
      ,[StudentName]
      ,[FatherName]
      ,[Age]
      ,[Email]
      ,[PhoneNumber]
      ,[Courses]
      ,[Program]
      ,[Fee]
  FROM [users].[dbo].[CourseRegistration] ";


        public static string GetDeleteBlogQuery { get; } =
            @"DELETE FROM CourseRegistration WHERE StudentID = @StudentID";


        public static string GetUpdateBlogQuery { get; } =
            @"UPDATE CourseRegistration SET StudentName = @StudentName, FatherName = @FatherName, Age = @Age, Email = @Email, PhoneNumber = @PhoneNumber, Courses = @Courses, Program = @Program, Fee = @Fee WHERE StudentId = @StudentId";


        public static string GetInsertBlogQuery { get; } =
            @"INSERT INTO CourseRegistration (StudentName,FatherName,Age,Email,PhoneNumber,Courses,Program,Fee) VALUES (@StudentName,@FatherName,@Age,@Email,@PhoneNumber,@Courses,@Program,@Fee)";
    }




}
