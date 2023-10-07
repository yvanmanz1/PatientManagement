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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool IsEmailValid(string email)
        {
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, pattern);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=Yvan-PC\SQLEXPRESS;Initial Catalog=HospitalPortalDB;Integrated Security=True");
        private void submitButton_Click(object sender, EventArgs e)
        {
            
            String fullName = fnameBox.Text + " " + lnameBox.Text;
            //String fac = facultyBox.Text;

            String email = emailBox.Text;
            if (!IsEmailValid(email))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email address.");
                return; 
            }

            String pass = pwdBox.Text;
            

            String query = "INSERT INTO Patients Values('" + fullName + "','" + email + "','" + pass + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            conn.Open();
            // Save to the database
            sda.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Patient saved with success ");
            Login loginForm = new Login();
            this.Hide();
            loginForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }
    }
}
