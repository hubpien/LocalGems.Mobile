
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocalGems.Models;
using LocalGems.Services;
using LocalGems.View;
using System.Collections.ObjectModel;

namespace LocalGems.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public readonly IDatabaseService databaseService;

        [ObservableProperty]
		Location? currentLocation;
        
        [ObservableProperty]
		ObservableCollection<User>? users;

        [ObservableProperty]
        ObservableCollection<UserType> userTypes;

        [ObservableProperty]
        ObservableCollection<UserType> selectedUserTypes;


        public MainViewModel(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        private void GetNearUsers()
        {
            Users = databaseService.GetUsers();   
            UserTypes = new ObservableCollection<UserType>(Users.Select(u => u.Type).GroupBy(ut => ut.Value).Select(g => g.First()).ToList());

        }

        [RelayCommand]
        async void Location()
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();

            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            CurrentLocation = await Geolocation.GetLocationAsync(request);
            GetNearUsers();
        }


        [RelayCommand]
        async void Filter(UserType selectedUserType)
        {
            //TODO: filtorwanie po wiekszej ilosci parametrow
            
            //if (!selectedUserTypes.Contains(selectedUserType))
            //{
            //    selectedUserTypes.Add(selectedUserType);
            //}
            //else
            //{
            //    selectedUserTypes.Remove(selectedUserType);
            //}
            Users = databaseService?.GetUsers(selectedUserType.Value);
        }

        [RelayCommand]
        async void NavigateToProfile(User user)
        {
            await Shell.Current.GoToAsync($"//{nameof(ProfilPage)}");

        }
    }
}
