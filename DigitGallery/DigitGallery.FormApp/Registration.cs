using DigitGallery.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitGallery.FormApp
{
    public partial class RegistrationForm : Form
    {
        private DigitGalleryService service;

        public RegistrationForm()
        {
            InitializeComponent();
            service = new DigitGalleryService();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
        }

        private void WhiteButton_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            RegistrationForm main = Application.OpenForms.OfType<RegistrationForm>().FirstOrDefault();
            if (main != null)
            {
                main.Show();
            };
            this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            RegistrationForm main = Application.OpenForms.OfType<RegistrationForm>().FirstOrDefault();
            if (main != null)
            {
                main.Show();
            };
            this.Close();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            if ( UsernameTextBox.Text != string.Empty || PasswordTextBox.Text != string.Empty || ConfirmPasswordTextBox.Text != string.Empty)
            {
                if (PasswordTextBox.Text == ConfirmPasswordTextBox.Text)
                {
                    try
                    {
                        service.AddArtist(UsernameTextBox.Text, PasswordTextBox.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            RegistrationForm main = Application.OpenForms.OfType<RegistrationForm>().FirstOrDefault();
            if (main != null)
            {
                main.Show();
            };
            this.Close();
        }
    }
}
