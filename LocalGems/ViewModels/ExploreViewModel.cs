using LocalGems.Models;
using LocalGems.Services;
using Syncfusion.Maui.Maps;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LocalGems.ViewModels
{
    public partial class ExploreViewModel : BaseViewModel
    {
         private IDatabaseService _databaseService;

        public ExploreViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [ObservableProperty]
        private IEnumerable<User> users = Enumerable.Empty<User>();

        [ObservableProperty]
        private bool isRefreshing;

        private bool isInitialized;

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;
            isInitialized = true;

            await LoadAllUsers(true);
        }

        private async Task LoadAllUsers(bool initialLoad)
        {
            if (initialLoad)
                IsBusy = true;
            else
                IsRefreshing = true;
            try
            {
                await Task.Delay(100);
                Users = _databaseService.GetAllUsers();
                
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Error in loading pets", ex.Message);
            }
            finally
            {
                IsBusy = IsRefreshing = false;
            }
        }

        [RelayCommand]
        private async Task LoadUsers() => await LoadAllUsers(false);
    }
}