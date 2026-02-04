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
    public class ExemplaireTests
    {
        private const int numero = 3;
        private static DateTime dateAchat = DateTime.Now;
        private const string photo = "image/chemin/";
        private const string idEtat = "00001";
        private const string idDocument = "10003";
        private readonly Exemplaire ex = new Exemplaire(numero, dateAchat, photo, idEtat, idDocument);

        /// <summary>
        /// Vérifie le constructeur
        /// </summary>
        [TestMethod()]
        public void ExemplaireTest()
        {
            Assert.AreEqual(numero, ex.Numero);
            Assert.AreEqual(dateAchat, ex.DateAchat);
            Assert.AreEqual(photo, ex.Photo);
            Assert.AreEqual(idEtat, ex.IdEtat);
            Assert.AreEqual(idDocument, ex.Id);
        }
    }
}