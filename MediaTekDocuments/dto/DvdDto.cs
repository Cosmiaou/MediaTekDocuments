using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.dto
{
    public class DvdDto
    {
        public string Id { get; set; }
        public string Titre { get; set; }
        public string Image { get; set; }
        public string IdRayon { get; set; }
        public string IdPublic { get; set; }
        public string IdGenre { get; set; }
        public string Synopsis { get; set; }
        public string Realisateur { get; set; }
        public int Duree { get; set; }
    }
}
