using CommunityToolkit.Mvvm.ComponentModel;
using LocalGems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.ViewModels
{
    [QueryProperty(nameof(User), "User")]
    public partial class ProfilViewModel : BaseViewModel
    {
        [ObservableProperty]
		private User user;

	

	}
}
