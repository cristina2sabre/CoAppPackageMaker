using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CoAppPackageMaker.ViewModels.Base
{
    class MainWindowViewModel:ViewModelBase
    {
        private string _ruleNameSelectedItem;
        private ObservableCollection<string> _ruleNames;

        //the key is the name of the rule property, the list contains values
        private Dictionary<string, List<string>> _dictionaryHistory;
        public MainWindowViewModel()
        {
        }

        //receiving RulesViewModel or RolesViewModel(depends on which tab have been selected)
        public MainWindowViewModel(IRules rulesColection)
        {
          _ruleNames= rulesColection.LoadRulesNames("");
           
          _dictionaryHistory = new Dictionary<string, List<string>>();
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

         public void AddRule(String ruleName)
         {
             
             _ruleNames.Add(ruleName);

                
         }

        
         #region Commands

         public ICommand DeleteCommand
         {
             get { throw new NotImplementedException(); }
         }

        public ICommand SaveCommand
         {
             get { throw new NotImplementedException(); }
         }

         public ICommand CancelCommand
         {
             get { throw new NotImplementedException(); }
         }

         public ICommand NewCommand
         {
             get { throw new NotImplementedException(); }
         }

#endregion
    }
}
