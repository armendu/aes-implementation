using System;
using System.Text;
using System.Windows.Forms;

namespace AesAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ddlKeyLength.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    lblErrorMessage.Visible = false;

                    var clearText = Encoding.UTF8.GetBytes(txtInput.Text);

                    // Get the key
                    var key = Encoding.UTF8.GetBytes(txtKey.Text); //Rijndael.Create().Key;

                    byte[] cipherText = AesImplementation.Encrypt(clearText, key);

                    txtOutput.Text = Convert.ToBase64String(cipherText);

                    txtHexOutput.Text = BitConverter.ToString(cipherText);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($@"An error occured: {exception}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    lblErrorMessage.Visible = false;

                    byte[] cipherText = Convert.FromBase64String(txtInput.Text);

                    // Get the key
                    var key = Encoding.UTF8.GetBytes(txtKey.Text);

                    // Decrypt the cipher text
                    byte[] plainText = AesImplementation.Decrypt(cipherText, key);

                    // Set the right output
                    txtOutput.Text = Encoding.UTF8.GetString(plainText);
                    txtHexOutput.Text = BitConverter.ToString(plainText);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($@"An error occured: {exception}");
                }
            }
        }

        private bool ValidateFields()
        {
            if (ddlKeyLength.SelectedIndex == 0)
            {
                ddlKeyLength.Focus();
                lblErrorMessage.Visible = true;
                lblErrorMessage.ForeColor = System.Drawing.Color.Blue;
                lblErrorMessage.Text = @"Zgjedhni gjatesine e celesit!";

                return false;
            }

            switch (ddlKeyLength.SelectedItem.ToString())
            {

                case "128":
                    if (txtKey.TextLength != 16)
                    {
                        txtKey.Focus();
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text =
                            "Duhet te shkruani 16 karaktere per celesin 128 bitesh!"; return false;
                    }

                    break;
                case "192":
                    if (txtKey.TextLength != 24)
                    {
                        txtKey.Focus();
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text =
                            "Duhet te shkruani 24 karaktere per celesin 192 bitesh!"; return false;
                    }

                    break;
                case "256":
                    if (txtKey.TextLength != 32)
                    {
                        txtKey.Focus();
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text =
                            "Duhet te shkruani 32 karaktere per celesin 256 bitesh!"; return false;
                    }

                    break;
            }


            return true;
        }
    }
}