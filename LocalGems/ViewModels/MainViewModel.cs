
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

       
    }
}
