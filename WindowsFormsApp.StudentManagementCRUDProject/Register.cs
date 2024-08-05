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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();
                string phoneNumber = txtPhoneNumber.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber))
                {
                    MessageBox.Show("Please fill in all field?", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlConnection conn = new SqlConnection(ConnectionString.getConnection);
                    conn.Open();
                    string query = Query.GetCreateBlogQuery;
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Phonenumber", phoneNumber);
                    int result = cmd.ExecuteNonQuery();

                    conn.Close();


                    if (result > 0)
                    {
                        MessageBox.Show("Register Successful", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtName.Clear();
                        txtEmail.Clear();
                        txtPassword.Clear();
                        txtPhoneNumber.Clear();

                    }
                    else 
                    {
                        MessageBox.Show("Create User Fail","Error!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    
                }
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
