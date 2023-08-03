using EstateV1App.Pages;

namespace EstateV1App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new HomePage();
        }
    }
}