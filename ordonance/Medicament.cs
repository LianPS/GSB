using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tools_médecin
{
    internal class Medicament
    {
        //ATTRIBUT
        private string name;
        private string dose;
        private string type;


        //ACCESSEURS
        public string getname() { return name; }
        public string getdose() { return dose; }
        public string gettype() { return type; }

        public void setname(string name) { this.name = name; }
        public void setdose(string dose) { this.dose = dose; }
        public void settype(string type) { this.type = type; }

        //CONSTRUCTEUR
        public Medicament() { }

        public Medicament(string newtype, string newname, string newdose)
        {
            this.name = newname;
            this.dose = newdose;
            this.type = newtype;
        }
    }
}
 
