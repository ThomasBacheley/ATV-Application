using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class Nuancier
    {
        public string ID_nuancier;
        public string teinte;
        public string numero;
        public string coefficient;
        public string gamme;
        public string plus_value;

        public Nuancier(string id_nuan,string couleur, string refe, string coef, string gamme_produit,string plus_val)
        {
            ID_nuancier = id_nuan;
            teinte = couleur;
            numero = refe;
            coefficient = coef;
            gamme = gamme_produit;
            plus_value = plus_val;
        }
    }
}
