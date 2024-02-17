using LocalGems.Models;
using LocalGems.Services;
using Syncfusion.Maui.Maps;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LocalGems.ViewModels
{
    public partial class MapExploreViewModel : ViewModelBase
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

        public ICommand BackCommand => new Command(OnBack);

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData is Message message)
            {
                User = message.Sender;
            }

            return base.InitializeAsync(navigationData);
        }

        void OnBack()
        {
            NavigationService.Instance.NavigateBackAsync();
        }



    }
}