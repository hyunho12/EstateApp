using EstateApp.Pages;

namespace EstateApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new RegisterPage();
	}
}
