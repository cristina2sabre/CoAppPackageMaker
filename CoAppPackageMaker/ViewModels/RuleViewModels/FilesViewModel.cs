using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CoAppPackageMaker.ViewModels.RuleViewModels
{
    class FilesViewModel:ExtraPropertiesViewModelBase
    {     
        
        public FilesViewModel(String paramater)
        {
            Name = String.Format("Files[{0}]",paramater);
        }

        public FilesViewModel()
        {
        }

        private string _root;

        public string Root
        {
            get { return _root; }
            set
            {
                _root = value;
                OnPropertyChanged("Root");
            }
        }


        private string _trimPath;

        public string TrimPath
        {
            get { return _trimPath; }
            set
            {
                _trimPath = value;
                OnPropertyChanged("TrimPath");
            }
        }

        private ObservableCollection<string> _include;

        public ObservableCollection<string> Include
        {
            get { return _include; }
            set
            {
                _include = value;
                OnPropertyChanged("Include");
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        

        
        
    }
}
