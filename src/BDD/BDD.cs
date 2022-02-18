using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;



/* ---------- Sommaire ---------- */


/* ----- Partie Client - Ligne 49 ----- */

/* ----- Partie Chantier - Ligne 156 ----- */

/* ----- Partie Fournisseur - Ligne 243 ----- */

/* ----- Partie Commande - Ligne 312 ----- */

/* ----- Partie Produit - Ligne 360 ----- */

/* ----- Partie Nuance - Ligne 435 ----- */


/* ------------------------------ */

namespace BDD
{
    public class bdd
    {
        MySqlConnection connexion = null;

        public bdd(string serveur, string Bdd, string User, string Mdp)
        {
            try
            {

                connexion = new MySqlConnection("server = " + serveur + ";database = " + Bdd + ";UID = " + User + ";Password = " + Mdp + ";SslMode = none;");

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /* ----- Partie Client ----- */

        public List<Client> ChercheClient(string Nom)
        {
            try
            {

                connexion.Open();

                string requete = "SELECT * FROM `clients` WHERE nom LIKE '" + Nom + "%' ORDER BY nom";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Client> ListClients = new List<Client>();
                while (reader.Read())
                {
                    Client client = new Client(reader["ID_client"].ToString(), reader["nom"].ToString(), reader["prenom"].ToString(), reader["adresse_rue"].ToString(), reader["adresse_ville"].ToString(), reader["adresse_cp"].ToString(), reader["tel_fix"].ToString(), reader["tel_port"].ToString(), reader["mail"].ToString(), reader["statut"].ToString());
                    ListClients.Add(client);
                }
                return ListClients;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int AjouterClient(Client client)
        {
            try
            {

                connexion.Open();

                string requete = "INSERT INTO `clients`(`nom`, `prenom`, `adresse_rue`, `adresse_ville`, `adresse_cp`, `tel_fixe`, `tel_port`, `mail`, `statut`) VALUES ('" + client.nom + "','" + client.prenom + "','" + client.adresse_rue + "','" + client.adresse_ville + "','" + client.adresse_cp + "','" + client.tel_fix + "','" + client.tel_port + "','" + client.mail + "','" + client.statut + "')";

                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int ModifierClient(Client client, int ID)
        {
            try
            {

                connexion.Open();

                string requete = "UPDATE `clients` SET `nom`='" + client.nom + "',`prenom`='" + client.prenom + "',`adresse_rue`='" + client.adresse_rue + "',`adresse_ville`='" + client.adresse_ville + "',`adresse_cp`='" + client.adresse_cp + "',`tel_fix`='" + client.tel_fix + "',`tel_port`='" + client.tel_port + "',`mail`='" + client.mail + "',`statut`='" + client.statut + "' WHERE ID_client = '" + ID + "'";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int SupprimerClient(int ID)
        {
            try
            {
                connexion.Open();

                string requete = "DELETE FROM `clients` WHERE ID_client = '" + ID + "'";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int VerifClient(Client cl)
        {
            try
            {
                connexion.Open();

                string requete = "SELECT * FROM `clients` WHERE `nom` LIKE '" + cl.nom + "' AND `prenom` LIKE '" + cl.prenom + "' AND `adresse_rue` LIKE '" + cl.adresse_rue + "' AND `adresse_ville` LIKE '" + cl.adresse_ville + "' AND `adresse_cp` LIKE '" + cl.adresse_cp + "' AND `tel_fix` LIKE '" + cl.tel_fix + "' AND `tel_port` LIKE '" + cl.tel_port + "' AND `mail` LIKE '" + cl.mail + "' AND `statut` LIKE '" + cl.statut + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /* ----- Partie Chantier----- */

        public List<Chantier> ChercheChantier(string nom_c)
        {
            try
            {

                connexion.Open();

                string requete = "SELECT * FROM `chantiers` WHERE nom_client LIKE '" + nom_c + "%' ORDER BY nom_client";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Chantier> ListChantiers = new List<Chantier>();
                while (reader.Read())
                {
                    Chantier chantier = new Chantier(reader["ID_chantier"].ToString(), reader["nom"].ToString(), reader["nom_client"].ToString(), reader["adresse_rue"].ToString(), reader["adresse_ville"].ToString(), reader["adresse_cp"].ToString(), reader["date_recep"].ToString(), reader["date_marche"].ToString());
                    ListChantiers.Add(chantier);
                }
                return ListChantiers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int AjouterChantier(Chantier chantier)
        {
            try
            {

                connexion.Open();

                string requete = "INSERT INTO `chantiers`(`nom`, `nom_client`, `adresse_rue`, `adresse_ville`, `adresse_cp`, `date_recep`, `date_marche`) VALUES ('" + chantier.nom + "','" + chantier.nom_client + "','" + chantier.adresse_rue + "','" + chantier.adresse_ville + "','" + chantier.adresse_cp + "','" + chantier.date_recep + "','" + chantier.date_marche + "')";

                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int ModifierChantier(Chantier ch, int ID_chantier)
        {
            try
            {

                connexion.Open();

                string requete = "UPDATE `chantiers` SET `nom_client`='" + ch.nom_client + "',`nom`='" + ch.nom + "',`adresse_rue`='" + ch.adresse_rue + "',`adresse_ville`='" + ch.adresse_ville + "',`adresse_cp`='" + ch.adresse_cp + "',`date_marche`='" + ch.date_marche + "',`date_reception`='" + ch.date_recep + "' WHERE ID_chantier = '" + ID_chantier + "'";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int SupprimerChantier(int ID)
        {
            try
            {
                connexion.Open();

                string requete = "DELETE FROM `chantiers` WHERE ID_chantier = '" + ID + "'";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /* ----- Partie Fournisseur ----- */

        public List<Fournisseur> ChercheFournisseur(string nom_f)
        {
            try
            {

                connexion.Open();

                string requete = "SELECT * FROM `fournisseurs` WHERE nom LIKE '" + nom_f + "%' ORDER BY nom";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Fournisseur> ListFournisseurs = new List<Fournisseur>();
                while (reader.Read())
                {
                    Fournisseur fournisseur = new Fournisseur(reader["ID_fournisseur"].ToString(), reader["nom"].ToString(), reader["mail"].ToString(), reader["tel"].ToString(), reader["adresse_rue"].ToString(), reader["adresse_ville"].ToString(), reader["adresse_cp"].ToString(), reader["site_web"].ToString());
                    ListFournisseurs.Add(fournisseur);
                }
                return ListFournisseurs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int AjouterFournisseur(string nom, string mail, string tel, string adresse_rue, string adresse_ville, string adresse_CP, string site)
        {
            try
            {


                connexion.Open();

                string requete = "INSERT INTO `fournisseurs`(`nom`, `mail`, `tel`, `adresse_rue`, `adresse_ville`, `adresse_cp`, `site_web`) VALUES ('" + nom + "','" + mail + "','" + tel + "','" + adresse_rue + "','" + adresse_ville + "','" + adresse_CP + "','" + site + "')";

                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int ModifierFournisseur(Fournisseur fourni, int ID_fournisseur)
        {
            try
            {

                connexion.Open();

                string requete = "UPDATE `fournisseurs` SET `nom`='" + fourni.nom + "',`mail`='" + fourni.mail + "',`tel=`'" + fourni.tel + "',`adresse_rue`='" + fourni.adresse_rue + "',`adresse_ville`='" + fourni.adresse_ville + "',`adresse_cp`='" + fourni.adresse_cp + "',`site_web`='" + fourni.site_web + "' WHERE ID_fournisseur = '" + ID_fournisseur + "'";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /* ----- Partie Commande ----- */

        public List<Commande> ChercheCommande(string num)
        {
            try
            {

                connexion.Open();

                string requete = "SELECT * FROM `commandes` WHERE numero LIKE '" + num + "%' ORDER BY numero";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Commande> ListCommandes = new List<Commande>();
                while (reader.Read())
                {
                    Commande comman = new Commande(reader["ID_commande"].ToString(), reader["fournisseur"].ToString(), reader["client"].ToString(), reader["chantier"].ToString(), reader["chanter_ville"].ToString(), reader["chantier_rue"].ToString(), reader["date_livraison"].ToString(), reader["numero"].ToString());
                    ListCommandes.Add(comman);
                }
                return ListCommandes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int AjouterCommande(Commande commande)
        {
            try
            {

                connexion.Open();

                string requete = "INSERT INTO `commandes`(`fournisseur`, `client`, `chantier`, `chantier_ville`, `chantier_rue`, `date_livraison`, `numero`) VALUES ('" + commande.fournisseur + "','" + commande.client + "','" + commande.chantier + "','" + commande.chantier_rue + "','" + commande.chantier_ville + "','" + commande.date_livraison + "','" + commande.numero + "')";

                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /* ----- Partie Produit ----- */

        public List<Produits> ChercheProduit(string n)
        {
            try
            {

                connexion.Open();

                string requete = "SELECT * FROM `produits` WHERE fabricant LIKE '" + n + "%' ORDER BY nom";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Produits> ListProduits = new List<Produits>();
                while (reader.Read())
                {
                    Produits produits = new Produits(reader["ID_produit"].ToString(), reader["nom"].ToString(), reader["caracteristique"].ToString(), reader["type_produit"].ToString(), reader["type_grain"].ToString(), reader["systeme"].ToString(), reader["support"].ToString(), reader["fournisseur"].ToString(), reader["fabricant"].ToString(), reader["consomation"].ToString(), reader["epaisseur_Rth"].ToString(), reader["prix_unitaire"].ToString(), reader["unite_grandeur"].ToString());
                    ListProduits.Add(produits);
                }
                return ListProduits;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public List<Produits> ChercheProduitnom(string n)
        {
            try
            {

                connexion.Open();

                string requete = "SELECT * FROM `produits` WHERE nom LIKE '" + n + "%' ORDER BY nom";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Produits> ListProduits = new List<Produits>();
                while (reader.Read())
                {
                    Produits produits = new Produits(reader["ID_produit"].ToString(), reader["nom"].ToString(), reader["caracteristique"].ToString(), reader["type_produit"].ToString(), reader["type_grain"].ToString(), reader["systeme"].ToString(), reader["support"].ToString(), reader["fournisseur"].ToString(), reader["fabricant"].ToString(), reader["consomation"].ToString(), reader["epaisseur_Rth"].ToString(), reader["prix_unitaire"].ToString(), reader["unite_grandeur"].ToString());
                    ListProduits.Add(produits);
                }
                return ListProduits;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int AjouterProduit(Produits prod)
        {
            try
            {

                connexion.Open();

                string requete = "INSERT INTO `produits`(`nom`, `caracteristique`, `type_produit`, `type_grain`, `systeme`, `support`, `fournisseur`, `fabricant`, `consomation`, `epaisseur_Rth`, `prix_unitaire`, `unite_grandeur`) VALUES ('" + prod.nom + "','" + prod.caracteristique + "','" + prod.type_produit + "','" + prod.type_grain + "','" + prod.systeme + "','" + prod.support + "','" + prod.fournisseur + "','" + prod.fabricant + "','" + prod.consomation + "','" + prod.epaisseur_Rth + "','" + prod.prix_unitaire + "','" + prod.unite_grandeur + "')";

                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /* ----- Partie Nuancier ----- */

        public List<Nuancier> ChercheNuancier(string Teinte)
        {
            try
            {

                connexion.Open();
                string requete = "SELECT * FROM `ref_nuancier` WHERE teinte LIKE '" + Teinte + "%' ORDER BY gamme DESC,teinte";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);

                MySqlDataReader reader = cmd.ExecuteReader();
                List<Nuancier> ListNuanciers = new List<Nuancier>();
                while (reader.Read())
                {
                    Nuancier nuancier = new Nuancier(reader["ID_nuancier"].ToString(), reader["teinte"].ToString(), reader["numero"].ToString(), reader["coefficient"].ToString(), reader["gamme"].ToString(), reader["plus_value"].ToString());
                    ListNuanciers.Add(nuancier);
                }
                return ListNuanciers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int AjouterNuancier(Nuancier nuancier)
        {
            try
            {

                connexion.Open();

                string requete = "INSERT INTO `ref_nuancier`(`teinte`, `numero`, `coefficient`, `gamme`, `plus_value`) VALUES ('" + nuancier.teinte + "','" + nuancier.numero + "','" + nuancier.coefficient + "','" + nuancier.gamme + "','" +  nuancier.plus_value + "')";

                //

                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int ModifierNuancier(Nuancier nuancier, int ID_nuancier)
        {
            try
            {

                connexion.Open();

                string requete = "UPDATE `ref_nuancier` SET `teinte`='" + nuancier.teinte + "',`numero`='" + nuancier.numero + "',`coefficient`='" + nuancier.coefficient + "',`gamme`='" + nuancier.gamme + "',`plus_value`='" + nuancier.plus_value + "' WHERE ID_nuancier = '" + ID_nuancier + "'";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //

        public int SupprimerNuancier(int ID)
        {
            try
            {
                connexion.Open();

                string requete = "DELETE FROM `ref_nuancier` WHERE ID_nuancier = '" + ID + "'";
                MySqlCommand cmd = new MySqlCommand(requete, connexion);
                int Result = cmd.ExecuteNonQuery();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
