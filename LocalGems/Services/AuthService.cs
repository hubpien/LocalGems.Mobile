using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.Services;
    
public class AuthService
{
    private readonly CommonService _commonService;
    private readonly IDatabaseService _databaseService;

    public AuthService(CommonService commonService, IDatabaseService databaseService)
    {
        _commonService = commonService;
        _databaseService = databaseService;
    }
    public async Task<bool> LoginRegisterAsync(LoginRegisterModel model)
    {
        User user = null;
        try
        {
            if (model.IsNewUser)
            {
                user = _databaseService.GetUser();
                //apiResponse = await _authApi.RegisterAsync(new RegisterRequestDto
                //{
                //    Email = model.Email,
                //    Name = model.Name,
                //    Password = model.Password,
                //});
            }
            else
            {
                user = _databaseService.GetUser();
                //apiResponse = await _authApi.LoginAsync(new LoginRequestDto
                //{
                //    Email = model.Email,
                //    Password = model.Password,
                //});
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            return false;
        }

        if (user.Id == 0)
        {
            await App.Current.MainPage.DisplayAlert("Error", user.Id.ToString(), "Ok");
            return false;
        }

        var loggedUser = new LoggedInUser(user.Id, user.Name, "token");
        SetUser(loggedUser);

        _commonService.SetToken("token");
        _commonService.ToggleLoginStatus();

        return true;
    }

    private void SetUser(LoggedInUser user) => Preferences.Default.Set(UIConstants.UserInfo, user.ToJson());

    public void Logout()
    {
        _commonService.SetToken(null);
        Preferences.Default.Remove(UIConstants.UserInfo);
        _commonService.ToggleLoginStatus();
    }

    public LoggedInUser GetUser()
    {
        var userJson = Preferences.Default.Get(UIConstants.UserInfo, string.Empty);
        return LoggedInUser.LoadFromJson(userJson);
    }

    public bool IsLoggedIn => Preferences.Default.ContainsKey(UIConstants.UserInfo);

    public bool IsAuth()
    {
        return true;
    }
}

