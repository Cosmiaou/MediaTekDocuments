using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Utilisateur
    {
        public int Id {  get; set; }
        public string Nom { get; set; }
        public string Password { get; set; }
        public int IdService { get; set; }

        public Utilisateur(int id, string nom, string password, int idService) {
            this.Id = id;
            this.Nom = nom;
            this.Password = password;
            this.IdService = idService;
        }
    }
}
