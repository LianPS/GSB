using System;
using System.Windows.Forms;
using tools_médecin.Controllers;
using tools_médecin.Models;

namespace liste_patients
{
    public partial class création_de_patient : Form
    {
        private Patient _patientEnCours = null;
        public création_de_patient()
        {
            InitializeComponent();
        }
        public création_de_patient(Patient p)
        {
            InitializeComponent();
            _patientEnCours = p;
            RemplirChamps(p);
            button4_créer1.Text = "Modifier";
        }

        private void RemplirChamps(Patient p)
        {
            textBox2_nom1.Text = p.Nom;
            textBox1_prenom1.Text = p.Prenom;
            textBox3_ddn.Text = p.DateNaissance.ToString("dd/MM/yyyy");
            textBox7_nds.Text = p.NumeroSecu;
            domainUpDown_sex1.Text = p.Sex;
            textBox4_poid1.Text = p.Poids.ToString();
            textBox5_taille.Text = p.Taille.ToString();
            textBox6_pathologies.Text = p.Patho;
        }

        private void button4_créer1_Click(object sender, EventArgs e)
        {
            //validation du nom
            if (string.IsNullOrWhiteSpace(textBox2_nom1.Text))
            {
                MessageBox.Show("Le nom est obligatoire.", "Validation refusée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //validation du NSS d'un maximum de 13 chiffres
            string secu = textBox7_nds.Text.Trim();
            if (secu.Length != 13 || !long.TryParse(secu, out _))
            {
                MessageBox.Show("Le numéro de sécurité sociale doit comporter exactement 13 chiffres.", "Validation refusée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Patient p = _patientEnCours ?? new Patient();

                p.Nom = textBox2_nom1.Text;
                p.Prenom = textBox1_prenom1.Text;
                p.DateNaissance = DateTime.Parse(textBox3_ddn.Text);
                p.NumeroSecu = textBox7_nds.Text;
                p.Sex = domainUpDown_sex1.Text;
                p.Poids = double.Parse(textBox4_poid1.Text);
                p.Taille = int.Parse(textBox5_taille.Text);
                p.Patho = textBox6_pathologies.Text;

                PatientController ctrl = new PatientController();

                bool succes;
                if (_patientEnCours == null)
                    succes = ctrl.AjouterPatient(p);
                else
                    succes = ctrl.ModifierPatient(p);

                if (succes)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur d'enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void création_de_patient_Load(object sender, EventArgs e)
        {

        }
    }
}