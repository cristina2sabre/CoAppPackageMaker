using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CoApp.Autopackage;
using CoApp.Developer.Toolkit.Scripting.Languages.PropertySheet;

namespace CoAppPackageMaker.ViewModels
{
   
        public class CustomRulesViewModel : ExtraPropertiesViewModelBase, IRules
        {
            private ObservableCollection<string> _customRuleNames;


            public CustomRulesViewModel(string pathToPackage)
            {
                _customRuleNames = new ObservableCollection<string>();
                LoadRulesNames(pathToPackage);
            }

            public ObservableCollection<string> CustomRulesNames
            {
                get { return _customRuleNames; }
                set
                {
                    _customRuleNames = value;
                    OnPropertyChanged("CustomRulesNames");
                }
            }


            public ObservableCollection<string> LoadRulesNames(string pathToPackage)
            {
                //using filepath _pathToPackage
                PackageSource packageSource = new PackageSource(new AutopackageMain());
               // to be addde in PackageSource packageSource.AllCustomRules?
                return _customRuleNames;

            }
        }
    }

