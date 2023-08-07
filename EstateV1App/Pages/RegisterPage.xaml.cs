using EstateV1App.Services;

namespace EstateV1App.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
        CheckAccessToken();
	}

    private async void CheckAccessToken()
    {
        var accessToken = Preferences.Get("accesstoken", string.Empty);
        if(string.IsNullOrEmpty(accessToken) )
        {
            await Shell.Current.GoToAsync("///register");
        }
        else
        {
            await Shell.Current.GoToAsync("///home");
        }
    }

    private async void BtnRegister_Clicked(object sender, EventArgs e)
    {
        var response = await ApiService.RegisterUser(EntFullName.Text, EntEmail.Text, EntPassword.Text, EntPhone.Text);
        if (response)
        {
            await DisplayAlert("", "이용자 등록성공", "확인");

            await Shell.Current.GoToAsync("///login");
        }
        else
        {
            await DisplayAlert("", "이용자 등록실패", "확인");
        }

    }

    private async void TapLogin_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage());
    }
}