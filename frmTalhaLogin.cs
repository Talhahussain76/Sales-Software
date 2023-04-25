using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace TALHA_PROJECTS_PRACTICE
{
    public partial class frmTalhaLogin : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public frmTalhaLogin()
        {
            InitializeComponent();
        }

        private void frmTalhaLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Table_6 where USERNAME = @user and PASSWORD = @pass";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", txtUsername.Text);
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                MessageBox.Show("Login Successfull", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCrud1 frmCrud1 = new frmCrud1();
                frmCrud1.Show();


            }
            else
            {
                MessageBox.Show("Login Failed", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;

            switch (check)
            {
                case true:
                    txtPassword.UseSystemPasswordChar = false;
                    break;

                default:
                    txtPassword.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSignUp s = new frmSignUp();
            s.Show();
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Focus();
                errorProvider1.SetError(this.txtUsername, "Please Enter username");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                errorProvider2.SetError(this.txtPassword, "Please Enter Password");
            }
            else
            {
                errorProvider2.Clear();
            }
        }
    }
}
