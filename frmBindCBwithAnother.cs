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
    public partial class frmBindCBwithAnother : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        DataRow dr;
        public frmBindCBwithAnother()
        {
            InitializeComponent();
            BindTechnolgyCombo();
        }

        private void frmBindCBwithAnother_Load(object sender, EventArgs e)
        {
            
        }
        void BindTechnolgyCombo()
        {
            SqlConnection con = new SqlConnection(cs);
            string query1 = "select * from TECHNOLOGIES_2";
            SqlDataAdapter sda = new SqlDataAdapter(query1,con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "Select Technology" };
            dt.Rows.InsertAt(dr, 0);
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "TECH_ID";
            comboBox1.DataSource = dt;
        }

        void BindTypesCombo(int TechId)
        {
            SqlConnection con = new SqlConnection(cs);
            string query1 = "select * from TYPES_2 where TECH_ID = @T_Id";
            SqlDataAdapter sda = new SqlDataAdapter(query1, con);
            sda.SelectCommand.Parameters.AddWithValue("T_Id", TechId);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "Select Types" };
            dt.Rows.InsertAt(dr, 0);
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "TYPE_ID";
            comboBox2.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue.ToString() != null)
            {
                int TechId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                BindTypesCombo(TechId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Success","Message Box",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
