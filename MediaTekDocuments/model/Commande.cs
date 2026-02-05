using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier commande (réunit les informations de CommandeDocument et Abonnement)
    /// </summary>
    public class Commande
    {
        public string Id { get; set; }
        public DateTime DateCommande { get; set; }
        public double Montant { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="id"></param>
        /// <param name="datecommande"></param>
        /// <param name="montant"></param>
        public Commande(string id, DateTime datecommande, double montant)
        {
            this.Id = id;
            this.DateCommande = datecommande;
            this.Montant = montant;
        }
    }
}
