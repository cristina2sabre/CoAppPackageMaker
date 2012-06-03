using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CoApp.Developer.Toolkit.Scripting.Languages.PropertySheet;
using CoApp.Packaging;
using CoApp.Packaging.Client;
using CoAppPackageMaker.ViewModels.RuleViewModels;


namespace CoAppPackageMaker.ViewModels.Base
{
    class MainWindowViewModel:ViewModelBase
    {
        private string _ruleNameSelectedItem;
        private ObservableCollection<string> _ruleNames;
        private ObservableCollection<string> _roleNames;
        //the key is the name of the rule property, the list contains values
        private Dictionary<string, List<string>> _dictionaryHistory;
        private PackageViewModel _packageViewModel;
        private MetadataViewModel _metadataViewModel;
        private RequiresViewModel _requiresViewModel;
        private PackageCompositionViewModel _packageCompositionViewModel;
      
        private ObservableCollection<FilesViewModel> _filesCollection;
        public MainWindowViewModel()
        {
         PathToFile = "D:\\P\\procmon\\copkg\\procmon.autopkg";
         if (PathToFile != null && File.Exists(PathToFile))
          {
              
              LoadData();
          }  
           
           
        }

        private void LoadData()
        {
            _dictionaryHistory = new Dictionary<string, List<string>>();
            PackageReader reader = new PackageReader();
          
            reader.Read(PathToFile);
           
            _ruleNames = reader.Rules;
            _roleNames = reader.Roles;
            CreateModels(reader);

            IEnumerable<string> asd = reader.GetRulesPropertyValues("files", "include");
            List<string> sfasfa = asd.ToList();
            string dwdw = asd.First();
            reader.ReadFilesParameters();
            string sfasffa = reader.GetRolesPropertyValueByName("faux-pax", "downloadsprocmon.chm");
        }

        private  string _pathToFile;

        public string PathToFile
        {
            get { return _pathToFile; }
            set
            {
                _pathToFile = value;
                OnPropertyChanged("PathToFile");

               

            }
        }

        
        private void CreateModels(PackageReader reader)
        {
            string package = "package";
            _packageViewModel = new PackageViewModel()

            {
                Name = reader.GetRulesPropertyValueByName(package, "name"),
                DisplayName = reader.GetRulesPropertyValueByName(package, "display-name"),
                Architecture = reader.GetRulesPropertyValueByName(package, "arch"),
                Feed = reader.GetRulesPropertyValueByName(package, "feed"),
                Location = reader.GetRulesPropertyValueByName(package, "location"),
                Publisher = reader.GetRulesPropertyValueByName(package, "publisher"),
                Version = reader.GetRulesPropertyValueByName(package, "version")
            };

            string metadata = "metadata";
            _metadataViewModel = new MetadataViewModel()
            {
                Summary = reader.GetRulesPropertyValueByName(metadata, "summary"),
                Description = reader.GetRulesPropertyValueByName(metadata, "description"),
                AuthorVersion = reader.GetRulesPropertyValueByName(metadata, "author-version"),
                BugTracker = reader.GetRulesPropertyValueByName(metadata, "bug-tracker"),
                Stability = reader.GetRulesPropertyValueByName(metadata, "stability"),
                Licenses = reader.GetRulesPropertyValueByName(metadata, "licenses"),
            };

            //_requiresViewModel = new RequiresViewModel()
            //{

            //    RequiredPackages = new ObservableCollection<Package>()
            //};

            _packageCompositionViewModel = new PackageCompositionViewModel()
            {
                Symlinks = reader.GetRulesPropertyValueByName("package-composition", "symlinks")


            };


            _packageCompositionViewModel = new PackageCompositionViewModel()
            {
                Symlinks = reader.GetRulesPropertyValueByName("package-composition", "symlinks")


            };

         

            _filesCollection = new ObservableCollection<FilesViewModel>();
           
            foreach (string parameter in reader.ReadFilesParameters())
            {
               
                ObservableCollection<string> collection = new ObservableCollection<string>(reader.GetFilesIncludeList(parameter));
               
                FilesViewModel model = new FilesViewModel(parameter)
                                      {
                                          Root = reader.GetFilesRulesPropertyValueByParameterAndName(parameter,"root"),
                                          TrimPath = reader.GetFilesRulesPropertyValueByParameterAndName(parameter, "trim-path"),
                                          Include = collection
                                      };
                _filesCollection.Add(model);
            }
           
           
        }

        #region ViewModels
        public PackageViewModel PackageViewModel
        {
            get
            {
                return _packageViewModel;
            }
            set
            {
                _packageViewModel = value;
                OnPropertyChanged("PackageViewModel");
            }
        }


        public MetadataViewModel MetadataViewModel
        {
            get
            {
                return _metadataViewModel;
            }
            set
            {
                _metadataViewModel = value;
                OnPropertyChanged(" MetadataViewModel");
            }
        }

        public RequiresViewModel RequiresViewModel
        {
            get
            {
                return _requiresViewModel;
            }
            set
            {
                _requiresViewModel = value;
                OnPropertyChanged("RequiresViewModel");
            }
        }

        public PackageCompositionViewModel PackageCompositionViewModel
        {
            get
            {
                return _packageCompositionViewModel;
            }
            set
            {
               _packageCompositionViewModel = value;
                OnPropertyChanged("PackageCompositionViewModel");
            }
        }
        #endregion ViewModels



        public ObservableCollection<FilesViewModel> FilesCollection
        {
            get { return _filesCollection; }
            set
            {
                _filesCollection = value;
                OnPropertyChanged("FilesCollection");
            }
        }

         public ObservableCollection<string> RulesNames
         {
             get { return _ruleNames; }
             set
             {
                 _ruleNames = value;
                 OnPropertyChanged("RulesNames");
             }
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

        //used for binding between Rule and it's properties and values
         public String RuleNameSelectedItem
         {
             get { return _ruleNameSelectedItem; }
             set
             {
                 _ruleNameSelectedItem = value;
                 OnPropertyChanged("RuleNameSelectedItem");
             }
         }

        

       

        
        
         #region Commands

         public ICommand DeleteCommand
         {
             get { return new RelayCommand(DeleteExecute, CanDeleteExecute); }
         }

        public ICommand SaveCommand
         {
             get { throw new NotImplementedException(); }
         }

         public ICommand ResetCommand
         {
             get { throw new NotImplementedException(); }
         }

         public ICommand NewCommand
         {
             get { return new RelayCommand(NewExecute, CanNewExecute); }
         }

         public ICommand UndoCommand
         {
             get { throw new NotImplementedException(); }
         }

         public ICommand RedoCommand
         {
             get { throw new NotImplementedException(); }
         }


#endregion


#region methods

         void DeleteExecute()
         {
             if (CanDeleteExecute() )
             {
                 try
                 {
                     _ruleNames.Remove(this._ruleNameSelectedItem);

                     // ResetForm();
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
             }
         }


        bool CanDeleteExecute()
         {
          return this.RuleNameSelectedItem!=null;
            
         }


         void NewExecute()
         {
             if (CanNewExecute())
             {
                 try
                 {
                     _ruleNames.Add(this._ruleNameSelectedItem);

                     // ResetForm();
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
             }
         }


         bool CanNewExecute()
         {
             //to add if rule properties have correct values
             return this.RuleNameSelectedItem != null;
         }

#endregion
    }
}
