using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaTekDocuments.dal;
using MediaTekDocuments.model;

namespace MediaTekDocuments.controller
{
    internal class FrmAuthentificationController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmAuthentificationController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Contrôle l'authentification en fonction du login et du mot de passe
        /// </summary>
        /// <param name="login"></param>
        /// <param name="mdp"></param>
        /// <returns></returns>
        public List<Utilisateur> controleAuthentification(string login, string mdp)
        {
            return access.ControleAuthentification(login, mdp);
        }

    }
}
