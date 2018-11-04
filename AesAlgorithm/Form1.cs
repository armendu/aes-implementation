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
            ddlGjatesiaCelesit.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var clearText = Encoding.UTF8.GetBytes(txtInput.Text);

            // Hard coded key
            var key = Encoding.UTF8.GetBytes("1a25s8fe5dsg65ad"); //Rijndael.Create().Key;

            byte[] cipherText = AesImplementation.Encrypt(clearText, key);

            string finalTeksti = Encoding.UTF8.GetString(cipherText);

            txtOutput.Text = finalTeksti;

            var someresult = AesImplementation.Decrypt(cipherText, key);

            txtHexOutput.Text = Encoding.UTF8.GetString(someresult);

            //            if (ValidateFields())
            //            {
            //                try
            //                {
            //                    lblValidateTekstin.Visible = false;
            //                    var enkriptim = radioEncrypt.Checked;
            //                    var rezultati = enkriptim
            //                        ? AesAlgorithm.EncryptString(txtTekstiHyres.Text, txtCelesi.Text)
            //                        : AesAlgorithm.DecryptString(txtTekstiHyres.Text, txtCelesi.Text);
            //
            //                    txtDalja.Text = rezultati;
            //                    var bajtat = enkriptim
            //                  ? Convert.FromBase64String(rezultati)
            //                  : Encoding.UTF8.GetBytes(rezultati);
            //                    RezultatiHex.Text = BitConverter.ToString(bajtat);
            //                }
            //                catch (Exception ex)
            //                {
            //                    txtDalja.Text = "Gabim " + ex.ToString();
            //                }
            //            }
        }

        private bool ValidateFields()
        {
            bool validoData = true;
            if (ddlGjatesiaCelesit.SelectedIndex == 0)
            {
                validoData = false;
                ddlGjatesiaCelesit.Focus();
                lblValidateTekstin.Visible = true;
                lblValidateTekstin.Text = "Ploteso gjatesin e qelesit";
            }
            else if (ddlGjatesiaCelesit.SelectedIndex != 0)
            {
                switch (ddlGjatesiaCelesit.SelectedItem)
                {
                    case "128":
                        if (txtKey.TextLength != 16)
                        {
                            validoData = false;
                            txtKey.Focus();
                            lblValidateTekstin.Visible = true;
                            lblValidateTekstin.Text =
                                "Gjatesia e karaktereve per qelesin 128 bitesh\n eshte 16 karaktere. Shikoni me kujdes te dhenat!";
                        }

                        break;
                    case "192":
                        if (txtKey.TextLength != 24)
                        {
                            validoData = false;
                            txtKey.Focus();
                            lblValidateTekstin.Visible = true;
                            lblValidateTekstin.Text =
                                "Gjatesia e karaktereve per qelesin 192 bitesh \n eshte 24 karaktere. Shikoni me kujdes te dhenat!";
                        }

                        break;
                    case "256":
                        if (txtKey.TextLength != 24)
                        {
                            validoData = false;
                            txtKey.Focus();
                            lblValidateTekstin.Visible = true;
                            lblValidateTekstin.Text =
                                "Gjatesia e karaktereve per qelesin  256 bitesh \n eshte 32 karaktere. Shikoni me kujdes te dhenat!";
                        }
                        
                        break;
                }
            }

            return validoData;
        }
    }
}