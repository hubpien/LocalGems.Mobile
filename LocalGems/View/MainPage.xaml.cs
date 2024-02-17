
using LocalGems.ViewModels;
using Syncfusion.Maui.ListView;

namespace LocalGems.View
{
    public partial class MainPage : ContentPage
    {
        private SfListView listview;
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = mainViewModel;

        }

    
    }

}
