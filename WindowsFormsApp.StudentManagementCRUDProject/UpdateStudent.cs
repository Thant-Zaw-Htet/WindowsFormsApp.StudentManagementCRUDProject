using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
