using ordonance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace liste_patients
{
    public partial class Inscription : Form
    {
        public Inscription()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_creataccount_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1_email1.Text) || string.IsNullOrWhiteSpace(textBox2_pasworld1.Text) || string.IsNullOrWhiteSpace(textBox3_confirme_pasworld.Text))
            {
                MessageBox.Show("Veuillez remplir les champs email et mot de passe.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            Login ordonance = new Login();
            ordonance.Show();

            this.Hide();
        }
    }
}
