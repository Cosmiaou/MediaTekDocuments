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
    public class RevueTests
    {
        private const string id = "30001";
        private const string titre = "test revue";
        private const string image = "/image";
        private const string idGenre = "10014";
        private const string genre = "action";
        private const string idPublic = "00002";
        private const string lePublic = "adulte";
        private const string idRayon = "MM003";
        private const string rayon = "magazines";
        private const string peri = "HB";
        private const int duree = 50;
        private readonly Revue doc = new Revue(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon, peri, duree);

        /// <summary>
        /// test le constructeur
        /// </summary>
        [TestMethod()]
        public void RevueTest()
        {
            Assert.AreEqual(id, doc.Id);
            Assert.AreEqual(titre, doc.Titre);
            Assert.AreEqual(image, doc.Image);
            Assert.AreEqual(duree, doc.DelaiMiseADispo);
            Assert.AreEqual(peri, doc.Periodicite);
            Assert.AreEqual(idGenre, doc.IdGenre);
            Assert.AreEqual(genre, doc.Genre);
            Assert.AreEqual(idPublic, doc.IdPublic);
            Assert.AreEqual(lePublic, doc.Public);
            Assert.AreEqual(idRayon, doc.IdRayon);
            Assert.AreEqual(rayon, doc.Rayon);
        }

        /// <summary>
        /// Vérifie la méthode tostring()
        /// </summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(titre, doc.ToString());
        }
    }
}