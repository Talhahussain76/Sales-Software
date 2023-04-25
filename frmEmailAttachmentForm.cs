using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.Net.Mail;


namespace TALHA_PROJECTS_PRACTICE
{
    public partial class frmEmailAttachmentForm : Form
    {
        public frmEmailAttachmentForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage(txtFrom.Text, txtTo.Text, txtSubject.Text, txtBody.Text);
                mail.Attachments.Add(new Attachment(txtAttachments.Text.ToString()));
                SmtpClient client = new SmtpClient(CmbSmtp.SelectedItem.ToString());
                client.Port = 465;
                client.Credentials = new NetworkCredential(txtUsername.Text, txtPassword.Text);
                client.EnableSsl = true;
                client.Send(mail);
                MessageBox.Show("Email Sent Successfully", "Success", MessageBoxButtons.OKCancel);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Files";
            ofd.Filter = "PNG FILE (*.png) | *.png|JPG FILE (*.jpg) | *.jpg|GIF FILE (*.gif) | *.gif|BMP FILE (*.bmp) | *.bmp|All files (*.*)|*.*";
            ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName.ToString();
                txtAttachments.Text = path;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        void resetcontrols()
        {
            txtFrom.Clear();
            txtTo.Clear();
            txtSubject.Clear();
            CmbSmtp.SelectedItem = null;
            txtUsername.Clear();
            txtPassword.Clear();
            txtBody.Clear();
            txtAttachments.Clear();
        }
    }
}
