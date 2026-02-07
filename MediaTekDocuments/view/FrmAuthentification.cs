using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaTekDocuments.controller;
using MediaTekDocuments.model;

namespace MediaTekDocuments.view
{
    /// <summary>
    /// Vue de la frame d'authentification
    /// </summary>
    public partial class FrmAuthentification : Form
    {
        FrmAuthentificationController controller = null;
        int compteurErreur;
        String apiauth = "";

        /// <summary>
        /// Constructeur, initialise le controller et le compteur d'erreur, ainsi que tous les éléments
        /// Récupère ApiAuth et rempli txbChaineConnexion avec, le masquant si nécessaire.
        /// </summary>
        public FrmAuthentification()
        {
            InitializeComponent();
            compteurErreur = 0;
            apiauth = ConfigurationManager.AppSettings["ApiAuth"];
            if (apiauth != "__API_AUTH__")
            {
                txbChaineConnexion.UseSystemPasswordChar = true;
            }
            txbChaineConnexion.Text = apiauth;
        }

        /// <summary>
        /// Initialise le controller et modifie le fichier de configuration avec la chaine de connexion à la BdD indiquée
        /// La modification n'a pas lieue si : la nouvelle chaine de connexion est identique à la précédente ; la nouvelle chaine est vide
        /// </summary>
        private void initialiseControler()
        {
            if (apiauth != txbChaineConnexion.Text && !String.IsNullOrEmpty(txbChaineConnexion.Text))
            {
                FrmAuthentificationController.UpdateConfig("ApiAuth", txbChaineConnexion.Text);
            }
            controller = new FrmAuthentificationController();
        }

        /// <summary>
        /// Initialise le controller. Vérifie si les champs sont remplis. Si oui, vérifie si les informations sont correctes. Si incorrect, 
        /// affiche une erreur et incrémente le compteur d'erreur. Si correct, vérifie si l'idService est égal à 1. Si oui, ferme 
        /// l'application. Si non, ouvre l'application. Si le compteur d'erreur est supérieur à 5, ferme l'application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (controller == null)
            {
                initialiseControler();
            }

            if (compteurErreur >= 5)
            {
                Application.Exit();
                return;
            }

            lblErreur.Text = "";
            if (txbLogin.Text.Length <= 0 || txbPassword.Text.Length <= 0)
            {
                lblErreur.Text = "Attention : les deux champs doivent être remplis.";
                return;
            }


            List<Utilisateur> users = controller.ControleAuthentification(txbLogin.Text, txbPassword.Text);

            if (users.Count == 0)
            {
                lblErreur.Text = "Attention : mot de passe, login, ou chaine connexion incorrect.";
                compteurErreur++;
                return;
            }
            else if (users[0].IdService == 1)
            {
                MessageBox.Show("Les utilisateurs du service Culture n'ont pas accès à cette application. Contactez un responsable.");
                Application.Exit();
            }
            else
            {
                FrmMediatek frmMediatek = new FrmMediatek(users[0].IdService);
                frmMediatek.ShowDialog();
            }
        }
    }
}
