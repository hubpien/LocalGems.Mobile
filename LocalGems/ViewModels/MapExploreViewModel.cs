using LocalGems.Models;
using LocalGems.Services;
using Syncfusion.Maui.Maps;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LocalGems.ViewModels
{
    public partial class MapExploreViewModel : BaseViewModel
    {
        User _user;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<CustomMarker> _markers;


        public ObservableCollection<CustomMarker> markers
        {
            get { return _markers; }
            set
            {
                _markers = value;
                OnPropertyChanged();
            }
        }




    }
}