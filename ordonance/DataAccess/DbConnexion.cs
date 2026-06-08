using MySql.Data.MySqlClient;

namespace tools_médecin.DataAccess
{
    public static class DbConnexion
    {
        private const string SERVEUR = "localhost";
        private const string PORT = "3306";
        private const string BASE_DE_DONNEES = "gsb_ordonnances";
        private const string UTILISATEUR = "gsb";
        private const string MOT_DE_PASSE = "gsbpass";

        private static readonly string CHAINE_CONNEXION =
            $"Server={SERVEUR};Port={PORT};Database={BASE_DE_DONNEES};Uid={UTILISATEUR};Pwd={MOT_DE_PASSE};";

        public static MySqlConnection Ouvrir()
        {
            MySqlConnection cnx = new MySqlConnection(CHAINE_CONNEXION);
            cnx.Open();
            return cnx;
        }
    }
}