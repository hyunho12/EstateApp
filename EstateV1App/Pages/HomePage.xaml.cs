using EstateV1App.Models;
using EstateV1App.Services;

namespace EstateV1App.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		GetCategories();
		GetTrendingProperties();
	}

    private async void GetCategories()
    {
        var categories = await ApiService.GetCategories();
        CvCategories.ItemsSource = categories;
    }

    private async void GetTrendingProperties()
    {
        var properties = await ApiService.GetRealProperties();
        CvTopPicks.ItemsSource = properties;
    }

    private async void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Category;
        if (currentSelection == null) return;
        //await Navigation.PushAsync(new PropertiesListPage(currentSelection.Id, currentSelection.Name));
        await Shell.Current.Navigation.PushAsync(new PropertiesListPage(currentSelection.Id, currentSelection.Name));
        ((CollectionView)sender).SelectedItem = null;
    }

    private void CvTopPicks_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void TapSearch_Tapped(object sender, EventArgs e)
    {

    }
}