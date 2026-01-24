using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class CommandeDocument : Commande
    {
        public int NbExemplaire { get; set;  }
        public int IdSuivi { get; set; }
        public string Suivi { get; set; }
        public string IdLivreDvd {  get; set; }

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
