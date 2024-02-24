using LocalGems.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.ViewModels
{
    public partial class FavoritesViewModel : BaseViewModel
    {
        private IDatabaseService databaseService;
        private AuthService authService;

        public FavoritesViewModel(IDatabaseService databaseService, AuthService authService)
        {
            this.databaseService = databaseService;
            this.authService = authService;
        }

        [ObservableProperty]
        public ObservableCollection<User> users = new();

        public async Task InitializeAsync()
        {
            if (!authService.IsAuth())
            {
                await ShowToastAsync("You need be logged in to load your favorite pets");
                return;
            }

            try
            {
                IsBusy = true;
                var favorites = databaseService.GetUserFavoritesAsync();
                Users = new ObservableCollection<User>(favorites);
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Error in fetching pets", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private void ToggleFavorite(int userId)
        {
            try
            {
                IsBusy = true;
                var user = databaseService.ToggleFavoritesAsync(userId);
                Users.Remove(user);
                
            }
            catch (Exception)
            {
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
