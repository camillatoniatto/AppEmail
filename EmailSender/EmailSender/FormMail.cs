using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace EmailSender
{
    public partial class FormMail : Form
    {
        public FormMail()
        {
            InitializeComponent();
        }

        public void SendEmail()
        {
            MailMessage message = new MailMessage();
            message.Priority = MailPriority.High;
            message.To.Add(txtPara.Text);
            message.CC.Add(txtCc.Text);
            Attachment anexo = new Attachment(txtAnexo.Text);
            message.Attachments.Add(anexo);
            message.Subject = txtAssunto.Text;
            message.From = new MailAddress("allanferreirateste@hotmail.com");
            message.Body = txtMensagem.Text;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("allanferreirateste@hotmail.com", "ter1515pobi");

            try
            {
                smtp.Send(message);
                MessageBox.Show("Email enviado com sucesso!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void btnAnexar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtAnexo.Text = openFileDialog1.FileName;
        }
    }
}
