using EstateV1App.Services;

namespace EstateV1App.Pages;

public partial class PropertyDetailPage : ContentPage
{
	public PropertyDetailPage(int propertyId)//
    {
		InitializeComponent();
        GetPropertyDetail(propertyId);
	}

    private async void GetPropertyDetail(int propertyId)
    {
        var property = await ApiService.GetPropertyDetail(propertyId);
        LblPrice.Text = "$ " + property.Price;
        LblDescription.Text = property.Detail;
        LblAddress.Text = property.Address;
        ImgProperty.Source = property.FullImageUrl;
        
    }

    private void ImgbackBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void ImgbookmarkBtn_Clicked(object sender, EventArgs e)
    {

    }

    private void TapMessage_Tapped(object sender, EventArgs e)
    {

    }

    private void TapCall_Tapped(object sender, EventArgs e)
    {

    }
}