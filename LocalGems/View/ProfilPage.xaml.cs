using LocalGems.ViewModels;
using Syncfusion.Maui.Core.Carousel;

namespace LocalGems.View;

public partial class ProfilPage : ContentPage
{
    private readonly ProfilViewModel _viewModel;

    public ProfilPage(ProfilViewModel vm)
	{
		InitializeComponent();
        _viewModel = vm;
        BindingContext = vm;
	}

    private async void ProfileOptionRow_Tapped(object sender, string optionText)
    {
        switch (optionText)
        {
            case "Add Photo":
                await _viewModel.GoToAsync(nameof(DetailsPage));
                break;

            case "My Photos":
                await _viewModel.GoToAsync(nameof(DetailsPage));
                break;
        }
    }
}