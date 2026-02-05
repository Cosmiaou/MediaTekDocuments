using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Service (service de travail d'un utilisateur) : hérite de Categorie
    /// </summary>
    public class Service : Categorie
    {
        public Service(string id, string libelle) : base(id, libelle)
        {
        }

    }
}
