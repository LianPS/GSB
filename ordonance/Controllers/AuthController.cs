using System;
using MySql.Data.MySqlClient;
using tools_médecin.DataAccess;

namespace tools_médecin.Controllers
{
    public class AuthController
    {
        public bool Authentifier(string rpps, string motDePasseSaisi)
        {
            //connexion a la base de donnees
            using (MySqlConnection cnx = DbConnexion.Ouvrir())
            {
                //requete SQL parametree pour eviter les injection SQL
                string sql = "SELECT motDePasse FROM MEDECIN WHERE numeroRPPS = @rpps";
                MySqlCommand cmd = new MySqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@rpps", rpps);

                //recuperation du hash du MDP
                object resultat = cmd.ExecuteScalar();

                if (resultat != null)
                {
                    string hashEnBase = resultat.ToString();

                    //validation du mot de passe
                    return BCrypt.Net.BCrypt.Verify(motDePasseSaisi, hashEnBase);
                }

                return false;
            }
        }
    }
}