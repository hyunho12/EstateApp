namespace EstateV1App.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private void TapLogout_Tapped(object sender, EventArgs e)
    {
		Preferences.Set("accessToken", string.Empty);
		Application.Current.MainPage = new LoginPage();
    }
}