using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model.Tests
{
    [TestClass()]
    public class UtilisateurTests
    {
        private const int id = 1;
        private const string nom = "admin";
        private const string password = "password";
        private const int idService = 4;
        private readonly Utilisateur user = new Utilisateur(id, nom, password, idService);

        /// <summary>
        /// Test le constructeur
        /// </summary>
        [TestMethod()]
        public void UtilisateurTest()
        {
            Assert.AreEqual(id, user.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(nom, user.Nom, "devrait réussir : nom valorisé");
            Assert.AreEqual(password, user.Password, "devrait réussir : password valorisé");
            Assert.AreEqual(idService, user.IdService, "devrait réussir : id valorisé");
        }
    }
}