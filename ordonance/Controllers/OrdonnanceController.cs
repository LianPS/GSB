using System;
using System.Data;
using MySql.Data.MySqlClient;
using tools_médecin.DataAccess;
using tools_médecin.Models;

namespace tools_médecin.Controllers
{
    public class OrdonnanceController
    {
        public bool AjouterOrdonnance(Ordonnance ord)
        {
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                using (MySqlTransaction transaction = cnx.BeginTransaction())
                {
                    try
                    {
                        //isertion de l'ordonnance et récupération de son identifiant généré
                        string sqlOrd = "INSERT INTO ORDONNANCE (dateEmission, numMedecin, numPatient) VALUES (@date, @numMedecin, @numPatient); SELECT LAST_INSERT_ID();";
                        int numOrdonnance = 0;

                        using (MySqlCommand cmd = new MySqlCommand(sqlOrd, cnx, transaction))
                        {
                            cmd.Parameters.AddWithValue("@date", ord.DateCommande);
                            cmd.Parameters.AddWithValue("@numMedecin", ord.IdMedecin);
                            cmd.Parameters.AddWithValue("@numPatient", ord.IdPatient);
                            numOrdonnance = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        //insertion des médicament prescrit
                        string sqlLigne = "INSERT INTO CONTENIR (numOrdonnance, codeMedicament, posologie, dureeJours) VALUES (@numOrd, @codeMed, @poso, @duree)";
                        foreach (var ligne in ord.Lignes)
                        {
                            using (MySqlCommand cmdLigne = new MySqlCommand(sqlLigne, cnx, transaction))
                            {
                                cmdLigne.Parameters.AddWithValue("@numOrd", numOrdonnance);
                                cmdLigne.Parameters.AddWithValue("@codeMed", Convert.ToInt32(ligne.Medicament));
                                cmdLigne.Parameters.AddWithValue("@poso", ligne.Posologie);
                                cmdLigne.Parameters.AddWithValue("@duree", ligne.Duree);
                                cmdLigne.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        //annulation en cas d'erreur
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool ModifierOrdonnance(int numOrdonnance, Ordonnance ord)
        {
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                using (MySqlTransaction transaction = cnx.BeginTransaction())
                {
                    try
                    {
                        //suppression des anciennes lignes de prescription
                        string sqlDelete = "DELETE FROM CONTENIR WHERE numOrdonnance = @numOrd";
                        using (MySqlCommand cmdDel = new MySqlCommand(sqlDelete, cnx, transaction))
                        {
                            cmdDel.Parameters.AddWithValue("@numOrd", numOrdonnance);
                            cmdDel.ExecuteNonQuery();
                        }

                        //MAJ des informations
                        string sqlUpdate = "UPDATE ORDONNANCE SET numMedecin = @numMed, dateEmission = @date WHERE numOrdonnance = @numOrd";
                        using (MySqlCommand cmdUp = new MySqlCommand(sqlUpdate, cnx, transaction))
                        {
                            cmdUp.Parameters.AddWithValue("@numMed", ord.IdMedecin);
                            cmdUp.Parameters.AddWithValue("@date", ord.DateCommande);
                            cmdUp.Parameters.AddWithValue("@numOrd", numOrdonnance);
                            cmdUp.ExecuteNonQuery();
                        }

                        //réinsertion des nouvelles lignes de prescription
                        string sqlLigne = "INSERT INTO CONTENIR (numOrdonnance, codeMedicament, posologie, dureeJours) VALUES (@numOrd, @codeMed, @poso, @duree)";
                        foreach (var ligne in ord.Lignes)
                        {
                            using (MySqlCommand cmdLigne = new MySqlCommand(sqlLigne, cnx, transaction))
                            {
                                cmdLigne.Parameters.AddWithValue("@numOrd", numOrdonnance);
                                cmdLigne.Parameters.AddWithValue("@codeMed", Convert.ToInt32(ligne.Medicament));
                                cmdLigne.Parameters.AddWithValue("@poso", ligne.Posologie);
                                cmdLigne.Parameters.AddWithValue("@duree", ligne.Duree);
                                cmdLigne.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public DataTable ObtenirOrdonnancesParPatient(int idPatient)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                //récupération de l'historique pour la grille principale
                string sql = "SELECT numOrdonnance, dateEmission, numMedecin FROM ORDONNANCE WHERE numPatient = @idPatient";
                using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@idPatient", idPatient);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenirLignesOrdonnance(int numOrdonnance)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                //récupération du détail des médicaments pour l'autre grille
                string sql = "SELECT codeMedicament, posologie, dureeJours FROM CONTENIR WHERE numOrdonnance = @numOrdonnance";
                using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@numOrdonnance", numOrdonnance);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenirDonneesCompletesOrdonnance(int numOrdonnance)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                //export en PDF
                string sql = @"
            SELECT o.numOrdonnance, o.dateEmission, 
                   p.nom AS patientNom, p.prenom AS patientPrenom, p.dateNaissance, p.numeroSecu,
                   m.nom AS medecinNom, m.specialite, m.numeroRPPS,
                   med.nom AS medicamentNom, c.posologie, c.dureeJours
            FROM ORDONNANCE o
            JOIN PATIENT p ON o.numPatient = p.numPatient
            JOIN MEDECIN m ON o.numMedecin = m.numMedecin
            JOIN CONTENIR c ON o.numOrdonnance = c.numOrdonnance
            JOIN MEDICAMENT med ON c.codeMedicament = med.codeMedicament
            WHERE o.numOrdonnance = @numOrd";

                using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@numOrd", numOrdonnance);
                    using (MySqlDataReader reader = cmd.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }
    }
}