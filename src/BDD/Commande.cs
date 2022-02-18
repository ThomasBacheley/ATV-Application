using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class Commande
    {
        public string ID_commande;
        public string fournisseur;
        public string client;
        public string chantier;
        public string chantier_ville;
        public string chantier_rue;
        public string date_livraison;
        public string numero;

        public Commande(string id, string fourni, string cl, string ch, string ch_ville, string ch_rue, string date_livrai, string num)
        {
            ID_commande = id;
            fournisseur = fourni;
            client = cl;
            chantier = ch;
            chantier_ville = ch_ville;
            chantier_rue = ch_rue;
            date_livraison = date_livrai;
            numero = num;
        }
    }
}
