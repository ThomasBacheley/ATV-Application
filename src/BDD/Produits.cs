using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class Produits
    {
        public string ID_produit;
        public string nom;
        public string caracteristique;
        public string type_produit;
        public string type_grain;
        public string systeme;
        public string support;
        public string fournisseur;
        public string fabricant;
        public string consomation;
        public string epaisseur_Rth;
        public string prix_unitaire;
        public string unite_grandeur;

        public Produits(string id_prod,string n,string carac,string type_prod,string type_g,string syst,string supp,string fourni,string fab,string conso,string epaisseur,string prix_u,string u_grandeur)
        {
            ID_produit = id_prod;
            nom = n;
            carac = caracteristique;
            type_prod = type_produit;
            type_g = type_grain;
            systeme = syst;
            support = supp;
            fournisseur = fourni;
            fabricant = fab;
            consomation = conso;
            epaisseur_Rth = epaisseur;
            prix_unitaire = prix_u;
            unite_grandeur = u_grandeur;
        }
    }
}
