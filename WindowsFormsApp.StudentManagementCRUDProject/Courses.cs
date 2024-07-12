using System;
using System.CodeDom;
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
                int age;
                string email = txtEmail.Text.Trim();
                string phoneNumber = txtPhoneNumber.Text.Trim();
                string courses = radBtnWeb.Checked ? "Web Development" : radBtnJava.Checked ? "Java" :
                    radBtnPhp.Checked ? "PHP" : radBtnCsharp.Checked ? "C#" : radBtnAndroid.Checked ? "Android Development" : radBtnIos.Checked ? "IOS Development" :
                    radBtnReact.Checked ? "React Native" : radBtnFlutter.Checked ? "Flutter" : radBtnPython.Checked ? "Python" : string.Empty;
                string program = comProgram.Text.Trim();
                decimal fee;

                if (name.IsNullOrEmpty()|| fatherName.IsNullOrEmpty() || email.IsNullOrEmpty() || phoneNumber.IsNullOrEmpty() || courses.IsNullOrEmpty() || program.IsNullOrEmpty())

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
                SqlConnection conn = new SqlConnection(ConnectionString.getConnection);
                conn.Open();
                string query = @"INSERT INTO CourseRegistration (StudentName,FatherName,Age,Email,PhoneNumber,Courses,Program,Fee) VALUES (@StudentName,@FatherName,@Age,@Email,@PhoneNumber,@Courses,@Program,@Fee)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentName",name);
                cmd.Parameters.AddWithValue("@FatherName", fatherName);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@Courses", courses);
                cmd.Parameters.AddWithValue("@Program", program);
                cmd.Parameters.AddWithValue("@Fee", fee);
                int result = cmd.ExecuteNonQuery();

                conn.Close();

                if (result > 0)
                {
                    MessageBox.Show("Create Student Successful!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("Create student Fail", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }

        }

        private void Courses_Load(object sender, EventArgs e)
        {
            radBtnWeb.CheckedChanged += new EventHandler(CourseOrProgramChanged);
            radBtnJava.CheckedChanged += new EventHandler(CourseOrProgramChanged);
            radBtnPhp.CheckedChanged += new EventHandler(CourseOrProgramChanged);
            radBtnCsharp.CheckedChanged += new EventHandler(CourseOrProgramChanged);
            radBtnAndroid.CheckedChanged += new EventHandler(CourseOrProgramChanged);
            radBtnIos.CheckedChanged += new EventHandler(CourseOrProgramChanged);
            radBtnReact.CheckedChanged += new EventHandler(CourseOrProgramChanged);
            radBtnFlutter.CheckedChanged += new EventHandler(CourseOrProgramChanged);
            radBtnPython.CheckedChanged += new EventHandler(CourseOrProgramChanged);

            comProgram.SelectedIndexChanged += new EventHandler(CourseOrProgramChanged);

            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
            {
                editBtn.Text = "Edit";
                editBtn.UseColumnTextForButtonValue = true;
            };
            editBtn.DefaultCellStyle.BackColor = Color.Green;
            dgv1.Columns.Add(editBtn);

            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            {
                deleteBtn.Text = "Delete";
                deleteBtn.UseColumnTextForButtonValue = true;
            };
            deleteBtn.DefaultCellStyle.BackColor = Color.Red;
            dgv1.Columns.Add(deleteBtn);
            LoadCoursesData();              
        }

        private void Courses_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCoursesData();
            txtName.Clear();
            txtFatherName.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            txtPhoneNumber.Clear();
            txtFee.Clear();
            radBtnAndroid.Checked = false;
            radBtnCsharp.Checked = false;
            radBtnFlutter.Checked = false;
            radBtnIos.Checked = false;
            radBtnJava.Checked = false;
            radBtnPhp.Checked = false;
            radBtnPython.Checked = false;
            radBtnReact.Checked = false;
            radBtnWeb.Checked = false;
            comProgram.SelectedIndex = -1;
        }

        private void LoadCoursesData()
        {    

            try
            {
                FetchData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells[2].Value);
                if (e.ColumnIndex == 0)
                {
                   
                    string studentName = Convert.ToString(dgv1.Rows[e.RowIndex].Cells[3].Value);
                    string fatherName = Convert.ToString(dgv1.Rows[e.RowIndex].Cells[4].Value);
                    int age = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells[5].Value);
                    string email = Convert.ToString(dgv1.Rows[e.RowIndex ].Cells[6].Value);
                    string phoneNumber = Convert.ToString(dgv1.Rows[e.RowIndex].Cells[7].Value);
                    string courses = Convert.ToString(dgv1.Rows[e.RowIndex].Cells[8].Value);
                    string program = Convert.ToString(dgv1.Rows[e.RowIndex].Cells[9].Value);
                    int fee = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells[10].Value);


                    var model = new CourseModel
                    {
                        StudentID = id,
                        StudentName = studentName,
                        FatherName = fatherName,
                        Age = age,
                        Email = email,
                        PhoneNumber = phoneNumber,
                        Courses = courses,
                        Program = program,
                        Fee = fee
                    };
                    UpdateStudent updateStudent = new UpdateStudent(model);
                    updateStudent.Show();
                    this.Hide();
                }

                if(e.ColumnIndex == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you Sure to delete?", "Confirmation!",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.OK)
                    {
                        string query = @"DELETE FROM CourseRegistration WHERE StudentID = @StudentID";
                        SqlConnection conn = new SqlConnection(ConnectionString.getConnection);
                        await conn.OpenAsync();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@StudentID", id);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0) 
                        {
                            MessageBox.Show("Delete Student Successful!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await FetchData();
                            return;
                        }
                        MessageBox.Show("Delete Student Fail", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        conn.Close();
                    }

                }
            }
            catch (Exception ex) 
            {
                throw new Exception (ex.Message);
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
        private async Task FetchData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString.getConnection);
                await conn.OpenAsync();
                string query = @"SELECT [StudentID]
      ,[StudentName]
      ,[FatherName]
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
