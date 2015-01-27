using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSA_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Encryption")
            {
                groupBox4.Enabled = false;
                groupBox2.Enabled = true;
            }

            if (comboBox1.Text == "Decryption")
            {
                groupBox2.Enabled = false;
                groupBox4.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (groupBox2.Enabled)
            {
                RSA rsa = new RSA();
                 textBox7.Text= (rsa.encrypt(textBox2.Text,textBox1.Text,textBox3.Text));
            }

            if (groupBox4.Enabled)
            {
                RSA rsa = new RSA();
                textBox8.Text = (rsa.decrypt(textBox6.Text, textBox5.Text, textBox4.Text));
            }

        }

    }
}
