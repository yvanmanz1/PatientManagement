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
    public partial class Handle : Form
    {
        public Handle()
        {
            InitializeComponent();
            DataGridView dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.ReadOnly = true;
            this.Controls.Add(dataGridView);
            SqlConnection conn = new SqlConnection(@"Data Source=Yvan-PC\SQLEXPRESS;Initial Catalog=StudentPortalDB;Integrated Security=True");
            string query = "SELECT * FROM Appointments";


            DataTable dataTable = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);


            sda.Fill(dataTable);


            dataGridView.DataSource = dataTable;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=Yvan-PC\SQLEXPRESS;Initial Catalog=StudentPortalDB;Integrated Security=True");
        private void acceptbutton_Click(object sender, EventArgs e)
        {
            String email = emailBox.Text;
            String feedback = feedBox.Text;
            String qry = "Update Appointments set feedback = '" + feedback + "' where email = '" + email + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(qry, conn);
            conn.Open();

            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succesful");
            Doctor rq = new Doctor();
            this.Hide();
            rq.Show();
        }
    }
}
