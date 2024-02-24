using CommunityToolkit.Mvvm.ComponentModel;
using LocalGems.Models;
using LocalGems.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.ViewModels
{
    [QueryProperty(nameof(User), "User")]
    public partial class ProfilViewModel : BaseViewModel
    {
        private readonly AuthService _authService;
        private IDatabaseService databaseService;

        [ObservableProperty]
		private User user;

        public ProfilViewModel(AuthService authService, IDatabaseService databaseService)
        {
            _authService = authService;
            this.databaseService = databaseService;
        }

        private void OnLoginStatusChanged(object sender, EventArgs e) => SetUserInfo();
      
        private void SetUserInfo()
        {
            if (_authService.IsAuth())
            {
                //var userInfo = _authService.GetUser();
                var userInfo = databaseService.GetUser();
                UserName = userInfo.Name;
                IsLoggedIn = true;
                //_commonService.SetToken(userInfo.Token);
            }
            else
            {
                UserName = "Not Logged In";
                IsLoggedIn = false;
            }
        }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Initials))]
        private string _userName = "Not Logged In";

        [ObservableProperty]
        private bool _isLoggedIn;

        public string Initials
        {
            get
            {
                var parts = UserName.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (parts.Length == 1)
                    return UserName.Length == 1
                            ? UserName          
                            : UserName[..2];   
                return $"{parts[0][0]}{parts[1][0]}";
            }
        }

        [RelayCommand]
        private async Task LoginLogoutAsync()
        {
            if (!IsLoggedIn)
            {
                // We pressed login
                await GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                // We pressed logout
                _authService.Logout();
                await GoToAsync($"//{nameof(HomePage)}");
            }
        }

        //[RelayCommand]
        //private async Task ChangePasswordAsync()
        //{
        //    if (!_authService.IsLoggedIn)
        //    {
        //        await ShowToastAsync("You need to be logged in to change your password");
        //        return;
        //    }

        //    var newPassword = await App.Current.MainPage.DisplayPromptAsync("Change Password", "Change password", placeholder: "Enter new password");
        //    if (!string.IsNullOrWhiteSpace(newPassword))
        //    {
        //        IsBusy = true;
        //        await _userApi.ChangePasswordAsync(new SingleValueDto<string>(newPassword));
        //        IsBusy = false;
        //        await ShowToastAsync("Password changed successfully");
        //    }
        //}
    }
}
