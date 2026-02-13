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

namespace SchoolManagement
{
    public partial class Main : Form
    {
     

        public Main()
        {
            
            InitializeComponent();
           
        }

      
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you need to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // Close the form
            }
            else
            {
                // Do nothing, stay on the same page
            }
        }

        private void btnstudent_Click(object sender, EventArgs e)
        {
            students st = new students();
            st.Show();
        }

        private void btnsubject_Click(object sender, EventArgs e)
        {
            Subject sb = new Subject();
            sb.Show();
        }

        private void btnteacher_Click(object sender, EventArgs e)
        {
            teachers ts = new teachers();
            ts.Show();
        }

        private void btnsection_Click(object sender, EventArgs e)
        {
            Sections Se = new Sections();
            Se.Show();
        }

        private void btnenrollment_Click(object sender, EventArgs e)
        {
            Entrollment En = new Entrollment();
            En.Show();
        }

        private void btnattendance_Click(object sender, EventArgs e)
        {
            Attendance An = new Attendance();
            An.Show();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard Ds = new Dashboard();
            Ds.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
