using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace PatientManagementSys
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private bool IsEmailValid(string email)
        {
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, pattern);
        }
        SqlConnection conn = new SqlConnection(@"Data Source=Yvan-PC\SQLEXPRESS;Initial Catalog=StudentPortalDB;Integrated Security=True");
        private void loginButton_Click(object sender, EventArgs e)
        {
            string email = idemailBox.Text;
            if (!IsEmailValid(email))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email address.");
                return;
            }

            string password = pswdBox.Text; 

            string query = "SELECT email, password FROM Patients WHERE email = @Email";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", email);


            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string retrievedEmail = reader["email"].ToString();
                    string retrievedPassword = reader["password"].ToString();
                   
                    if (retrievedEmail == email && retrievedPassword == password)
                    {
                        // Authentication successful
                        Apointment pg = new Apointment();
                        this.Hide();
                        pg.Show();
                    }
                    else
                    {
                        // Authentication failed
                        MessageBox.Show("Invalid email or password");
                    }
                }

                else if (email == "admin@gmail.com" && password == "password")
                {
                    Doctor rq = new Doctor();
                    this.Hide();
                    rq.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
