using EstateV1App.Services;

namespace EstateV1App.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        GetCategories();
	}

    private async void GetCategories()
    {
        var categories = await ApiService.GetCategories();
        CvCategories.ItemsSource = categories;
    }
}