
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Etat (état d'usure d'un document)
    /// </summary>
    public class Etat : Categorie
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="id"></param>
        /// <param name="libelle"></param>
        public Etat(string id, string libelle) : base(id, libelle)
        {
        }

    }
}
