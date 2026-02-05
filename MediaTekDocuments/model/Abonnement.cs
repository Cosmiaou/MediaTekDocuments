using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Abonnement : hérite de commande et contient les éléments spécifiques à un abonnement d'une revue
    /// </summary>
    public class Abonnement : Commande
    {
        public DateTime DateFinAbonnement { get; set; }
        public string IdRevue { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="id"></param>
        /// <param name="datefinabonnement"></param>
        /// <param name="idrevue"></param>
        /// <param name="datecommande"></param>
        /// <param name="montant"></param>
        public Abonnement(string id, DateTime datefinabonnement, string idrevue, DateTime datecommande, double montant)
            : base(id, datecommande, montant)
        {
            this.IdRevue = idrevue;
            this.DateFinAbonnement = datefinabonnement;
        }
    }
    }
