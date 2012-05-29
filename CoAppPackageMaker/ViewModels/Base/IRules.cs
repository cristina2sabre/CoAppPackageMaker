using System.Collections.ObjectModel;

namespace CoAppPackageMaker.ViewModels
{
    interface IRules
    {
     ObservableCollection<string>  LoadRulesNames(string pathToPackage);
    }
}