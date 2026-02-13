using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public partial class Dashboard : Form
    {
        // Standardized Connection String
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\schoolDB.mdf;Integrated Security=True";

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Call the centralized load method on startup
            LoadAllDashboardCounts();
        }

        // **NEW: Event to refresh counts whenever the dashboard regains focus**
        private void Dashboard_Activated(object sender, EventArgs e)
        {
            LoadAllDashboardCounts();
        }

        // **NEW: Centralized method to run all count queries**
        private void LoadAllDashboardCounts()
        {
            LoadStudentCount();
            LoadSubjectCount();
            LoadTeacherCount();
            LoadEnrollmentCount();
        }

        // Renamed display() for clarity
        private void LoadStudentCount()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM students", con))
                    {
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        lblstudents.Text = count > 0 ? Convert.ToString(count) : "0";
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error loading student count: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Renamed display1() for clarity
        private void LoadSubjectCount()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM subject", con))
                    {
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        // **FIXED LOGIC:** Now updates the correct label (lblsubjects)
                        lblsubjects.Text = count > 0 ? Convert.ToString(count) : "0";
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error loading subject count: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Renamed display2() for clarity
        private void LoadTeacherCount()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM teachers", con))
                    {
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        lblteachers.Text = count > 0 ? Convert.ToString(count) : "0";
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error loading teacher count: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Renamed display3() for clarity
        private void LoadEnrollmentCount()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Entroll", con))
                    {
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        lblentrollments.Text = count > 0 ? Convert.ToString(count) : "0";
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error loading enrollment count: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // This method is no longer needed/used after renaming and consolidating logic.
        private void UpdateCounts()
        {
            // Placeholder: Logic is now in LoadAllDashboardCounts()
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}