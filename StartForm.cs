using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<EncrpytForm>().Any())
            {
                Application.OpenForms.OfType<EncrpytForm>().First().BringToFront();
            }
            else
            {
                EncrpytForm f = new EncrpytForm();
                f.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<DecryptForm>().Any())
            {
                Application.OpenForms.OfType<DecryptForm>().First().BringToFront();
            }
            else
            {
                DecryptForm f = new DecryptForm();
                f.Show();
            }
        }
    }
}
