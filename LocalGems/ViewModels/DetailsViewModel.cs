using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocalGems.Models;
using LocalGems.Services;
using LocalGems.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.ViewModels
{
    [QueryProperty(nameof(UserId), nameof(UserId))]
    public partial class DetailsViewModel : BaseViewModel
    {
        public IDatabaseService databaseService;
        public AuthService _authService;

        public DetailsViewModel(IDatabaseService databaseService, AuthService authService)
        {
            this.databaseService = databaseService;
            _authService = authService;
        }

        [ObservableProperty]
        private int userId;

        [ObservableProperty]
        private User user;

        async partial void OnUserIdChanging(int userid)
        {
            IsBusy = true;
            try
            {
                await Task.Delay(100);


                User = databaseService.GetUser(UserId);
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Error in fetching pet details", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        [RelayCommand]
        private async Task GoBack() => await GoToAsync("..");

        //[RelayCommand]
        //private async Task AdoptNowAsync()
        //{
        //    if (!_authService.IsLoggedIn)
        //    {
        //        if (await ShowConfirmAsync("Not Logged in", "You need to be logged in to adopt a pet." + Environment.NewLine + "Do you want to go to login page?", "Yes", "No"))
        //        {
        //            await GoToAsync($"//{nameof(LoginRegisterPage)}");
        //        }
        //        return;
        //    }

        //    IsBusy = true;
        //    try
        //    {
        //        var apiResponse = await _userApi.AdoptPetAsync(PetId);
        //        if (apiResponse.IsSuccess)
        //        {
        //            User.AdoptionStatus = AdoptionStatus.Adopted;
        //            if (_hubConnection is not null)
        //            {
        //                try
        //                {
        //                    await _hubConnection.SendAsync(nameof(IPetHubServer.PetAdopted), PetId);
        //                }
        //                catch (Exception)
        //                {
        //                }
        //            }
        //            await GoToAsync(nameof(AdoptionSuccessPage));
        //        }
        //        else
        //        {
        //            await ShowAlertAsync("Error in adoption", apiResponse.Message);
        //        }
        //        IsBusy = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        await ShowAlertAsync("Error in adoption", ex.Message);
        //        IsBusy = false;
        //    }
        //}


        [RelayCommand]
        private async Task ToggleFavorite()
        {
            if (!_authService.IsAuth())
            {
                await ShowToastAsync("You need to be logged in to mark this pet as favorite");
                return;
            }

            User.IsFavorite = !User.IsFavorite;

            try
            {
                IsBusy = true;
                await databaseService.ToggleFavoritesAsync(UserId);
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;

                //Revert 
                User.IsFavorite = !User.IsFavorite;

                await ShowAlertAsync("Error in toggling favorite status", ex.Message);
            }
        }
    }
}
