namespace LocalGems.Pages;

public partial class OnboardingPage : ContentPage
{
	public OnboardingPage()
	{
		InitializeComponent();

		Preferences.Default.Set(UIConstants.OnboardingShown, string.Empty);
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var parameters = new Dictionary<string, object>
		{
			[nameof(LoginPageViewModel.IsFirstTime)] = true
		};
		await Shell.Current.GoToAsync($"//{nameof(LoginPage)}", parameters);
    }
}