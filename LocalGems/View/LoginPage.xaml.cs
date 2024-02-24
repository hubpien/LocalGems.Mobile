using LocalGems.Services;
using Syncfusion.Maui.Core.Carousel;

namespace LocalGems.View;

public partial class LoginPage : ContentPage
{
    private readonly LoginPageViewModel _viewModel;

    public LoginPage(LoginPageViewModel vm)
    {
        InitializeComponent();

        _viewModel = vm;
        BindingContext = vm;

    }

}