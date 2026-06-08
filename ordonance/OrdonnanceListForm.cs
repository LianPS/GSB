using System;
using System.Data;
using System.Windows.Forms;
using tools_médecin.Controllers;

namespace tools_médecin
{
    public partial class OrdonnanceListForm : Form
    {
        private int _idPatient;
        private OrdonnanceController _ordonnanceCtrl;

        public OrdonnanceListForm(int idPatient)
        {
            InitializeComponent();
            _idPatient = idPatient;
            _ordonnanceCtrl = new OrdonnanceController();
        }

        public OrdonnanceListForm()
        {
            InitializeComponent();
        }

        //historique des ordonnances du patient
        private void OrdonnanceListForm_Load(object sender, EventArgs e)
        {
            dgvOrdonnances.DataSource = _ordonnanceCtrl.ObtenirOrdonnancesParPatient(_idPatient);
        }

        //affiche les médicaments dans l'ordonnace dans le tableau du bas
        private void dgvOrdonnances_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrdonnances.CurrentRow != null)
            {
                int numOrd = Convert.ToInt32(dgvOrdonnances.CurrentRow.Cells["numOrdonnance"].Value);
                dgvLignes.DataSource = _ordonnanceCtrl.ObtenirLignesOrdonnance(numOrd);
            }
        }

        //ouvre la fenêtre pour modifier l'ordonnance sélectionnée
        private void dgvOrdonnances_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrdonnances.CurrentRow != null)
            {
                int numOrd = Convert.ToInt32(dgvOrdonnances.CurrentRow.Cells["numOrdonnance"].Value);

                using (OrdonnanceEditForm formEdit = new OrdonnanceEditForm(this._idPatient, numOrd))
                {
                    if (formEdit.ShowDialog() == DialogResult.OK)
                    {
                        //rafraichit le DGV 
                        dgvOrdonnances.DataSource = _ordonnanceCtrl.ObtenirOrdonnancesParPatient(_idPatient);
                    }
                }
            }
        }

        // Ouvre la fenetre pour créer une ordonnance
        private void btnNouvelleOrdonnance_Click(object sender, EventArgs e)
        {
            using (OrdonnanceEditForm formEdit = new OrdonnanceEditForm(this._idPatient))
            {
                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    //rafraichit le DGV si une ordonnance a été ajoutée
                    dgvOrdonnances.DataSource = _ordonnanceCtrl.ObtenirOrdonnancesParPatient(_idPatient);
                }
            }
        }

        //demande ou sauvegarder le fichier puis crée le PDF
        private void btnEnregistrerPDF_Click(object sender, EventArgs e)
        {
            if (dgvOrdonnances.CurrentRow != null)
            {
                int numOrd = Convert.ToInt32(dgvOrdonnances.CurrentRow.Cells["numOrdonnance"].Value);

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Portable Document Format (*.pdf)|*.pdf";
                sfd.FileName = $"Ordonnance_{numOrd}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DataTable dt = _ordonnanceCtrl.ObtenirDonneesCompletesOrdonnance(numOrd);
                        OrdonnancePdf.Generer(dt, sfd.FileName);

                        MessageBox.Show("Fichier enregistré avec succès sous : " + sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message);
                    }
                }
            }
        }
    }
}