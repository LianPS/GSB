using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using tools_médecin.Controllers;
using tools_médecin.Models;
using tools_médecin.DataAccess;

namespace tools_médecin
{
    public partial class OrdonnanceEditForm : Form
    {
        //liste liée au DGV
        private BindingList<LignePrescription> _lignesLocales = new BindingList<LignePrescription>();
        private PatientController _patientCtrl = new PatientController();
        private OrdonnanceController _ordonnanceCtrl = new OrdonnanceController();

        private int _idPatientTransmis;
        private int _numOrdonnanceAModifier = 0; //0 = mode création > 0 = mode modification

        //mode création
        public OrdonnanceEditForm(int idPatient) : this()
        {
            _idPatientTransmis = idPatient;
        }

        //mode modification
        public OrdonnanceEditForm(int idPatient, int numOrdonnance) : this()
        {
            _idPatientTransmis = idPatient;
            _numOrdonnanceAModifier = numOrdonnance;
        }

        public OrdonnanceEditForm()
        {
            InitializeComponent();
            dgvLignes.DataSource = _lignesLocales;

            //édition manuels du DGV désactivés
            dgvLignes.AllowUserToAddRows = false;
            dgvLignes.ReadOnly = true;

            btnAjouterLigne.Click += btnAjouterLigne_Click;
            btnValider.Click += btnValider_Click;
        }

        private void OrdonnanceEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                //chargement des données pour les listes déroulantes
                List<Patient> lp = _patientCtrl.ObtenirTousLesPatients();
                comboBox1.DataSource = lp;
                comboBox1.DisplayMember = "Nom";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedValue = _idPatientTransmis;

                DataTable dtMedecins = new DataTable();
                using (MySqlConnection cnx = DbConnexion.Ouvrir())
                {
                    string sql = "SELECT numMedecin, CONCAT('Dr. ', nom) as NomComplet FROM MEDECIN";
                    using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader()) { dtMedecins.Load(reader); }
                    }
                }
                comboBox2.DataSource = dtMedecins;
                comboBox2.DisplayMember = "NomComplet";
                comboBox2.ValueMember = "numMedecin";

                DataTable dtMedicaments = new DataTable();
                using (MySqlConnection cnx = DbConnexion.Ouvrir())
                {
                    string sql = "SELECT codeMedicament, nom FROM MEDICAMENT";
                    using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader()) { dtMedicaments.Load(reader); }
                    }
                }
                cmbMedicament.DataSource = dtMedicaments;
                cmbMedicament.DisplayMember = "nom";
                cmbMedicament.ValueMember = "codeMedicament";

                //remplissage de la grille avec les données du patiant en mode modif
                if (_numOrdonnanceAModifier > 0)
                {
                    btnValider.Text = "Modifier";
                    this.Text = "Modification de l'ordonnance n°" + _numOrdonnanceAModifier;

                    DataTable dtLignesExistantes = _ordonnanceCtrl.ObtenirLignesOrdonnance(_numOrdonnanceAModifier);
                    foreach (DataRow row in dtLignesExistantes.Rows)
                    {
                        _lignesLocales.Add(new LignePrescription
                        {
                            Medicament = row["codeMedicament"].ToString(),
                            Posologie = row["posologie"].ToString(),
                            Duree = row["dureeJours"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement : " + ex.Message);
            }
        }

        private void btnAjouterLigne_Click(object sender, EventArgs e)
        {
            // Vérification de si le champs et vide avant l'ajout à la BindingList
            if (cmbMedicament.SelectedValue != null && !string.IsNullOrWhiteSpace(txtPosologie.Text) && !string.IsNullOrWhiteSpace(txtDuree.Text))
            {
                _lignesLocales.Add(new LignePrescription
                {
                    Medicament = cmbMedicament.SelectedValue.ToString(),
                    Posologie = txtPosologie.Text,
                    Duree = txtDuree.Text
                });

                //vidage des textbox
                txtPosologie.Clear();
                txtDuree.Clear();
                cmbMedicament.Focus();
            }
            else
            {
                MessageBox.Show("Veuillez remplir le médicament, la posologie et la durée avant de cliquer sur Ajouté.", "Saisie incomplète", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (_lignesLocales.Count == 0)
            {
                MessageBox.Show("Veuillez ajouter au moins un médicament.", "Validation");
                return;
            }

            //création et remplissage de l'ordonnance
            Ordonnance ord = new Ordonnance();
            ord.IdPatient = _idPatientTransmis;
            ord.IdMedecin = Convert.ToInt32(comboBox2.SelectedValue);
            ord.DateCommande = DateTime.Now;

            foreach (var ligne in _lignesLocales)
            {
                if (!string.IsNullOrWhiteSpace(ligne.Medicament))
                {
                    ord.Lignes.Add(ligne);
                }
            }

            //sauvegarde de l'ordonnance en BDD
            bool resultatExecution;
            if (_numOrdonnanceAModifier > 0)
            {
                resultatExecution = _ordonnanceCtrl.ModifierOrdonnance(_numOrdonnanceAModifier, ord);
            }
            else
            {
                resultatExecution = _ordonnanceCtrl.AjouterOrdonnance(ord);
            }

            if (resultatExecution)
            {
                MessageBox.Show("L'ordonnance a été enregistrée avec succès.", "Succès");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'enregistrement en base de données. Opération annulée.", "Erreur Critique");
            }
        }

        private void btnSupprimerLigne_Click(object sender, EventArgs e)
        {
            //supprime la ligne sélectionnée du tableau
            if (dgvLignes.SelectedRows.Count > 0)
            {
                LignePrescription ligneSelectionnee = (LignePrescription)dgvLignes.SelectedRows[0].DataBoundItem;
                _lignesLocales.Remove(ligneSelectionnee);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne dans le tableau.", "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}