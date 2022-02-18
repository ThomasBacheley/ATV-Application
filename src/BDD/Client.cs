using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class Client
    {
        public string ID_client;
        public string nom;
        public string prenom;
        public string adresse_rue;
        public string adresse_ville;
        public string adresse_cp;
        public string tel_fix;
        public string tel_port;
        public string mail;
        public string statut;

        public Client(string id, string nom_client, string prenom_client, string adresse_r_client, string adresse_v_client, string adresse_c_client, string tel_client_f,string tel_client_p, string mail_client, string stat)
        {
            ID_client = id;
            nom = nom_client;
            prenom = prenom_client;
            adresse_rue = adresse_r_client;
            adresse_ville = adresse_v_client;
            adresse_cp = adresse_c_client;
            tel_fix = tel_client_f;
            tel_port = tel_client_p;
            mail = mail_client;
            statut = stat;
        }
    }
}

