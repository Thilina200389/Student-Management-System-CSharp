using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class loading : Form
    {
        public int s = 0;
        public loading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            if (pbar01.Value < 100)
            {
                pbar01.Value += 5;
                s++;
                label2.Text = s + "%";
            }
            else
            {
                timer1.Stop();

                this.Visible = false;

                Form Login = new Login();
                Login.Show();
            }

        }

        private void loading_Load(object sender, EventArgs e)
        {

        }
    }
}
