using LocalGems.ViewModels;

namespace LocalGems.View;

public partial class ProfilPage : ContentPage
{
	public ProfilPage(ProfilViewModel profilViewModel)
	{
		InitializeComponent();
		BindingContext = profilViewModel;
	}
}