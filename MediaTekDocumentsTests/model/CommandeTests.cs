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
    public class CommandeTests
    {
        private const string id = "20001";
        private static DateTime dateCommande = new DateTime(2025, 01, 01);
        private const double montant = 25.05;
        private static readonly Commande abo = new Commande(id, dateCommande, montant);


        /// <summary>
        /// Vérifie le fonctionnement du constructeur de Commande
        /// </summary>
        [TestMethod()]
        public void CommandeTest()
        {
            Assert.AreEqual(id, abo.Id, "doit réussir : id valorisé");
            Assert.AreEqual(dateCommande, abo.DateCommande, "doit réussir : date valorisée");
            Assert.AreEqual(montant, abo.Montant, "doit réussir : montant valorisé");
        }
    }
}