using System.ComponentModel;
using CoAppPackageMaker.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Policy;

namespace TestProject1
{


    /// <summary>
    ///This is a test class for PackageViewModelTest and is intended
    ///to contain all PackageViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PackageViewModelTest : ViewModelTest
    {


        [TestMethod]
        public void TestUpdateProperty()
        {
            PackageViewModel target = new PackageViewModel() {Architecture = "86"};
            target.Architecture = "64";
            Assert.AreEqual(target.Architecture,"64");
        }

        [TestMethod]
        public void ChangePropertyOfTheViewModelAndCheckNotifyPropertyChangedWorks()
        {
            CheckPropertyChangedRaised(ChangePackageArhitectureProprety(), "Architecture");
        }

        private Action<PackageViewModel> ChangePackageArhitectureProprety()
        {
            return x => x.Architecture ="sfs";
        }

      
    }

    
    }

