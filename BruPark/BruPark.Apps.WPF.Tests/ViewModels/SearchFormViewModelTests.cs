using BruPark.OpenData.Client;
using BruPark.OpenData.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BruPark.Apps.WPF.ViewModels.Tests
{
    [TestClass]
    public class SearchFormViewModelTests
    {
        [TestMethod]
        public void TestLoadMunicipalities()
        {
            SearchFormViewModel model = new SearchFormViewModel();

            IList<Municipality> municipalities = new MunicipalityManager().GetMunicipalitiesByPostalCode();

            Assert.AreEqual(municipalities.Count, model.Municipalities.Count);
        }

        [TestMethod]
        public void TestRandomize()
        {
            SearchFormViewModel model = new SearchFormViewModel();

            Assert.AreEqual("Randomize", model.RandomizeLabel);

            model.Randomize.Execute(null);

            Assert.AreNotEqual("Randomize", model.RandomizeLabel);
        }
    }
}