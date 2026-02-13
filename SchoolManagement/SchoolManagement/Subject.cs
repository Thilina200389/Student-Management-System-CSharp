using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public partial class Subject : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\schoolDB.mdf";

        public Subject()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtsubid.Text, out int subjectID))
            {
                MessageBox.Show("Please enter a valid Subject ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Subject (SubjectID, SubjectName) VALUES(@SubjectID, @SubjectName)";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@SubjectID", subjectID);
                        cnn.Parameters.AddWithValue("@SubjectName", txtsubname.Text);

                        cnn.ExecuteNonQuery();
                        MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cnn = new SqlCommand("select * from Subject", con))
                using (SqlDataAdapter da = new SqlDataAdapter(cnn))
                {
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtsubid.Text, out int subjectID))
            {
                MessageBox.Show("Please enter a valid Subject ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE Subject SET SubjectName=@SubjectName WHERE SubjectID=@SubjectID";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@SubjectID", subjectID);
                        cnn.Parameters.AddWithValue("@SubjectName", txtsubname.Text);

                        cnn.ExecuteNonQuery();
                        MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtsubid.Text = "";
            txtsubname.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtsubid.Text, out int subjectID))
            {
                MessageBox.Show("Please enter a valid Subject ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM Subject WHERE SubjectID=@SubjectID";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@SubjectID", subjectID);

                        cnn.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cnn = new SqlCommand("select * from Subject", con))
                using (SqlDataAdapter da = new SqlDataAdapter(cnn))
                {
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
        }
    }
}