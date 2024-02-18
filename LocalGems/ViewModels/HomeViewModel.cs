using CommunityToolkit.Mvvm.ComponentModel;
using LocalGems.Models;
using LocalGems.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LocalGems.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        public IDatabaseService databaseService;
        public AuthService _authService;

        [ObservableProperty]
        private IEnumerable<User> _newlyAdded = Enumerable.Empty<User>();


        [ObservableProperty]
        private IEnumerable<User> _poplar = Enumerable.Empty<User>();

        [ObservableProperty]
        private IEnumerable<User> _random = Enumerable.Empty<User>();

        [ObservableProperty]
        private string _userName = "Stranger";

        private bool _isInitialized;

        public HomeViewModel(IDatabaseService databaseService, AuthService authService)
        {
            this.databaseService = databaseService;
            _authService = authService;
            SetUserInfo();
        }

        private void SetUserInfo()
        {
            if ( !_authService.IsAuth())
            {
                UserName = "Stranger";
            }
            else
            {
                UserName = "Stranger";
            }
        }

        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            IsBusy = true;
            try
            {
                NewlyAdded = databaseService.GetNewlyAddedUsers();
                Poplar = databaseService.GetPopularUsers();
                Random = databaseService.GetRandomUsers();


                _isInitialized = true;
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Error", ex.Message);

            }
            finally 
            { 
                IsBusy = false; 
            }
        }
    }
}