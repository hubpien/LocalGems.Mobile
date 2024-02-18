using LocalGems.ViewModels;
using Syncfusion.Maui.Maps;

namespace LocalGems.View;

public partial class ExplorePage : ContentPage
{
	public ExplorePage( ExploreViewModel vm )
	{
		InitializeComponent();
		BindingContext = vm;
    }

}