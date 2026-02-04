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
    public class DvdTests
    {
        private const string id = "00001";
        private const string titre = "test dvd";
        private const string image = "/image";
        private const string idGenre = "10014";
        private const string genre = "action";
        private const string idPublic = "00002";
        private const string lePublic = "adulte";
        private const string idRayon = "LV003";
        private const string rayon = "Policiers français étrangers";
        private const int duree = 123;
        private const string realisateur = "John Test";
        private const string synopsis = "Un test est effectuée par un étudiant fatigué";
        private readonly Dvd doc = new Dvd(id, titre, image, duree, realisateur, synopsis, idGenre, genre, idPublic, lePublic, idRayon, rayon);

        /// <summary>
        /// test le constructeur
        /// </summary>
        [TestMethod()]
        public void DvdTest()
        {
            Assert.AreEqual(id, doc.Id);
            Assert.AreEqual(titre, doc.Titre);
            Assert.AreEqual(image, doc.Image);
            Assert.AreEqual(duree, doc.Duree);
            Assert.AreEqual(realisateur, doc.Realisateur);
            Assert.AreEqual(synopsis, doc.Synopsis);
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