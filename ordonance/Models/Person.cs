using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tools_médecin.Models
{
    public class Person
    {
        //ATTRIBUT
        private string name;
        private string firstname;
        private string age;
        private string sex;

        //ACCESSEURS
        public string getFirstname() { return firstname; }
        public string getAge() { return age; }
        public string getSex() { return sex; }

        public void setFirstname(string firstname) { this.firstname = firstname; }
        public void setAge(string age) { this.age = age; }
        public void setName(string name) { this.name = name; }

        //CONSTRUCTEUR
        public Person() { }

        public Person(string newName, string newFirstname, string newAge)
        {
            this.name = newName;
            this.firstname = newFirstname;
            this.age = newAge;
        }
    }
}
 
