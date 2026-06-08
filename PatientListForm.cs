using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using tools_médecin.Controllers;
using tools_médecin.Models;

namespace tools_médecin.Views
{
    public partial class PatientListForm : Form
    {
        [cite_start] private readonly PatientController _controller; [cite: 628]

        public PatientListForm()
        {
            InitializeComponent();
            [cite_start] _controller = new PatientController(); [cite: 632]
        }

        private void PatientListForm_Load(object sender, EventArgs e)
        {
            [cite_start] ChargerPatients(); [cite: 636]
        }

        private void ChargerPatients()
        {
            try
            {
                [cite_start] List<Patient> patients = _controller.ObtenirTousLesPatients(); [cite: 644]
                [cite_start] dtgvPatient.DataSource = patients; [cite: 648]
            }
            [cite_start]catch (MySqlException ex) [cite: 649]
            {
                MessageBox.Show(
                    "Impossible de charger les patients :\n" + ex.Message,
                    "Erreur base de données",
                    MessageBoxButtons.OK,
                    [cite_start]MessageBoxIcon.Error); [cite: 651 - 654]
            }
            }
        }
    }