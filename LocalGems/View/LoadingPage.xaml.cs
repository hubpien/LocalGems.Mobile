using LocalGems.Services;

namespace LocalGems.View;

public partial class LoadingPage : ContentPage
{
    private AuthService _authService;
    public LoadingPage( AuthService authService )
	{
		InitializeComponent();

        this._authService = authService;
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (await _authService.IsAuth())
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        else
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

        }
    }
}