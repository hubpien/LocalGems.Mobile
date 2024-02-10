using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocalGems.Models;
using LocalGems.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocalGems.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the login form model.
        /// </summary>
        public LoginFormModel LoginFormModel { get; set; }
        public ICommand LoginCommand { get; }

        public LoginPageViewModel()
        {
            this.LoginFormModel = new LoginFormModel();
            LoginCommand = new Command(OnLoginExecuted, CanLoginExecute);
        }

        private bool CanLoginExecute(object parameter)
        {
            // Tutaj możesz dodać logikę sprawdzającą, czy komenda może być wykonana.
            // Na przykład: upewnij się, że email i hasło nie są puste.
            return true;
        }

        private async void OnLoginExecuted(object parameter)
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
