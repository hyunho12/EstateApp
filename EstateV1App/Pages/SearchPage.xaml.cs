using EstateV1App.Models;
using EstateV1App.Services;

namespace EstateV1App.Pages;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();
	}

    private void ImgBackBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();       
    }

    private async void SbProperty_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue == null) return;
        var propertiesResult = await ApiService.FindProperties(e.NewTextValue);
        CvSearch.ItemsSource = propertiesResult;
    }

    private void CvSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //var currentSelection = e.CurrentSelection.FirstOrDefault() as SearchProperty;
        //if (currentSelection == null) return;
        //Navigation.PushAsync(new PropertyDetailPage(currentSelection.Id));
        ////await Shell.Current.Navigation.PushAsync(new PropertyDetailPage(currentSelection.Id));
        //((CollectionView)sender).SelectedItem = null;
    }

    private void SbProperty_SearchButtonPressed(object sender, EventArgs e)
    {
        
    }
}