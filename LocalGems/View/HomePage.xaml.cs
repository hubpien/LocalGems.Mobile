
using LocalGems.ViewModels;
using Syncfusion.Maui.Core.Carousel;
using Syncfusion.Maui.ListView;

namespace LocalGems.View
{
    public partial class HomePage : ContentPage
    {
        private readonly HomeViewModel _viewModel;

        public HomePage(HomeViewModel vm)
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

}
