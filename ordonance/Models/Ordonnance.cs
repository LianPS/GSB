using System;
using System.Collections.Generic;

namespace tools_médecin.Models
{
    public class Ordonnance
    {
        public int Id { get; set; }
        public int IdMedecin { get; set; }
        public int IdPatient { get; set; }
        public DateTime DateCommande { get; set; }

        public List<LignePrescription> Lignes { get; set; }

        public Ordonnance()
        {
            Lignes = new List<LignePrescription>();
            DateCommande = DateTime.Now;
        }
    }

    public class LignePrescription
    {
        public string Medicament { get; set; }
        public string Posologie { get; set; }
        public string Duree { get; set; }
    }
}