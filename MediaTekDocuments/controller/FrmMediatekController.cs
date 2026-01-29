using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using MediaTekDocuments.dto;
using System;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    class FrmMediatekController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// getter sur la liste des genres
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Liste d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        /// <summary>
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// getter sur les rayons
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// getter sur les publics
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }

        /// <summary>
        /// getter sur les suivis
        /// </summary>
        /// <returns>Liste d 'objets Suivi</returns>
        public List<Suivi> GetAllSuivis()
        {
            return access.GetAllSuivis();
        }


        /// <summary>
        /// récupère les exemplaires d'un document
        /// </summary>
        /// <param name="idDocument">id de la document concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesDocument(string idDocument)
        {
            return access.GetExemplairesDocument(idDocument);
        }

        /// <summary>
        /// retourne une liste de commande en fonction de l'id du document et du type de document
        /// </summary>
        /// <param name="type">commande_dvd ou commande_livre</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CommandeDocument> GetCommandeDocument(string type, string id = null)
        {
            return access.GetCommandeDocument(type, id);
        }

        /// <summary>
        /// retourne une liste d'abonnement en fonction de l'id de la revue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Abonnement> GetAbonnement(string id)
        {
            return access.GetAbonnement(id);
        }

        public Livre GetLivre(string id)
        {
            return access.GetLivre(id);
        }

        public Dvd GetDvd(string id)
        {
            return access.GetDvd(id);
        }

        public Revue GetRevue(string id)
        {
            return access.GetRevue(id);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }

        /// <summary>
        /// Vérifie si des exemplaires ou des commandes sont rattachés à ce livre
        /// </summary>
        /// <param name="livre"></param>
        /// <returns>true si la suppression a fonctionnée. False le cas échéant</returns>
        public bool SupprimerLivre(Livre livre)
        {
            if (GetExemplairesDocument(livre.Id).Count != 0 || GetCommandeDocument("commande_livre", livre.Id).Count != 0)
            {
                return false;
            } else
            {
                return access.SupprLivre(livre);
            }
        }

        /// <summary>
        /// Crée un livre  dans la bdd
        /// </summary>
        /// <param name="livre">L'objet Livre concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerLivre(LivreDto livre)
        {
            return access.CreerLivre(livre);
        }

        public bool ModifierLivre(LivreDto livre)
        {
            return access.ModifierLivre(livre);
        }

        public bool CreerDvd(DvdDto dvd)
        {
            return access.CreerDvd(dvd);
        }

        public bool ModifierDvd(DvdDto dvd)
        {
            return access.ModifierDvd(dvd);
        }

        public bool CreerRevue(RevueDto revue)
        {
            return access.CreerRevue(revue);
        }

        public bool ModifierRevue(RevueDto revue)
        {
            return access.ModifierRevue(revue);
        }

        public bool AjouterCommande(CommandeDocumentDto cd)
        {
            return access.AjouterCommande(cd);
        }

        public bool SupprimerCommande(Commande cd)
        {
            return access.SupprimerCommande(cd);
        }

        public bool ModifierCommande(CommandeDocumentDto dto)
        {
            return access.UpdateCommande(dto);
        }

        public bool AjouterAbonnement(Abonnement abo)
        {
            return access.AjouterAbonnement(abo);
        }


        /// <summary>
        /// Vérifie si des exemplaires ou des commandes sont rattachés à ce dvd
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si la suppression a fonctionnée. False le cas échéant</returns>
        public bool SupprimerDvd(Dvd dvd)
        {
            if (GetExemplairesDocument(dvd.Id).Count != 0 || GetCommandeDocument("commande_dvd", dvd.Id).Count != 0)
            {
                return false;
            }
            else
            {
                return access.SupprDvd(dvd);
            }
        }

        /// <summary>
        /// Vérifie si des exemplaires ou des commandes sont rattachés à ce revue. Si non, la supprime
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si la suppression a fonctionnée. False le cas échéant</returns>
        public bool SupprimerRevue(Revue revue)
        {
            if (GetExemplairesDocument(revue.Id).Count != 0 || GetAbonnement(revue.Id).Count != 0)
            {
                return false;
            }
            else
            {
                return access.SupprRevue(revue);
            }
        }

        /// <summary>
        /// Retourne une liste de tous les abonnements qui vont prochainement expirer
        /// </summary>
        /// <returns></returns>
        public List<Abonnement> GetAbonnementsDate()
        {
            return access.GetAbonnementsDate();
        }

        /// <summary>
        /// Si la date de parution indiqué est située entre la date de la commande et la date de fin, retourne vrai. Sinon, retourne faux
        /// </summary>
        /// <param name="dateCommande"></param>
        /// <param name="dateFin"></param>
        /// <param name="dateParution"></param>
        /// <returns>boolean</returns>
        public bool ParutionDansAbonnement(DateTime dateCommande, DateTime dateFin, DateTime dateParution)
        {
            if (dateParution > dateCommande && dateParution < dateFin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
