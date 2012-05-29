using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CoApp.Autopackage;
using CoApp.Developer.Toolkit.Scripting.Languages.PropertySheet;

namespace CoAppPackageMaker.ViewModels
{
    public class RolesViewModel : ExtraPropertiesViewModelBase, IRules
    {
        private ObservableCollection<string> _roleNames;
       

        public RolesViewModel(string pathToPackage)
        {
            _roleNames = new ObservableCollection<string>();
            LoadRulesNames(pathToPackage);
        }

        public ObservableCollection<string> RolesNames
        {
            get { return _roleNames; }
            set
            {
                _roleNames = value;
                OnPropertyChanged("RolesNames");
            }
        }


        public ObservableCollection<string> LoadRulesNames(string pathToPackage)
        {
            //using filepath _pathToPackage
            PackageSource packageSource = new PackageSource(new AutopackageMain());
            //expect to obtain form packageSource.AllRoles - application, assembly, developer-library
            foreach (Rule rule in packageSource.AllRoles)
            {
                _roleNames.Add(rule.Name);

            }
            return _roleNames;

        }
    }
}
