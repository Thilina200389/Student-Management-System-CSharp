using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public partial class Attendance : Form
    {
        // Standardized Connection String
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\schoolDB.mdf";

        public Attendance()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cnn = new SqlCommand("select * from Attendance", con))
                using (SqlDataAdapter da = new SqlDataAdapter(cnn))
                {
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtaid.Text, out int attendanceID))
            {
                MessageBox.Show("Please enter a valid Attendance ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Attendance (AID, StudentName, Status) VALUES(@AID, @StudentName, @Status)";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@AID", attendanceID);
                        cnn.Parameters.AddWithValue("@StudentName", txtstname.Text);
                        cnn.Parameters.AddWithValue("@Status", txtstatus.Text);

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtaid.Text, out int attendanceID))
            {
                MessageBox.Show("Please enter a valid Attendance ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE Attendance SET StudentName=@StudentName, Status=@Status WHERE AID=@AID";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@AID", attendanceID);
                        cnn.Parameters.AddWithValue("@StudentName", txtstname.Text);
                        cnn.Parameters.AddWithValue("@Status", txtstatus.Text);

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
            txtaid.Text = "";
            txtstname.Text = "";
            txtstatus.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtaid.Text, out int attendanceID))
            {
                MessageBox.Show("Please enter a valid Attendance ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM Attendance WHERE AID=@AID";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@AID", attendanceID);

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
            // Fixed connection string typo
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cnn = new SqlCommand("select * from Attendance", con))
                using (SqlDataAdapter da = new SqlDataAdapter(cnn))
                {
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Attendance_Load(object sender, EventArgs e)
        {

        }
    }
}