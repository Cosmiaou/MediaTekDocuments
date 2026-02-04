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
    public class SuiviTests
    {
        private const int id = 1;
        private const string libelle = "en cours";
        private readonly Suivi suivi = new Suivi(id, libelle);

        /// <summary>
        /// test le constructeur de Suivi
        /// </summary>
        [TestMethod()]
        public void SuiviTest()
        {
            Assert.AreEqual(id, suivi.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(libelle, suivi.Libelle, "devrait réussir : libelle valorisé");
        }

        /// <summary>
        /// teste la rédéfinition de tostring()
        /// </summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(libelle, suivi.ToString(), "devrait réussir : strign retourné");
        }
    }
}