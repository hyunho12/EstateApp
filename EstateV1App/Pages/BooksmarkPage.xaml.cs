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
        //var properties = await ApiService.Get
    }

    private void CvProperties_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}