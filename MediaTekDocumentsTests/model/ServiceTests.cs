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
    public class ServiceTests
    {
        private const string id = "00001";
        private const string libelle = "catégorie";
        private readonly Service service = new Service(id, libelle);

        /// <summary>
        /// test le constructeur de Service
        /// </summary>
        [TestMethod()]
        public void ServiceTest()
        {
            Assert.AreEqual(id, service.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(libelle, service.Libelle, "devrait réussir : libelle valorisé");
        }
    }
}