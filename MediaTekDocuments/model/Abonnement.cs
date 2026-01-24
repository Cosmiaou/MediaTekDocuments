using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Abonnement : Commande
    {
        public DateTime DateFinAbonnement { get; set; }
        public string IdRevue { get; set; }

        public Abonnement(string id, DateTime datefinabonnement, string idrevue, DateTime datecommande, double montant)
            : base(id, datecommande, montant)
        {
            this.IdRevue = idrevue;
            this.DateFinAbonnement = datefinabonnement;
        }
    }
    }
