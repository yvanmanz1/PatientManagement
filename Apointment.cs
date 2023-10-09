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

namespace PatientManagementSys
{
    public partial class Apointment : Form
    {
        public Apointment()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=Yvan-PC\SQLEXPRESS;Initial Catalog=HospitalPortalDB;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            String fullName = fnameBox.Text + " " + lnameBox.Text;
            String email = emailBox.Text;
            String reason = reasonBox.Text;
            String date = dateTimePicker.Text;
            String query = "INSERT INTO Appointments(fullnames, email, reason, date) Values('" + fullName + "','" + email + "','" + reason + "','" + date + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            conn.Open();
            // Save to the database
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Appointment requested Succesfully");
            Login loginForm = new Login();
            this.Hide();
            loginForm.Show();
        }
    }
}
