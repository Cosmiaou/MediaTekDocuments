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
    public class AbonnementTests
    {
        private const string id = "20001";
        private static DateTime dateFinAbonnement = new DateTime(2027,01,01);
        private const string idRevue = "10003";
        private static DateTime dateCommande = new DateTime(2025, 01, 01);
        private const double montant = 25.05;
        private static readonly Abonnement abo = new Abonnement(id, dateFinAbonnement, idRevue, dateCommande, montant);


        /// <summary>
        /// Vérifie le fonctionnement du constructeur d'Abonnement
        /// </summary>
        [TestMethod()]
        public void AbonnementTest()
        {
            Assert.AreEqual(id, abo.Id, "doit réussir : id valorisé");
            Assert.AreEqual(dateFinAbonnement, abo.DateFinAbonnement, "doit réussir : date valorisée");
            Assert.AreEqual(idRevue, abo.IdRevue, "doit réussir : id valorisé");
            Assert.AreEqual(dateCommande, abo.DateCommande, "doit réussir : date valorisée");
            Assert.AreEqual(montant, abo.Montant, "doit réussir : montant valorisé");
        }
    }
}