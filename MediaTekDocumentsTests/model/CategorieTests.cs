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
    public class CategorieTests
    {
        private const string id = "00001";
        private const string libelle = "catégorie";
        private readonly Categorie cat = new Categorie(id, libelle);

        /// <summary>
        /// test le constructeur de categorie
        /// </summary>
        [TestMethod()]
        public void CategorieTest()
        {
            Assert.AreEqual(id, cat.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(libelle, cat.Libelle, "devrait réussir : libelle valorisé");
        }
        
        /// <summary>
        /// teste la rédéfinition de tostring()
        /// </summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(libelle, cat.ToString(), "devrait réussir : strign retourné");
        }
    }
}