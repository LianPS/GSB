using liste_patients;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using tools_médecin;
using tools_médecin.Controllers;
using tools_médecin.Models;

namespace ordonance
{
    public partial class PatientListForm : Form
    {
        private readonly PatientController _controller;

        public PatientListForm()
        {
            InitializeComponent();
            _controller = new PatientController();
        }
        private void liste_patients_Load(object sender, EventArgs e)
        {
            ActualiserGrille();
        }

        //charge ou rafraîchit les données dans le DGV
        private void ActualiserGrille()
        {
            try
            {
                List<Patient> lesPatients = _controller.ObtenirTousLesPatients();

                dgvPatients.DataSource = null;
                dgvPatients.DataSource = lesPatients;

                ConfigurerApparenceGrille();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur technique : " + ex.Message, "Erreur GSB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurerApparenceGrille()
        {
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.ReadOnly = true;

            if (dgvPatients.Columns["Id"] != null) dgvPatients.Columns["Id"].Visible = false;
        }

        //création d'un patient
        private void button4_créer_Click(object sender, EventArgs e)
        {
            using (création_de_patient formCreer = new création_de_patient())
            {
                if (formCreer.ShowDialog() == DialogResult.OK)
                {
                    ActualiserGrille();
                }
            }
        }

        //modification par double clic
        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Patient patientSelectionne = (Patient)dgvPatients.Rows[e.RowIndex].DataBoundItem;

                using (création_de_patient formEdit = new création_de_patient(patientSelectionne))
                {
                    if (formEdit.ShowDialog() == DialogResult.OK)
                    {
                        ActualiserGrille();
                    }
                }
            }
        }

        //bouton de suppression
        private void button_suppr_Click_1(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count > 0)
            {
                Patient p = (Patient)dgvPatients.SelectedRows[0].DataBoundItem;

                DialogResult dr = MessageBox.Show($"Voulez-vous vraiment supprimer le patient {p.Nom} ?",
                    "Confirmation GSB", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _controller.SupprimerPatient(p.Id);
                        ActualiserGrille();
                        MessageBox.Show("Patient supprimé avec succès.");
                    }
                    catch (MySqlException ex)
                    {
                        if (ex.Number == 1451)
                            MessageBox.Show("Impossible de supprimer ce patient car il possède des ordonnances enregistrées.", "Action refusée", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        else
                            MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne dans le tableau pour la supprimer.");
            }
        }
        private void ordonnance_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null)
            {
                MessageBox.Show("Veuillez d'abord sélectionner un patient", "Action impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPatient = (int)dgvPatients.CurrentRow.Cells["Id"].Value;

            using (OrdonnanceListForm formOrd = new OrdonnanceListForm(idPatient))
            {
                formOrd.ShowDialog();
            }
        }
        private void domainUpDown_sex_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        //recherche part le Nom
        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            string motCle = txtRecherche.Text.Trim();

            if (string.IsNullOrWhiteSpace(motCle))
            {
                ActualiserGrille();
            }
            else
            {
                dgvPatients.DataSource = null;
                dgvPatients.DataSource = _controller.ObtenirPatientsParNom(motCle);
                ConfigurerApparenceGrille();
            }
        }
    }
}