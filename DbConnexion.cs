using MySql.Data.MySqlClient;

namespace tools_médecin.DataAccess
{
    public static class DbConnexion
    {
        [cite_start]// Configuration simulant un accès serveur distant [cite: 527-532]
        // Remplacer "localhost" par une IP (ex: "192.168.1.50") si le serveur change de machine.
        private const string SERVEUR = "localhost";
        private const string PORT = "3306";
        private const string BASE_DE_DONNEES = "gsb_ordonnances";
        private const string UTILISATEUR = "gsb";
        private const string MOT_DE_PASSE = "gsbpass";

        [cite_start]// Construction de la chaîne de connexion ADO.NET [cite: 171]
        private static readonly string CHAINE_CONNEXION =
            $"Server={SERVEUR};Port={PORT};Database={BASE_DE_DONNEES};Uid={UTILISATEUR};Pwd={MOT_DE_PASSE};";

        /// <summary>
        /// Initialise et ouvre une connexion réseau vers le serveur MySQL.
        /// </summary>
        public static MySqlConnection Ouvrir()
        {
            [cite_start]// L'objet MySqlConnection traite le conteneur comme une entité externe via TCP [cite: 539]
            MySqlConnection cnx = new MySqlConnection(CHAINE_CONNEXION);
            cnx.Open();
            return cnx;
        }
    }
}