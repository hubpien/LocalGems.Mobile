using LocalGems.View;

namespace LocalGems.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        protected async Task ShowAlertAsync(string title, string message, string buttonText = "Ok") =>
         await App.Current.MainPage.DisplayAlert(title, message, buttonText);


        public async Task GoToAsync(ShellNavigationState state) =>
            await Shell.Current.GoToAsync(state);

        [RelayCommand]
        private async Task GoToDetailsPage(int userId) =>
            await GoToAsync($"{nameof(DetailsPage)}?{nameof(DetailsViewModel.UserId)}={userId}");


        public async Task ShowToastAsync(string message) =>
                await Toast.Make(message).Show();

        protected async Task<bool> ShowConfirmAsync(string title, string message, string okButtonText, string cancelButtonText) =>
           await App.Current.MainPage.DisplayAlert(title, message, okButtonText, cancelButtonText);


    }


}