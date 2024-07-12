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
    public partial class UpdateStudent : Form
    {
        private readonly CourseModel _courseModel;
        public UpdateStudent(CourseModel courseModel)
        {
            InitializeComponent();
            _courseModel = courseModel;
        }

        private void UpdateStudent_Load(object sender, EventArgs e)
        {
          

            txtName.Text = _courseModel.StudentName;
            txtFatherName.Text = _courseModel.FatherName;
            txtAge.Text = _courseModel.Age.ToString();
            txtEmail.Text = _courseModel.Email;
            txtPhoneNumber.Text = _courseModel.PhoneNumber;
            radBtnWeb.Checked = _courseModel.Courses.Contains("Web Development");
            radBtnJava.Checked = _courseModel.Courses.Contains("Java");
            radBtnPhp.Checked = _courseModel.Courses.Contains("PHP");
            radBtnCsharp.Checked = _courseModel.Courses.Contains("C#");
            radBtnAndroid.Checked = _courseModel.Courses.Contains("Android Development");
            radBtnIos.Checked = _courseModel.Courses.Contains("IOS Development");
            radBtnReact.Checked = _courseModel.Courses.Contains("React Native");
            radBtnFlutter.Checked = _courseModel.Courses.Contains("Flutter");
            radBtnPython.Checked = _courseModel.Courses.Contains("Python");
            comProgram.SelectedItem = _courseModel.Program;
            txtFee.Text = _courseModel.Fee.ToString();

            radBtnWeb.CheckedChanged += CourseOrProgramChanged;
            radBtnJava.CheckedChanged += CourseOrProgramChanged;
            radBtnPhp.CheckedChanged += CourseOrProgramChanged;
            radBtnCsharp.CheckedChanged += CourseOrProgramChanged;
            radBtnAndroid.CheckedChanged += CourseOrProgramChanged;
            radBtnIos.CheckedChanged += CourseOrProgramChanged;
            radBtnReact.CheckedChanged += CourseOrProgramChanged;
            radBtnFlutter.CheckedChanged += CourseOrProgramChanged;
            radBtnPython.CheckedChanged += CourseOrProgramChanged;

            comProgram.SelectedIndexChanged += CourseOrProgramChanged;

        }

        private void UpdateStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Courses courses = new Courses();
            courses.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try 
            {
                string name = txtName.Text.Trim();
                string fatherName = txtFatherName.Text.Trim();
                int age;
                string email = txtEmail.Text.Trim();
                string phoneNumber = txtPhoneNumber.Text.Trim();
                string courses = radBtnWeb.Checked ? "Web Development" : radBtnJava.Checked ? "Java" :
                    radBtnPhp.Checked ? "PHP" : radBtnCsharp.Checked ? "C#" : radBtnAndroid.Checked ? "Android Development" : radBtnIos.Checked ? "IOS Development" :
                    radBtnReact.Checked ? "React Native" : radBtnFlutter.Checked ? "Flutter" : radBtnPython.Checked ? "Python" : string.Empty;
                string program = comProgram.Text.Trim();
                decimal fee;

                if (name.IsNullOrEmpty() || fatherName.IsNullOrEmpty() ||email.IsNullOrEmpty() || phoneNumber.IsNullOrEmpty() || courses.IsNullOrEmpty() || program.IsNullOrEmpty())

                {
                    MessageBox.Show("Please fill out all fields.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(txtAge.Text.Trim(), out age) || age <= 0)
                {
                    MessageBox.Show("Please enter a valid age.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtFee.Text.Trim(), out fee) || fee <= 0)
                {
                    MessageBox.Show("Please enter a valid fee.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string query = Query.GetUpdateBlogQuery;     
                SqlConnection conn = new SqlConnection(ConnectionString.getConnection);
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentName", name);
                cmd.Parameters.AddWithValue("@FatherName", fatherName);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@Courses", courses);
                cmd.Parameters.AddWithValue("@Program", program);
                cmd.Parameters.AddWithValue("@Fee", fee);
                cmd.Parameters.AddWithValue("@StudentID", _courseModel.StudentID);
                int result = cmd.ExecuteNonQuery();


                conn.Close();

                if (result > 0)
                {
                    MessageBox.Show("Update Student Successful!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("Update Student Fail", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }

        }
        private decimal CalculateFee(string course, string program)
        {
            decimal fee = 0;
            if (program == "Normal")
            {
                if (course == "Web Development") fee = 150000;
                else if (course == "Java") fee = 250000;
                else if (course == "PHP") fee = 250000;
                else if (course == "C#") fee = 250000;
                else if (course == "Android Development") fee = 300000;
                else if (course == "IOS Development") fee = 300000;
                else if (course == "React Native") fee = 350000;
                else if (course == "Flutter") fee = 250000;
                else if (course == "Python") fee = 150000;
            }
            else if (program == "By One")
            {
                if (course == "Web Development") fee = 250000;
                else if (course == "Java") fee = 550000;
                else if (course == "PHP") fee = 550000;
                else if (course == "C#") fee = 550000;
                else if (course == "Android Development") fee = 600000;
                else if (course == "IOS Development") fee = 600000;
                else if (course == "React Native") fee = 650000;
                else if (course == "Flutter") fee = 500000;
                else if (course == "Python") fee = 250000;
            }
            else if (program == "Training")
            {
                if (course == "Web Development") fee = 550000;
                else if (course == "Java") fee = 700000;
                else if (course == "PHP") fee = 700000;
                else if (course == "C#") fee = 700000;
                else if (course == "Android Development") fee = 750000;
                else if (course == "IOS Development") fee = 750000;
                else if (course == "React Native") fee = 800000;
                else if (course == "Flutter") fee = 600000;
                else if (course == "Python") fee = 450000;
            }
            return fee;
        }
        private void CourseOrProgramChanged(object sender, EventArgs e)
        {
            string selectedCourse = GetSelectedCourse();
            string selectedProgram = comProgram.Text.Trim();

            if (!string.IsNullOrEmpty(selectedCourse) && !string.IsNullOrEmpty(selectedProgram))
            {
                decimal fee = CalculateFee(selectedCourse, selectedProgram);
                txtFee.Text = fee.ToString();
            }
        }

        private string GetSelectedCourse()
        {
            if (radBtnWeb.Checked) return "Web Development";
            if (radBtnJava.Checked) return "Java";
            if (radBtnPhp.Checked) return "PHP";
            if (radBtnCsharp.Checked) return "C#";
            if (radBtnAndroid.Checked) return "Android Development";
            if (radBtnIos.Checked) return "IOS Development";
            if (radBtnReact.Checked) return "React Native";
            if (radBtnFlutter.Checked) return "Flutter";
            if (radBtnPython.Checked) return "Python";
            return string.Empty;
        }
    }
}
