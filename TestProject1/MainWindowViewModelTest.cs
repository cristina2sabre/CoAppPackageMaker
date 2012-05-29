using CoAppPackageMaker.ViewModels.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CoAppPackageMaker.ViewModels;
using System.Collections.ObjectModel;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for MainWindowViewModelTest and is intended
    ///to contain all MainWindowViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainWindowViewModelTest
    {
       
        /// <summary>
        ///A test for AddRule
        ///</summary>
        [TestMethod]
        public void TestNewRuleIsAdded()
        {
            MainWindowViewModel mainWindowViewModel= new MainWindowViewModel( );
            mainWindowViewModel.RulesNames = new ObservableCollection<string>(){"package"};
            mainWindowViewModel.AddRule("manifest");
            Assert.AreEqual(2,mainWindowViewModel.RulesNames.Count);
        }


        //after adding commands ->more tests for commands
    }
}
