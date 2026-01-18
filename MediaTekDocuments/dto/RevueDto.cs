using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.dto
{
    public class RevueDto
    {
        public string Id { get; set; }
        public string Titre { get; set; }
        public string Image { get; set; }
        public string IdRayon { get; set; }
        public string IdPublic { get; set; }
        public string IdGenre { get; set; }
        public string Periodicite { get; set; }
        public int DelaiMiseADispo { get; set; }

    }
}
