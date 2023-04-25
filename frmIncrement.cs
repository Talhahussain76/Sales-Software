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
using System.Configuration;
using System.Web;

namespace TALHA_PROJECTS_PRACTICE
{
    public partial class frmIncrement : Form
    {
        int i;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public frmIncrement()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Save", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Insertbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into Table_5 values(@name,@company,@categroy,@price,@stalk)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@company", txtCompany.Text);
            cmd.Parameters.AddWithValue("@categroy", txtCategroy.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@stalk", txtStalk.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if(a > 0)
            {
                MessageBox.Show("Inserted");
                bindGridView();
            }
            else
            {
                MessageBox.Show("Not Inserted");
            }
            con.Close();

        }
        void bindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Table_5";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindGridView();
        }

        private void frmIncrement_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            i = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            txtName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtCompany.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtCategroy.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtPrice.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtStalk.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
         
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update Table_5 set NAME =@name, COMPANY=@company, CATEGORY=@categroy, PRICE=@price, STALK =@stalk where ID =@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id",i);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@company", txtCompany.Text);
            cmd.Parameters.AddWithValue("@categroy", txtCategroy.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@stalk", txtStalk.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Updated");
                bindGridView();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
            con.Close();

        }
    }
}
