using Online_Store.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store.UI
{
    public partial class Login : Form
    {
        // This field if for storing the parent form of this form.
        public Form parent;

        // This is the constructor of this form.
        public Login(Form parentForm)
        {
            InitializeComponent();
            parent = parentForm;
        }

        // Called when the cancel button is clicked.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // called when the login button is clicked.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the username and password fields match from the database.
                var con = Config.Instance.Connection;
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Administrators] WHERE [email] = '" + tbEmail.Text + "' AND [password] = '" + tbPassword.Text + "';", con);
                object result = cmd.ExecuteScalar();
                
                // If the result is any number greater then 0 that means a record is matched and its id is returned
                if (Convert.ToInt32(result) > 0)
                {
                    // So, we can now show the product form of the application.
                    this.parent.Hide();
                    Product product = new Product(this);
                    this.Hide();
                    product.ShowDialog();
                }
                // Otherwise we show an error message
                else
                {
                    MessageBox.Show("The given email or password is not valid. Please try again.", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // If any error occurs we show an error message
            catch (Exception)
            {
                MessageBox.Show("The given email or password is not valid. Please try again.", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        // Close this form and load the main form.
        public void closeAndLoadMainForm()
        {
            MainForm form = (MainForm)parent;
            form.LoadDataInDataGridView();
            form.Show();
            this.Close();
        }

        // Called when the focus entes the email field.
        private void tbEmail_Enter(object sender, EventArgs e)
        {
            if (tbEmail.Text.Equals(tbEmail.Tag.ToString()))
            {
                tbEmail.Text = "";
                tbEmail.ForeColor = Color.Black;
            }
        }

        // Called when the focus enters the password field.
        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text.Equals(tbPassword.Tag.ToString()))
            {
                tbPassword.Text = "";
                tbPassword.ForeColor = Color.Black;
                if (!checkBox1.Checked)
                {
                    tbPassword.UseSystemPasswordChar = true;
                }
            }
        }

        // Called when the focus leaves the email field.
        private void tbEmail_Leave(object sender, EventArgs e)
        {
            if (tbEmail.Text.Equals(""))
            {
                tbEmail.Text = tbEmail.Tag.ToString();
                tbEmail.ForeColor = Color.DimGray;
            }
        }

        // Called when the focus leaves the password field.
        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text.Equals(""))
            {
                if (tbPassword.UseSystemPasswordChar)
                {
                    tbPassword.UseSystemPasswordChar = false;
                }
                tbPassword.Text = tbPassword.Tag.ToString();
                tbPassword.ForeColor = Color.DimGray;
            }
        }

        // Catch the key that is pressend when the focus is in password field
        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // If there is no password entered, we show move the focus to the email field
                if (tbEmail.Text.Equals(tbEmail.Tag.ToString()))
                {
                    tbEmail.Focus();
                    e.Handled = e.SuppressKeyPress = true;
                }
                // If the enter key is pressed we call the login button click event.
                else
                {
                    btnLogin_Click(sender, e);
                    e.Handled = e.SuppressKeyPress = true;
                }
            }
        }

        // Catch the key that is pressend when the focus is in email field
        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            // If the enter key is pressed we move the focus to the password field
            if (e.KeyCode == Keys.Enter)
            {
                tbPassword.Focus();
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        // Called when the checkbox value is changed
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // if the checkbox is checked we show the password as plain text
            if (checkBox1.Checked)
            {
                tbPassword.UseSystemPasswordChar = false;
            }
            // ohterwise we show the password as asterisks
            else
            {
                if (!tbPassword.Text.Equals(tbPassword.Tag.ToString()))
                {
                    tbPassword.UseSystemPasswordChar = true;
                }
            }
        }
    }
}
