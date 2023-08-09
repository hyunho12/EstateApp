using EstateV1App.Models;
using EstateV1App.Services;

namespace EstateV1App.Pages;

public partial class PropertiesListPage : ContentPage
{
    public PropertiesListPage()
    {
        //InitializeComponent();
    }

    public PropertiesListPage(int categoryId, string categoryName)
	{
		InitializeComponent();
		Title = categoryName;
		GetPropertiesList(categoryId);
	}    

    private async void GetPropertiesList(int categoryId)
    {
        var properties = await ApiService.GetPropertyByCategory(categoryId);
        CvProperties.ItemsSource = properties;
    }

    private void CvProperties_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as PropertyByCategory;
        if (currentSelection == null) return;
        Navigation.PushAsync(new PropertyDetailPage(currentSelection.Id));
        ((CollectionView)sender).SelectedItem = null;
    }
}