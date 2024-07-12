using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.StudentManagementCRUDProject
{
    public static class DevCode
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }
    }
}
