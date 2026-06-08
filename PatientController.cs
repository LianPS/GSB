using tools_médecin.Controllers; // Doit correspondre au namespace du contrôleur
using tools_médecin.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using tools_médecin.DataAccess; // Assure-toi que c'est le bon projet
using tools_médecin.Models;

namespace tools_médecin.Controllers // C'est cette ligne qui définit l'espace de noms
{
    public class PatientController
    {
        // Méthode pour lire les patients
        public List<Patient> ObtenirTousLesPatients()
        {
            List<Patient> patients = new List<Patient>();
            [cite_start] string sql = "SELECT numPatient, nom, prenom, dateNaissance, numerosecu FROM PATIENT ORDER BY nom, prenom"; [cite: 568 - 571]

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            using (MySqlDataReader lecteur = cmd.ExecuteReader())
            {
                while (lecteur.Read())
                {
                    Patient p = new Patient();
                    p.Id = lecteur.GetInt32("numPatient");
                    p.setNom(lecteur.GetString("nom"));
                    p.setPrenom(lecteur.GetString("prenom"));
                    p.setDateNaissance(lecteur.GetDateTime("dateNaissance"));
                    p.setNumeroSecu(lecteur.GetString("numeroSecu"));
                    patients.Add(p);
                }
            }
            return patients;
        }

        // Méthode pour ajouter un patient (nécessaire pour ton formulaire de création)
        public bool AjouterPatient(Patient p)
        {
            [cite_start] string sql = "INSERT INTO PATIENT (nom, prenom, dateNaissance, numerosecu) VALUES (@nom, @prenom, @ddn, @secu)"; [cite: 188 - 205]

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@nom", p.getNom());
                cmd.Parameters.AddWithValue("@prenom", p.getPrenom());
                cmd.Parameters.AddWithValue("@ddn", p.getDateNaissance());
                cmd.Parameters.AddWithValue("@secu", p.getNumeroSecu());

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}