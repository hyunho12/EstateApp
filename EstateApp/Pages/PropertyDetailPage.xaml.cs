using EstateApp.Services;

namespace EstateApp.Pages;

public partial class PropertyDetailPage : ContentPage
{
    private string phoneNumber;
    private int propertyId;
    private int bookmarkId;

	public PropertyDetailPage(int propertyId)
	{
		InitializeComponent();
        GetPropertyDetail(propertyId);
        this.propertyId = propertyId;
	}

    private async void GetPropertyDetail(int propertyId)
    {
        var property = await ApiService.GetPropertyDetail(propertyId);
        LblPrice.Text = "$" + property.Price;
        LblDescription.Text = property.Detail;
        LblAddress.Text = property.Address;
        ImgProperty.Source = property.ImageUrl;
        phoneNumber = property.Phone;        
    }

    private void ImgbackBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void ImgBookmarkBtn_Clicked(object sender, EventArgs e)
    {

    }

    private void TapMessage_Tapped(object sender, EventArgs e)
    {
        var message = new SmsMessage("Hi! I am interested in your property", phoneNumber);
        Sms.ComposeAsync(message);
    }

    private void TapCall_Tapped(object sender, EventArgs e)
    {
        PhoneDialer.Open(phoneNumber);
    }
}