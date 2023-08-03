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

	private async void GetTrendingProperties()
	{

	}

    private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void CvTopPicks_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void TapSearch_Tapped(object sender, EventArgs e)
    {

    }
}