using EstateApp.Services;

namespace EstateApp.Pages;

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
            //await Navigation.PushModalAsync(new HomePage());
            Application.Current.MainPage = new CustomTabbedPage();
        }
        else
        {
            await DisplayAlert("", "Oops something went wrong", "Cancel");
        }
    }

    private async void TapJoinNow_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new HomePage());
    }
}