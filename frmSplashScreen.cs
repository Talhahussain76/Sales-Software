using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TALHA_PROJECTS_PRACTICE
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if(progressBar1.Value == 100)
            {
                timer1.Stop();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 20;


            if (progressBar1.Value == timer1.Interval)

            {
                timer1.Interval = 1;
                timer1.Enabled = false;
                progressBar1.Value = 0;
                goto ExitPro;
            ExitPro: { progressBar1.Visible = false; }

            }


        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 100;
            progressBar1.Maximum = 100;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
