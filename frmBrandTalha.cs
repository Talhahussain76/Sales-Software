using ADODB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TALHA_PROJECTS_PRACTICE
{
    public partial class frmBrandTalha : Form
    {
        public frmBrandTalha()
        {
            InitializeComponent();
        }
        //SqlDataReader RsBrand;
        SqlCommand cmd;
        string SqlQuery;

        DataTable Dt;

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image File (*.png;*.jpg;*.bmp; *.gif;*.jpeg;) | *.png;*.jpg;*.bmp;*.gif;*.jpeg;)";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }


        }
        void visiblegridview()
        {
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;

        }
        void RecordSetOpen()
        {
            DataSet TalhaBrand = new DataSet();

            Dt = TalhaBrand.Tables.Add("Items");

            SqlDataAdapter Sda = new SqlDataAdapter("Select * from Items Order by Barcode Desc", TalhaConnectionstring.conn);

            // 'Fill the DataTable with records from Table.

            Sda.Fill(TalhaBrand, "Items");

            if (Dt.Rows.Count > 0)
            {
                //Settings Data source nothing

                txtBarCode.DataBindings.Clear();
                txtBarCodeInCharacter.DataBindings.Clear();
                txtItemName.DataBindings.Clear();
                txtPurchasePrice.DataBindings.Clear();
                txtSalesPrice.DataBindings.Clear();
                txtDiscount.DataBindings.Clear();
                txtDiscountCategory.DataBindings.Clear();
                txtAmountAfterDiscount.DataBindings.Clear();

                //Now setting data source

                txtBarCode.DataBindings.Add("Text", Dt, "Barcode");
                txtBarCodeInCharacter.DataBindings.Add("Text", Dt, "BarCodeInCharacter");
                txtItemName.DataBindings.Add("Text", Dt, "ItemDescription");
                txtPurchasePrice.DataBindings.Add("Text", Dt, "PurchasePrice");
                txtSalesPrice.DataBindings.Add("Text", Dt, "SalesPrice");
                txtDiscount.DataBindings.Add("Text", Dt, "Discount");
                txtDiscountCategory.DataBindings.Add("Text", Dt, "DiscountType");
                txtAmountAfterDiscount.DataBindings.Add("Text", Dt, "SalesPriceAfterDiscount");

                dataGridView1.DataSource = Dt;

                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                //dgv = (DataGridViewImageColumn)dataGridView1.Columns[23];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 30;

                toolStripButtonCancel.Enabled = false;
                toolStripButtonCancelEdit.Enabled = false;
            }
            else
            {
                txtBarCode.Clear();
                txtItemName.Clear();
                txtPurchasePrice.Clear();
                txtSalesPrice.Clear();
                txtAmountAfterDiscount.Clear();
                txtDiscount.Clear();
                txtDiscountCategory.Clear();
                txtBarCodeInCharacter.Clear();

                toolStripButtonNewRecord.Enabled = true;
                toolStripButtonCancel.Enabled = false;
                toolStripButtonSave.Enabled = false;
                toolStripButtonSearch.Enabled = false;
                toolStripButtonEdit.Enabled = false;
                toolStripButtonDelete.Enabled = false;
                toolStripButtonCancelEdit.Enabled = false;

                dataGridView1.DataSource = Dt;
            }
            visiblegridview();
        }

        private void frmBrandTalha_Load(object sender, EventArgs e)
        {
            ConnectDatabasePos.MainTalha();
            RecordSetOpen();

            CmbDiscountCategory.Visible = false;
            toolStripSearchBarCode.Enabled = false;
            toolStripTextBoxItemName.Enabled = false;
            toolStripButtonExitSearch.Enabled = false;
            toolStripButtonSearch.Enabled = true;
        }

        private void toolStripButtonNewRecord_Click(object sender, EventArgs e)
        {
            txtBarCode.Clear();
            txtItemName.Clear();
            txtPurchasePrice.Clear();
            txtSalesPrice.Clear();
            txtAmountAfterDiscount.Clear();
            txtDiscountCategory.Clear();
            txtBarCodeInCharacter.Clear();


            CmbDiscountCategory.Visible = true;

            GetNewCode();
            CmbFillDiscountCategory();


            toolStripButtonNewRecord.Enabled = false;
            toolStripButtonCancel.Enabled = true;
            toolStripButtonSave.Enabled = true;
            toolStripButtonSearch.Enabled = false;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            toolStripButtonCancelEdit.Enabled = false;

            txtDiscount.Clear();




        }
        void GetNewCode()
        {
            ConnectADODBPos.MainSyed();
            string GetCode;
            ADODB.Recordset Rs;

            Rs = new ADODB.Recordset();
            string SqlQry = "Select isNull(max(Barcode), null) as G from Items";
            Rs.Open(SqlQry, TalhaConnectionString.DataBaseConnection, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockPessimistic);

            bool GetRecCountVal = Convert.ToBoolean(Convert.IsDBNull(Rs.Fields[0].Value));
            if (GetRecCountVal == true)
            {
                GetCode = Convert.ToString(1);
                txtBarCode.Text = GetCode.ToString();
            }
            else
            {
                GetCode = Convert.ToString(Rs.Fields[0].Value + 1);
                txtBarCode.Text = GetCode.ToString();
            }
            string GetTextData;
            int CharLength;

            GetTextData = txtBarCode.Text;
            CharLength = GetTextData.Length;

            switch (CharLength)
            {
                case 1:
                    GetTextData = Convert.ToString("00000") + txtBarCode.Text + "/BC";
                    txtBarCodeInCharacter.Text = GetTextData.ToString();
                    break;

                case 2:
                    GetTextData = Convert.ToString("0000") + txtBarCode.Text + "/BC";
                    txtBarCodeInCharacter.Text = GetTextData.ToString();
                    break;

                case 3:
                    GetTextData = Convert.ToString("000") + txtBarCode.Text + "/BC";
                    txtBarCodeInCharacter.Text = GetTextData.ToString();
                    break;

                case 4:
                    GetTextData = Convert.ToString("00") + txtBarCode.Text + "/BC";
                    txtBarCodeInCharacter.Text = GetTextData.ToString();
                    break;

                case 5:
                    GetTextData = Convert.ToString("0") + txtBarCode.Text + "/BC";
                    txtBarCodeInCharacter.Text = GetTextData.ToString();
                    break;

                case 6:
                    GetTextData = txtBarCode.Text + "/BC";
                    txtBarCodeInCharacter.Text = GetTextData.ToString();
                    break;
            }
            txtItemName.Focus();
        }
        void CmbFillDiscountCategory()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from DiscountType", TalhaConnectionstring.conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            CmbDiscountCategory.DataSource = dt;
            CmbDiscountCategory.DisplayMember = "AmountType";
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter the name of item ", "Empty Value");
                txtItemName.Focus();
                goto ExitClickEvent;
            }
            else if (txtPurchasePrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the purchase price ", "Empty Value");
                txtPurchasePrice.Focus();
                goto ExitClickEvent;
            }
            else if (txtSalesPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the Sales price ", "Empty Value");
                txtPurchasePrice.Focus();
                goto ExitClickEvent;
            }
            else if (txtDiscount.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the Discount ", "Empty Value");
                txtPurchasePrice.Focus();
                goto ExitClickEvent;
            }
            else if (txtDiscountCategory.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the Discount Category ", "Empty Value");
                CmbDiscountCategory.Focus();
                goto ExitClickEvent;
            }
            else if (txtAmountAfterDiscount.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the Amount after the discount ", "Empty Value");
                txtAmountAfterDiscount.Focus();
                goto ExitClickEvent;
            }
            InsertQuery();


            toolStripButtonNewRecord.Enabled = true;
            toolStripButtonCancel.Enabled = false;
            toolStripButtonSave.Enabled = false;
            toolStripButtonSearch.Enabled = true;
            toolStripButtonEdit.Enabled = true;
            toolStripButtonDelete.Enabled = true;
            toolStripButtonCancelEdit.Enabled = true;

            CmbDiscountCategory.Visible = false;

            RecordSetOpen();


        ExitClickEvent: { }
        }

        void InsertQuery()
        {
            SqlQuery = "Insert into Items (Barcode,ItemDescription,PurchasePrice,SalesPrice,Discount,DiscountType,SalesPriceAfterDiscount,BarCodeInCharacter,CompanyLogo)Values(@Barcode,@ItemDescription,@PurchasePrice,@SalesPrice,@Discount,@DiscountType,@SalesPriceAfterDiscount,@BarCodeInCharacter,@CompanyLogo)";

            cmd = new SqlCommand(SqlQuery, TalhaConnectionstring.conn);

            cmd.Parameters.AddWithValue("@Barcode", Convert.ToDecimal(txtBarCode.Text));
            cmd.Parameters.AddWithValue("@ItemDescription", txtItemName.Text);
            cmd.Parameters.AddWithValue("@SalesPrice", Convert.ToDecimal(txtSalesPrice.Text));
            cmd.Parameters.AddWithValue("@PurchasePrice", Convert.ToDecimal(txtPurchasePrice.Text));
            cmd.Parameters.AddWithValue("@Discount", Convert.ToDecimal(txtDiscount.Text));
            cmd.Parameters.AddWithValue("@DiscountType", CmbDiscountCategory.Text);
            cmd.Parameters.AddWithValue("@SalesPriceAfterDiscount", Convert.ToDecimal(txtAmountAfterDiscount.Text));
            cmd.Parameters.AddWithValue("@BarCodeInCharacter", txtBarCodeInCharacter.Text);
            cmd.Parameters.AddWithValue("@CompanyLogo", SavePhoto());

            cmd.ExecuteNonQuery();
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
        private Image Getphoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            toolStripButtonNewRecord.Enabled = true;
            toolStripButtonCancel.Enabled = false;
            toolStripButtonSave.Enabled = false;
            toolStripButtonSearch.Enabled = true;
            toolStripButtonEdit.Enabled = true;
            toolStripButtonDelete.Enabled = true;
            toolStripButtonCancelEdit.Enabled = true;

            txtDiscountCategory.Visible = true;
            CmbDiscountCategory.Visible = false;

            RecordSetOpen();
        }

        private void CmbDiscountCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDiscountCategory.Text = CmbDiscountCategory.Text;

                if (toolStripButtonSave.Enabled == true || toolStripButtonEdit.Text == "Save Editing")
                {
                    if (CmbDiscountCategory.Text.Trim() == "Amount")
                    {
                        txtAmountAfterDiscount.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtSalesPrice.Text), 1) - Convert.ToDecimal(txtDiscount.Text));
                        txtDiscountCategory.Text = CmbDiscountCategory.Text;
                    }
                    else if (CmbDiscountCategory.Text == "Percentage")
                    {
                        txtAmountAfterDiscount.Text = Convert.ToString((Convert.ToDecimal(txtDiscount.Text) * Convert.ToDecimal(txtSalesPrice.Text)) / 100);
                        txtAmountAfterDiscount.Text = Convert.ToString(Convert.ToDecimal(txtSalesPrice.Text) - Convert.ToDecimal(txtAmountAfterDiscount.Text));
                        txtDiscountCategory.Text = CmbDiscountCategory.Text;
                    }
                }

            }
            catch (Exception ex)

            { goto ExitNow; }

        ExitNow: { }

        }
        void UpdateRecord()
        {
            SqlQuery = "update Items set PurchasePrice=@PurchasePrice, SalesPrice=@SalesPrice, Discount=@Discount, " +
                "DiscountType=@DiscountType, SalesPriceAfterDiscount=@SalesPriceAfterDiscount, CompanyLogo=@CompanyLogo where BarCode=@BarCode";

            cmd = new SqlCommand(SqlQuery, TalhaConnectionstring.conn);
            cmd.Parameters.AddWithValue("@BarCode", txtBarCode.Text);
            cmd.Parameters.AddWithValue("@PurchasePrice", txtPurchasePrice.Text);
            cmd.Parameters.AddWithValue("@SalesPrice", txtSalesPrice.Text);
            cmd.Parameters.AddWithValue("@Discount", txtDiscount.Text);
            cmd.Parameters.AddWithValue("@DiscountType", txtDiscountCategory.Text);
            cmd.Parameters.AddWithValue("@SalesPriceAfterDiscount", txtAmountAfterDiscount.Text);
            cmd.Parameters.AddWithValue("@CompanyLogo", SavePhoto());

            cmd.ExecuteNonQuery();

        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you like to Edit this Record .....?", "Confirm Editing", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UpdateRecord();

                toolStripButtonNewRecord.Enabled = false;
                toolStripButtonCancel.Enabled = false;
                toolStripButtonSave.Enabled = false;
                toolStripButtonSearch.Enabled = false;
                toolStripButtonEdit.Enabled = true;
                toolStripButtonDelete.Enabled = false;
                toolStripButtonCancelEdit.Enabled = true;
                CmbDiscountCategory.Visible = true;
                CmbFillDiscountCategory();

                if (toolStripButtonEdit.Text == "Save Editing")
                {
                    toolStripButtonEdit.Text = "Edit";
                    MessageBox.Show("Your Data is Successfully Updated", "Success");

                    toolStripButtonNewRecord.Enabled = true;
                    toolStripButtonCancel.Enabled = false;
                    toolStripButtonSave.Enabled = false;
                    toolStripButtonSearch.Enabled = true;
                    toolStripButtonEdit.Enabled = true;
                    toolStripButtonDelete.Enabled = true;
                    toolStripButtonCancelEdit.Enabled = false;
                    CmbDiscountCategory.Visible = false;

                    RecordSetOpen();
                }
                else
                {
                    txtPurchasePrice.Focus();
                    toolStripButtonEdit.Text = "Edit";
                }
            }
            else
            {
                toolStripButtonNewRecord.Enabled = true;
                toolStripButtonCancel.Enabled = false;
                toolStripButtonSave.Enabled = false;
                toolStripButtonSearch.Enabled = true;
                toolStripButtonEdit.Enabled = true;
                toolStripButtonDelete.Enabled = true;
                toolStripButtonCancelEdit.Enabled = false;

                toolStripButtonEdit.Text = "Edit";
            }
        }

         void DeleteRecord()
        {
            SqlQuery = "Delete from Items where Barcode=" + txtBarCode.Text;
            cmd = new SqlCommand(SqlQuery, TalhaConnectionstring.conn);

            cmd.ExecuteNonQuery();
        }
        private void toolStripButtonCancelEdit_Click(object sender, EventArgs e)
        {
            toolStripButtonNewRecord.Enabled = true;
            toolStripButtonCancel.Enabled = false;
            toolStripButtonSave.Enabled = false;
            toolStripButtonSearch.Enabled = true;
            toolStripButtonEdit.Enabled = true;
            toolStripButtonDelete.Enabled = true;
            toolStripButtonCancelEdit.Enabled = true;

            txtDiscountCategory.Visible = true;
            CmbDiscountCategory.Visible = false;

            toolStripButtonEdit.Text = "Edit";

            RecordSetOpen();

        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you like to Delete the Record.?","Deletion",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteRecord();
                RecordSetOpen();
            }
        }

        private void toolStripSearchBarCode_Click(object sender, EventArgs e)
        {

        }
        void Searchfrombarcode()
        {
            DataSet TalhaBrand = new DataSet();

            Dt = TalhaBrand.Tables.Add("Items");

            SqlDataAdapter Sda = new SqlDataAdapter("Select * from Items where Barcode like'" +Convert.ToInt32(toolStripSearchBarCode.Text)+ "'",TalhaConnectionstring.conn);

            // 'Fill the DataTable with records from Table.

            Sda.Fill(TalhaBrand, "Items");

            if (Dt.Rows.Count > 0)
            {
                //Settings Data source nothing

                txtBarCode.DataBindings.Clear();
                txtBarCodeInCharacter.DataBindings.Clear();
                txtItemName.DataBindings.Clear();
                txtPurchasePrice.DataBindings.Clear();
                txtSalesPrice.DataBindings.Clear();
                txtDiscount.DataBindings.Clear();
                txtDiscountCategory.DataBindings.Clear();
                txtAmountAfterDiscount.DataBindings.Clear();

                //Now setting data source

                txtBarCode.DataBindings.Add("Text", Dt, "Barcode");
                txtBarCodeInCharacter.DataBindings.Add("Text", Dt, "BarCodeInCharacter");
                txtItemName.DataBindings.Add("Text", Dt, "ItemDescription");
                txtPurchasePrice.DataBindings.Add("Text", Dt, "PurchasePrice");
                txtSalesPrice.DataBindings.Add("Text", Dt, "SalesPrice");
                txtDiscount.DataBindings.Add("Text", Dt, "Discount");
                txtDiscountCategory.DataBindings.Add("Text", Dt, "DiscountType");
                txtAmountAfterDiscount.DataBindings.Add("Text", Dt, "SalesPriceAfterDiscount");

                dataGridView1.DataSource = Dt;


                toolStripButtonCancel.Enabled = false;
                toolStripButtonCancelEdit.Enabled = false;
            }
        }

        private void toolStripSearchBarCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Searchfrombarcode();
            }
            catch(Exception ex)
            {
                //dd
            }
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            toolStripSearchBarCode.Enabled = true;
            toolStripTextBoxItemName.Enabled = true;
            toolStripButtonExitSearch.Enabled = true;
            toolStripTextBoxItemName.Enabled = true;
            toolStripSearchBarCode.Focus();
        }
        void SearchTextItemName()
        {
            DataSet RsBrand = new DataSet();

            Dt = RsBrand.Tables.Add("Items");

            SqlDataAdapter Sda = new SqlDataAdapter("Select * from Items Where ItemDescription like '" + toolStripTextBoxItemName.Text + "%'", TalhaConnectionstring.conn);

            // 'Fill the DataTable with records from Table.

            Sda.Fill(RsBrand, "Items");

            if (Dt.Rows.Count > 0)
            {
                // Setting DataSource Nothing
                txtBarCode.DataBindings.Clear();
                txtBarCodeInCharacter.DataBindings.Clear();
                txtItemName.DataBindings.Clear();
                txtPurchasePrice.DataBindings.Clear();
                txtSalesPrice.DataBindings.Clear();
                txtDiscount.DataBindings.Clear();
                txtDiscountCategory.DataBindings.Clear();
                txtAmountAfterDiscount.DataBindings.Clear();

                // Now Setting Datasource

                txtBarCode.DataBindings.Add("Text", Dt, "Barcode");
                txtBarCodeInCharacter.DataBindings.Add("Text", Dt, "BarCodeInCharacter");
                txtItemName.DataBindings.Add("Text", Dt, "ItemDescription");
                txtPurchasePrice.DataBindings.Add("Text", Dt, "PurchasePrice");
                txtSalesPrice.DataBindings.Add("Text", Dt, "SalesPrice");
                txtDiscount.DataBindings.Add("Text", Dt, "Discount");
                txtDiscountCategory.DataBindings.Add("Text", Dt, "DiscountType");
                txtAmountAfterDiscount.DataBindings.Add("Text", Dt, "SalesPriceAfterDiscount");

                dataGridView1.DataSource = Dt;


                toolStripButtonCancel.Enabled = false;
                toolStripButtonCancelEdit.Enabled = false;
            }
        }

        private void toolStripTextBoxItemName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchTextItemName();
            }
            catch(Exception ex)
            {
                //dd
            }
        }
    }
}
