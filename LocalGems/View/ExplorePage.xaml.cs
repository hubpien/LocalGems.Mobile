using LocalGems.ViewModels;
using Syncfusion.Maui.Core.Carousel;
using Syncfusion.Maui.Maps;

namespace LocalGems.View;

public partial class ExplorePage : ContentPage
{
    private ExploreViewModel _viewModel;
	public ExplorePage( ExploreViewModel vm )
    {
        InitializeComponent();

        _viewModel = vm;
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }
}