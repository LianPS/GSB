using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using tools_médecin.DataAccess;
using tools_médecin.Models;

namespace tools_médecin.Controllers
{
    public class PatientController
    {
        public List<Patient> ObtenirTousLesPatients()
        {
            List<Patient> patients = new List<Patient>();
            string sql = "SELECT numPatient, nom, prenom, dateNaissance, numerosecu, Sex, poids, taille, patho FROM PATIENT ORDER BY nom, prenom";

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            using (MySqlDataReader lecteur = cmd.ExecuteReader())
            {
                while (lecteur.Read())
                {
                    Patient p = new Patient();
                    p.Id = lecteur.GetInt32("numPatient");
                    p.Nom = lecteur.GetString("nom");
                    p.Prenom = lecteur.GetString("prenom");
                    p.DateNaissance = lecteur.GetDateTime("dateNaissance");
                    p.NumeroSecu = lecteur.GetString("numerosecu");
                    p.Sex = lecteur.IsDBNull(lecteur.GetOrdinal("Sex")) ? "" : lecteur.GetString("Sex");
                    p.Poids = lecteur.IsDBNull(lecteur.GetOrdinal("poids")) ? 0 : lecteur.GetDouble("poids");
                    p.Taille = lecteur.IsDBNull(lecteur.GetOrdinal("taille")) ? 0 : lecteur.GetInt32("taille");
                    p.Patho = lecteur.IsDBNull(lecteur.GetOrdinal("patho")) ? "" : lecteur.GetString("patho");
                    patients.Add(p);
                }
            }
            return patients;
        }

        public bool AjouterPatient(Patient p)
        {
            string sql = "INSERT INTO PATIENT (nom, prenom, dateNaissance, numerosecu, Sex, poids, taille, patho) " +
                         "VALUES (@nom, @prenom, @ddn, @secu, @sex, @poids, @taille, @patho)";
            return ExecuterRequete(sql, p);
        }
        public bool ModifierPatient(Patient p)
        {
            string sql = "UPDATE PATIENT SET nom=@nom, prenom=@prenom, dateNaissance=@ddn, numerosecu=@secu, " +
                         "Sex=@sex, poids=@poids, taille=@taille, patho=@patho WHERE numPatient=@id";
            return ExecuterRequete(sql, p, true);
        }

        public bool SupprimerPatient(int id)
        {
            string sql = "DELETE FROM PATIENT WHERE numPatient=@id";
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private bool ExecuterRequete(string sql, Patient p, bool isUpdate = false)
        {
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@nom", p.Nom);
                cmd.Parameters.AddWithValue("@prenom", p.Prenom);
                cmd.Parameters.AddWithValue("@ddn", p.DateNaissance);
                cmd.Parameters.AddWithValue("@secu", p.NumeroSecu);
                cmd.Parameters.AddWithValue("@sex", p.Sex);
                cmd.Parameters.AddWithValue("@poids", p.Poids);
                cmd.Parameters.AddWithValue("@taille", p.Taille);
                cmd.Parameters.AddWithValue("@patho", p.Patho);
                if (isUpdate) cmd.Parameters.AddWithValue("@id", p.Id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<Patient> ObtenirPatientsParNom(string motCle)
        {
            List<Patient> lesPatients = new List<Patient>();

            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                //requête paramétrée pour éviter l'injection SQL
                string sql = "SELECT numPatient, nom, prenom, dateNaissance, numeroSecu FROM PATIENT WHERE nom LIKE @recherche";

                using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
                {
                    //recherche part mot clé
                    cmd.Parameters.AddWithValue("@recherche", motCle + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Patient p = new Patient();
                            p.Id = Convert.ToInt32(reader["numPatient"]);
                            p.Nom = reader["nom"].ToString();
                            p.Prenom = reader["prenom"].ToString();

                            if (reader["dateNaissance"] != DBNull.Value)
                                p.DateNaissance = Convert.ToDateTime(reader["dateNaissance"]);

                            p.NumeroSecu = reader["numeroSecu"].ToString();

                            lesPatients.Add(p);
                        }
                    }
                }
            }
            return lesPatients;
        }
    }
}