using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace TALHA_PROJECTS_PRACTICE
{
    public partial class frmSignUp : Form
    {
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        string pass = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";

        public frmSignUp()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtSurname.Clear();
            Gender.SelectedItem = null;
            Class.Value = 0;
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) == true)
            {
                txtID.Focus();
                errorProvider1.SetError(this.txtID, "Please Fill This");
            }
            else if (string.IsNullOrEmpty(txtName.Text) == true)
            {
                txtName.Focus();
                errorProvider2.SetError(this.txtName, "Please Fill This");
            }
            else if (string.IsNullOrEmpty(txtFather.Text) == true)
            {
                txtName.Focus();
                errorProvider3.SetError(this.txtFather, "Please Fill This");
            }
            else if (string.IsNullOrEmpty(txtSurname.Text) == true)
            {
                txtName.Focus();
                errorProvider4.SetError(this.txtSurname, "Please Fill This");
            }
            else if (Gender.SelectedItem == null)
            {
                Gender.Focus();
                errorProvider5.SetError(this.Gender, "Please Fill This");
            }
            else if (Class.Value == 0)
            {
                Class.Focus();
                errorProvider6.SetError(this.Class, "Please Fill This");
            }
            else if (Regex.IsMatch(txtEmail.Text, pattern) == false)
            {
                txtEmail.Focus();
                errorProvider7.SetError(this.txtEmail, "Invalid Email");
            }
            else if (Regex.IsMatch(txtPassword.Text, pass) == false)
            {
                txtPassword.Focus();
                errorProvider8.SetError(this.txtPassword, "Hint=UPPER CASE, LOWERCASE, SYMBOLS, NUMERS, etc");
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                txtConfirmPassword.Focus();
                errorProvider9.SetError(this.txtConfirmPassword, "Password does not Match");
            }
            else
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                string query1 = "select * from signup where ID = @id";
                SqlCommand cmd2 = new SqlCommand(query1, con);
                cmd2.Parameters.AddWithValue("@id", txtID.Text);
                con.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show(txtID.Text + "ID Already Exist", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                else
                {
                    con.Close();
                    string query = "insert into SIGNUP values(@id, @name, @fname, @surname, @gender, @class, @email, @pass)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@fname", txtFather.Text);
                    cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@gender", Gender.SelectedItem);
                    cmd.Parameters.AddWithValue("@class", Class.Value);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Registered Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Registeration Fail", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    con.Close();

                }

            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) == true)
            {
                txtID.Focus();
                errorProvider1.SetError(this.txtID, "Please Fill This");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) == true)
            {
                txtName.Focus();
                errorProvider2.SetError(this.txtName, "Please Fill This");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtFather_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFather.Text) == true)
            {
                txtName.Focus();
                errorProvider3.SetError(this.txtFather, "Please Fill This");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void txtFather_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtSurname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSurname.Text) == true)
            {
                txtName.Focus();
                errorProvider4.SetError(this.txtSurname, "Please Fill This");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void Gender_Leave(object sender, EventArgs e)
        {
            if (Gender.SelectedItem == null)
            {
                Gender.Focus();
                errorProvider5.SetError(this.Gender, "Please Fill This");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void Class_Leave(object sender, EventArgs e)
        {
            if (Class.Value == 0)
            {
                Class.Focus();
                errorProvider6.SetError(this.Class, "Please Fill This");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtEmail.Text, pattern) == false)
            {
                txtEmail.Focus();
                errorProvider7.SetError(this.txtEmail, "Invalid Email");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtPassword.Text, pass) == false)
            {
                txtPassword.Focus();
                errorProvider8.SetError(this.txtPassword, "Hint=UPPER CASE, LOWERCASE, SYMBOLS, NUMERS, etc");
            }
            else
            {
                errorProvider8.Clear();
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                txtConfirmPassword.Focus();
                errorProvider9.SetError(this.txtConfirmPassword, "Password does not Match");
            }
            else
            {
                errorProvider9.Clear();
            }
        }
    }
}