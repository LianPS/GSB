using liste_patients;
using System;
using System.Windows.Forms;
using tools_médecin.Controllers;

namespace ordonance
{
    public partial class Login : Form
    {
        private AuthController _authCtrl = new AuthController();

        public Login()
        {
            InitializeComponent();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //verification si les champs sont vide
            if (string.IsNullOrWhiteSpace(textBox_email.Text) || string.IsNullOrWhiteSpace(textBox_pswrd.Text))
            {
                MessageBox.Show("Veuillez remplir les champs.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //transmission des identifiants au controleur pour verification en BDD
            if (_authCtrl.Authentifier(textBox_email.Text, textBox_pswrd.Text))
            {
                PatientListForm ordonance = new PatientListForm();

                ordonance.FormClosed += (s, args) => this.Close();

                ordonance.Show();
                this.Hide();
            }
            else
            {
                //echec de l'authentification
                MessageBox.Show("Identifiant RPPS ou mot de passe incorrect.", "Échec d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_sin_Click(object sender, EventArgs e)
        {
            Inscription ordonance = new Inscription();

            ordonance.FormClosed += (s, args) => this.Show();

            ordonance.Show();
            this.Hide();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}