using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using MySql.Data;
using MySql.Data.MySqlClient;
using BDD;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;



/* ---------- Sommaire Par Partie ---------- */


/* - Partie client : Ligne 128 -  */

/* - Partie chantier : Ligne 452 - */

/* - Partie fournisseur : Ligne 654 - */

/* - Partie commande : Ligne 838 - */

/* - Partie produit : Ligne 2760 - */

/* - Partie parametre : Ligne 3043 - */


/* ----------------------------------------- */



namespace Application_Stage
{
    public partial class MainWindow : Window
    {
        public List<Client> monClient;
        public List<Commande> maCommande;
        public List<Nuancier> monNuancier;
        public List<Chantier> monChantier;
        public List<Fournisseur> monfournisseur;
        public List<Produits> monProduit;
        string coef;
        int i = 0;
        string stat;

        //
        string info_client = "";
        string n_chantier = "";
        string r_chantier = "";
        string v_chantier = "";
        string info_fournisseur = "";
        //

        //
        string quant_prod1;
        string unite_prod1;
        string ref_prod1;
        string produit_info1;
        string produit_prix1;

        string quant_prod2;
        string unite_prod2;
        string ref_prod2;
        string produit_info2;
        string produit_prix2;

        string quant_prod3;
        string unite_prod3;
        string ref_prod3;
        string produit_info3;
        string produit_prix3;

        string quant_prod4;
        string unite_prod4;
        string ref_prod4;
        string produit_info4;
        string produit_prix4;

        string quant_prod5;
        string unite_prod5;
        string ref_prod5;
        string produit_info5;
        string produit_prix5;

        string quant_prod6;
        string unite_prod6;
        string ref_prod6;
        string produit_info6;
        string produit_prix6;

        string quant_prod7;
        string unite_prod7;
        string ref_prod7;
        string produit_info7;
        string produit_prix7;

        string quant_prod8;
        string unite_prod8;
        string ref_prod8;
        string produit_info8;
        string produit_prix8;

        string quant_prod9;
        string unite_prod9;
        string ref_prod9;
        string produit_info9;
        string produit_prix9;

        string quant_prod10;
        string unite_prod10;
        string ref_prod10;
        string produit_info10;
        string produit_prix10;
        //

        //
        string prix_total_commande;
        //
        public MainWindow()
        {
            InitializeComponent();
        }

        /* ----- Partie Client ----- */

        private void txtbox_client_nom_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                if (lb_client.Items.Count != 0)
                {
                    lb_client.Items.Clear();
                }

                bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                List<Client> client = bdd.ChercheClient(txtbox_client_nom.Text.ToUpper());

                if (client != null)
                {
                    monClient = client;

                    foreach (Client cl in client)
                    {
                        lb_client.Items.Add(" | Nom : " + cl.nom + " | Prenom : " + cl.prenom + " | Adresse : " + cl.adresse_rue + " " + cl.adresse_ville + " " + cl.adresse_cp + " | Tel : " + cl.tel_fix + "/" + cl.tel_port + " | Mail : " + cl.mail + " | Statut : " + cl.statut + " |");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //

        private void rb_client_entreprise_Checked(object sender, RoutedEventArgs e)
        {
            stat = rb_client_entreprise.Content.ToString();
            txtbox_client_prenom.IsReadOnly = true;
            txtbox_client_prenom.Text = "";
        }

        //

        private void rb_client_particulier_Checked(object sender, RoutedEventArgs e)
        {
            stat = rb_client_particulier.Content.ToString();
            txtbox_client_prenom.IsReadOnly = false;
        }

        //

        private void lb_client_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (monClient[lb_client.SelectedIndex].statut == "Entreprise")
            {
                rb_client_entreprise.IsChecked = true;
            }
            else
            {
                rb_client_particulier.IsChecked = true;
            }

            txtbox_client_prenom.Text = monClient[lb_client.SelectedIndex].prenom.ToUpper();
            txtbox_client_tel_fix.Text = monClient[lb_client.SelectedIndex].tel_fix;
            txtbox_client_tel_portable.Text = monClient[lb_client.SelectedIndex].tel_port;
            txtbox_client_mail.Text = monClient[lb_client.SelectedIndex].mail.ToUpper();
            txtbox_client_adresse_rue.Text = monClient[lb_client.SelectedIndex].adresse_rue.ToUpper();
            txtbox_client_adresse_ville.Text = monClient[lb_client.SelectedIndex].adresse_ville.ToUpper();
            txtbox_client_adresse_codepostal.Text = monClient[lb_client.SelectedIndex].adresse_cp;

            btn_client_supprimer.IsEnabled = true;
            btn_client_modif.IsEnabled = true;
            btn_client_selection.IsEnabled = true;
        }

        //

        private void btn_client_ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (verif_champ_client())
            {
                try
                {
                    bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                    Client cl = new Client("", txtbox_client_nom.Text.ToUpper(), txtbox_client_prenom.Text.ToUpper(), txtbox_client_adresse_rue.Text.ToUpper(), txtbox_client_adresse_ville.Text.ToUpper(), txtbox_client_adresse_codepostal.Text, txtbox_client_tel_fix.Text, txtbox_client_tel_portable.Text, txtbox_client_mail.Text.ToUpper(), stat);

                    MessageBox.Show((bdd.VerifClient(cl)).ToString());

                    //if(bdd.VerifClient(cl))
                    //{
                    //    bdd.AjouterClient(cl);
                    //    MessageBox.Show("L'ajout a été effectué");
                    //    clear_ch_client();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Un client avec les mêmes informations existe déjà");
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("L'ajout n'a pas été effectué");
            }

        }

        //

        private void btn_client_modif_Click(object sender, RoutedEventArgs e)
        {
            if (verif_champ_client())
            {
                try
                {
                    bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                    Client cl = new Client("", monClient[lb_client.SelectedIndex].nom.ToUpper(), txtbox_client_prenom.Text.ToUpper(), txtbox_client_adresse_rue.Text.ToUpper(), txtbox_client_adresse_ville.Text.ToUpper(), txtbox_client_adresse_codepostal.Text, txtbox_client_tel_fix.Text, txtbox_client_tel_portable.Text, txtbox_client_mail.Text.ToUpper(), stat);
                    int ID = Convert.ToInt32(monClient[lb_client.SelectedIndex].ID_client);
                    bdd.ModifierClient(cl, ID);
                    MessageBox.Show("Modification effectuée");
                    clear_ch_client();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("La modification n'a pas été effectuée");
            }
        }

        //

        private void btn_client_selection_Click(object sender, RoutedEventArgs e)
        {
            info_client = monClient[lb_client.SelectedIndex].nom.ToUpper() + " " + monClient[lb_client.SelectedIndex].prenom.ToUpper();
            tabcontrolapp.SelectedItem = TB_chantier;
        }

        //

        private void btn_client_supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (verif_champ_client())
            {
                bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);

                bdd.SupprimerClient(Convert.ToInt32(monClient[lb_client.SelectedIndex].ID_client));
                MessageBox.Show("Le client a bien été supprimé");
                clear_ch_client();
            }
            else
            {
                MessageBox.Show("Le client n'a pas pu être supprimé");
            }
        }

        //

        private bool verif_champ_client()
        {
            Regex regex_nom = new Regex(@"^[a-zA-Z][a-zéèà]{2,15}$");
            Regex regex_prenom = new Regex(@"^[a-zA-Z][a-zé]{2,15}$");
            Regex regex_ville = new Regex(@"^([a-zA-Z]{1}[a-z]{1,15}(\s){0,1}){1,5}$");
            Regex regex_CP = new Regex(@"[0-9]{5}$");
            Regex regex_rue = new Regex(@"^[0-9]{0,3}(\s{1}[a-zA-Z]{1,20}){1,5}$");// 1 à 5 paquets de "lettre"
            Regex regex_telephone = new Regex(@"0[2-7]{1}[0-9]{8}$");
            Regex regex_mail = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

            try
            {
                if (stat == "Entreprise")
                {
                    if (!regex_nom.IsMatch(txtbox_client_nom.Text))
                    {
                        throw new Exception("Erreur : Nom incorrect ou vide");
                    }
                    else
                    {
                        if (!regex_rue.IsMatch(txtbox_client_adresse_rue.Text))
                        {
                            throw new Exception("Erreur : Rue incorrecte ou vide");
                        }
                        else
                        {
                            if (!regex_ville.IsMatch(txtbox_client_adresse_ville.Text))
                            {
                                throw new Exception("Erreur : Ville incorrecte ou vide");
                            }
                            else
                            {
                                if (!regex_CP.IsMatch(txtbox_client_adresse_codepostal.Text))
                                {
                                    throw new Exception("Erreur : Code Postal incorrect ou vide");
                                }
                                else
                                {
                                    if (!regex_telephone.IsMatch(txtbox_client_tel_fix.Text))
                                    {
                                        throw new Exception("Erreur : Téléphone fix incorrect ou vide");
                                    }
                                    else
                                    {
                                        if(!regex_telephone.IsMatch(txtbox_client_tel_portable.Text))
                                        {
                                            throw new Exception("Erreur : Téléphone portable incorrect ou vide");
                                        }
                                        else
                                        {
                                            if (!regex_mail.IsMatch(txtbox_client_mail.Text))
                                            {
                                                throw new Exception("Erreur : Mail invalide ou vide");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Vérification réussie !");
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (stat == "Particulier")
                    {
                        if (!regex_nom.IsMatch(txtbox_client_nom.Text))
                        {
                            throw new Exception("Erreur : Nom incorrect ou vide");
                        }
                        else
                        {
                            if (!regex_prenom.IsMatch(txtbox_client_prenom.Text))
                            {
                                throw new Exception("Erreur : Prénom incorrect ou vide");
                            }
                            else
                            {
                                if (!regex_rue.IsMatch(txtbox_client_adresse_rue.Text))
                                {
                                    throw new Exception("Erreur : Rue incorrecte ou vide");
                                }
                                else
                                {
                                    if (!regex_ville.IsMatch(txtbox_client_adresse_ville.Text))
                                    {
                                        throw new Exception("Erreur : Ville incorrecte ou vide");
                                    }
                                    else
                                    {
                                        if (!regex_CP.IsMatch(txtbox_client_adresse_codepostal.Text))
                                        {
                                            throw new Exception("Erreur : Code Postal incorrect ou vide");
                                        }
                                        else
                                        {
                                            if (!regex_telephone.IsMatch(txtbox_client_tel_fix.Text))
                                            {
                                                throw new Exception("Erreur : Téléphone fix incorrect ou vide");
                                            }
                                            else
                                            {
                                                if (!regex_telephone.IsMatch(txtbox_client_tel_portable.Text))
                                                {
                                                    throw new Exception("Erreur : Téléphone portable incorrect ou vide");
                                                }
                                                else
                                                {
                                                    if (!regex_mail.IsMatch(txtbox_client_mail.Text))
                                                    {
                                                        throw new Exception("Erreur : Mail invalide ou vide");
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Vérification réussie !");
                                                        return true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Pas de statut sélectionné");
                    }
                }
            }
            catch (Exception verif)
            {
                MessageBox.Show(verif.Message);
                return false;
            }
        }

        //

        private void clear_ch_client()
        {
            txtbox_client_nom.Text = "";
            txtbox_client_prenom.IsReadOnly = false;
            txtbox_client_prenom.Text = "";
            txtbox_client_adresse_rue.Text = "";
            txtbox_client_adresse_ville.Text = "";
            txtbox_client_adresse_codepostal.Text = "";
            txtbox_client_mail.Text = "";
            txtbox_client_tel_fix.Text = "";
            txtbox_client_tel_portable.Text = "";
        }



        /* ----- Partie Chantier ----- */

        private void txtbox_chantier_client_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (lb_chantier.Items.Count != 0)
                {
                    lb_chantier.Items.Clear();
                }

                bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                List<Chantier> chantier = bdd.ChercheChantier(txtbox_chantier_client.Text.ToUpper());

                monChantier = chantier;

                foreach (Chantier ch in chantier)
                {
                    lb_chantier.Items.Add(" | Nom Client : " + ch.nom_client + " | Chantier : " + ch.nom + " | Adresse : " + ch.adresse_rue + " " + ch.adresse_ville + " " + ch.adresse_cp + " |");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //

        private void lb_chantier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtbox_chantier_nom.Text = monChantier[lb_chantier.SelectedIndex].nom.ToUpper();
            txtbox_chantier_rue.Text = monChantier[lb_chantier.SelectedIndex].adresse_rue.ToUpper();
            txtbox_chantier_ville.Text = monChantier[lb_chantier.SelectedIndex].adresse_ville.ToUpper();
            txtbox_chantier_CP.Text = monChantier[lb_chantier.SelectedIndex].adresse_cp;

            btn_chantier_modif.IsEnabled = true;
            btn_chantier_supprimer.IsEnabled = true;
            btn_chantier_valide.IsEnabled = true;

        }

        //

        private void btn_chantier_ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (verif_champ_chantier())
            {
                try
                {
                    string date_recep = dtp_chantier_reception.SelectedDate.Value.ToString("d");
                    string date_marche = dtp_chantier_marche.SelectedDate.Value.ToString("d");
                    bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                    Chantier ch = new Chantier("", txtbox_chantier_nom.Text.ToUpper(), txtbox_chantier_client.Text.ToUpper(), txtbox_chantier_rue.Text.ToUpper(), txtbox_chantier_ville.Text.ToUpper(), txtbox_chantier_CP.Text, date_recep, date_marche);
                    bdd.AjouterChantier(ch);
                    MessageBox.Show("L'ajout a été éffectué");
                    clear_ch_chantier();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("L'ajout n'a pas été éffectué");
            }
        }

        //

        private void btn_chantier_modif_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (verif_champ_chantier())
                {
                    string date_recep = dtp_chantier_reception.SelectedDate.Value.ToString("d");
                    string date_marche = dtp_chantier_marche.SelectedDate.Value.ToString("d");
                    bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                    Chantier ch = new Chantier("", txtbox_chantier_nom.Text.ToUpper(), monChantier[lb_chantier.SelectedIndex].nom_client.ToUpper(), txtbox_chantier_rue.Text.ToUpper(), txtbox_chantier_ville.Text.ToUpper(), txtbox_chantier_CP.Text, date_recep, date_marche);
                    int ID = Convert.ToInt32(monChantier[lb_chantier.SelectedIndex].ID_chantier);
                    bdd.ModifierChantier(ch, ID);
                    MessageBox.Show("La modification a été effectuée");
                }
                else
                {
                    MessageBox.Show("La modification n'a pas été effectuée");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //

        private void btn_chantier_valide_Click(object sender, RoutedEventArgs e)
        {
            n_chantier = monChantier[lb_chantier.SelectedIndex].nom.ToUpper();
            r_chantier = monChantier[lb_chantier.SelectedIndex].adresse_rue.ToUpper();
            v_chantier = monChantier[lb_chantier.SelectedIndex].adresse_ville.ToUpper();
            tabcontrolapp.SelectedItem = TB_fournisseur;
        }

        //

        private void btn_chantier_supprimer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (verif_champ_chantier())
                {
                    bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);

                    bdd.SupprimerChantier(Convert.ToInt32(monChantier[lb_chantier.SelectedIndex].ID_chantier));
                    MessageBox.Show("Le chantier a été suprimé");
                    clear_ch_chantier();
                    
                }
                else
                {
                    MessageBox.Show("Le chantier n'a pas été suprimé");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //


        private bool verif_champ_chantier()
        {
            Regex regex_nom = new Regex(@"^[a-zA-ZÉ]{1}[a-zé]{2,15}(\s{0,1}[a-zA-ZÉ]{1}[a-zé]{2,15}){0,4}$");
            Regex regex_client = new Regex(@"^[a-zA-ZÉ]{1}[a-zé]{2,15}$");
            Regex regex_ville = new Regex(@"^([a-zA-Z]{1}[a-z]{1,15}(\s){0,1}){1,5}$");
            Regex regex_CP = new Regex(@"[0-9]{5}$");
            Regex regex_rue = new Regex(@"^[0-9]{0,3}(\s{1}[a-zA-Z]{1,20}){1,5}$");// 1 à 5 paquets de "lettre"

            try
            {
                if (!regex_nom.IsMatch(txtbox_chantier_nom.Text))
                {
                    throw new Exception("Le nom du chantier est incorrect ou vide");
                }
                else
                {
                    if (!regex_client.IsMatch(txtbox_chantier_client.Text))
                    {
                        throw new Exception("Le nom du client est incorrect ou vide");
                    }
                    else
                    {
                        if (!regex_rue.IsMatch(txtbox_chantier_rue.Text))
                        {
                            throw new Exception("La rue est incorrecte ou vide");
                        }
                        else
                        {
                            if (!regex_ville.IsMatch(txtbox_chantier_ville.Text))
                            {
                                throw new Exception("La ville est incorrecte ou vide");
                            }
                            else
                            {
                                if (!regex_CP.IsMatch(txtbox_chantier_CP.Text))
                                {
                                    throw new Exception("Code Postal incorrect ou vide");
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception verif)
            {
                MessageBox.Show(verif.Message);
                return false;
            }
        }

        //

        private void clear_ch_chantier()
        {
            txtbox_chantier_client.Text = "";
            txtbox_chantier_nom.Text = "";
            txtbox_chantier_rue.Text = "";
            txtbox_chantier_ville.Text = "";
            txtbox_chantier_CP.Text = "";
        }



        /* ----- Partie Fournisseur ----- */

        private void txtbox_fournisseur_nom_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (lb_fournisseur.Items.Count != 0)
                {
                    lb_fournisseur.Items.Clear();
                }

                bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                List<Fournisseur> fournisseur = bdd.ChercheFournisseur(txtbox_fournisseur_nom.Text.ToUpper());

                if (fournisseur != null)
                {
                    monfournisseur = fournisseur;

                    foreach (Fournisseur fr in fournisseur)
                    {
                        lb_fournisseur.Items.Add(" | Nom : " + fr.nom + " | Mail : " + fr.mail + " | Tel : " + fr.tel + " | Adresse : " + fr.adresse_rue + " " + fr.adresse_ville + " " + fr.adresse_cp + " | Site : " + fr.site_web + " | ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //

        private void lb_fournisseur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            btn_fournisseur_modif.IsEnabled = true;
            btn_fournisseur_selectionne.IsEnabled = true;

            txtbox_fournisseur_mail.Text = monfournisseur[lb_fournisseur.SelectedIndex].mail.ToUpper();
            txtbox_fournisseur_tel.Text = monfournisseur[lb_fournisseur.SelectedIndex].tel;
            txtbox_fournisseur_rue.Text = monfournisseur[lb_fournisseur.SelectedIndex].adresse_rue.ToUpper();
            txtbox_fournisseur_ville.Text = monfournisseur[lb_fournisseur.SelectedIndex].adresse_ville.ToUpper();
            txtbox_fournisseur_CP.Text = monfournisseur[lb_fournisseur.SelectedIndex].adresse_cp;
            txtbox_fournisseur_site.Text = monfournisseur[lb_fournisseur.SelectedIndex].site_web.ToUpper();

        }

        //

        private void btn_fournisseur_ajoute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (verif_champ_fournisseur())
                {
                    bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                    bdd.AjouterFournisseur(txtbox_fournisseur_nom.Text.ToUpper(), txtbox_fournisseur_mail.Text.ToUpper(), txtbox_fournisseur_tel.Text.ToUpper(), txtbox_fournisseur_rue.Text.ToUpper(), txtbox_fournisseur_ville.Text.ToUpper(), txtbox_fournisseur_CP.Text, txtbox_fournisseur_site.Text.ToUpper());
                    MessageBox.Show("L'ajout a été effectué");
                    clear_ch_fournisseur();
                }
                else
                {
                    MessageBox.Show("L'ajout n'a pas été effectué");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //

        private void btn_fournisseur_modif_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (verif_champ_fournisseur())
                {
                    bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                    Fournisseur four = new Fournisseur("", txtbox_fournisseur_nom.Text.ToUpper(), txtbox_fournisseur_mail.Text.ToUpper(), txtbox_fournisseur_tel.Text, txtbox_fournisseur_rue.Text.ToUpper(), txtbox_fournisseur_ville.Text.ToUpper(), txtbox_fournisseur_CP.Text, txtbox_fournisseur_site.Text.ToUpper());
                    bdd.ModifierFournisseur(four, Convert.ToInt32(monfournisseur[lb_fournisseur.SelectedIndex].ID_fournisseur));
                    MessageBox.Show("La modification a été effectuée");
                }
                else
                {
                    MessageBox.Show("La modification n'a pas été effectuée");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //

        private void btn_fournisseur_selectionne_Click(object sender, RoutedEventArgs e)
        {
            info_fournisseur = monfournisseur[lb_fournisseur.SelectedIndex].nom;
            tabcontrolapp.SelectedItem = TB_commande;
        }

        //

        private bool verif_champ_fournisseur()
        {
            Regex regex_nom = new Regex(@"^\s+");
            Regex regex_mail = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            Regex regex_telephone = new Regex(@"0[2-7]{1}[0-9]{8}$");
            Regex regex_ville = new Regex(@"^([a-zA-Z]{1}[a-z]{1,15}(\s){0,1}){1,5}$");
            Regex regex_CP = new Regex(@"[0-9]{5}$");
            Regex regex_rue = new Regex(@"^[0-9]{0,3}[a-zA-Z]{0,2}(\s{1}[a-zA-Z]{1,20}){1,5}$");// 1 à 5 paquets de "lettre"

            try
            {
                if (regex_nom.IsMatch(txtbox_fournisseur_nom.Text) || txtbox_fournisseur_nom.Text == "")
                {
                    throw new Exception("Erreur : Nom incorrect ou vide");
                }
                else
                {
                    if (!regex_mail.IsMatch(txtbox_fournisseur_mail.Text))
                    {
                        throw new Exception("Erreur : Mail incorrect ou vide");
                    }
                    else
                    {
                        if (!regex_telephone.IsMatch(txtbox_fournisseur_tel.Text))
                        {
                            throw new Exception("Erreur : Téléphone incorrect ou vide");
                        }
                        else
                        {
                            if (!regex_rue.IsMatch(txtbox_fournisseur_rue.Text))
                            {
                                throw new Exception("Erreur : Rue incorrecte ou vide");
                            }
                            else
                            {
                                if (!regex_ville.IsMatch(txtbox_fournisseur_ville.Text))
                                {
                                    throw new Exception("Erreur : Ville incorrecte ou vide");
                                }
                                else
                                {
                                    if (!regex_CP.IsMatch(txtbox_fournisseur_CP.Text))
                                    {
                                        throw new Exception("Erreur : Code Postal incorrect ou vide");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Vérification réussie !");
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception verif)
            {
                MessageBox.Show(verif.Message);
                return false;
            }
        }

        //

        private void clear_ch_fournisseur()
        {
            txtbox_fournisseur_nom.Text = "";
            txtbox_fournisseur_mail.Text = "";
            txtbox_fournisseur_tel.Text = "";
            txtbox_fournisseur_rue.Text = "";
            txtbox_fournisseur_ville.Text = "";
            txtbox_fournisseur_CP.Text = "";
            txtbox_fournisseur_site.Text = "";
        }



        /* ----- Partie Commande ----- */

        private void txtbox_commande_num_cmd_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (lb_commande_commande.Items.Count != 0)
            //{
            //    lb_commande_commande.Items.Clear();
            //}


            //bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
            //List<Commande> cmd = bdd.ChercheCommande((txtbox_commande_teinte.Text).ToUpper());

            //if (cmd != null)
            //{

            //    foreach (Commande cmde in cmd)
            //    {
            //        lb_commande_commande.Items.Add(" | Numero : " + cmde.numero + " | Client : " + cmde.client + " | Chantier : " + cmde.chantier + " |");
            //    }
            //}
        }

        //

        private void txtbox_commande_produit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lb_commande_produit.Items.Count != 0)
            {
                lb_commande_produit.Items.Clear();
            }


            bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
            List<Produits> produits = bdd.ChercheProduit((txtbox_commande_produit.Text).ToUpper());

            if (produits != null)
            {
                monProduit = produits;

                foreach (Produits pr in produits)
                {
                    lb_commande_produit.Items.Add(pr.nom + " " + pr.caracteristique + " " + pr.systeme + " " + pr.type_grain + " " + pr.prix_unitaire + " € / " + pr.unite_grandeur);
                }
            }
            else
            {
                txtbox_commande_prix_unitaire.Text = "";
                txtbox_commande_prix_total.Text = "";
                label_unite.Content = "";
            }
        }

        //

        private void lb_commande_produit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtbox_commande_prix_unitaire.Text = monProduit[lb_commande_produit.SelectedIndex].prix_unitaire;
            label_unite.Content = monProduit[lb_commande_produit.SelectedIndex].unite_grandeur;
            if (txtbox_commande_quantite.Text != "")
            {
                txtbox_commande_prix_total.Text = (Convert.ToInt32(txtbox_commande_quantite.Text) * Convert.ToInt32(txtbox_commande_prix_unitaire.Text)).ToString();
            }
        }

        //

        private void txtbox_commande_teinte_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lb_commande_nuance.Items.Count != 0)
            {
                lb_commande_nuance.Items.Clear();
            }


            bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
            List<Nuancier> nuancier = bdd.ChercheNuancier((txtbox_commande_teinte.Text).ToUpper());

            if (nuancier != null)
            {
                monNuancier = nuancier;

                foreach (Nuancier nua in nuancier)
                {
                    lb_commande_nuance.Items.Add(" | Teinte : " + nua.teinte + " | N° : " + nua.numero + " | Plus-value " + nua.plus_value + " |");
                }
            }
        }

        //

        private void txtbox_commande_quantite_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex quantite = new Regex(@"^[1-9]{1}[0-9]{0,5}$");
            if (!quantite.IsMatch(txtbox_commande_quantite.Text))
            {
                txtbox_commande_prix_total.Text = "";
            }
            else
            {
                if (txtbox_commande_prix_unitaire.Text == "")
                {
                    txtbox_commande_prix_total.Text = "";
                }
                else
                {
                    txtbox_commande_prix_total.Text = (Convert.ToInt32(txtbox_commande_prix_unitaire.Text) * Convert.ToInt32(txtbox_commande_quantite.Text)).ToString();
                }

            }
        }

        //

        private void btn_commande_ajouter_prod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lb_commande_nuance.SelectedItem != null)
                {
                    if (txtbox_commande_prix_unitaire.Text == "")
                    {
                        throw new Exception("Prix du produit inconnu");
                    }
                    else
                    {
                        if (txtbox_commande_quantite.Text == "")
                        {
                            throw new Exception("La quantité n'est pas renseignée");
                        }
                        else
                        {
                            i++;

                            if (i == 1)
                            {
                                quant_prod1 = txtbox_commande_quantite.Text;
                                unite_prod1 = monProduit[lb_commande_produit.SelectedIndex].unite_grandeur;
                                ref_prod1 = monNuancier[lb_commande_nuance.SelectedIndex].numero + " " + monNuancier[lb_commande_nuance.SelectedIndex].teinte;
                                produit_info1 = monProduit[lb_commande_produit.SelectedIndex].nom + " " + monProduit[lb_commande_produit.SelectedIndex].type_produit + " " + monProduit[lb_commande_produit.SelectedIndex].type_grain;
                                produit_prix1 = txtbox_commande_prix_total.Text;
                                MessageBox.Show("Produit Ajouté à la commande");
                                lb_commande_produit_final.Items.Add(" | " + quant_prod1 + " " + unite_prod1 + " | " + ref_prod1 + " | " + produit_info1 + " | " + produit_prix1 + " €");
                                txtbox_commande_prix_total_produit.Text = "";
                                txtbox_commande_prix_total_produit.Text = (Convert.ToUInt32(produit_prix1)).ToString() + " €";
                            }
                            else
                            {
                                if (i == 2)
                                {
                                    quant_prod2 = txtbox_commande_quantite.Text;
                                    unite_prod2 = monProduit[lb_commande_produit.SelectedIndex].unite_grandeur;
                                    ref_prod2 = monNuancier[lb_commande_nuance.SelectedIndex].numero + " " + monNuancier[lb_commande_nuance.SelectedIndex].teinte;
                                    produit_info2 = monProduit[lb_commande_produit.SelectedIndex].nom + " " + monProduit[lb_commande_produit.SelectedIndex].type_produit + " " + monProduit[lb_commande_produit.SelectedIndex].type_grain;
                                    produit_prix2 = txtbox_commande_prix_total.Text;
                                    MessageBox.Show("Produit Ajouté à la commande");
                                    lb_commande_produit_final.Items.Add(" | " + quant_prod2 + " " + unite_prod2 + " | " + ref_prod2 + " | " + produit_info2 + " | " + produit_prix2 + " €");
                                    txtbox_commande_prix_total_produit.Text = "";
                                    txtbox_commande_prix_total_produit.Text = (Convert.ToUInt32(produit_prix1) + Convert.ToUInt32(produit_prix2)).ToString() + " €";
                                }
                                else
                                {
                                    if (i == 3)
                                    {
                                        quant_prod3 = txtbox_commande_quantite.Text;
                                        unite_prod3 = monProduit[lb_commande_produit.SelectedIndex].unite_grandeur;
                                        ref_prod3 = monNuancier[lb_commande_nuance.SelectedIndex].numero + " " + monNuancier[lb_commande_nuance.SelectedIndex].teinte;
                                        produit_info3 = monProduit[lb_commande_produit.SelectedIndex].nom + " " + monProduit[lb_commande_produit.SelectedIndex].type_produit + " " + monProduit[lb_commande_produit.SelectedIndex].type_grain;
                                        produit_prix3 = txtbox_commande_prix_total.Text;
                                        MessageBox.Show("Produit Ajouté à la commande");
                                        lb_commande_produit_final.Items.Add(" | " + quant_prod3 + " " + unite_prod3 + " | " + ref_prod3 + " | " + produit_info3 + " | " + produit_prix3 + " €");
                                        txtbox_commande_prix_total_produit.Text = "";
                                        txtbox_commande_prix_total_produit.Text = (Convert.ToUInt32(produit_prix1) + Convert.ToUInt32(produit_prix2) + Convert.ToUInt32(produit_prix3)).ToString() + " €";
                                    }
                                    else
                                    {
                                        if (i == 4)
                                        {
                                            quant_prod4 = txtbox_commande_quantite.Text;
                                            unite_prod4 = monProduit[lb_commande_produit.SelectedIndex].unite_grandeur;
                                            ref_prod4 = monNuancier[lb_commande_nuance.SelectedIndex].numero + " " + monNuancier[lb_commande_nuance.SelectedIndex].teinte;
                                            produit_info4 = monProduit[lb_commande_produit.SelectedIndex].nom + " " + monProduit[lb_commande_produit.SelectedIndex].type_produit + " " + monProduit[lb_commande_produit.SelectedIndex].type_grain;
                                            produit_prix4 = txtbox_commande_prix_total.Text;
                                            MessageBox.Show("Produit Ajouté à la commande");
                                            lb_commande_produit_final.Items.Add(" | " + quant_prod4 + " " + unite_prod4 + " | " + ref_prod4 + " | " + produit_info4 + " | " + produit_prix4 + " €");
                                            txtbox_commande_prix_total_produit.Text = "";
                                            txtbox_commande_prix_total_produit.Text = (Convert.ToUInt32(produit_prix1) + Convert.ToUInt32(produit_prix2) + Convert.ToUInt32(produit_prix3) + Convert.ToUInt32(produit_prix4)).ToString() + " €";
                                        }
                                        else
                                        {
                                            if (i == 5)
                                            {
                                                quant_prod5 = txtbox_commande_quantite.Text;
                                                unite_prod5 = monProduit[lb_commande_produit.SelectedIndex].unite_grandeur;
                                                ref_prod5 = monNuancier[lb_commande_nuance.SelectedIndex].numero + " " + monNuancier[lb_commande_nuance.SelectedIndex].teinte;
                                                produit_info5 = monProduit[lb_commande_produit.SelectedIndex].nom + " " + monProduit[lb_commande_produit.SelectedIndex].type_produit + " " + monProduit[lb_commande_produit.SelectedIndex].type_grain;
                                                produit_prix5 = txtbox_commande_prix_total.Text;
                                                MessageBox.Show("Produit Ajouté à la commande");
                                                lb_commande_produit_final.Items.Add(" | " + quant_prod5 + " " + unite_prod5 + " | " + ref_prod5 + " | " + produit_info5 + " | " + produit_prix5 + " €");
                                                txtbox_commande_prix_total_produit.Text = "";
                                                txtbox_commande_prix_total_produit.Text = (Convert.ToUInt32(produit_prix1) + Convert.ToUInt32(produit_prix2) + Convert.ToUInt32(produit_prix3) + Convert.ToUInt32(produit_prix4) + Convert.ToUInt32(produit_prix5)).ToString() + " €";
                                            }
                                            else
                                            {
                                                if (i == 6)
                                                {
                                                    quant_prod6 = txtbox_commande_quantite.Text;
                                                    unite_prod6 = monProduit[lb_commande_produit.SelectedIndex].unite_grandeur;
                                                    ref_prod6 = monNuancier[lb_commande_nuance.SelectedIndex].numero + " " + monNuancier[lb_commande_nuance.SelectedIndex].teinte;
                                                    produit_info6 = monProduit[lb_commande_produit.SelectedIndex].nom + " " + monProduit[lb_commande_produit.SelectedIndex].type_produit + " " + monProduit[lb_commande_produit.SelectedIndex].type_grain;
                                                    produit_prix6 = txtbox_commande_prix_total.Text;
                                                    MessageBox.Show("Produit Ajouté à la commande");
                                                    lb_commande_produit_final.Items.Add(" | " + quant_prod6 + " " + unite_prod6 + " | " + ref_prod6 + " | " + produit_info6 + " | " + produit_prix6 + " €");
                                                    txtbox_commande_prix_total_produit.Text = "";
                                                    txtbox_commande_prix_total_produit.Text = (Convert.ToUInt32(produit_prix1) + Convert.ToUInt32(produit_prix2) + Convert.ToUInt32(produit_prix3) + Convert.ToUInt32(produit_prix4) + Convert.ToUInt32(produit_prix5) + Convert.ToUInt32(produit_prix6)).ToString() + " €";
                                                }
                                                else
                                                {
                                                    if (i == 7)
                                                    {
                                                        quant_prod7 = txtbox_commande_quantite.Text;
                                                        unite_prod7 = monProduit[lb_commande_produit.SelectedIndex].unite_grandeur;
                                                        ref_prod7 = monNuancier[lb_commande_nuance.SelectedIndex].numero + " " + monNuancier[lb_commande_nuance.SelectedIndex].teinte;
                                                        produit_info7 = monProduit[lb_commande_produit.SelectedIndex].nom + " " + monProduit[lb_commande_produit.SelectedIndex].type_produit + " " + monProduit[lb_commande_produit.SelectedIndex].type_grain;
                                                        produit_prix7 = txtbox_commande_prix_total.Text;
                                                        MessageBox.Show("Produit Ajouté à la commande");
                                                        lb_commande_produit_final.Items.Add(" | " + quant_prod7 + " " + unite_prod7 + " | " + ref_prod7 + " | " + produit_info7 + " | " + produit_prix7 + " €");
                                                        txtbox_commande_prix_total_produit.Text = "";
                                                        txtbox_commande_prix_total_produit.Text = (Convert.ToUInt32(produit_prix1) + Convert.ToUInt32(produit_prix2) + Convert.ToUInt32(produit_prix3) + Convert.ToUInt32(produit_prix4) + Convert.ToUInt32(produit_prix5) + Convert.ToUInt32(produit_prix6) + Convert.ToUInt32(produit_prix7)).ToString() + " €";
                                                    }
                                                    else
                                                    {
                                                        if (i == 8)
                                                        {
                                                            quant_prod8 = txtbox_commande_quantite.Text;
                                                            unite_prod8 = monProduit[lb_commande_produit.SelectedIndex].unite_grandeur;
                                                            ref_prod8 = monNuancier[lb_commande_nuance.SelectedIndex].numero + " " + monNuancier[lb_commande_nuance.SelectedIndex].teinte;
                                                            produit_info8 = monProduit[lb_commande_produit.SelectedIndex].nom + " " + monProduit[lb_commande_produit.SelectedIndex].type_produit + " " + monProduit[lb_commande_produit.SelectedIndex].type_grain;
                                                            produit_prix8 = txtbox_commande_prix_total.Text;
                                                            MessageBox.Show("Produit Ajouté à la commande");
                                                            lb_commande_produit_final.Items.Add(" | " + quant_prod8 + " " + unite_prod8 + " | " + ref_prod8 + " | " + produit_info8 + " | " + produit_prix8 + " €");
                                                            txtbox_commande_prix_total_produit.Text = "";
                                                            txtbox_commande_prix_total_produit.Text = (Convert.ToUInt32(produit_prix1) + Convert.ToUInt32(produit_prix2) + Convert.ToUInt32(produit_prix3) + Convert.ToUInt32(produit_prix4) + Convert.ToUInt32(produit_prix5) + Convert.ToUInt32(produit_prix6) + Convert.ToUInt32(produit_prix7) + Convert.ToUInt32(produit_prix8)).ToString() + " €";
                                                        }
                                                        else
                                                        {
                                                            if (i == 9)
                                                            {
                                                                quant_prod9 = txtbox_commande_quantite.Text;
                                                                unite_prod9 = monProduit[lb_commande_produit.SelectedIndex].unite_grandeur;
                                                                ref_prod9 = monNuancier[lb_commande_nuance.SelectedIndex].numero + " " + monNuancier[lb_commande_nuance.SelectedIndex].teinte;
                                                                produit_info9 = monProduit[lb_commande_produit.SelectedIndex].nom + " " + monProduit[lb_commande_produit.SelectedIndex].type_produit + " " + monProduit[lb_commande_produit.SelectedIndex].type_grain;
                                                                produit_prix9 = txtbox_commande_prix_total.Text;
                                                                MessageBox.Show("Produit Ajouté à la commande");
                                                                lb_commande_produit_final.Items.Add(" | " + quant_prod9 + " " + unite_prod9 + " | " + ref_prod9 + " | " + produit_info9 + " | " + produit_prix9 + " €");
                                                                txtbox_commande_prix_total_produit.Text = "";
                                                                txtbox_commande_prix_total_produit.Text = (Convert.ToUInt32(produit_prix1) + Convert.ToUInt32(produit_prix2) + Convert.ToUInt32(produit_prix3) + Convert.ToUInt32(produit_prix4) + Convert.ToUInt32(produit_prix5) + Convert.ToUInt32(produit_prix6) + Convert.ToUInt32(produit_prix7) + Convert.ToUInt32(produit_prix8) + Convert.ToUInt32(produit_prix9)).ToString() + " €";
                                                            }
                                                            else
                                                            {
                                                                if (i == 10)
                                                                {
                                                                    quant_prod10 = txtbox_commande_quantite.Text;
                                                                    unite_prod10 = monProduit[lb_commande_produit.SelectedIndex].unite_grandeur;
                                                                    ref_prod10 = monNuancier[lb_commande_nuance.SelectedIndex].numero + " " + monNuancier[lb_commande_nuance.SelectedIndex].teinte;
                                                                    produit_info10 = monProduit[lb_commande_produit.SelectedIndex].nom + " " + monProduit[lb_commande_produit.SelectedIndex].type_produit + " " + monProduit[lb_commande_produit.SelectedIndex].type_grain;
                                                                    produit_prix10 = txtbox_commande_prix_total.Text;
                                                                    MessageBox.Show("Produit Ajouté à la commande");
                                                                    lb_commande_produit_final.Items.Add(" | " + quant_prod10 + " " + unite_prod10 + " | " + ref_prod10 + " | " + produit_info10 + " | " + produit_prix10 + " €");
                                                                    txtbox_commande_prix_total_produit.Text = "";
                                                                    txtbox_commande_prix_total_produit.Text = (Convert.ToUInt32(produit_prix1) + Convert.ToUInt32(produit_prix2) + Convert.ToUInt32(produit_prix3) + Convert.ToUInt32(produit_prix4) + Convert.ToUInt32(produit_prix5) + Convert.ToUInt32(produit_prix6) + Convert.ToUInt32(produit_prix7) + Convert.ToUInt32(produit_prix8) + Convert.ToUInt32(produit_prix9) + Convert.ToUInt32(produit_prix10)).ToString() + " €";
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Limite Atteinte");
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                else
                {
                    throw new Exception("Pas de teinte selectionnée");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //

        private void btn_commande_enregistrer_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (Champ_cmd())
                {
                    string date_livraison = dtp_livraison.SelectedDate.Value.ToString("d");
                    string path = Properties.Settings.Default.chemin + "commande_" + txtbox_commande_num_cmd.Text + ".pdf";

                    if (!File.Exists(path))
                    {
                        // Étape 1 : on creait notre PDF

                        bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                        Commande cmmd = new Commande("", txtbox_commande_fournisseur.Text, txtbox_commande_client.Text, txtbox_commande_chantier.Text, txtbox_commande_chantier_ville.Text, txtbox_commande_chantier_rue.Text, date_livraison, txtbox_commande_num_cmd.Text);
                        bdd.AjouterCommande(cmmd);

                        Document commande = new Document(PageSize.A4);
                        PdfWriter writer = PdfWriter.GetInstance(commande, new FileStream(path, FileMode.Create));

                        Font mainFont = FontFactory.GetFont("Segoe UI", 16);
                        Font Font_tab_prod = FontFactory.GetFont("Segoe UI", 12);

                        commande.Open();

                        //



                        // Étape 2 : Tableau entete 

                        // Étape 2.1 : on creait notre tableau

                        PdfPTable en_tete = new PdfPTable(5);

                        // Étape 2.2 : les cellules + leur style
                        

                        PdfPCell date = new PdfPCell(new Paragraph("Le : " + DateTime.Today.ToString("d"), mainFont));
                        date.Border = 0;

                        PdfPCell num_cmd = new PdfPCell(new Paragraph("Commande N° " + txtbox_commande_num_cmd.Text, mainFont));
                        num_cmd.Border = 0;

                        // Étape 2.4 : colspan + ajout des cellules au tableau

                        date.Colspan = 3;
                        num_cmd.Colspan = 2;

                        en_tete.AddCell(date);
                        en_tete.AddCell(num_cmd);

                        // Étape 2.5 : ajout du tableau au document

                        commande.Add(en_tete);

                        //

                        commande.Add(new Paragraph(" "));
                        commande.Add(new Paragraph(" "));

                        //

                        PdfPTable fourni = new PdfPTable(5);
                        fourni.DefaultCell.Border = 0;

                        PdfPCell fournisseur = new PdfPCell(new Paragraph(info_fournisseur, mainFont));
                        fournisseur.Border = 0;
                        fournisseur.Colspan = 2;

                        fourni.AddCell("");
                        fourni.AddCell("");
                        fourni.AddCell("");
                        fourni.AddCell(fournisseur);

                        commande.Add(fourni);

                        //

                        commande.Add(new Paragraph(" "));
                        commande.Add(new Paragraph(" "));

                        //

                        PdfPTable chantier = new PdfPTable(5);

                        PdfPCell client = new PdfPCell(new Paragraph("Client " + info_client, mainFont));
                        client.Border = 0;
                        client.VerticalAlignment = Element.ALIGN_CENTER;


                        PdfPCell nom_chantier = new PdfPCell(new Paragraph("Chantier " + n_chantier, mainFont));
                        nom_chantier.Border = 0;

                        PdfPCell ville_chantier = new PdfPCell(new Paragraph("à " + v_chantier, mainFont));
                        ville_chantier.Border = 0;

                        PdfPCell rue_chantier = new PdfPCell(new Paragraph(r_chantier, mainFont));
                        rue_chantier.Border = 0;

                        chantier.DefaultCell.Border = 0;
                        chantier.AddCell("");
                        chantier.AddCell("");
                        client.Colspan = 3;
                        chantier.AddCell(client);
                        chantier.AddCell("");
                        chantier.AddCell("");
                        nom_chantier.Colspan = 3;
                        chantier.AddCell(nom_chantier);
                        chantier.AddCell("");
                        chantier.AddCell("");
                        ville_chantier.Colspan = 3;
                        chantier.AddCell(ville_chantier);
                        chantier.AddCell("");
                        chantier.AddCell("");
                        rue_chantier.Colspan = 3;
                        chantier.AddCell(rue_chantier);

                        commande.Add(chantier);

                        commande.Add(new Paragraph(" "));
                        commande.Add(new Paragraph(" "));


                        PdfPTable livraison = new PdfPTable(1);

                        PdfPCell date_livrai = new PdfPCell(new Paragraph("Date de livraison souhaitée : " + date_livraison, mainFont));
                        date_livrai.Border = 0;

                        livraison.AddCell(date_livrai);

                        commande.Add(livraison);

                        commande.Add(new Paragraph(" "));
                        commande.Add(new Paragraph(" "));



                        //

                        PdfPTable produit = new PdfPTable(14);

                        //

                        PdfPCell quantite = new PdfPCell(new Paragraph("Quantité", Font_tab_prod));
                        PdfPCell unite = new PdfPCell(new Paragraph("Unité", Font_tab_prod));
                        PdfPCell refe = new PdfPCell(new Paragraph("Référence", Font_tab_prod));
                        PdfPCell prod = new PdfPCell(new Paragraph("Produit", Font_tab_prod));
                        PdfPCell prix = new PdfPCell(new Paragraph("Prix HT", Font_tab_prod));

                        //

                        quantite.Colspan = 2;
                        unite.Colspan = 2;
                        refe.Colspan = 4;
                        prod.Colspan = 4;
                        prix.Colspan = 2;

                        produit.AddCell(quantite);
                        produit.AddCell(unite);
                        produit.AddCell(refe);
                        produit.AddCell(prod);
                        produit.AddCell(prix);

                        //

                        if (i == 1)
                        {
                            PdfPCell quantite_test1 = new PdfPCell(new Paragraph(quant_prod1, Font_tab_prod));
                            quantite_test1.FixedHeight = 50f;
                            PdfPCell unite_test1 = new PdfPCell(new Paragraph(unite_prod1, Font_tab_prod));
                            unite_test1.FixedHeight = 50f;
                            PdfPCell refe_test1 = new PdfPCell(new Paragraph(ref_prod1, Font_tab_prod));
                            refe_test1.FixedHeight = 50f;
                            PdfPCell prod_test1 = new PdfPCell(new Paragraph(produit_info1, Font_tab_prod));
                            prod_test1.FixedHeight = 50f;
                            PdfPCell prix_test1 = new PdfPCell(new Paragraph(produit_prix1 + " €", Font_tab_prod));
                            prix_test1.FixedHeight = 50f;

                            quantite_test1.Colspan = 2;
                            unite_test1.Colspan = 2;
                            refe_test1.Colspan = 4;
                            prod_test1.Colspan = 4;
                            prix_test1.Colspan = 2;

                            produit.AddCell(quantite_test1);
                            produit.AddCell(unite_test1);
                            produit.AddCell(refe_test1);
                            produit.AddCell(prod_test1);
                            produit.AddCell(prix_test1);

                            prix_total_commande = Convert.ToInt32(produit_prix1).ToString();
                        }

                        else
                        {
                            if (i == 2)
                            {
                                PdfPCell quantite_test1 = new PdfPCell(new Paragraph(quant_prod1, Font_tab_prod));
                                quantite_test1.FixedHeight = 50f;
                                PdfPCell unite_test1 = new PdfPCell(new Paragraph(unite_prod1, Font_tab_prod));
                                unite_test1.FixedHeight = 50f;
                                PdfPCell refe_test1 = new PdfPCell(new Paragraph(ref_prod1, Font_tab_prod));
                                refe_test1.FixedHeight = 50f;
                                PdfPCell prod_test1 = new PdfPCell(new Paragraph(produit_info1, Font_tab_prod));
                                prod_test1.FixedHeight = 50f;
                                PdfPCell prix_test1 = new PdfPCell(new Paragraph(produit_prix1 + " €", Font_tab_prod));
                                prix_test1.FixedHeight = 50f;

                                quantite_test1.Colspan = 2;
                                unite_test1.Colspan = 2;
                                refe_test1.Colspan = 4;
                                prod_test1.Colspan = 4;
                                prix_test1.Colspan = 2;

                                produit.AddCell(quantite_test1);
                                produit.AddCell(unite_test1);
                                produit.AddCell(refe_test1);
                                produit.AddCell(prod_test1);
                                produit.AddCell(prix_test1);

                                PdfPCell quantite_test2 = new PdfPCell(new Paragraph(quant_prod2, Font_tab_prod));
                                quantite_test2.FixedHeight = 50f;
                                PdfPCell unite_test2 = new PdfPCell(new Paragraph(unite_prod2, Font_tab_prod));
                                unite_test2.FixedHeight = 50f;
                                PdfPCell refe_test2 = new PdfPCell(new Paragraph(ref_prod2, Font_tab_prod));
                                refe_test2.FixedHeight = 50f;
                                PdfPCell prod_test2 = new PdfPCell(new Paragraph(produit_info2, Font_tab_prod));
                                prod_test2.FixedHeight = 50f;
                                PdfPCell prix_test2 = new PdfPCell(new Paragraph(produit_prix2 + " €", Font_tab_prod));
                                prix_test2.FixedHeight = 50f;

                                quantite_test2.Colspan = 2;
                                unite_test2.Colspan = 2;
                                refe_test2.Colspan = 4;
                                prod_test2.Colspan = 4;
                                prix_test2.Colspan = 2;

                                produit.AddCell(quantite_test2);
                                produit.AddCell(unite_test2);
                                produit.AddCell(refe_test2);
                                produit.AddCell(prod_test2);
                                produit.AddCell(prix_test2);

                                prix_total_commande = (Convert.ToInt32(produit_prix1) + Convert.ToInt32(produit_prix2)).ToString();
                            }
                            else
                            {
                                if (i == 3)
                                {
                                    PdfPCell quantite_test1 = new PdfPCell(new Paragraph(quant_prod1, Font_tab_prod));
                                    quantite_test1.FixedHeight = 50f;
                                    PdfPCell unite_test1 = new PdfPCell(new Paragraph(unite_prod1, Font_tab_prod));
                                    unite_test1.FixedHeight = 50f;
                                    PdfPCell refe_test1 = new PdfPCell(new Paragraph(ref_prod1, Font_tab_prod));
                                    refe_test1.FixedHeight = 50f;
                                    PdfPCell prod_test1 = new PdfPCell(new Paragraph(produit_info1, Font_tab_prod));
                                    prod_test1.FixedHeight = 50f;
                                    PdfPCell prix_test1 = new PdfPCell(new Paragraph(produit_prix1 + " €", Font_tab_prod));
                                    prix_test1.FixedHeight = 50f;

                                    quantite_test1.Colspan = 2;
                                    unite_test1.Colspan = 2;
                                    refe_test1.Colspan = 4;
                                    prod_test1.Colspan = 4;
                                    prix_test1.Colspan = 2;

                                    produit.AddCell(quantite_test1);
                                    produit.AddCell(unite_test1);
                                    produit.AddCell(refe_test1);
                                    produit.AddCell(prod_test1);
                                    produit.AddCell(prix_test1);

                                    PdfPCell quantite_test2 = new PdfPCell(new Paragraph(quant_prod2, Font_tab_prod));
                                    quantite_test2.FixedHeight = 50f;
                                    PdfPCell unite_test2 = new PdfPCell(new Paragraph(unite_prod2, Font_tab_prod));
                                    unite_test2.FixedHeight = 50f;
                                    PdfPCell refe_test2 = new PdfPCell(new Paragraph(ref_prod2, Font_tab_prod));
                                    refe_test2.FixedHeight = 50f;
                                    PdfPCell prod_test2 = new PdfPCell(new Paragraph(produit_info2, Font_tab_prod));
                                    prod_test2.FixedHeight = 50f;
                                    PdfPCell prix_test2 = new PdfPCell(new Paragraph(produit_prix2 + " €", Font_tab_prod));
                                    prix_test2.FixedHeight = 50f;

                                    quantite_test2.Colspan = 2;
                                    unite_test2.Colspan = 2;
                                    refe_test2.Colspan = 4;
                                    prod_test2.Colspan = 4;
                                    prix_test2.Colspan = 2;

                                    produit.AddCell(quantite_test2);
                                    produit.AddCell(unite_test2);
                                    produit.AddCell(refe_test2);
                                    produit.AddCell(prod_test2);
                                    produit.AddCell(prix_test2);

                                    PdfPCell quantite_test3 = new PdfPCell(new Paragraph(quant_prod3, Font_tab_prod));
                                    quantite_test3.FixedHeight = 50f;
                                    PdfPCell unite_test3 = new PdfPCell(new Paragraph(unite_prod3, Font_tab_prod));
                                    unite_test3.FixedHeight = 50f;
                                    PdfPCell refe_test3 = new PdfPCell(new Paragraph(ref_prod3, Font_tab_prod));
                                    refe_test3.FixedHeight = 50f;
                                    PdfPCell prod_test3 = new PdfPCell(new Paragraph(produit_info3, Font_tab_prod));
                                    prod_test3.FixedHeight = 50f;
                                    PdfPCell prix_test3 = new PdfPCell(new Paragraph(produit_prix3 + " €", Font_tab_prod));
                                    prix_test3.FixedHeight = 50f;

                                    quantite_test3.Colspan = 2;
                                    unite_test3.Colspan = 2;
                                    refe_test3.Colspan = 4;
                                    prod_test3.Colspan = 4;
                                    prix_test3.Colspan = 2;

                                    produit.AddCell(quantite_test3);
                                    produit.AddCell(unite_test3);
                                    produit.AddCell(refe_test3);
                                    produit.AddCell(prod_test3);
                                    produit.AddCell(prix_test3);

                                    prix_total_commande = (Convert.ToInt32(produit_prix1) + Convert.ToInt32(produit_prix2) + Convert.ToInt32(produit_prix3)).ToString();
                                }
                                else
                                {
                                    if (i == 4)
                                    {
                                        PdfPCell quantite_test1 = new PdfPCell(new Paragraph(quant_prod1, Font_tab_prod));
                                        quantite_test1.FixedHeight = 50f;
                                        PdfPCell unite_test1 = new PdfPCell(new Paragraph(unite_prod1, Font_tab_prod));
                                        unite_test1.FixedHeight = 50f;
                                        PdfPCell refe_test1 = new PdfPCell(new Paragraph(ref_prod1, Font_tab_prod));
                                        refe_test1.FixedHeight = 50f;
                                        PdfPCell prod_test1 = new PdfPCell(new Paragraph(produit_info1, Font_tab_prod));
                                        prod_test1.FixedHeight = 50f;
                                        PdfPCell prix_test1 = new PdfPCell(new Paragraph(produit_prix1 + " €", Font_tab_prod));
                                        prix_test1.FixedHeight = 50f;

                                        quantite_test1.Colspan = 2;
                                        unite_test1.Colspan = 2;
                                        refe_test1.Colspan = 4;
                                        prod_test1.Colspan = 4;
                                        prix_test1.Colspan = 2;

                                        produit.AddCell(quantite_test1);
                                        produit.AddCell(unite_test1);
                                        produit.AddCell(refe_test1);
                                        produit.AddCell(prod_test1);
                                        produit.AddCell(prix_test1);

                                        PdfPCell quantite_test2 = new PdfPCell(new Paragraph(quant_prod2, Font_tab_prod));
                                        quantite_test2.FixedHeight = 50f;
                                        PdfPCell unite_test2 = new PdfPCell(new Paragraph(unite_prod2, Font_tab_prod));
                                        unite_test2.FixedHeight = 50f;
                                        PdfPCell refe_test2 = new PdfPCell(new Paragraph(ref_prod2, Font_tab_prod));
                                        refe_test2.FixedHeight = 50f;
                                        PdfPCell prod_test2 = new PdfPCell(new Paragraph(produit_info2, Font_tab_prod));
                                        prod_test2.FixedHeight = 50f;
                                        PdfPCell prix_test2 = new PdfPCell(new Paragraph(produit_prix2 + " €", Font_tab_prod));
                                        prix_test2.FixedHeight = 50f;

                                        quantite_test2.Colspan = 2;
                                        unite_test2.Colspan = 2;
                                        refe_test2.Colspan = 4;
                                        prod_test2.Colspan = 4;
                                        prix_test2.Colspan = 2;

                                        produit.AddCell(quantite_test2);
                                        produit.AddCell(unite_test2);
                                        produit.AddCell(refe_test2);
                                        produit.AddCell(prod_test2);
                                        produit.AddCell(prix_test2);

                                        PdfPCell quantite_test3 = new PdfPCell(new Paragraph(quant_prod3, Font_tab_prod));
                                        quantite_test3.FixedHeight = 50f;
                                        PdfPCell unite_test3 = new PdfPCell(new Paragraph(unite_prod3, Font_tab_prod));
                                        unite_test3.FixedHeight = 50f;
                                        PdfPCell refe_test3 = new PdfPCell(new Paragraph(ref_prod3, Font_tab_prod));
                                        refe_test3.FixedHeight = 50f;
                                        PdfPCell prod_test3 = new PdfPCell(new Paragraph(produit_info3, Font_tab_prod));
                                        prod_test3.FixedHeight = 50f;
                                        PdfPCell prix_test3 = new PdfPCell(new Paragraph(produit_prix3 + " €", Font_tab_prod));
                                        prix_test3.FixedHeight = 50f;

                                        quantite_test3.Colspan = 2;
                                        unite_test3.Colspan = 2;
                                        refe_test3.Colspan = 4;
                                        prod_test3.Colspan = 4;
                                        prix_test3.Colspan = 2;

                                        produit.AddCell(quantite_test3);
                                        produit.AddCell(unite_test3);
                                        produit.AddCell(refe_test3);
                                        produit.AddCell(prod_test3);
                                        produit.AddCell(prix_test3);

                                        PdfPCell quantite_test4 = new PdfPCell(new Paragraph(quant_prod4, Font_tab_prod));
                                        quantite_test4.FixedHeight = 50f;
                                        PdfPCell unite_test4 = new PdfPCell(new Paragraph(unite_prod4, Font_tab_prod));
                                        unite_test4.FixedHeight = 50f;
                                        PdfPCell refe_test4 = new PdfPCell(new Paragraph(ref_prod4, Font_tab_prod));
                                        refe_test4.FixedHeight = 50f;
                                        PdfPCell prod_test4 = new PdfPCell(new Paragraph(produit_info4, Font_tab_prod));
                                        prod_test4.FixedHeight = 50f;
                                        PdfPCell prix_test4 = new PdfPCell(new Paragraph(produit_prix4 + " €", Font_tab_prod));
                                        prix_test4.FixedHeight = 50f;

                                        quantite_test4.Colspan = 2;
                                        unite_test4.Colspan = 2;
                                        refe_test4.Colspan = 4;
                                        prod_test4.Colspan = 4;
                                        prix_test4.Colspan = 2;

                                        produit.AddCell(quantite_test4);
                                        produit.AddCell(unite_test4);
                                        produit.AddCell(refe_test4);
                                        produit.AddCell(prod_test4);
                                        produit.AddCell(prix_test4);

                                        prix_total_commande = (Convert.ToInt32(produit_prix1) + Convert.ToInt32(produit_prix2) + Convert.ToInt32(produit_prix3) + Convert.ToInt32(produit_prix4)).ToString();
                                    }
                                    else
                                    {
                                        if (i == 5)
                                        {
                                            PdfPCell quantite_test1 = new PdfPCell(new Paragraph(quant_prod1, Font_tab_prod));
                                            quantite_test1.FixedHeight = 50f;
                                            PdfPCell unite_test1 = new PdfPCell(new Paragraph(unite_prod1, Font_tab_prod));
                                            unite_test1.FixedHeight = 50f;
                                            PdfPCell refe_test1 = new PdfPCell(new Paragraph(ref_prod1, Font_tab_prod));
                                            refe_test1.FixedHeight = 50f;
                                            PdfPCell prod_test1 = new PdfPCell(new Paragraph(produit_info1, Font_tab_prod));
                                            prod_test1.FixedHeight = 50f;
                                            PdfPCell prix_test1 = new PdfPCell(new Paragraph(produit_prix1 + " €", Font_tab_prod));
                                            prix_test1.FixedHeight = 50f;

                                            quantite_test1.Colspan = 2;
                                            unite_test1.Colspan = 2;
                                            refe_test1.Colspan = 4;
                                            prod_test1.Colspan = 4;
                                            prix_test1.Colspan = 2;

                                            produit.AddCell(quantite_test1);
                                            produit.AddCell(unite_test1);
                                            produit.AddCell(refe_test1);
                                            produit.AddCell(prod_test1);
                                            produit.AddCell(prix_test1);

                                            PdfPCell quantite_test2 = new PdfPCell(new Paragraph(quant_prod2, Font_tab_prod));
                                            quantite_test2.FixedHeight = 50f;
                                            PdfPCell unite_test2 = new PdfPCell(new Paragraph(unite_prod2, Font_tab_prod));
                                            unite_test2.FixedHeight = 50f;
                                            PdfPCell refe_test2 = new PdfPCell(new Paragraph(ref_prod2, Font_tab_prod));
                                            refe_test2.FixedHeight = 50f;
                                            PdfPCell prod_test2 = new PdfPCell(new Paragraph(produit_info2, Font_tab_prod));
                                            prod_test2.FixedHeight = 50f;
                                            PdfPCell prix_test2 = new PdfPCell(new Paragraph(produit_prix2 + " €", Font_tab_prod));
                                            prix_test2.FixedHeight = 50f;

                                            quantite_test2.Colspan = 2;
                                            unite_test2.Colspan = 2;
                                            refe_test2.Colspan = 4;
                                            prod_test2.Colspan = 4;
                                            prix_test2.Colspan = 2;

                                            produit.AddCell(quantite_test2);
                                            produit.AddCell(unite_test2);
                                            produit.AddCell(refe_test2);
                                            produit.AddCell(prod_test2);
                                            produit.AddCell(prix_test2);

                                            PdfPCell quantite_test3 = new PdfPCell(new Paragraph(quant_prod3, Font_tab_prod));
                                            quantite_test3.FixedHeight = 50f;
                                            PdfPCell unite_test3 = new PdfPCell(new Paragraph(unite_prod3, Font_tab_prod));
                                            unite_test3.FixedHeight = 50f;
                                            PdfPCell refe_test3 = new PdfPCell(new Paragraph(ref_prod3, Font_tab_prod));
                                            refe_test3.FixedHeight = 50f;
                                            PdfPCell prod_test3 = new PdfPCell(new Paragraph(produit_info3, Font_tab_prod));
                                            prod_test3.FixedHeight = 50f;
                                            PdfPCell prix_test3 = new PdfPCell(new Paragraph(produit_prix3 + " €", Font_tab_prod));
                                            prix_test3.FixedHeight = 50f;

                                            quantite_test3.Colspan = 2;
                                            unite_test3.Colspan = 2;
                                            refe_test3.Colspan = 4;
                                            prod_test3.Colspan = 4;
                                            prix_test3.Colspan = 2;

                                            produit.AddCell(quantite_test3);
                                            produit.AddCell(unite_test3);
                                            produit.AddCell(refe_test3);
                                            produit.AddCell(prod_test3);
                                            produit.AddCell(prix_test3);

                                            PdfPCell quantite_test4 = new PdfPCell(new Paragraph(quant_prod4, Font_tab_prod));
                                            quantite_test4.FixedHeight = 50f;
                                            PdfPCell unite_test4 = new PdfPCell(new Paragraph(unite_prod4, Font_tab_prod));
                                            unite_test4.FixedHeight = 50f;
                                            PdfPCell refe_test4 = new PdfPCell(new Paragraph(ref_prod4, Font_tab_prod));
                                            refe_test4.FixedHeight = 50f;
                                            PdfPCell prod_test4 = new PdfPCell(new Paragraph(produit_info4, Font_tab_prod));
                                            prod_test4.FixedHeight = 50f;
                                            PdfPCell prix_test4 = new PdfPCell(new Paragraph(produit_prix4 + " €", Font_tab_prod));
                                            prix_test4.FixedHeight = 50f;

                                            quantite_test4.Colspan = 2;
                                            unite_test4.Colspan = 2;
                                            refe_test4.Colspan = 4;
                                            prod_test4.Colspan = 4;
                                            prix_test4.Colspan = 2;

                                            produit.AddCell(quantite_test4);
                                            produit.AddCell(unite_test4);
                                            produit.AddCell(refe_test4);
                                            produit.AddCell(prod_test4);
                                            produit.AddCell(prix_test4);

                                            PdfPCell quantite_test5 = new PdfPCell(new Paragraph(quant_prod5, Font_tab_prod));
                                            quantite_test5.FixedHeight = 50f;
                                            PdfPCell unite_test5 = new PdfPCell(new Paragraph(unite_prod5, Font_tab_prod));
                                            unite_test5.FixedHeight = 50f;
                                            PdfPCell refe_test5 = new PdfPCell(new Paragraph(ref_prod5, Font_tab_prod));
                                            refe_test5.FixedHeight = 50f;
                                            PdfPCell prod_test5 = new PdfPCell(new Paragraph(produit_info5, Font_tab_prod));
                                            prod_test5.FixedHeight = 50f;
                                            PdfPCell prix_test5 = new PdfPCell(new Paragraph(produit_prix5 + " €", Font_tab_prod));
                                            prix_test5.FixedHeight = 50f;

                                            quantite_test5.Colspan = 2;
                                            unite_test5.Colspan = 2;
                                            refe_test5.Colspan = 4;
                                            prod_test5.Colspan = 4;
                                            prix_test5.Colspan = 2;

                                            produit.AddCell(quantite_test5);
                                            produit.AddCell(unite_test5);
                                            produit.AddCell(refe_test5);
                                            produit.AddCell(prod_test5);
                                            produit.AddCell(prix_test5);

                                            prix_total_commande = (Convert.ToInt32(produit_prix1) + Convert.ToInt32(produit_prix2) + Convert.ToInt32(produit_prix3) + Convert.ToInt32(produit_prix4) + Convert.ToInt32(produit_prix5)).ToString();
                                        }
                                        else
                                        {
                                            if (i == 6)
                                            {
                                                PdfPCell quantite_test1 = new PdfPCell(new Paragraph(quant_prod1, Font_tab_prod));
                                                quantite_test1.FixedHeight = 50f;
                                                PdfPCell unite_test1 = new PdfPCell(new Paragraph(unite_prod1, Font_tab_prod));
                                                unite_test1.FixedHeight = 50f;
                                                PdfPCell refe_test1 = new PdfPCell(new Paragraph(ref_prod1, Font_tab_prod));
                                                refe_test1.FixedHeight = 50f;
                                                PdfPCell prod_test1 = new PdfPCell(new Paragraph(produit_info1, Font_tab_prod));
                                                prod_test1.FixedHeight = 50f;
                                                PdfPCell prix_test1 = new PdfPCell(new Paragraph(produit_prix1 + " €", Font_tab_prod));
                                                prix_test1.FixedHeight = 50f;

                                                quantite_test1.Colspan = 2;
                                                unite_test1.Colspan = 2;
                                                refe_test1.Colspan = 4;
                                                prod_test1.Colspan = 4;
                                                prix_test1.Colspan = 2;

                                                produit.AddCell(quantite_test1);
                                                produit.AddCell(unite_test1);
                                                produit.AddCell(refe_test1);
                                                produit.AddCell(prod_test1);
                                                produit.AddCell(prix_test1);

                                                PdfPCell quantite_test2 = new PdfPCell(new Paragraph(quant_prod2, Font_tab_prod));
                                                quantite_test2.FixedHeight = 50f;
                                                PdfPCell unite_test2 = new PdfPCell(new Paragraph(unite_prod2, Font_tab_prod));
                                                unite_test2.FixedHeight = 50f;
                                                PdfPCell refe_test2 = new PdfPCell(new Paragraph(ref_prod2, Font_tab_prod));
                                                refe_test2.FixedHeight = 50f;
                                                PdfPCell prod_test2 = new PdfPCell(new Paragraph(produit_info2, Font_tab_prod));
                                                prod_test2.FixedHeight = 50f;
                                                PdfPCell prix_test2 = new PdfPCell(new Paragraph(produit_prix2 + " €", Font_tab_prod));
                                                prix_test2.FixedHeight = 50f;

                                                quantite_test2.Colspan = 2;
                                                unite_test2.Colspan = 2;
                                                refe_test2.Colspan = 4;
                                                prod_test2.Colspan = 4;
                                                prix_test2.Colspan = 2;

                                                produit.AddCell(quantite_test2);
                                                produit.AddCell(unite_test2);
                                                produit.AddCell(refe_test2);
                                                produit.AddCell(prod_test2);
                                                produit.AddCell(prix_test2);

                                                PdfPCell quantite_test3 = new PdfPCell(new Paragraph(quant_prod3, Font_tab_prod));
                                                quantite_test3.FixedHeight = 50f;
                                                PdfPCell unite_test3 = new PdfPCell(new Paragraph(unite_prod3, Font_tab_prod));
                                                unite_test3.FixedHeight = 50f;
                                                PdfPCell refe_test3 = new PdfPCell(new Paragraph(ref_prod3, Font_tab_prod));
                                                refe_test3.FixedHeight = 50f;
                                                PdfPCell prod_test3 = new PdfPCell(new Paragraph(produit_info3, Font_tab_prod));
                                                prod_test3.FixedHeight = 50f;
                                                PdfPCell prix_test3 = new PdfPCell(new Paragraph(produit_prix3 + " €", Font_tab_prod));
                                                prix_test3.FixedHeight = 50f;

                                                quantite_test3.Colspan = 2;
                                                unite_test3.Colspan = 2;
                                                refe_test3.Colspan = 4;
                                                prod_test3.Colspan = 4;
                                                prix_test3.Colspan = 2;

                                                produit.AddCell(quantite_test3);
                                                produit.AddCell(unite_test3);
                                                produit.AddCell(refe_test3);
                                                produit.AddCell(prod_test3);
                                                produit.AddCell(prix_test3);

                                                PdfPCell quantite_test4 = new PdfPCell(new Paragraph(quant_prod4, Font_tab_prod));
                                                quantite_test4.FixedHeight = 50f;
                                                PdfPCell unite_test4 = new PdfPCell(new Paragraph(unite_prod4, Font_tab_prod));
                                                unite_test4.FixedHeight = 50f;
                                                PdfPCell refe_test4 = new PdfPCell(new Paragraph(ref_prod4, Font_tab_prod));
                                                refe_test4.FixedHeight = 50f;
                                                PdfPCell prod_test4 = new PdfPCell(new Paragraph(produit_info4, Font_tab_prod));
                                                prod_test4.FixedHeight = 50f;
                                                PdfPCell prix_test4 = new PdfPCell(new Paragraph(produit_prix4 + " €", Font_tab_prod));
                                                prix_test4.FixedHeight = 50f;

                                                quantite_test4.Colspan = 2;
                                                unite_test4.Colspan = 2;
                                                refe_test4.Colspan = 4;
                                                prod_test4.Colspan = 4;
                                                prix_test4.Colspan = 2;

                                                produit.AddCell(quantite_test4);
                                                produit.AddCell(unite_test4);
                                                produit.AddCell(refe_test4);
                                                produit.AddCell(prod_test4);
                                                produit.AddCell(prix_test4);

                                                PdfPCell quantite_test5 = new PdfPCell(new Paragraph(quant_prod5, Font_tab_prod));
                                                quantite_test5.FixedHeight = 50f;
                                                PdfPCell unite_test5 = new PdfPCell(new Paragraph(unite_prod5, Font_tab_prod));
                                                unite_test5.FixedHeight = 50f;
                                                PdfPCell refe_test5 = new PdfPCell(new Paragraph(ref_prod5, Font_tab_prod));
                                                refe_test5.FixedHeight = 50f;
                                                PdfPCell prod_test5 = new PdfPCell(new Paragraph(produit_info5, Font_tab_prod));
                                                prod_test5.FixedHeight = 50f;
                                                PdfPCell prix_test5 = new PdfPCell(new Paragraph(produit_prix5 + " €", Font_tab_prod));
                                                prix_test5.FixedHeight = 50f;

                                                quantite_test5.Colspan = 2;
                                                unite_test5.Colspan = 2;
                                                refe_test5.Colspan = 4;
                                                prod_test5.Colspan = 4;
                                                prix_test5.Colspan = 2;

                                                produit.AddCell(quantite_test5);
                                                produit.AddCell(unite_test5);
                                                produit.AddCell(refe_test5);
                                                produit.AddCell(prod_test5);
                                                produit.AddCell(prix_test5);

                                                PdfPCell quantite_test6 = new PdfPCell(new Paragraph(quant_prod6, Font_tab_prod));
                                                quantite_test6.FixedHeight = 50f;
                                                PdfPCell unite_test6 = new PdfPCell(new Paragraph(unite_prod6, Font_tab_prod));
                                                unite_test6.FixedHeight = 50f;
                                                PdfPCell refe_test6 = new PdfPCell(new Paragraph(ref_prod6, Font_tab_prod));
                                                refe_test6.FixedHeight = 50f;
                                                PdfPCell prod_test6 = new PdfPCell(new Paragraph(produit_info6, Font_tab_prod));
                                                prod_test6.FixedHeight = 50f;
                                                PdfPCell prix_test6 = new PdfPCell(new Paragraph(produit_prix6 + " €", Font_tab_prod));
                                                prix_test6.FixedHeight = 50f;

                                                quantite_test6.Colspan = 2;
                                                unite_test6.Colspan = 2;
                                                refe_test6.Colspan = 4;
                                                prod_test6.Colspan = 4;
                                                prix_test6.Colspan = 2;

                                                produit.AddCell(quantite_test6);
                                                produit.AddCell(unite_test6);
                                                produit.AddCell(refe_test6);
                                                produit.AddCell(prod_test6);
                                                produit.AddCell(prix_test6);

                                                prix_total_commande = (Convert.ToInt32(produit_prix1) + Convert.ToInt32(produit_prix2) + Convert.ToInt32(produit_prix3) + Convert.ToInt32(produit_prix4) + Convert.ToInt32(produit_prix5) + Convert.ToInt32(produit_prix6)).ToString();
                                            }
                                            else
                                            {
                                                if (i == 7)
                                                {
                                                    PdfPCell quantite_test1 = new PdfPCell(new Paragraph(quant_prod1, Font_tab_prod));
                                                    quantite_test1.FixedHeight = 50f;
                                                    PdfPCell unite_test1 = new PdfPCell(new Paragraph(unite_prod1, Font_tab_prod));
                                                    unite_test1.FixedHeight = 50f;
                                                    PdfPCell refe_test1 = new PdfPCell(new Paragraph(ref_prod1, Font_tab_prod));
                                                    refe_test1.FixedHeight = 50f;
                                                    PdfPCell prod_test1 = new PdfPCell(new Paragraph(produit_info1, Font_tab_prod));
                                                    prod_test1.FixedHeight = 50f;
                                                    PdfPCell prix_test1 = new PdfPCell(new Paragraph(produit_prix1 + " €", Font_tab_prod));
                                                    prix_test1.FixedHeight = 50f;

                                                    quantite_test1.Colspan = 2;
                                                    unite_test1.Colspan = 2;
                                                    refe_test1.Colspan = 4;
                                                    prod_test1.Colspan = 4;
                                                    prix_test1.Colspan = 2;

                                                    produit.AddCell(quantite_test1);
                                                    produit.AddCell(unite_test1);
                                                    produit.AddCell(refe_test1);
                                                    produit.AddCell(prod_test1);
                                                    produit.AddCell(prix_test1);

                                                    PdfPCell quantite_test2 = new PdfPCell(new Paragraph(quant_prod2, Font_tab_prod));
                                                    quantite_test2.FixedHeight = 50f;
                                                    PdfPCell unite_test2 = new PdfPCell(new Paragraph(unite_prod2, Font_tab_prod));
                                                    unite_test2.FixedHeight = 50f;
                                                    PdfPCell refe_test2 = new PdfPCell(new Paragraph(ref_prod2, Font_tab_prod));
                                                    refe_test2.FixedHeight = 50f;
                                                    PdfPCell prod_test2 = new PdfPCell(new Paragraph(produit_info2, Font_tab_prod));
                                                    prod_test2.FixedHeight = 50f;
                                                    PdfPCell prix_test2 = new PdfPCell(new Paragraph(produit_prix2 + " €", Font_tab_prod));
                                                    prix_test2.FixedHeight = 50f;

                                                    quantite_test2.Colspan = 2;
                                                    unite_test2.Colspan = 2;
                                                    refe_test2.Colspan = 4;
                                                    prod_test2.Colspan = 4;
                                                    prix_test2.Colspan = 2;

                                                    produit.AddCell(quantite_test2);
                                                    produit.AddCell(unite_test2);
                                                    produit.AddCell(refe_test2);
                                                    produit.AddCell(prod_test2);
                                                    produit.AddCell(prix_test2);

                                                    PdfPCell quantite_test3 = new PdfPCell(new Paragraph(quant_prod3, Font_tab_prod));
                                                    quantite_test3.FixedHeight = 50f;
                                                    PdfPCell unite_test3 = new PdfPCell(new Paragraph(unite_prod3, Font_tab_prod));
                                                    unite_test3.FixedHeight = 50f;
                                                    PdfPCell refe_test3 = new PdfPCell(new Paragraph(ref_prod3, Font_tab_prod));
                                                    refe_test3.FixedHeight = 50f;
                                                    PdfPCell prod_test3 = new PdfPCell(new Paragraph(produit_info3, Font_tab_prod));
                                                    prod_test3.FixedHeight = 50f;
                                                    PdfPCell prix_test3 = new PdfPCell(new Paragraph(produit_prix3 + " €", Font_tab_prod));
                                                    prix_test3.FixedHeight = 50f;

                                                    quantite_test3.Colspan = 2;
                                                    unite_test3.Colspan = 2;
                                                    refe_test3.Colspan = 4;
                                                    prod_test3.Colspan = 4;
                                                    prix_test3.Colspan = 2;

                                                    produit.AddCell(quantite_test3);
                                                    produit.AddCell(unite_test3);
                                                    produit.AddCell(refe_test3);
                                                    produit.AddCell(prod_test3);
                                                    produit.AddCell(prix_test3);

                                                    PdfPCell quantite_test4 = new PdfPCell(new Paragraph(quant_prod4, Font_tab_prod));
                                                    quantite_test4.FixedHeight = 50f;
                                                    PdfPCell unite_test4 = new PdfPCell(new Paragraph(unite_prod4, Font_tab_prod));
                                                    unite_test4.FixedHeight = 50f;
                                                    PdfPCell refe_test4 = new PdfPCell(new Paragraph(ref_prod4, Font_tab_prod));
                                                    refe_test4.FixedHeight = 50f;
                                                    PdfPCell prod_test4 = new PdfPCell(new Paragraph(produit_info4, Font_tab_prod));
                                                    prod_test4.FixedHeight = 50f;
                                                    PdfPCell prix_test4 = new PdfPCell(new Paragraph(produit_prix4 + " €", Font_tab_prod));
                                                    prix_test4.FixedHeight = 50f;

                                                    quantite_test4.Colspan = 2;
                                                    unite_test4.Colspan = 2;
                                                    refe_test4.Colspan = 4;
                                                    prod_test4.Colspan = 4;
                                                    prix_test4.Colspan = 2;

                                                    produit.AddCell(quantite_test4);
                                                    produit.AddCell(unite_test4);
                                                    produit.AddCell(refe_test4);
                                                    produit.AddCell(prod_test4);
                                                    produit.AddCell(prix_test4);

                                                    PdfPCell quantite_test5 = new PdfPCell(new Paragraph(quant_prod5, Font_tab_prod));
                                                    quantite_test5.FixedHeight = 50f;
                                                    PdfPCell unite_test5 = new PdfPCell(new Paragraph(unite_prod5, Font_tab_prod));
                                                    unite_test5.FixedHeight = 50f;
                                                    PdfPCell refe_test5 = new PdfPCell(new Paragraph(ref_prod5, Font_tab_prod));
                                                    refe_test5.FixedHeight = 50f;
                                                    PdfPCell prod_test5 = new PdfPCell(new Paragraph(produit_info5, Font_tab_prod));
                                                    prod_test5.FixedHeight = 50f;
                                                    PdfPCell prix_test5 = new PdfPCell(new Paragraph(produit_prix5 + " €", Font_tab_prod));
                                                    prix_test5.FixedHeight = 50f;

                                                    quantite_test5.Colspan = 2;
                                                    unite_test5.Colspan = 2;
                                                    refe_test5.Colspan = 4;
                                                    prod_test5.Colspan = 4;
                                                    prix_test5.Colspan = 2;

                                                    produit.AddCell(quantite_test5);
                                                    produit.AddCell(unite_test5);
                                                    produit.AddCell(refe_test5);
                                                    produit.AddCell(prod_test5);
                                                    produit.AddCell(prix_test5);

                                                    PdfPCell quantite_test6 = new PdfPCell(new Paragraph(quant_prod6, Font_tab_prod));
                                                    quantite_test6.FixedHeight = 50f;
                                                    PdfPCell unite_test6 = new PdfPCell(new Paragraph(unite_prod6, Font_tab_prod));
                                                    unite_test6.FixedHeight = 50f;
                                                    PdfPCell refe_test6 = new PdfPCell(new Paragraph(ref_prod6, Font_tab_prod));
                                                    refe_test6.FixedHeight = 50f;
                                                    PdfPCell prod_test6 = new PdfPCell(new Paragraph(produit_info6, Font_tab_prod));
                                                    prod_test6.FixedHeight = 50f;
                                                    PdfPCell prix_test6 = new PdfPCell(new Paragraph(produit_prix6 + " €", Font_tab_prod));
                                                    prix_test6.FixedHeight = 50f;

                                                    quantite_test6.Colspan = 2;
                                                    unite_test6.Colspan = 2;
                                                    refe_test6.Colspan = 4;
                                                    prod_test6.Colspan = 4;
                                                    prix_test6.Colspan = 2;

                                                    produit.AddCell(quantite_test6);
                                                    produit.AddCell(unite_test6);
                                                    produit.AddCell(refe_test6);
                                                    produit.AddCell(prod_test6);
                                                    produit.AddCell(prix_test6);

                                                    PdfPCell quantite_test7 = new PdfPCell(new Paragraph(quant_prod7, Font_tab_prod));
                                                    quantite_test7.FixedHeight = 50f;
                                                    PdfPCell unite_test7 = new PdfPCell(new Paragraph(unite_prod7, Font_tab_prod));
                                                    unite_test7.FixedHeight = 50f;
                                                    PdfPCell refe_test7 = new PdfPCell(new Paragraph(ref_prod7, Font_tab_prod));
                                                    refe_test7.FixedHeight = 50f;
                                                    PdfPCell prod_test7 = new PdfPCell(new Paragraph(produit_info7, Font_tab_prod));
                                                    prod_test7.FixedHeight = 50f;
                                                    PdfPCell prix_test7 = new PdfPCell(new Paragraph(produit_prix7 + " €", Font_tab_prod));
                                                    prix_test7.FixedHeight = 50f;

                                                    quantite_test7.Colspan = 2;
                                                    unite_test7.Colspan = 2;
                                                    refe_test7.Colspan = 4;
                                                    prod_test7.Colspan = 4;
                                                    prix_test7.Colspan = 2;

                                                    produit.AddCell(quantite_test7);
                                                    produit.AddCell(unite_test7);
                                                    produit.AddCell(refe_test7);
                                                    produit.AddCell(prod_test7);
                                                    produit.AddCell(prix_test7);

                                                    prix_total_commande = (Convert.ToInt32(produit_prix1) + Convert.ToInt32(produit_prix2) + Convert.ToInt32(produit_prix3) + Convert.ToInt32(produit_prix4) + Convert.ToInt32(produit_prix5) + Convert.ToInt32(produit_prix6) + Convert.ToInt32(produit_prix7)).ToString();
                                                }
                                                else
                                                {
                                                    if (i == 8)
                                                    {
                                                        PdfPCell quantite_test1 = new PdfPCell(new Paragraph(quant_prod1, Font_tab_prod));
                                                        quantite_test1.FixedHeight = 50f;
                                                        PdfPCell unite_test1 = new PdfPCell(new Paragraph(unite_prod1, Font_tab_prod));
                                                        unite_test1.FixedHeight = 50f;
                                                        PdfPCell refe_test1 = new PdfPCell(new Paragraph(ref_prod1, Font_tab_prod));
                                                        refe_test1.FixedHeight = 50f;
                                                        PdfPCell prod_test1 = new PdfPCell(new Paragraph(produit_info1, Font_tab_prod));
                                                        prod_test1.FixedHeight = 50f;
                                                        PdfPCell prix_test1 = new PdfPCell(new Paragraph(produit_prix1 + " €", Font_tab_prod));
                                                        prix_test1.FixedHeight = 50f;

                                                        quantite_test1.Colspan = 2;
                                                        unite_test1.Colspan = 2;
                                                        refe_test1.Colspan = 4;
                                                        prod_test1.Colspan = 4;
                                                        prix_test1.Colspan = 2;

                                                        produit.AddCell(quantite_test1);
                                                        produit.AddCell(unite_test1);
                                                        produit.AddCell(refe_test1);
                                                        produit.AddCell(prod_test1);
                                                        produit.AddCell(prix_test1);

                                                        PdfPCell quantite_test2 = new PdfPCell(new Paragraph(quant_prod2, Font_tab_prod));
                                                        quantite_test2.FixedHeight = 50f;
                                                        PdfPCell unite_test2 = new PdfPCell(new Paragraph(unite_prod2, Font_tab_prod));
                                                        unite_test2.FixedHeight = 50f;
                                                        PdfPCell refe_test2 = new PdfPCell(new Paragraph(ref_prod2, Font_tab_prod));
                                                        refe_test2.FixedHeight = 50f;
                                                        PdfPCell prod_test2 = new PdfPCell(new Paragraph(produit_info2, Font_tab_prod));
                                                        prod_test2.FixedHeight = 50f;
                                                        PdfPCell prix_test2 = new PdfPCell(new Paragraph(produit_prix2 + " €", Font_tab_prod));
                                                        prix_test2.FixedHeight = 50f;

                                                        quantite_test2.Colspan = 2;
                                                        unite_test2.Colspan = 2;
                                                        refe_test2.Colspan = 4;
                                                        prod_test2.Colspan = 4;
                                                        prix_test2.Colspan = 2;

                                                        produit.AddCell(quantite_test2);
                                                        produit.AddCell(unite_test2);
                                                        produit.AddCell(refe_test2);
                                                        produit.AddCell(prod_test2);
                                                        produit.AddCell(prix_test2);

                                                        PdfPCell quantite_test3 = new PdfPCell(new Paragraph(quant_prod3, Font_tab_prod));
                                                        quantite_test3.FixedHeight = 50f;
                                                        PdfPCell unite_test3 = new PdfPCell(new Paragraph(unite_prod3, Font_tab_prod));
                                                        unite_test3.FixedHeight = 50f;
                                                        PdfPCell refe_test3 = new PdfPCell(new Paragraph(ref_prod3, Font_tab_prod));
                                                        refe_test3.FixedHeight = 50f;
                                                        PdfPCell prod_test3 = new PdfPCell(new Paragraph(produit_info3, Font_tab_prod));
                                                        prod_test3.FixedHeight = 50f;
                                                        PdfPCell prix_test3 = new PdfPCell(new Paragraph(produit_prix3 + " €", Font_tab_prod));
                                                        prix_test3.FixedHeight = 50f;

                                                        quantite_test3.Colspan = 2;
                                                        unite_test3.Colspan = 2;
                                                        refe_test3.Colspan = 4;
                                                        prod_test3.Colspan = 4;
                                                        prix_test3.Colspan = 2;

                                                        produit.AddCell(quantite_test3);
                                                        produit.AddCell(unite_test3);
                                                        produit.AddCell(refe_test3);
                                                        produit.AddCell(prod_test3);
                                                        produit.AddCell(prix_test3);

                                                        PdfPCell quantite_test4 = new PdfPCell(new Paragraph(quant_prod4, Font_tab_prod));
                                                        quantite_test4.FixedHeight = 50f;
                                                        PdfPCell unite_test4 = new PdfPCell(new Paragraph(unite_prod4, Font_tab_prod));
                                                        unite_test4.FixedHeight = 50f;
                                                        PdfPCell refe_test4 = new PdfPCell(new Paragraph(ref_prod4, Font_tab_prod));
                                                        refe_test4.FixedHeight = 50f;
                                                        PdfPCell prod_test4 = new PdfPCell(new Paragraph(produit_info4, Font_tab_prod));
                                                        prod_test4.FixedHeight = 50f;
                                                        PdfPCell prix_test4 = new PdfPCell(new Paragraph(produit_prix4 + " €", Font_tab_prod));
                                                        prix_test4.FixedHeight = 50f;

                                                        quantite_test4.Colspan = 2;
                                                        unite_test4.Colspan = 2;
                                                        refe_test4.Colspan = 4;
                                                        prod_test4.Colspan = 4;
                                                        prix_test4.Colspan = 2;

                                                        produit.AddCell(quantite_test4);
                                                        produit.AddCell(unite_test4);
                                                        produit.AddCell(refe_test4);
                                                        produit.AddCell(prod_test4);
                                                        produit.AddCell(prix_test4);

                                                        PdfPCell quantite_test5 = new PdfPCell(new Paragraph(quant_prod5, Font_tab_prod));
                                                        quantite_test5.FixedHeight = 50f;
                                                        PdfPCell unite_test5 = new PdfPCell(new Paragraph(unite_prod5, Font_tab_prod));
                                                        unite_test5.FixedHeight = 50f;
                                                        PdfPCell refe_test5 = new PdfPCell(new Paragraph(ref_prod5, Font_tab_prod));
                                                        refe_test5.FixedHeight = 50f;
                                                        PdfPCell prod_test5 = new PdfPCell(new Paragraph(produit_info5, Font_tab_prod));
                                                        prod_test5.FixedHeight = 50f;
                                                        PdfPCell prix_test5 = new PdfPCell(new Paragraph(produit_prix5 + " €", Font_tab_prod));
                                                        prix_test5.FixedHeight = 50f;

                                                        quantite_test5.Colspan = 2;
                                                        unite_test5.Colspan = 2;
                                                        refe_test5.Colspan = 4;
                                                        prod_test5.Colspan = 4;
                                                        prix_test5.Colspan = 2;

                                                        produit.AddCell(quantite_test5);
                                                        produit.AddCell(unite_test5);
                                                        produit.AddCell(refe_test5);
                                                        produit.AddCell(prod_test5);
                                                        produit.AddCell(prix_test5);

                                                        PdfPCell quantite_test6 = new PdfPCell(new Paragraph(quant_prod6, Font_tab_prod));
                                                        quantite_test6.FixedHeight = 50f;
                                                        PdfPCell unite_test6 = new PdfPCell(new Paragraph(unite_prod6, Font_tab_prod));
                                                        unite_test6.FixedHeight = 50f;
                                                        PdfPCell refe_test6 = new PdfPCell(new Paragraph(ref_prod6, Font_tab_prod));
                                                        refe_test6.FixedHeight = 50f;
                                                        PdfPCell prod_test6 = new PdfPCell(new Paragraph(produit_info6, Font_tab_prod));
                                                        prod_test6.FixedHeight = 50f;
                                                        PdfPCell prix_test6 = new PdfPCell(new Paragraph(produit_prix6 + " €", Font_tab_prod));
                                                        prix_test6.FixedHeight = 50f;

                                                        quantite_test6.Colspan = 2;
                                                        unite_test6.Colspan = 2;
                                                        refe_test6.Colspan = 4;
                                                        prod_test6.Colspan = 4;
                                                        prix_test6.Colspan = 2;

                                                        produit.AddCell(quantite_test6);
                                                        produit.AddCell(unite_test6);
                                                        produit.AddCell(refe_test6);
                                                        produit.AddCell(prod_test6);
                                                        produit.AddCell(prix_test6);

                                                        PdfPCell quantite_test7 = new PdfPCell(new Paragraph(quant_prod7, Font_tab_prod));
                                                        quantite_test7.FixedHeight = 50f;
                                                        PdfPCell unite_test7 = new PdfPCell(new Paragraph(unite_prod7, Font_tab_prod));
                                                        unite_test7.FixedHeight = 50f;
                                                        PdfPCell refe_test7 = new PdfPCell(new Paragraph(ref_prod7, Font_tab_prod));
                                                        refe_test7.FixedHeight = 50f;
                                                        PdfPCell prod_test7 = new PdfPCell(new Paragraph(produit_info7, Font_tab_prod));
                                                        prod_test7.FixedHeight = 50f;
                                                        PdfPCell prix_test7 = new PdfPCell(new Paragraph(produit_prix7 + " €", Font_tab_prod));
                                                        prix_test7.FixedHeight = 50f;

                                                        quantite_test7.Colspan = 2;
                                                        unite_test7.Colspan = 2;
                                                        refe_test7.Colspan = 4;
                                                        prod_test7.Colspan = 4;
                                                        prix_test7.Colspan = 2;

                                                        produit.AddCell(quantite_test7);
                                                        produit.AddCell(unite_test7);
                                                        produit.AddCell(refe_test7);
                                                        produit.AddCell(prod_test7);
                                                        produit.AddCell(prix_test7);

                                                        PdfPCell quantite_test8 = new PdfPCell(new Paragraph(quant_prod8, Font_tab_prod));
                                                        quantite_test8.FixedHeight = 50f;
                                                        PdfPCell unite_test8 = new PdfPCell(new Paragraph(unite_prod8, Font_tab_prod));
                                                        unite_test8.FixedHeight = 50f;
                                                        PdfPCell refe_test8 = new PdfPCell(new Paragraph(ref_prod8, Font_tab_prod));
                                                        refe_test8.FixedHeight = 50f;
                                                        PdfPCell prod_test8 = new PdfPCell(new Paragraph(produit_info8, Font_tab_prod));
                                                        prod_test8.FixedHeight = 50f;
                                                        PdfPCell prix_test8 = new PdfPCell(new Paragraph(produit_prix8 + " €", Font_tab_prod));
                                                        prix_test8.FixedHeight = 50f;

                                                        quantite_test8.Colspan = 2;
                                                        unite_test8.Colspan = 2;
                                                        refe_test8.Colspan = 4;
                                                        prod_test8.Colspan = 4;
                                                        prix_test8.Colspan = 2;

                                                        produit.AddCell(quantite_test8);
                                                        produit.AddCell(unite_test8);
                                                        produit.AddCell(refe_test8);
                                                        produit.AddCell(prod_test8);
                                                        produit.AddCell(prix_test8);

                                                        prix_total_commande = (Convert.ToInt32(produit_prix1) + Convert.ToInt32(produit_prix2) + Convert.ToInt32(produit_prix3) + Convert.ToInt32(produit_prix4) + Convert.ToInt32(produit_prix5) + Convert.ToInt32(produit_prix6) + Convert.ToInt32(produit_prix7) + Convert.ToInt32(produit_prix8)).ToString();
                                                    }
                                                    else
                                                    {
                                                        if (i == 9)
                                                        {
                                                            PdfPCell quantite_test1 = new PdfPCell(new Paragraph(quant_prod1, Font_tab_prod));
                                                            quantite_test1.FixedHeight = 50f;
                                                            PdfPCell unite_test1 = new PdfPCell(new Paragraph(unite_prod1, Font_tab_prod));
                                                            unite_test1.FixedHeight = 50f;
                                                            PdfPCell refe_test1 = new PdfPCell(new Paragraph(ref_prod1, Font_tab_prod));
                                                            refe_test1.FixedHeight = 50f;
                                                            PdfPCell prod_test1 = new PdfPCell(new Paragraph(produit_info1, Font_tab_prod));
                                                            prod_test1.FixedHeight = 50f;
                                                            PdfPCell prix_test1 = new PdfPCell(new Paragraph(produit_prix1 + " €", Font_tab_prod));
                                                            prix_test1.FixedHeight = 50f;

                                                            quantite_test1.Colspan = 2;
                                                            unite_test1.Colspan = 2;
                                                            refe_test1.Colspan = 4;
                                                            prod_test1.Colspan = 4;
                                                            prix_test1.Colspan = 2;

                                                            produit.AddCell(quantite_test1);
                                                            produit.AddCell(unite_test1);
                                                            produit.AddCell(refe_test1);
                                                            produit.AddCell(prod_test1);
                                                            produit.AddCell(prix_test1);

                                                            PdfPCell quantite_test2 = new PdfPCell(new Paragraph(quant_prod2, Font_tab_prod));
                                                            quantite_test2.FixedHeight = 50f;
                                                            PdfPCell unite_test2 = new PdfPCell(new Paragraph(unite_prod2, Font_tab_prod));
                                                            unite_test2.FixedHeight = 50f;
                                                            PdfPCell refe_test2 = new PdfPCell(new Paragraph(ref_prod2, Font_tab_prod));
                                                            refe_test2.FixedHeight = 50f;
                                                            PdfPCell prod_test2 = new PdfPCell(new Paragraph(produit_info2, Font_tab_prod));
                                                            prod_test2.FixedHeight = 50f;
                                                            PdfPCell prix_test2 = new PdfPCell(new Paragraph(produit_prix2 + " €", Font_tab_prod));
                                                            prix_test2.FixedHeight = 50f;

                                                            quantite_test2.Colspan = 2;
                                                            unite_test2.Colspan = 2;
                                                            refe_test2.Colspan = 4;
                                                            prod_test2.Colspan = 4;
                                                            prix_test2.Colspan = 2;

                                                            produit.AddCell(quantite_test2);
                                                            produit.AddCell(unite_test2);
                                                            produit.AddCell(refe_test2);
                                                            produit.AddCell(prod_test2);
                                                            produit.AddCell(prix_test2);

                                                            PdfPCell quantite_test3 = new PdfPCell(new Paragraph(quant_prod3, Font_tab_prod));
                                                            quantite_test3.FixedHeight = 50f;
                                                            PdfPCell unite_test3 = new PdfPCell(new Paragraph(unite_prod3, Font_tab_prod));
                                                            unite_test3.FixedHeight = 50f;
                                                            PdfPCell refe_test3 = new PdfPCell(new Paragraph(ref_prod3, Font_tab_prod));
                                                            refe_test3.FixedHeight = 50f;
                                                            PdfPCell prod_test3 = new PdfPCell(new Paragraph(produit_info3, Font_tab_prod));
                                                            prod_test3.FixedHeight = 50f;
                                                            PdfPCell prix_test3 = new PdfPCell(new Paragraph(produit_prix3 + " €", Font_tab_prod));
                                                            prix_test3.FixedHeight = 50f;

                                                            quantite_test3.Colspan = 2;
                                                            unite_test3.Colspan = 2;
                                                            refe_test3.Colspan = 4;
                                                            prod_test3.Colspan = 4;
                                                            prix_test3.Colspan = 2;

                                                            produit.AddCell(quantite_test3);
                                                            produit.AddCell(unite_test3);
                                                            produit.AddCell(refe_test3);
                                                            produit.AddCell(prod_test3);
                                                            produit.AddCell(prix_test3);

                                                            PdfPCell quantite_test4 = new PdfPCell(new Paragraph(quant_prod4, Font_tab_prod));
                                                            quantite_test4.FixedHeight = 50f;
                                                            PdfPCell unite_test4 = new PdfPCell(new Paragraph(unite_prod4, Font_tab_prod));
                                                            unite_test4.FixedHeight = 50f;
                                                            PdfPCell refe_test4 = new PdfPCell(new Paragraph(ref_prod4, Font_tab_prod));
                                                            refe_test4.FixedHeight = 50f;
                                                            PdfPCell prod_test4 = new PdfPCell(new Paragraph(produit_info4, Font_tab_prod));
                                                            prod_test4.FixedHeight = 50f;
                                                            PdfPCell prix_test4 = new PdfPCell(new Paragraph(produit_prix4 + " €", Font_tab_prod));
                                                            prix_test4.FixedHeight = 50f;

                                                            quantite_test4.Colspan = 2;
                                                            unite_test4.Colspan = 2;
                                                            refe_test4.Colspan = 4;
                                                            prod_test4.Colspan = 4;
                                                            prix_test4.Colspan = 2;

                                                            produit.AddCell(quantite_test4);
                                                            produit.AddCell(unite_test4);
                                                            produit.AddCell(refe_test4);
                                                            produit.AddCell(prod_test4);
                                                            produit.AddCell(prix_test4);

                                                            PdfPCell quantite_test5 = new PdfPCell(new Paragraph(quant_prod5, Font_tab_prod));
                                                            quantite_test5.FixedHeight = 50f;
                                                            PdfPCell unite_test5 = new PdfPCell(new Paragraph(unite_prod5, Font_tab_prod));
                                                            unite_test5.FixedHeight = 50f;
                                                            PdfPCell refe_test5 = new PdfPCell(new Paragraph(ref_prod5, Font_tab_prod));
                                                            refe_test5.FixedHeight = 50f;
                                                            PdfPCell prod_test5 = new PdfPCell(new Paragraph(produit_info5, Font_tab_prod));
                                                            prod_test5.FixedHeight = 50f;
                                                            PdfPCell prix_test5 = new PdfPCell(new Paragraph(produit_prix5 + " €", Font_tab_prod));
                                                            prix_test5.FixedHeight = 50f;

                                                            quantite_test5.Colspan = 2;
                                                            unite_test5.Colspan = 2;
                                                            refe_test5.Colspan = 4;
                                                            prod_test5.Colspan = 4;
                                                            prix_test5.Colspan = 2;

                                                            produit.AddCell(quantite_test5);
                                                            produit.AddCell(unite_test5);
                                                            produit.AddCell(refe_test5);
                                                            produit.AddCell(prod_test5);
                                                            produit.AddCell(prix_test5);

                                                            PdfPCell quantite_test6 = new PdfPCell(new Paragraph(quant_prod6, Font_tab_prod));
                                                            quantite_test6.FixedHeight = 50f;
                                                            PdfPCell unite_test6 = new PdfPCell(new Paragraph(unite_prod6, Font_tab_prod));
                                                            unite_test6.FixedHeight = 50f;
                                                            PdfPCell refe_test6 = new PdfPCell(new Paragraph(ref_prod6, Font_tab_prod));
                                                            refe_test6.FixedHeight = 50f;
                                                            PdfPCell prod_test6 = new PdfPCell(new Paragraph(produit_info6, Font_tab_prod));
                                                            prod_test6.FixedHeight = 50f;
                                                            PdfPCell prix_test6 = new PdfPCell(new Paragraph(produit_prix6 + " €", Font_tab_prod));
                                                            prix_test6.FixedHeight = 50f;

                                                            quantite_test6.Colspan = 2;
                                                            unite_test6.Colspan = 2;
                                                            refe_test6.Colspan = 4;
                                                            prod_test6.Colspan = 4;
                                                            prix_test6.Colspan = 2;

                                                            produit.AddCell(quantite_test6);
                                                            produit.AddCell(unite_test6);
                                                            produit.AddCell(refe_test6);
                                                            produit.AddCell(prod_test6);
                                                            produit.AddCell(prix_test6);

                                                            PdfPCell quantite_test7 = new PdfPCell(new Paragraph(quant_prod7, Font_tab_prod));
                                                            quantite_test7.FixedHeight = 50f;
                                                            PdfPCell unite_test7 = new PdfPCell(new Paragraph(unite_prod7, Font_tab_prod));
                                                            unite_test7.FixedHeight = 50f;
                                                            PdfPCell refe_test7 = new PdfPCell(new Paragraph(ref_prod7, Font_tab_prod));
                                                            refe_test7.FixedHeight = 50f;
                                                            PdfPCell prod_test7 = new PdfPCell(new Paragraph(produit_info7, Font_tab_prod));
                                                            prod_test7.FixedHeight = 50f;
                                                            PdfPCell prix_test7 = new PdfPCell(new Paragraph(produit_prix7 + " €", Font_tab_prod));
                                                            prix_test7.FixedHeight = 50f;

                                                            quantite_test7.Colspan = 2;
                                                            unite_test7.Colspan = 2;
                                                            refe_test7.Colspan = 4;
                                                            prod_test7.Colspan = 4;
                                                            prix_test7.Colspan = 2;

                                                            produit.AddCell(quantite_test7);
                                                            produit.AddCell(unite_test7);
                                                            produit.AddCell(refe_test7);
                                                            produit.AddCell(prod_test7);
                                                            produit.AddCell(prix_test7);

                                                            PdfPCell quantite_test8 = new PdfPCell(new Paragraph(quant_prod8, Font_tab_prod));
                                                            quantite_test8.FixedHeight = 50f;
                                                            PdfPCell unite_test8 = new PdfPCell(new Paragraph(unite_prod8, Font_tab_prod));
                                                            unite_test8.FixedHeight = 50f;
                                                            PdfPCell refe_test8 = new PdfPCell(new Paragraph(ref_prod8, Font_tab_prod));
                                                            refe_test8.FixedHeight = 50f;
                                                            PdfPCell prod_test8 = new PdfPCell(new Paragraph(produit_info8, Font_tab_prod));
                                                            prod_test8.FixedHeight = 50f;
                                                            PdfPCell prix_test8 = new PdfPCell(new Paragraph(produit_prix8 + " €", Font_tab_prod));
                                                            prix_test8.FixedHeight = 50f;

                                                            quantite_test8.Colspan = 2;
                                                            unite_test8.Colspan = 2;
                                                            refe_test8.Colspan = 4;
                                                            prod_test8.Colspan = 4;
                                                            prix_test8.Colspan = 2;

                                                            produit.AddCell(quantite_test8);
                                                            produit.AddCell(unite_test8);
                                                            produit.AddCell(refe_test8);
                                                            produit.AddCell(prod_test8);
                                                            produit.AddCell(prix_test8);

                                                            PdfPCell quantite_test9 = new PdfPCell(new Paragraph(quant_prod9, Font_tab_prod));
                                                            quantite_test9.FixedHeight = 50f;
                                                            PdfPCell unite_test9 = new PdfPCell(new Paragraph(unite_prod9, Font_tab_prod));
                                                            unite_test9.FixedHeight = 50f;
                                                            PdfPCell refe_test9 = new PdfPCell(new Paragraph(ref_prod9, Font_tab_prod));
                                                            refe_test9.FixedHeight = 50f;
                                                            PdfPCell prod_test9 = new PdfPCell(new Paragraph(produit_info9, Font_tab_prod));
                                                            prod_test9.FixedHeight = 50f;
                                                            PdfPCell prix_test9 = new PdfPCell(new Paragraph(produit_prix9 + " €", Font_tab_prod));
                                                            prix_test9.FixedHeight = 50f;

                                                            quantite_test9.Colspan = 2;
                                                            unite_test9.Colspan = 2;
                                                            refe_test9.Colspan = 4;
                                                            prod_test9.Colspan = 4;
                                                            prix_test9.Colspan = 2;

                                                            produit.AddCell(quantite_test9);
                                                            produit.AddCell(unite_test9);
                                                            produit.AddCell(refe_test9);
                                                            produit.AddCell(prod_test9);
                                                            produit.AddCell(prix_test9);

                                                            prix_total_commande = (Convert.ToInt32(produit_prix1) + Convert.ToInt32(produit_prix2) + Convert.ToInt32(produit_prix3) + Convert.ToInt32(produit_prix4) + Convert.ToInt32(produit_prix5) + Convert.ToInt32(produit_prix6) + Convert.ToInt32(produit_prix7) + Convert.ToInt32(produit_prix8) + Convert.ToInt32(produit_prix9)).ToString();
                                                        }
                                                        else
                                                        {
                                                            PdfPCell quantite_test1 = new PdfPCell(new Paragraph(quant_prod1, Font_tab_prod));
                                                            quantite_test1.FixedHeight = 50f;
                                                            PdfPCell unite_test1 = new PdfPCell(new Paragraph(unite_prod1, Font_tab_prod));
                                                            unite_test1.FixedHeight = 50f;
                                                            PdfPCell refe_test1 = new PdfPCell(new Paragraph(ref_prod1, Font_tab_prod));
                                                            refe_test1.FixedHeight = 50f;
                                                            PdfPCell prod_test1 = new PdfPCell(new Paragraph(produit_info1, Font_tab_prod));
                                                            prod_test1.FixedHeight = 50f;
                                                            PdfPCell prix_test1 = new PdfPCell(new Paragraph(produit_prix1 + " €", Font_tab_prod));
                                                            prix_test1.FixedHeight = 50f;

                                                            quantite_test1.Colspan = 2;
                                                            unite_test1.Colspan = 2;
                                                            refe_test1.Colspan = 4;
                                                            prod_test1.Colspan = 4;
                                                            prix_test1.Colspan = 2;

                                                            produit.AddCell(quantite_test1);
                                                            produit.AddCell(unite_test1);
                                                            produit.AddCell(refe_test1);
                                                            produit.AddCell(prod_test1);
                                                            produit.AddCell(prix_test1);

                                                            PdfPCell quantite_test2 = new PdfPCell(new Paragraph(quant_prod2, Font_tab_prod));
                                                            quantite_test2.FixedHeight = 50f;
                                                            PdfPCell unite_test2 = new PdfPCell(new Paragraph(unite_prod2, Font_tab_prod));
                                                            unite_test2.FixedHeight = 50f;
                                                            PdfPCell refe_test2 = new PdfPCell(new Paragraph(ref_prod2, Font_tab_prod));
                                                            refe_test2.FixedHeight = 50f;
                                                            PdfPCell prod_test2 = new PdfPCell(new Paragraph(produit_info2, Font_tab_prod));
                                                            prod_test2.FixedHeight = 50f;
                                                            PdfPCell prix_test2 = new PdfPCell(new Paragraph(produit_prix2 + " €", Font_tab_prod));
                                                            prix_test2.FixedHeight = 50f;

                                                            quantite_test2.Colspan = 2;
                                                            unite_test2.Colspan = 2;
                                                            refe_test2.Colspan = 4;
                                                            prod_test2.Colspan = 4;
                                                            prix_test2.Colspan = 2;

                                                            produit.AddCell(quantite_test2);
                                                            produit.AddCell(unite_test2);
                                                            produit.AddCell(refe_test2);
                                                            produit.AddCell(prod_test2);
                                                            produit.AddCell(prix_test2);

                                                            PdfPCell quantite_test3 = new PdfPCell(new Paragraph(quant_prod3, Font_tab_prod));
                                                            quantite_test3.FixedHeight = 50f;
                                                            PdfPCell unite_test3 = new PdfPCell(new Paragraph(unite_prod3, Font_tab_prod));
                                                            unite_test3.FixedHeight = 50f;
                                                            PdfPCell refe_test3 = new PdfPCell(new Paragraph(ref_prod3, Font_tab_prod));
                                                            refe_test3.FixedHeight = 50f;
                                                            PdfPCell prod_test3 = new PdfPCell(new Paragraph(produit_info3, Font_tab_prod));
                                                            prod_test3.FixedHeight = 50f;
                                                            PdfPCell prix_test3 = new PdfPCell(new Paragraph(produit_prix3 + " €", Font_tab_prod));
                                                            prix_test3.FixedHeight = 50f;

                                                            quantite_test3.Colspan = 2;
                                                            unite_test3.Colspan = 2;
                                                            refe_test3.Colspan = 4;
                                                            prod_test3.Colspan = 4;
                                                            prix_test3.Colspan = 2;

                                                            produit.AddCell(quantite_test3);
                                                            produit.AddCell(unite_test3);
                                                            produit.AddCell(refe_test3);
                                                            produit.AddCell(prod_test3);
                                                            produit.AddCell(prix_test3);

                                                            PdfPCell quantite_test4 = new PdfPCell(new Paragraph(quant_prod4, Font_tab_prod));
                                                            quantite_test4.FixedHeight = 50f;
                                                            PdfPCell unite_test4 = new PdfPCell(new Paragraph(unite_prod4, Font_tab_prod));
                                                            unite_test4.FixedHeight = 50f;
                                                            PdfPCell refe_test4 = new PdfPCell(new Paragraph(ref_prod4, Font_tab_prod));
                                                            refe_test4.FixedHeight = 50f;
                                                            PdfPCell prod_test4 = new PdfPCell(new Paragraph(produit_info4, Font_tab_prod));
                                                            prod_test4.FixedHeight = 50f;
                                                            PdfPCell prix_test4 = new PdfPCell(new Paragraph(produit_prix4 + " €", Font_tab_prod));
                                                            prix_test4.FixedHeight = 50f;

                                                            quantite_test4.Colspan = 2;
                                                            unite_test4.Colspan = 2;
                                                            refe_test4.Colspan = 4;
                                                            prod_test4.Colspan = 4;
                                                            prix_test4.Colspan = 2;

                                                            produit.AddCell(quantite_test4);
                                                            produit.AddCell(unite_test4);
                                                            produit.AddCell(refe_test4);
                                                            produit.AddCell(prod_test4);
                                                            produit.AddCell(prix_test4);

                                                            PdfPCell quantite_test5 = new PdfPCell(new Paragraph(quant_prod5, Font_tab_prod));
                                                            quantite_test5.FixedHeight = 50f;
                                                            PdfPCell unite_test5 = new PdfPCell(new Paragraph(unite_prod5, Font_tab_prod));
                                                            unite_test5.FixedHeight = 50f;
                                                            PdfPCell refe_test5 = new PdfPCell(new Paragraph(ref_prod5, Font_tab_prod));
                                                            refe_test5.FixedHeight = 50f;
                                                            PdfPCell prod_test5 = new PdfPCell(new Paragraph(produit_info5, Font_tab_prod));
                                                            prod_test5.FixedHeight = 50f;
                                                            PdfPCell prix_test5 = new PdfPCell(new Paragraph(produit_prix5 + " €", Font_tab_prod));
                                                            prix_test5.FixedHeight = 50f;

                                                            quantite_test5.Colspan = 2;
                                                            unite_test5.Colspan = 2;
                                                            refe_test5.Colspan = 4;
                                                            prod_test5.Colspan = 4;
                                                            prix_test5.Colspan = 2;

                                                            produit.AddCell(quantite_test5);
                                                            produit.AddCell(unite_test5);
                                                            produit.AddCell(refe_test5);
                                                            produit.AddCell(prod_test5);
                                                            produit.AddCell(prix_test5);

                                                            PdfPCell quantite_test6 = new PdfPCell(new Paragraph(quant_prod6, Font_tab_prod));
                                                            quantite_test6.FixedHeight = 50f;
                                                            PdfPCell unite_test6 = new PdfPCell(new Paragraph(unite_prod6, Font_tab_prod));
                                                            unite_test6.FixedHeight = 50f;
                                                            PdfPCell refe_test6 = new PdfPCell(new Paragraph(ref_prod6, Font_tab_prod));
                                                            refe_test6.FixedHeight = 50f;
                                                            PdfPCell prod_test6 = new PdfPCell(new Paragraph(produit_info6, Font_tab_prod));
                                                            prod_test6.FixedHeight = 50f;
                                                            PdfPCell prix_test6 = new PdfPCell(new Paragraph(produit_prix6 + " €", Font_tab_prod));
                                                            prix_test6.FixedHeight = 50f;

                                                            quantite_test6.Colspan = 2;
                                                            unite_test6.Colspan = 2;
                                                            refe_test6.Colspan = 4;
                                                            prod_test6.Colspan = 4;
                                                            prix_test6.Colspan = 2;

                                                            produit.AddCell(quantite_test6);
                                                            produit.AddCell(unite_test6);
                                                            produit.AddCell(refe_test6);
                                                            produit.AddCell(prod_test6);
                                                            produit.AddCell(prix_test6);

                                                            PdfPCell quantite_test7 = new PdfPCell(new Paragraph(quant_prod7, Font_tab_prod));
                                                            quantite_test7.FixedHeight = 50f;
                                                            PdfPCell unite_test7 = new PdfPCell(new Paragraph(unite_prod7, Font_tab_prod));
                                                            unite_test7.FixedHeight = 50f;
                                                            PdfPCell refe_test7 = new PdfPCell(new Paragraph(ref_prod7, Font_tab_prod));
                                                            refe_test7.FixedHeight = 50f;
                                                            PdfPCell prod_test7 = new PdfPCell(new Paragraph(produit_info7, Font_tab_prod));
                                                            prod_test7.FixedHeight = 50f;
                                                            PdfPCell prix_test7 = new PdfPCell(new Paragraph(produit_prix7 + " €", Font_tab_prod));
                                                            prix_test7.FixedHeight = 50f;

                                                            quantite_test7.Colspan = 2;
                                                            unite_test7.Colspan = 2;
                                                            refe_test7.Colspan = 4;
                                                            prod_test7.Colspan = 4;
                                                            prix_test7.Colspan = 2;

                                                            produit.AddCell(quantite_test7);
                                                            produit.AddCell(unite_test7);
                                                            produit.AddCell(refe_test7);
                                                            produit.AddCell(prod_test7);
                                                            produit.AddCell(prix_test7);

                                                            PdfPCell quantite_test8 = new PdfPCell(new Paragraph(quant_prod8, Font_tab_prod));
                                                            quantite_test8.FixedHeight = 50f;
                                                            PdfPCell unite_test8 = new PdfPCell(new Paragraph(unite_prod8, Font_tab_prod));
                                                            unite_test8.FixedHeight = 50f;
                                                            PdfPCell refe_test8 = new PdfPCell(new Paragraph(ref_prod8, Font_tab_prod));
                                                            refe_test8.FixedHeight = 50f;
                                                            PdfPCell prod_test8 = new PdfPCell(new Paragraph(produit_info8, Font_tab_prod));
                                                            prod_test8.FixedHeight = 50f;
                                                            PdfPCell prix_test8 = new PdfPCell(new Paragraph(produit_prix8 + " €", Font_tab_prod));
                                                            prix_test8.FixedHeight = 50f;

                                                            quantite_test8.Colspan = 2;
                                                            unite_test8.Colspan = 2;
                                                            refe_test8.Colspan = 4;
                                                            prod_test8.Colspan = 4;
                                                            prix_test8.Colspan = 2;

                                                            produit.AddCell(quantite_test8);
                                                            produit.AddCell(unite_test8);
                                                            produit.AddCell(refe_test8);
                                                            produit.AddCell(prod_test8);
                                                            produit.AddCell(prix_test8);

                                                            PdfPCell quantite_test9 = new PdfPCell(new Paragraph(quant_prod9, Font_tab_prod));
                                                            quantite_test9.FixedHeight = 50f;
                                                            PdfPCell unite_test9 = new PdfPCell(new Paragraph(unite_prod9, Font_tab_prod));
                                                            unite_test9.FixedHeight = 50f;
                                                            PdfPCell refe_test9 = new PdfPCell(new Paragraph(ref_prod9, Font_tab_prod));
                                                            refe_test9.FixedHeight = 50f;
                                                            PdfPCell prod_test9 = new PdfPCell(new Paragraph(produit_info9, Font_tab_prod));
                                                            prod_test9.FixedHeight = 50f;
                                                            PdfPCell prix_test9 = new PdfPCell(new Paragraph(produit_prix9 + " €", Font_tab_prod));
                                                            prix_test9.FixedHeight = 50f;

                                                            quantite_test9.Colspan = 2;
                                                            unite_test9.Colspan = 2;
                                                            refe_test9.Colspan = 4;
                                                            prod_test9.Colspan = 4;
                                                            prix_test9.Colspan = 2;

                                                            produit.AddCell(quantite_test9);
                                                            produit.AddCell(unite_test9);
                                                            produit.AddCell(refe_test9);
                                                            produit.AddCell(prod_test9);
                                                            produit.AddCell(prix_test9);

                                                            PdfPCell quantite_test10 = new PdfPCell(new Paragraph(quant_prod10, Font_tab_prod));
                                                            quantite_test10.FixedHeight = 50f;
                                                            PdfPCell unite_test10 = new PdfPCell(new Paragraph(unite_prod10, Font_tab_prod));
                                                            unite_test10.FixedHeight = 50f;
                                                            PdfPCell refe_test10 = new PdfPCell(new Paragraph(ref_prod10, Font_tab_prod));
                                                            refe_test10.FixedHeight = 50f;
                                                            PdfPCell prod_test10 = new PdfPCell(new Paragraph(produit_info10, Font_tab_prod));
                                                            prod_test10.FixedHeight = 50f;
                                                            PdfPCell prix_test10 = new PdfPCell(new Paragraph(produit_prix10 + " €", Font_tab_prod));
                                                            prix_test10.FixedHeight = 50f;

                                                            quantite_test10.Colspan = 2;
                                                            unite_test10.Colspan = 2;
                                                            refe_test10.Colspan = 4;
                                                            prod_test10.Colspan = 4;
                                                            prix_test10.Colspan = 2;

                                                            produit.AddCell(quantite_test10);
                                                            produit.AddCell(unite_test10);
                                                            produit.AddCell(refe_test10);
                                                            produit.AddCell(prod_test10);
                                                            produit.AddCell(prix_test10);

                                                            prix_total_commande = (Convert.ToInt32(produit_prix1) + Convert.ToInt32(produit_prix2) + Convert.ToInt32(produit_prix3) + Convert.ToInt32(produit_prix4) + Convert.ToInt32(produit_prix5) + Convert.ToInt32(produit_prix6) + Convert.ToInt32(produit_prix7) + Convert.ToInt32(produit_prix8) + Convert.ToInt32(produit_prix9) + Convert.ToInt32(produit_prix10)).ToString();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //


                        //

                        PdfPCell prix_txt_total = new PdfPCell(new Paragraph("Prix HT Total = ", Font_tab_prod));
                        PdfPCell prix_chiffre_total = new PdfPCell(new Paragraph(prix_total_commande + " €", Font_tab_prod));
                        prix_txt_total.Colspan = 12;
                        prix_chiffre_total.Colspan = 2;

                        prix_txt_total.HorizontalAlignment = Element.ALIGN_RIGHT;

                        produit.AddCell(prix_txt_total);
                        produit.AddCell(prix_chiffre_total);

                        //

                        commande.Add(produit);
                        commande.Close();

                        MessageBox.Show("Commande enregistrée");
                        i = 0;
                        lb_commande_produit_final.Items.Clear();

                        MessageBoxResult messageBoxResult = MessageBox.Show("Ouvrir le PDF ?", "Ouverture", MessageBoxButton.YesNo);

                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            System.Diagnostics.Process.Start(path);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Un Fichier porte déjà ce nom : commande_" + txtbox_commande_num_cmd.Text);
                    }
                }
                else
                {
                    MessageBox.Show("L'enregistrement a échoué");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //

        private bool Champ_cmd()
        {
            Regex regex_num_commande = new Regex(@"^[1-9][0-9]{0,5}$");

            try
            {
                if (txtbox_commande_num_cmd.Text == "")
                {
                    throw new Exception("Numero de commande vide");
                }
                else
                {
                    if (!regex_num_commande.IsMatch(txtbox_commande_num_cmd.Text))
                    {
                        throw new Exception("Numero de commande incorrect");
                    }
                    else
                    {
                        if (txtbox_commande_client.Text == "")
                        {
                            throw new Exception("Champ Client vide");
                        }
                        else
                        {
                            if (txtbox_commande_chantier.Text == "")
                            {
                                throw new Exception("Champ Chantier vide");
                            }
                            else
                            {
                                if (txtbox_commande_chantier_rue.Text == "")
                                {
                                    throw new Exception("Champ Rue vide");
                                }
                                else
                                {
                                    if (txtbox_commande_chantier_ville.Text == "")
                                    {
                                        throw new Exception("Champ Ville vide");
                                    }
                                    else
                                    {
                                        if (txtbox_commande_fournisseur.Text == "")
                                        {
                                            throw new Exception("Champ Fournisseur vide");
                                        }
                                        else
                                        {
                                            if (dtp_livraison.SelectedDate.Value.ToString() == "")
                                            {
                                                throw new Exception("Aucune date de livraison selectionnée");
                                            }
                                            else
                                            {
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }



        /* ----- Partie Produit ----- */

        private void txtbox_produit_nom_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lb_commande_produit.Items.Count != 0)
            {
                lb_commande_produit.Items.Clear();
            }


            bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
            List<Produits> produits = bdd.ChercheProduitnom((txtbox_produit_nom.Text).ToUpper());

            if (produits != null)
            {
                monProduit = produits;

                foreach (Produits pr in produits)
                {
                    LB_produit_produit.Items.Add(pr.nom + " " + pr.caracteristique + " " + pr.systeme + " " + pr.type_grain + " " + pr.prix_unitaire + " € / " + pr.unite_grandeur);
                }
            }
        }

        //

        private void btn_produit_ajouter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (champ_produit())
                {
                    bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                    Produits prod = new Produits("", txtbox_produit_nom.Text, cb_produit_caracteristique.SelectedIndex.ToString(), txtbox_produit_type.Text, cb_produit_grain.SelectedIndex.ToString(), txtbox_produit_systeme.Text, txtbox_produit_support.Text, txtbox_produit_fournisseur.Text, txtbox_produit_fabricant.Text, txtbox_produit_consomation.Text, cb_produit_epaisseur.SelectedIndex.ToString(), txtbox_produit_prix.Text, txtbox_produit_format.Text);
                    bdd.AjouterProduit(prod);
                    MessageBox.Show("L'ajout a été effectué");
                }
                else
                {
                    MessageBox.Show("L'ajout n'a pas été effectué");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //

        private void btn_produit_modifier_Click(object sender, RoutedEventArgs e)
        {

        }

        //

        private void btn_produit_supprimer_Click(object sender, RoutedEventArgs e)
        {

        }

        //

        private bool champ_produit()
        {
            Regex regex_systeme = new Regex(@"#[0-9]#");
            Regex regex_prix = new Regex(@"#[a-zA-Z]#");

            try
            {
                if (regex_systeme.IsMatch(txtbox_produit_systeme.Text))
                {
                    throw new Exception("Erreur Produit");
                }
                else
                {
                    if (regex_prix.IsMatch(txtbox_produit_prix.Text))
                    {
                        throw new Exception("Erreur Prix");
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //

        private void txtbox_produit_couleur_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (LB_produit_nuancier.Items.Count != 0)
            {
                LB_produit_nuancier.Items.Clear();
            }


            bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
            List<Nuancier> nuancier = bdd.ChercheNuancier((txtbox_produit_couleur.Text).ToUpper());

            if (nuancier != null)
            {
                monNuancier = nuancier;

                foreach (Nuancier nua in nuancier)
                {
                    LB_produit_nuancier.Items.Add(" | Teinte : " + nua.teinte + " | N° : " + nua.numero + " | Coefficient : " + nua.coefficient + " | Gamme : " + nua.gamme + " | Plus-value " + nua.plus_value + " |");
                }
            }
        }

        //

        private void LB_produit_nuancier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtbox_produit_ref.Text = "";
            txtbox_produit_gamme.Text = "";
            btn_produit_ajouter_nuance.IsEnabled = false;

            if (monNuancier[LB_produit_nuancier.SelectedIndex].coefficient == "<0,7")
            {
                rb_produit_coef1.IsChecked = true;
            }
            else
            {
                if (monNuancier[LB_produit_nuancier.SelectedIndex].coefficient == ">=0,7")
                {
                    rb_produit_coef2.IsChecked = true;
                }
                else
                {
                    rb_produit_coef3.IsChecked = true;
                }
            }
            txtbox_produit_ref.Text = monNuancier[LB_produit_nuancier.SelectedIndex].numero;
            txtbox_produit_gamme.Text = monNuancier[LB_produit_nuancier.SelectedIndex].gamme;
        }

        //

        private void btn_produit_ajouter_nuance_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                if (verif_champ_nuancier())
                {
                    Nuancier nua = new Nuancier("", (txtbox_produit_couleur.Text).ToUpper(), txtbox_produit_ref.Text, coef, txtbox_produit_gamme.Text, txtbox_produit_plus_value.Text);
                    bdd.AjouterNuancier(nua);
                    MessageBox.Show("L'ajout a été effectué");
                }
                else
                {
                    MessageBox.Show("L'ajout n'a pas été effectué");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //

        private void btn_produit_modif_nuancier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (verif_champ_nuancier())
                {
                    bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);
                    Nuancier nua = new Nuancier("", monNuancier[LB_produit_nuancier.SelectedIndex].teinte, txtbox_produit_ref.Text, coef, txtbox_produit_gamme.Text, txtbox_produit_plus_value.Text);
                    int ID = Convert.ToInt32(monNuancier[LB_produit_nuancier.SelectedIndex].ID_nuancier);
                    bdd.ModifierNuancier(nua, ID);
                    MessageBox.Show("La modification a été effectuée");
                }
                else
                {
                    MessageBox.Show("La modification n'a pas été effectuée");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //

        private void btn_produit_suppr_nuancier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bdd bdd = new bdd(Properties.Settings.Default.server, Properties.Settings.Default.bdd, Properties.Settings.Default.user, Properties.Settings.Default.password);

                bdd.SupprimerNuancier(Convert.ToInt32(monNuancier[LB_produit_nuancier.SelectedIndex].ID_nuancier));
                MessageBox.Show("La teinte a bien été supprimé");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //

        private void rb_produit_coef1_Checked(object sender, RoutedEventArgs e)
        {
            coef = rb_produit_coef1.Content.ToString();
        }

        //

        private void rb_produit_coef2_Checked(object sender, RoutedEventArgs e)
        {
            coef = rb_produit_coef2.Content.ToString();
        }

        //

        private void rb_produit_coef3_Checked(object sender, RoutedEventArgs e)
        {
            coef = rb_produit_coef3.Content.ToString();
        }

        //

        private bool verif_champ_nuancier()
        {
            Regex regex_teinte = new Regex(@"([a-zA-Z]{1}[a-z]{1,10}(\s){0,1}){1,3}$");
            Regex regex_ref = new Regex(@"^[0-9]{3}");
            Regex regex_plus_value = new Regex(@"^[0-9]{0,3}");

            try
            {
                if (!regex_teinte.IsMatch(txtbox_produit_couleur.Text))
                {
                    throw new Exception("Teinte incorrecte ou vide");
                }
                else
                {
                    if (!regex_ref.IsMatch(txtbox_produit_ref.Text))
                    {
                        throw new Exception("Référence incorrecte ou vide");
                    }
                    else
                    {
                        if (rb_produit_coef1.IsChecked == false && rb_produit_coef2.IsChecked == false && rb_produit_coef3.IsChecked == false)
                        {
                            throw new Exception("Aucun coéfficient n'est sélectionné");
                        }
                        else
                        {
                            if (!regex_plus_value.IsMatch(txtbox_produit_plus_value.Text))
                            {
                                throw new Exception("plus-value incorrecte ou vide");
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }



        /* ----- Partie Parametre ----- */

        private void btn_modif_setting_Click(object sender, RoutedEventArgs e)
        {

            Regex regex_port = new Regex(@"^[0-9]{2,5}$");
            Regex regex_username = new Regex(@"^(\w+)$");
            Regex regex_psw = new Regex(@"^(\w+)$");
            Regex regex_bdd = new Regex(@"^(\w+)$");
            Regex regex_server = new Regex(@"^([0-9]{3}.){2}[0-9]{1,3}.[0-9]{3}$");
            try
            {
                if (!regex_username.IsMatch(txtbox_user.Text))
                {
                    throw new Exception("Erreur : Utilisateur incorrect ou vide");
                }
                else
                {
                    if (!regex_psw.IsMatch(pswbox_psw.Password))
                    {
                        throw new Exception("Erreur : Mot de Passe incorrect ou vide");
                    }
                    else
                    {
                        if (!regex_bdd.IsMatch(txtbox_bdd.Text))
                        {
                            throw new Exception("Erreur : base de données incorrecte ou vide");
                        }
                        else
                        {
                                if (!regex_port.IsMatch(txtbox_port.Text))
                                {
                                    throw new Exception("Erreur : Port invalide ou vide");
                                }
                                else
                                {
                                    MessageBox.Show("Vérification réussie !");
                                    try
                                    {
                                        Properties.Settings.Default.user = txtbox_user.Text;
                                        Properties.Settings.Default.password = pswbox_psw.Password;
                                        Properties.Settings.Default.bdd = txtbox_bdd.Text;
                                        Properties.Settings.Default.server = txtbox_server.Text;
                                        Properties.Settings.Default.port = Convert.ToInt32(txtbox_port.Text);
                                        Properties.Settings.Default.Save();
                                        MessageBox.Show("Modification effectuée");
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Une erreur est survenue lors de l'enregistrement des paramètres , veuillez réessayer");
                                    }
                                }
                            
                        }

                    }
                }
            }
            catch (Exception verif)
            {
                MessageBox.Show(verif.Message);
            }
        }

        //

        private void btn_chemin_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.chemin = txtbox_chemin.Text;
            Properties.Settings.Default.Save();
        }



        /* ----- Autre ----- */

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(TabItem.IsSelected)
            //{
            // fait ça
            //}

            if (TB_setting.IsSelected)
            {
                txtbox_user.Text = Properties.Settings.Default.user;
                pswbox_psw.Password = Properties.Settings.Default.password;
                txtbox_bdd.Text = Properties.Settings.Default.bdd;
                txtbox_server.Text = Properties.Settings.Default.server;
                txtbox_port.Text = Properties.Settings.Default.port.ToString();
                txtbox_chemin.Text = Properties.Settings.Default.chemin;
            }

            if(TB_commande.IsSelected)
            {
                txtbox_commande_client.Text = info_client;
                txtbox_commande_chantier.Text = n_chantier;
                txtbox_commande_chantier_rue.Text = r_chantier;
                txtbox_commande_chantier_ville.Text = v_chantier;
                txtbox_commande_fournisseur.Text = info_fournisseur;
            }
        }

        private void TB_produit_Loaded(object sender, RoutedEventArgs e)
        {
            cb_produit_caracteristique.Items.Add("semi-allégé");
            cb_produit_caracteristique.Items.Add("allégé");
            cb_produit_caracteristique.Items.Add("semi-lourd");
            cb_produit_caracteristique.Items.Add("lourd");

            cb_produit_grain.Items.Add("Grain Fin");
            cb_produit_grain.Items.Add("Grain Moyen");
        }


        private void dtp_livraison_Loaded(object sender, RoutedEventArgs e)
        {
            dtp_livraison.SelectedDate = DateTime.Today;
            dtp_livraison.BlackoutDates.AddDatesInPast();
        }
    }
}
