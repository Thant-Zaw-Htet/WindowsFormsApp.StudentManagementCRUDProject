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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void labCreateAccount_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtName.Text.Trim();
                string password = txtPassword.Text.Trim();

                SqlConnection conn = new SqlConnection(ConnectionString.getConnection);
                conn.Open();
                string query = Query.GetSelectBlogQuery;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("email", username);
                cmd.Parameters.AddWithValue("password", password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);


                DataTable dt = new DataTable();
                da.Fill(dt);
               
                conn.Close();

                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Courses courses = new Courses();
                    courses.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed! Username and password are wrong!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
