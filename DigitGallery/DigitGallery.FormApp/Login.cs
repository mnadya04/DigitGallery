using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitGallery.Models;
using DigitGallery.Services;


namespace DigitGallery.FormApp
{
    public partial class Login : Form
    {
        private DigitGalleryService service;

        public Login()
        {
            InitializeComponent();
            service = new DigitGalleryService();

        }

        private void logIn_Load(object sender, EventArgs e)
        {

        }

        private void BlackButton_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            label2.ForeColor = Color.White;
            label4.ForeColor = Color.White;
        }

        private void WhiteButton_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            label2.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Login main = Application.OpenForms.OfType<Login>().FirstOrDefault();
            if (main != null)
            {
                main.Show();
            };
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registration = new RegistrationForm();
            registration.ShowDialog();
            RegistrationForm main = Application.OpenForms.OfType<RegistrationForm>().FirstOrDefault();
            if (main != null)
            {
                main.Show();
            };
            this.Close();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            bool isLoged = service.Login(UsernameTextBox.Text, PasswordTextBox.Text);
            if (isLoged)
            {
                this.Hide();
                Home form = new Home(service);
                form.ShowDialog();
                Home main = Application.OpenForms.OfType<Home>().FirstOrDefault();
                if (main != null)
                {
                    main.Show();
                };
                this.Close();

            }
            else
            {
                MessageBox.Show("Enter valid value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
