using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace MediaTekDocuments.controller.Tests
{

    [TestClass()]
    public class FrmMediatekControllerTests
    {

        private static DateTime date1 = new DateTime(2024, 01, 01);
        private static DateTime date2 = new DateTime(2025, 01, 01);
        private static DateTime date3 = new DateTime(2026, 01, 01);

        /// <summary>
        /// Vérifie le fonctionnement correct de la méthode
        /// </summary>
        [TestMethod()]
        public void ParutionDansAbonnementTest()
        {
            Assert.AreEqual(false, FrmMediatekController.ParutionDansAbonnement(date1, date2, date3), "devrait être false : dateParution postérieure à l'abonnement");
            Assert.AreEqual(false, FrmMediatekController.ParutionDansAbonnement(date2, date3, date1), "devrait être false : dateParution antérieure à l'abonnement");
            Assert.AreEqual(true, FrmMediatekController.ParutionDansAbonnement(date1, date3, date2), "devrait être true : dateParution comprise dans l'abonnement");
            Assert.AreEqual(true, FrmMediatekController.ParutionDansAbonnement(date1, date3, date1), "devrait être true : dateParution égale à la date de début");
            Assert.AreEqual(true, FrmMediatekController.ParutionDansAbonnement(date1, date3, date3), "devrait être true : dateParution égale à la date de fin");
            Assert.AreEqual(false, FrmMediatekController.ParutionDansAbonnement(date2, date1, date3), "devrait être false : dateParution non comprise dans l'abonnement, malgré l'incohérence des dates de celui-ci");
        }
    }
}