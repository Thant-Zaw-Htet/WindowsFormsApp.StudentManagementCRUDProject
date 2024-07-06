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
                int age;
                string email = txtEmail.Text.Trim();
                string phoneNumber = txtPhoneNumber.Text.Trim();
                string courses = radBtnWeb.Checked ? "Web Development" : radBtnJava.Checked ? "Java" :
                    radBtnPhp.Checked ? "PHP" : radBtnCsharp.Checked ? "C#" : radBtnAndroid.Checked ? "Android Development" : radBtnIos.Checked ? "IOS Development" :
                    radBtnReact.Checked ? "React Native" : radBtnFlutter.Checked ? "Flutter" : radBtnPython.Checked ? "Python" : string.Empty;
                string program = comProgram.Text.Trim();
                decimal fee;

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(fatherName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(courses) || string.IsNullOrEmpty(program))

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
                SqlConnection conn = new SqlConnection(ConnectionString.getConnection);
                conn.Open();
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

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    int id = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells[2].Value);
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
            }
            catch (Exception ex) 
            {
                throw new Exception (ex.Message);
            }
        }
    }
}
