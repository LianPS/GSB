using System;

namespace tools_médecin.Models
{
    public class Patient : Person
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string NumeroSecu { get; set; }
        public string Sex { get; set; }
        public double Poids { get; set; }
        public int Taille { get; set; }
        public string Patho { get; set; }
        public Patient()
        {
        }
        public Patient(string nom, string prenom, DateTime ddn, string secu, string sex, double poids, int taille, string patho)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaissance = ddn;
            this.NumeroSecu = secu;
            this.Sex = sex;
            this.Poids = poids;
            this.Taille = taille;
            this.Patho = patho;
        }
        public string getNom() { return Nom; }
        public string getPrenom() { return Prenom; }
        public DateTime getDateNaissance() { return DateNaissance; }
        public string getNumeroSecu() { return NumeroSecu; }

        public void setNom(string n) { Nom = n; }
        public void setPrenom(string p) { Prenom = p; }
        public void setDateNaissance(DateTime d) { DateNaissance = d; }
        public void setNumeroSecu(string s) { NumeroSecu = s; }
    }
}