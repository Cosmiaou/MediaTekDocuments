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
    public class PublicTests
    {
        private const string id = "00001";
        private const string libelle = "tout public";
        private readonly Public lepublic = new Public(id, libelle);

        /// <summary>
        /// test le constructeur de Public
        /// </summary>
        [TestMethod()]
        public void PublicTest()
        {
            Assert.AreEqual(id, lepublic.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(libelle, lepublic.Libelle, "devrait réussir : libelle valorisé");
        }

        /// <summary>
        /// teste la rédéfinition de tostring()
        /// </summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(libelle, lepublic.ToString(), "devrait réussir : strign retourné");
        }
    }
}