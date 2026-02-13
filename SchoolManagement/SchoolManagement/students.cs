using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public partial class students : Form
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\schoolDB.mdf";

        public students()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtstid.Text, out int studentID))
            {
                MessageBox.Show("Please enter a valid Student ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    // FIX: Changed 'studentdetails' to 'students'
                    string query = "INSERT INTO students (StudentID, StudentName, Dob, Gender, Phone, Email) VALUES(@StudentID, @StudentName, @Dob, @Gender, @Phone, @Email)";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@StudentID", studentID);
                        cnn.Parameters.AddWithValue("@StudentName", txtstname.Text);
                        cnn.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
                        cnn.Parameters.AddWithValue("@Gender", txtgender.Text);
                        cnn.Parameters.AddWithValue("@Phone", txtphone.Text);
                        cnn.Parameters.AddWithValue("@Email", txtemail.Text);

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
                // FIX: Changed 'studentdetails' to 'students'
                using (SqlCommand cnn = new SqlCommand("select * from students", con))
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
            if (!int.TryParse(txtstid.Text, out int studentID))
            {
                MessageBox.Show("Please enter a valid Student ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    // FIX: Changed 'studentdetails' to 'students'
                    string query = "UPDATE students SET StudentName=@StudentName, Dob=@Dob, Gender=@Gender, Phone=@Phone, Email=@Email WHERE StudentID=@StudentID";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@StudentID", studentID);
                        cnn.Parameters.AddWithValue("@StudentName", txtstname.Text);
                        cnn.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
                        cnn.Parameters.AddWithValue("@Gender", txtgender.Text);
                        cnn.Parameters.AddWithValue("@Phone", txtphone.Text);
                        cnn.Parameters.AddWithValue("@Email", txtemail.Text);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtstid.Text, out int studentID))
            {
                MessageBox.Show("Please enter a valid Student ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    // FIX: Changed 'studentdetails' to 'students'
                    string query = "DELETE FROM students WHERE StudentID=@StudentID";
                    using (SqlCommand cnn = new SqlCommand(query, con))
                    {
                        cnn.Parameters.AddWithValue("@StudentID", studentID);

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

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtstid.Text = "";
            txtstname.Text = "";
            txtgender.Text = "";
            txtphone.Text = "";
            txtemail.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                // FIX: Changed 'studentdetails' to 'students'
                using (SqlCommand cnn = new SqlCommand("select * from students", con))
                using (SqlDataAdapter da = new SqlDataAdapter(cnn))
                {
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void students_Load(object sender, EventArgs e)
        {

        }
    }
}