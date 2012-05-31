﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
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
           // PackageViewModel mod=new PackageViewModel();
            _ruleNames=new ObservableCollection<string>();
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

        

        private string _test;

        public string Test
        {
            get { return _test; }
            set
            {
                _test = value;
                OnPropertyChanged("Test");
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
