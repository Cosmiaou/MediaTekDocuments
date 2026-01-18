using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using MediaTekDocuments.dto;

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
        /// récupère les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocuement">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return access.GetExemplairesRevue(idDocuement);
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
            if (GetExemplairesRevue(livre.Id).Count != 0)
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


        /// <summary>
        /// Vérifie si des exemplaires ou des commandes sont rattachés à ce dvd
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si la suppression a fonctionnée. False le cas échéant</returns>
        public bool SupprimerDvd(Dvd dvd)
        {
            if (GetExemplairesRevue(dvd.Id).Count != 0)
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
            if (GetExemplairesRevue(revue.Id).Count != 0)
            {
                return false;
            }
            else
            {
                return access.SupprRevue(revue);
            }
        }
    }
}
