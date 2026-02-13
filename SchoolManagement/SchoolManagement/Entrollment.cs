using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public partial class Entrollment : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\schoolDB.mdf";

        public Entrollment()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy"; // Note: 'MM' for month is typically safer than 'mm'
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker2.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txteid.Text, out int enrollmentID))
            {
                MessageBox.Show("Please enter a valid Enrollment ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Entroll (EID, StudentName, Section, EntrollDate) VALUES(@EID, @StudentName, @Section, @EntrollDate)";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@EID", enrollmentID);
                        cnn.Parameters.AddWithValue("@StudentName", txtstname.Text);
                        cnn.Parameters.AddWithValue("@Section", txtsection.Text);
                        cnn.Parameters.AddWithValue("@EntrollDate", dateTimePicker2.Value);

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
                using (SqlCommand cnn = new SqlCommand("select * from Entroll", con))
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
            if (!int.TryParse(txteid.Text, out int enrollmentID))
            {
                MessageBox.Show("Please enter a valid Enrollment ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE Entroll SET StudentName=@StudentName, Section=@Section, EntrollDate=@EntrollDate WHERE EID=@EID";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@EID", enrollmentID);
                        cnn.Parameters.AddWithValue("@StudentName", txtstname.Text);
                        cnn.Parameters.AddWithValue("@Section", txtsection.Text);
                        cnn.Parameters.AddWithValue("@EntrollDate", dateTimePicker2.Value);

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
            txteid.Text = "";
            txtstname.Text = "";
            txtsection.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txteid.Text, out int enrollmentID))
            {
                MessageBox.Show("Please enter a valid Enrollment ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM Entroll WHERE EID=@EID";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@EID", enrollmentID);

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
                using (SqlCommand cnn = new SqlCommand("select * from Entroll", con))
                using (SqlDataAdapter da = new SqlDataAdapter(cnn))
                {
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}