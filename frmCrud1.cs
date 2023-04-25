using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.IO;
using TALHA_PROJECTS_PRACTICE.Properties;

namespace TALHA_PROJECTS_PRACTICE
{
    public partial class frmCrud1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public frmCrud1()
        {
            InitializeComponent();
        }

        private void frmCrud1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void browsebutton_Click(object sender, EventArgs e)
        {
           
        }


        private byte[] Savephoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
        void bindGridView1()
        {
            SqlConnection con = new SqlConnection(cs);
            string query1 = "select * from Table_4";
            SqlDataAdapter dsa = new SqlDataAdapter(query1, con);
            DataTable dt = new DataTable();
            dsa.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[7];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;


        }

        private void resertbutton_Click(object sender, EventArgs e)
        {

        }
        void resetcontrols()
        {
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            GenderCOMBO.SelectedItem = null;
            txtEmail.Clear();
            txtPostal.Clear();
            txtAddress.Clear();
            pictureBox1.Image = Resources.pngtree_no_photo_icon_png_image_1557651;
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtPhone.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            GenderCOMBO.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtPostal.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtAddress.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            pictureBox1.Image = Getphoto((byte[])dataGridView1.SelectedRows[0].Cells[7].Value);

        }

        private Image Getphoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
           
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                txtID.Focus();
                errorProvider1.SetError(this.txtID, "Please Enter ID");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtID.Focus();
                errorProvider2.SetError(this.txtName, "Please Enter Name");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.Focus();
                errorProvider3.SetError(this.txtPhone, "Please Enter PhoneNo");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.Focus();
                errorProvider4.SetError(this.txtEmail, "Please Enter Email");
            }
            else
            {
                errorProvider4.Clear();
            }

        }

        private void GenderCOMBO_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GenderCOMBO.Text))
            {
                GenderCOMBO.Focus();
                errorProvider5.SetError(this.GenderCOMBO, "Please Enter Gender");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void txtPostal_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPostal.Text))
            {
                txtPostal.Focus();
                errorProvider6.SetError(this.txtPostal, "Please Enter Postal Code");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                txtAddress.Focus();
                errorProvider7.SetError(this.txtAddress, "Please Enter Address");
            }
            else
            {
                errorProvider7.Clear();
            }
        }
        private void txtBasicPay_TextChanged(object sender, EventArgs e)
        {
            int MA, HR, CA, grosspay, IT, NT;
            int basicpay = 0;

            if (string.IsNullOrEmpty(txtBasicPay.Text))
            {
                txtBasicPay.Focus();
                errorProvider8.SetError(this.txtBasicPay, "Please Fill the Field");
            }
            else
            {
                errorProvider8.Clear();
                basicpay = Convert.ToInt32((txtBasicPay.Text));
            }

            if (basicpay >= 40000)
            {
                CA = (int)(basicpay * 0.40);
                txtConvienence.Text = CA.ToString();
                MA = (int)(basicpay * 0.30);
                txtMedical.Text = MA.ToString();
                HR = (int)(basicpay * 0.20);
                txtHouseRent.Text = HR.ToString();
                grosspay = basicpay + MA + HR + CA;
                txtGrossPay.Text = grosspay.ToString();

                if (grosspay >= 60000)
                {
                    IT = (int)(grosspay * 0.03);
                    txtIncomeTax.Text = IT.ToString();
                    NT = grosspay - IT;
                    txtSalary.Text = NT.ToString();
                }
                else if (grosspay >= 50000)
                {
                    IT = (int)(grosspay * 0.02);
                    txtIncomeTax.Text = IT.ToString();
                    NT = grosspay - IT;
                    txtSalary.Text = NT.ToString();
                }
            }
            else if (basicpay >= 30000)
            {
                CA = (int)(basicpay * 0.35);
                txtConvienence.Text = CA.ToString();
                MA = (int)(basicpay * 0.25);
                txtMedical.Text = MA.ToString();
                HR = (int)(basicpay * 0.15);
                txtHouseRent.Text = HR.ToString();
                grosspay = basicpay + MA + HR + CA;
                txtGrossPay.Text = grosspay.ToString();

                if (grosspay >= 60000)
                {
                    IT = (int)(grosspay * 0.03);
                    txtIncomeTax.Text = IT.ToString();
                    NT = grosspay - IT;
                    txtSalary.Text = NT.ToString();
                }
                else if (grosspay >= 50000)
                {
                    IT = (int)(grosspay * 0.02);
                    txtIncomeTax.Text = IT.ToString();
                    NT = grosspay - IT;
                    txtSalary.Text = NT.ToString();
                }
            }
            else
            {
                CA = 3000;
                txtConvienence.Text = CA.ToString();
                MA = 2000;
                txtMedical.Text = MA.ToString();
                HR = 1000;
                txtHouseRent.Text = HR.ToString();
                grosspay = basicpay + MA + HR + CA;
                txtGrossPay.Text = grosspay.ToString();


                txtIncomeTax.Text = "No Tax Applied";
                NT = grosspay;
                txtSalary.Text = NT.ToString();
            }
        }

        private void txtBasicPay_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBasicPay.Text))
            {
                txtBasicPay.Focus();
                errorProvider8.SetError(this.txtBasicPay, "Please Enter BasicPay");
            }
            else
            {
                errorProvider8.Clear();
            }
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolstripinsertbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query3 = "select * from Table_4 where ID = @id";
            SqlCommand cmd2 = new SqlCommand(query3, con);
            cmd2.Parameters.AddWithValue("@id", txtID.Text);
            con.Open();
            SqlDataReader dr = cmd2.ExecuteReader();

            if (dr.HasRows == true)
            {
                MessageBox.Show(txtID.Text + "Id Already Exists", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            else
            {
                con.Close();

                string query = "insert into Table_4 values(@id,@name,@phoneno,@email,@gender,@postalcode,@address,@image)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@phoneno", txtPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@gender", GenderCOMBO.SelectedItem);
                cmd.Parameters.AddWithValue("@postalcode", txtPostal.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@image", Savephoto());


                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindGridView1();
                    resetcontrols();

                }
                else
                {
                    MessageBox.Show("Inserted Failure", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();
            }
        }

        private void insertbutton_Click(object sender, EventArgs e)
        {

        }

        private void toolStripUpdatebtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "update Table_4 set ID = @id, NAME = @name, PHONENO = @phoneno, EMAIL = @email, GENDER = @gender, POSTALCODE = @postalcode, ADDRESS = @address, IMAGE = @image where ID = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@phoneno", txtPhone.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@gender", GenderCOMBO.SelectedItem);
            cmd.Parameters.AddWithValue("@postalcode", txtPostal.Text);
            cmd.Parameters.AddWithValue("@address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@image", Savephoto());
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView1();
                resetcontrols();

            }
            else
            {
                MessageBox.Show("Update Failure", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        private void toolStripDeletebtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "delete from Table_4 where ID = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@phoneno", txtPhone.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@gender", GenderCOMBO.SelectedItem);
            cmd.Parameters.AddWithValue("@postalcode", txtPostal.Text);
            cmd.Parameters.AddWithValue("@address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@image", Savephoto());
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView1();
                resetcontrols();

            }
            else
            {
                MessageBox.Show("Deletion Failure", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        private void toolStripViewbtn_Click(object sender, EventArgs e)
        {
            bindGridView1();
        }

        private void toolStripResetbtn_Click(object sender, EventArgs e)
        {
            resetcontrols();
        }

        private void toolStripBrowsebtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "PNG FILE (*.png) | *.png|JPG FILE (*.jpg) | *.jpg|GIF FILE (*.gif) | *.gif|BMP FILE (*.bmp) | *.bmp|All files (*.*)|*.*";
            ofd.Filter = "Image File (*.png;*.jpg;*.bmp; *.gif;) | *.png;*.jpg;*.bmp;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void toolStripSearchbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Table_4 where NAME like @name + '%'";
            SqlDataAdapter dsa = new SqlDataAdapter(query, con);
            dsa.SelectCommand.Parameters.AddWithValue("@name", txtSearch.Text.Trim());
            DataTable dt = new DataTable();
            dsa.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
    }






