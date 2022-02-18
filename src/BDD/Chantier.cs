using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class Chantier
    {
        public string ID_chantier;
        public string nom;
        public string nom_client;
        public string adresse_rue;
        public string adresse_ville;
        public string adresse_cp;
        public string date_recep;
        public string date_marche;

        public Chantier(string id_chant,string n,string n_c,string add_r,string add_v,string add_cp,string date_re,string date_mar)
        {
            ID_chantier = id_chant;
            nom = n;
            nom_client = n_c;
            adresse_rue = add_r;
            adresse_ville = add_v;
            adresse_cp = add_cp;
            date_recep = date_re;
            date_marche = date_mar;
        }
    }
}
