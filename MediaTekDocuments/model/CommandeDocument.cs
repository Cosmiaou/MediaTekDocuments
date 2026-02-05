using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier COmmandeDocument : hérite de commande et contient les éléments spécifiques à une commande de DVD ou de livre
    /// </summary>
    public class CommandeDocument : Commande
    {
        public int NbExemplaire { get; set;  }
        public int IdSuivi { get; set; }
        public string Suivi { get; set; }
        public string IdLivreDvd {  get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="id"></param>
        /// <param name="datecommande"></param>
        /// <param name="montant"></param>
        /// <param name="nbexemplaire"></param>
        /// <param name="idsuivi"></param>
        /// <param name="suivi"></param>
        /// <param name="idlivredvd"></param>
        public CommandeDocument(string id, DateTime datecommande, double montant, int nbexemplaire, int idsuivi, string suivi, string idlivredvd)
            : base(id, datecommande, montant)
        {
            this.NbExemplaire = nbexemplaire;
            this.IdSuivi = idsuivi;
            this.Suivi = suivi;
            this.IdLivreDvd = idlivredvd;
        }
    }
}
