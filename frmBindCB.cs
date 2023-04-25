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

namespace TALHA_PROJECTS_PRACTICE
{
    public partial class frmBindCB : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public frmBindCB()
        {
            InitializeComponent();
        }

        private void frmBindCB_Load(object sender, EventArgs e)
        {
            BindComboBox();
        }
        void BindComboBox()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Table_School";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string name = dr.GetString(1);
                PostCombo.Items.Add(name);
            }

            con.Close();
        }
    }
}
