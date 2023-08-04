using EstateApp.Models;
using EstateApp.Services;
using Microsoft.Maui.Controls;

namespace EstateApp.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		GetCategories();
		GetTrendingProperties();
	}

	private async void GetTrendingProperties()
	{
		var properties = await ApiService.GetTrendingProperties();
		CvTopPicks.ItemsSource = properties;
	}

	private async void GetCategories()
	{
		var categories = await ApiService.GetCategories();
		CvCategories.ItemsSource = categories;		
	}

    private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		var currentSelection = e.CurrentSelection.FirstOrDefault() as Category;
		if(currentSelection == null)
		{
			return;
		}
		Navigation.PushAsync(new PropertiesListPage(currentSelection.Id, currentSelection.Name));
		((CollectionView)sender).SelectedItem = null;
    }

    private void CvTopPicks_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		var currentSelection = e.CurrentSelection.FirstOrDefault() as TrendingProperty;
		if(currentSelection == null)
		{
			return;
		}
		Navigation.PushAsync(new PropertyDetailPage(currentSelection.Id));
		((CollectionView)sender).SelectedItem = null;
    }


}