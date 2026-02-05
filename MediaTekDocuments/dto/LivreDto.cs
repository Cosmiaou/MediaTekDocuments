using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.dto
{
    /// <summary>
    /// Objet de transfert de données
    /// </summary>
    public class LivreDto
    {
        public string Id { get; set; }
        public string Titre { get; set; }
        public string Image { get; set; }
        public string IdRayon { get; set; }
        public string IdPublic { get; set; }
        public string IdGenre { get; set; }

        public string ISBN { get; set; }
        public string Auteur { get; set; }
        public string Collection { get; set; }
    }
}