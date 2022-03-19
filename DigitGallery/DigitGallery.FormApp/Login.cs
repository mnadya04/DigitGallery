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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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
    }
}
