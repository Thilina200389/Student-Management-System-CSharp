using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public partial class teachers : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\schoolDB.mdf";

        public teachers()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtteid.Text, out int teacherID))
            {
                MessageBox.Show("Please enter a valid Teacher ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO teachers (TeacherID, TeacherName, Gender, Phone) VALUES(@TeacherID, @TeacherName, @Gender, @Phone)";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@TeacherID", teacherID);
                        cnn.Parameters.AddWithValue("@TeacherName", txttename.Text);
                        cnn.Parameters.AddWithValue("@Gender", txtgender.Text);
                        cnn.Parameters.AddWithValue("@Phone", txtphone.Text);

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
                using (SqlCommand cnn = new SqlCommand("select * from teachers", con))
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
            if (!int.TryParse(txtteid.Text, out int teacherID))
            {
                MessageBox.Show("Please enter a valid Teacher ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE teachers SET TeacherName=@TeacherName, Gender=@Gender, Phone=@Phone WHERE TeacherID=@TeacherID";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@TeacherID", teacherID);
                        cnn.Parameters.AddWithValue("@TeacherName", txttename.Text);
                        cnn.Parameters.AddWithValue("@Gender", txtgender.Text);
                        cnn.Parameters.AddWithValue("@Phone", txtphone.Text);

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
            txtteid.Text = "";
            txttename.Text = "";
            txtgender.Text = "";
            txtphone.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtteid.Text, out int teacherID))
            {
                MessageBox.Show("Please enter a valid Teacher ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM teachers WHERE TeacherID=@TeacherID";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        // FIX: Changed @StudentID parameter to correct @TeacherID parameter.
                        cnn.Parameters.AddWithValue("@TeacherID", teacherID);

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
                using (SqlCommand cnn = new SqlCommand("select * from teachers", con))
                using (SqlDataAdapter da = new SqlDataAdapter(cnn))
                {
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void teachers_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}