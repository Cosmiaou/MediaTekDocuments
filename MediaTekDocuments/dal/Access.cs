using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.manager;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Linq;
using MediaTekDocuments.dto;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Text;
using Serilog;

namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Classe d'accès aux données
    /// </summary>
    public class Access
    {
        /// <summary>
        /// adresse de l'API
        /// </summary>
        private static readonly string uriApi = "http://localhost/rest_mediatekdocuments/";
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access instance = null;
        /// <summary>
        /// instance de ApiRest pour envoyer des demandes vers l'api et recevoir la réponse
        /// </summary>
        private readonly ApiRest api = null;
        /// <summary>
        /// méthode HTTP pour select
        /// </summary>
        private const string GET = "GET";
        /// <summary>
        /// méthode HTTP pour insert
        /// </summary>
        private const string POST = "POST";
        /// <summary>
        /// méthode HTTP pour update
        /// </summary>
        private const string PUT = "PUT";
        /// <summary>
        /// méthode HTTP pour delete
        /// </summary>
        private const string DELETE = "DELETE";
        /// <summary>
        /// Méthode privée pour créer un singleton
        /// initialise l'accès à l'API
        /// </summary>
        private Access()
        {
            String authenticationString;
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.Console()
                    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();
                authenticationString = "apiadmin:";
                api = ApiRest.GetInstance(uriApi, authenticationString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Log.Fatal(e, "Erreur lors de l'initialisation d'accès.");
                Environment.Exit(0);
            }
        }

        #region Getters

        /// <summary>
        /// Création et retour de l'instance unique de la classe
        /// </summary>
        /// <returns>instance unique de la classe</returns>
        public static Access GetInstance()
        {
            if (instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        /// <summary>
        /// Retourne tous les genres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            IEnumerable<Genre> lesGenres = TraitementRecup<Genre>(GET, "genre", null);
            return new List<Categorie>(lesGenres);
        }

        /// <summary>
        /// Retourne tous les rayons à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            IEnumerable<Rayon> lesRayons = TraitementRecup<Rayon>(GET, "rayon", null);
            return new List<Categorie>(lesRayons);
        }

        /// <summary>
        /// Retourne toutes les catégories de public à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            IEnumerable<Public> lesPublics = TraitementRecup<Public>(GET, "public", null);
            return new List<Categorie>(lesPublics);
        }

        /// <summary>
        /// Retourne toutes les livres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = TraitementRecup<Livre>(GET, "livre", null);
            return lesLivres;
        }

        /// <summary>
        /// Retourne toutes les dvd à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            List<Dvd> lesDvd = TraitementRecup<Dvd>(GET, "dvd", null);
            return lesDvd;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            List<Revue> lesRevues = TraitementRecup<Revue>(GET, "revue", null);
            return lesRevues;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BdD
        /// </summary>
        /// <returns></returns>
        public List<Suivi> GetAllSuivis()
        {
            List<Suivi> lesSuivis = TraitementRecup<Suivi>(GET, "suivi", null);
            return lesSuivis;
        }

        public Livre GetLivre(string id)
        {
            String jsonIdDocument = convertToJson("id", id);
            List<Livre> livres = TraitementRecup<Livre>(GET, "livre/" + jsonIdDocument, null);
            return livres[0];
        }

        public Dvd GetDvd(string id)
        {
            String jsonIdDocument = convertToJson("id", id);
            Console.WriteLine(jsonIdDocument);
            List<Dvd> dvd = TraitementRecup<Dvd>(GET, "dvd/" + jsonIdDocument, null);
            return dvd[0];
        }

        public Revue GetRevue(string id)
        {
            String jsonIdDocument = convertToJson("id", id);
            List<Revue> revue = TraitementRecup<Revue>(GET, "revue/" + jsonIdDocument, null);
            return revue[0];
        }


        /// <summary>
        /// Retourne les exemplaires d'un document
        /// </summary>
        /// <param name="idDocument">id de la document concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesDocument(string idDocument)
        {
            String jsonIdDocument = convertToJson("id", idDocument);
            List<Exemplaire> lesExemplaires = TraitementRecup<Exemplaire>(GET, "exemplaire/" + jsonIdDocument, null);
            return lesExemplaires;
        }

        /// <summary>
        /// Retourne une liste de commandes en fonction du type et de l'id du document
        /// </summary>
        /// <param name="type">string, indique la table. Doit être fixé sur "livre" ou sur "dvd"</param>
        /// <param name="id">string, indique l'id du document voulu</param>
        /// <returns>Liste d'objets CommandeDocument</returns>
        public List<CommandeDocument> getCommandeDocument(string type, string id)
        {
            String jsonIdDocument = convertToJson("id", id);
            List<CommandeDocument> lesCommandes = TraitementRecup<CommandeDocument>(GET, type + "/" + jsonIdDocument, null);
            return lesCommandes;
        }

        /// <summary>
        /// Retourne une liste d'abonnement en fonction de l'id de la revue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Abonnement> getAbonnement(string id)
        {
            String jsonIdDocument = convertToJson("id", id);
            List<Abonnement> lesCommandes = TraitementRecup<Abonnement>(GET, "commande_revue/" + jsonIdDocument, null);
            return lesCommandes;
        }

        #endregion
            #region Modifications

            /// <summary>
            /// ecriture d'un exemplaire en base de données
            /// </summary>
            /// <param name="exemplaire">exemplaire à insérer</param>
            /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            String jsonExemplaire = JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter());
            try
            {
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(POST, "exemplaire", "champs=" + jsonExemplaire);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la création de l'exemplaire. Champs = {0}", jsonExemplaire);
            }
            return false;
        }

        /// <summary>
        /// Supprime un livre de la BdD
        /// </summary>
        /// <param name="livre"></param>
        /// <returns></returns>
        public bool SupprLivre(Livre livre)
        {
            String jsonLivre = convertToJson("id", livre.Id);
            try
            {
                List<Livre> liste = TraitementRecup<Livre>(DELETE, "livre/" + jsonLivre, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la suppression du livre. Champs = {0}", jsonLivre);
            }
            return false;
        }

        /// <summary>
        /// ecriture d'un livre en base de données
        /// </summary>
        /// <param name="livre">livre à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerLivre(LivreDto livre)
        {
            String jsonLivre = JsonConvert.SerializeObject(livre);
            try
            {
                List<LivreDto> liste = TraitementRecup<LivreDto>(POST, "livre", "champs=" + jsonLivre);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la création du livre. Champs = {0}", jsonLivre);
            }
            return false;
        }
        
        public bool ModifierLivre(LivreDto livre)
        {
            String jsonLivre = JsonConvert.SerializeObject(livre);
            try
            {
                List<LivreDto> liste = TraitementRecup<LivreDto>(PUT, "livre/" + livre.Id, "champs=" + jsonLivre);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la modification du livre. Champs = {0}", jsonLivre);
            }
            return false;
        }

        /// <summary>
        /// Supprime un Dvd de la BdD
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns></returns>
        public bool SupprDvd(Dvd dvd)
        {
            String jsonDvd = convertToJson("id", dvd.Id);
            try
            {
                List<Livre> liste = TraitementRecup<Livre>(DELETE, "dvd/" + jsonDvd, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la suppression du DVD. Champs = {0}", jsonDvd);
            }
            return false;
        }

        public bool CreerDvd(DvdDto dvd)
        {
            String jsonDvd = JsonConvert.SerializeObject(dvd);
            try
            {
                List<DvdDto> liste = TraitementRecup<DvdDto>(POST, "dvd", "champs=" + jsonDvd);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la création du DVD. Champs = {0}", jsonDvd);
            }
            return false;
        }

        public bool ModifierDvd(DvdDto dvd)
        {
            String jsonDvd = JsonConvert.SerializeObject(dvd);
            try
            {
                List<DvdDto> liste = TraitementRecup<DvdDto>(PUT, "dvd/" + dvd.Id, "champs=" + jsonDvd);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la modification du DVD. Champs = {0}", jsonDvd);
            }
            return false;
        }

        /// <summary>
        /// Supprime une Revue de la BdD
        /// </summary>
        /// <param name="revue"></param>
        /// <returns></returns>
        public bool SupprRevue(Revue revue)
        {
            String jsonRevue = convertToJson("id", revue.Id);
            try
            {
                List<Revue> liste = TraitementRecup<Revue>(DELETE, "revue/" + jsonRevue, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la suppression de la revue. Champs = {0}", jsonRevue);
            }
            return false;
        }

        public bool CreerRevue(RevueDto revue)
        {
            String jsonRevue = JsonConvert.SerializeObject(revue);
            try
            {
                List<RevueDto> liste = TraitementRecup<RevueDto>(POST, "revue", "champs=" + jsonRevue);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la création de la revue. Champs = {0}", jsonRevue);
            }
            return false;
        }

        public bool ModifierRevue(RevueDto revue)
        {
            String jsonRevue = JsonConvert.SerializeObject(revue);
            try
            {
                List<RevueDto> liste = TraitementRecup<RevueDto>(PUT, "revue/" + revue.Id, "champs=" + jsonRevue);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la modification de la revue. Champs = {0}", jsonRevue);
            }
            return false;
        }

        public bool AjouterCommande(CommandeDocumentDto cd)
        {
            String jsonCommande = JsonConvert.SerializeObject(cd, new CustomDateTimeConverter());
            try
            {
                List<CommandeDocumentDto> liste = TraitementRecup<CommandeDocumentDto>(POST, "commande", "champs=" + jsonCommande);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de l'ajout de la commande. Champs = {0}", jsonCommande);
            }
            return false;
        }

        public bool SupprimerCommande(Commande cd)
        {
            String jsonCommande = convertToJson("id", cd.Id);
            try
            {
                List<Commande> liste = TraitementRecup<Commande>(DELETE, "commande/" + jsonCommande, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la suppression de la commande. Champs = {0}", jsonCommande);
            }
            return false;
        }


        public bool UpdateCommande(CommandeDocumentDto dto)
        {
            String jsonDto = JsonConvert.SerializeObject(dto, new CustomDateTimeConverter());
            try
            {
                List<RevueDto> liste = TraitementRecup<RevueDto>(PUT, "commandedocument/" + dto.Id, "champs=" + jsonDto);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la modification de la commande. Champs = {0}", jsonDto);
            }
            return false;
        }

        public bool AjouterAbonnement(Abonnement abo)
        {
            String jsonAbonnement = JsonConvert.SerializeObject(abo, new CustomDateTimeConverter());
            try
            {
                List<Abonnement> liste = TraitementRecup<Abonnement>(POST, "abonnement", "champs=" + jsonAbonnement);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de l'ajout de la commande. Champs = {0}", jsonAbonnement);
            }
            return false;
        }

        /// <summary>
        /// Retourne une liste de tous les abonnements qui vont prochainement expirer.
        /// </summary>
        /// <returns></returns>
        public List<Abonnement> GetAbonnementsDate()
        {
            try
            {
                List<Abonnement> abonnements = TraitementRecup<Abonnement>(GET, "abonnements", null);
                return abonnements;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur lors de la récupération des abonnements");
            }
            return null;
        }

        /// <summary>
        /// Hash le mot de passe avant de demander à l'API si un compte ayant le même MDP et le même login existe. Si oui
        /// </summary>
        /// <param name="login"></param>
        /// <param name="mdp"></param>
        /// <returns></returns>
        public List<Utilisateur> ControleAuthentification(string login, string mdp)
        {
            string mdpHash = sha256_hash(mdp);
            Utilisateur user = new Utilisateur(0, login, mdpHash, 0);
            String jsonUser = JsonConvert.SerializeObject(user);
            Console.WriteLine(jsonUser);

            List<Utilisateur> users = TraitementRecup<Utilisateur>(GET, "utilisateur_check/" + jsonUser, null);
            return users;
        }

        #endregion
        #region Traitement

        /// <summary>
        /// Traitement de la récupération du retour de l'api, avec conversion du json en liste pour les select (GET)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methode">verbe HTTP (GET, POST, PUT, DELETE)</param>
        /// <param name="message">information envoyée dans l'url</param>
        /// <param name="parametres">paramètres à envoyer dans le body, au format "chp1=val1&chp2=val2&..."</param>
        /// <returns>liste d'objets récupérés (ou liste vide)</returns>
        private List<T> TraitementRecup<T>(String methode, String message, String parametres)
        {
            // trans
            List<T> liste = new List<T>();
            try
            {
                JObject retour = api.RecupDistant(methode, message, parametres);
                // extraction du code retourné
                String code = (String)retour["code"];
                if (code.Equals("200"))
                {
                    // dans le cas du GET (select), récupération de la liste d'objets
                    if (methode.Equals(GET))
                    {
                        String resultString = JsonConvert.SerializeObject(retour["result"]);
                        Log.Information("Récupération du contenu de la requête : {0}", resultString);
                        // construction de la liste d'objets à partir du retour de l'api
                        liste = JsonConvert.DeserializeObject<List<T>>(resultString, new CustomBooleanJsonConverter());
                    }
                }
                else
                {
                    Log.Error("Erreur dans l'exécution de la requête : paramètres : {0} ; code erreur : {1} ; message : {2}", parametres, code, (String)retour["message"]);
                }
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Erreur lors de l'accès à l'API : {0}", e.Message);
                Environment.Exit(0);
            }
            return liste;
        }

        /// <summary>
        /// Convertit en json un couple nom/valeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="valeur"></param>
        /// <returns>couple au format json</returns>
        private String convertToJson(Object nom, Object valeur)
        {
            Dictionary<Object, Object> dictionary = new Dictionary<Object, Object>();
            dictionary.Add(nom, valeur);
            return JsonConvert.SerializeObject(dictionary);
        }

        /// <summary>
        /// Modification du convertisseur Json pour gérer le format de date
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }

        /// <summary>
        /// Modification du convertisseur Json pour prendre en compte les booléens
        /// classe trouvée sur le site :
        /// https://www.thecodebuzz.com/newtonsoft-jsonreaderexception-could-not-convert-string-to-boolean/
        /// </summary>
        private sealed class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

        /// <summary>
        /// Méthode hashant une string avec l'algorithme Sha256
        /// méthode trouvée sur le site :
        /// https://stackoverflow.com/questions/16999361/obtain-sha-256-string-of-a-string
        /// </summary>
        /// <param name="value">string à convertir</param>
        /// <returns>string hashée</returns>
        public static String sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        #endregion
    }
}
