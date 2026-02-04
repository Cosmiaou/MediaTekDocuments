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
    public class CommandeDocumentTests
    {
        private const string id = "20001";
        public const int idSuivi = 1;
        public const string suivi = "en cours";
        private const string idLivreDvd = "00003";
        public const int nbEx = 12;
        private static DateTime dateCommande = new DateTime(2025, 01, 01);
        private const double montant = 25.05;
        private static readonly CommandeDocument cd = new CommandeDocument(id, dateCommande, montant, nbEx, idSuivi, suivi, idLivreDvd);


        /// <summary>
        /// Vérifie le fonctionnement du constructeur de CommandeDocument
        /// </summary>
        [TestMethod()]
        public void CommandeDocumentTest()
        {
            Assert.AreEqual(id, cd.Id, "doit réussir : id valorisé");
            Assert.AreEqual(idSuivi, cd.IdSuivi, "doit réussir : id valorisé");
            Assert.AreEqual(suivi, cd.Suivi, "doit réussir : suivi valorisé");
            Assert.AreEqual(nbEx, cd.NbExemplaire, "doit réussir : nombre valorisé");
            Assert.AreEqual(idLivreDvd, cd.IdLivreDvd, "doit réussir : id valorisé");
            Assert.AreEqual(dateCommande, cd.DateCommande, "doit réussir : date valorisée");
            Assert.AreEqual(montant, cd.Montant, "doit réussir : montant valorisé");
        }
    }
}