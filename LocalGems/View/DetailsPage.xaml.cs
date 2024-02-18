


namespace LocalGems.View;

public partial class DetailsPage : ContentPage
{
    private readonly DetailsViewModel _viewModel;

    public DetailsPage(DetailsViewModel vm)
	{
		InitializeComponent();
		_viewModel = vm;
		BindingContext = vm;
	}

    protected async override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}