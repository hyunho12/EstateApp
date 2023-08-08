using EstateV1App.Services;

namespace EstateV1App.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        var response = await ApiService.Login(EntEmail.Text, EntPassword.Text);
        if (response)
        {
            await Shell.Current.GoToAsync("///home");
            //await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("", "로그인 에러 발생", "확인");
        }
    }

    private async void TapJoinNow_Tapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///register");
    }
}