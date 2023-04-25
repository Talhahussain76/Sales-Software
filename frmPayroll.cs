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
    public partial class frmPayroll : Form
    {
        public frmPayroll()
        {
            InitializeComponent();
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
                txtName.Focus();
                errorProvider2.SetError(this.txtName, "Please Enter Name");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void txtDesignation_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDesignation.Text))
            {
                txtDesignation.Focus();
                errorProvider3.SetError(this.txtDesignation, "Please Enter Designation");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void txtBasicPay_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBasicPay.Text))
            {
                txtBasicPay.Focus();
                errorProvider4.SetError(this.txtBasicPay, "Please Enter Basic Pay");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void txtBasicPay_TextChanged(object sender, EventArgs e)
        {
            int CA, MA, HR, grosspay, IT, NT;
            int BasicPay = Convert.ToInt32(txtBasicPay.Text);
            if (BasicPay >= 40000)
            {
                CA = (int)(BasicPay * 0.40);
                txtConvienence.Text = CA.ToString();
                MA = (int)(BasicPay * 0.30);
                txtMedical.Text = MA.ToString();
                HR = (int)(BasicPay * 0.20);
                txtHouseRent.Text = HR.ToString();
                grosspay = BasicPay + HR + MA + CA;
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
                if (BasicPay >= 30000)
                {
                    CA = (int)(BasicPay * 0.35);
                    txtConvienence.Text = CA.ToString();
                    MA = (int)(BasicPay * 0.25);
                    txtMedical.Text = MA.ToString();
                    HR = (int)(BasicPay * 0.15);
                    txtHouseRent.Text = HR.ToString();
                    grosspay = BasicPay + HR + MA + CA;
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
                else
                  {
                        CA = 3000;
                        txtConvienence.Text = CA.ToString();
                        MA = 2000;
                        txtMedical.Text = MA.ToString();
                        HR = 1000;
                        txtHouseRent.Text = HR.ToString();
                        grosspay = BasicPay + HR + MA + CA;
                        txtGrossPay.Text = grosspay.ToString();

                        txtIncomeTax.Text = "No Tax Applied";
                        NT = grosspay;
                        txtSalary.Text = NT.ToString();
                    }
                }


            }
           
        }
    }
}
