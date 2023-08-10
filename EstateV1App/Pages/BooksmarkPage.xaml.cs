using EstateV1App.Models;
using EstateV1App.Services;

namespace EstateV1App.Pages;

public partial class BooksmarkPage : ContentPage
{
	public BooksmarkPage()
	{
		InitializeComponent();
		GetPropertiesList();
	}

    private async void GetPropertiesList()
    {
        var properties = await ApiService.GetBookmarkList();
        CvProperties.ItemsSource = properties;
    }

    private void CvProperties_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as BookmarkList;
        if(currentSelection == null) return;
        Navigation.PushAsync(new PropertyDetailPage(currentSelection.PropertyId));
        ((CollectionView)sender).SelectedItem = null;
    }
}