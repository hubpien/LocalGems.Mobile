using LocalGems.Models;
using LocalGems.Services;
using Syncfusion.Maui.Maps;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LocalGems.ViewModels
{
    public class ExploreViewModel : BaseViewModel
    {
        User _user;
        //ObservableCollection<CustomMarker> _markers;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
    }
}