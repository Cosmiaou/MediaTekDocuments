using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.dto
{
    public class CommandeDocumentDto
    {
        public string Id { get; set; }
        public DateTime DateCommande { get; set; }
        public double Montant { get; set; }
        public int NbExemplaire { get; set; }
        public int IdSuivi { get; set; }
        public string IdLivreDvd { get; set; }
    }
}
