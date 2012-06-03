using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Policy;

namespace CoAppPackageMaker.ViewModels
{
    class MetadataViewModel : ExtraPropertiesViewModelBase
    {
        private string _summary;
        private string _description;
        private string _authorVersion;
        private string _bugTracker;
        private string _stability;
        private string _licenses;
       

        public String Summary
        {
            get { return _summary; }
            set
            {
                _summary = value;
                OnPropertyChanged("Summary");
            }
        }

        public String Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public String AuthorVersion
        {
            get { return _authorVersion; }
            set
            {
                _authorVersion = value;
                OnPropertyChanged("AuthorVersion");
            }
        }

        public String BugTracker
        {
            get { return _bugTracker; }
            set
            {
                _bugTracker = value;
                OnPropertyChanged("BugTracker");
            }
        }

        public String Stability
        {
            get { return _stability; }
            set
            {
                _stability = value;
                OnPropertyChanged("Stability");
            }
        }

        public String Licenses
        {
            get { return _licenses; }
            set
            {
                _licenses = value;
                OnPropertyChanged("Licenses");
            }
        }
      

    }
}
