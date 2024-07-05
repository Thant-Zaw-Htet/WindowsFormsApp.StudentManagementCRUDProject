using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.StudentManagementCRUDProject
{
    public partial class Courses : Form
    {
        public Courses()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string fatherName = txtFatherName.Text.Trim();
                int age = int.Parse(txtAge.Text.Trim());
                string email = txtEmail.Text.Trim();
                string phoneNumber = txtPhoneNumber.Text.Trim();

                string courses = radBtnWeb.Checked ? "Web Development" : radBtnJava.Checked ? "Java" :
                    radBtnPhp.Checked ? "PHP" : radBtnCsharp.Checked ? "C#" : radBtnAndroid.Checked ? "Android Development" : radBtnIos.Checked ? "IOS Development" :
                    radBtnReact.Checked ? "React Native" : radBtnFlutter.Checked ? "Flutter" : radBtnPython.Checked ? "Python" : string.Empty;

                string program = comProgram.Text.Trim();
                decimal fee = decimal.Parse(txtFee.Text.Trim());

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(fatherName) || age <= 0 || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(courses) || string.IsNullOrEmpty(program) || fee <= 0)

                {
                    MessageBox.Show("Please fill out all fields correctly.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }

        }

        private void Courses_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString.getConnection);
                conn.Open();
                string query = @"SELECT [StudentID]
      ,[Studentname]
      ,[Fathername]
      ,[Age]
      ,[Email]
      ,[PhoneNumber]
      ,[Courses]
      ,[Program]
      ,[Fee]
  FROM [users].[dbo].[CourseRegistration] ";
                SqlCommand cmd = new SqlCommand(query, conn);   
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                conn.Close();

                dgv1.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
