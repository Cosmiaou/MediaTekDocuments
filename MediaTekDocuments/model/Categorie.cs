
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Categorie (réunit les informations des classes Public, Genre, Rayon, Service, Etat)
    /// </summary>
    public class Categorie
    {
        public string Id { get; }
        public string Libelle { get; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="id"></param>
        /// <param name="libelle"></param>
        public Categorie(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

        /// <summary>
        /// Récupération du libellé pour l'affichage dans les combos
        /// </summary>
        /// <returns>Libelle</returns>
        public override string ToString()
        {
            return this.Libelle;
        }

    }
}
