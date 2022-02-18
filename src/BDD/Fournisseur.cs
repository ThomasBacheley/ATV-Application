using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class Fournisseur
    {
        public string ID_fournisseur;
        public string nom;
        public string mail;
        public string tel;
        public string adresse_rue;
        public string adresse_ville;
        public string adresse_cp;
        public string site_web;


        public Fournisseur(string ID_f, string n, string m, string t, string add_rue, string add_vil, string add_cp, string site)
        {
            ID_fournisseur = ID_f;
            nom = n;
            mail = m;
            tel = t;
            adresse_rue = add_rue;
            adresse_ville = add_vil;
            adresse_cp = add_cp;
            site_web = site;
        }
    }
}
