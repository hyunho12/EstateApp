using EstateV1App.Models;
using EstateV1App.Services;

namespace EstateV1App.Pages;

public partial class PropertyDetailPage : ContentPage
{
    private bool IsBookmarkEnabled;
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
        LblPrice.Text = "$ " + property.Price;
        LblDescription.Text = property.Detail;
        LblAddress.Text = property.Address;
        ImgProperty.Source = property.FullImageUrl;

        if(property.Bookmark == null)
        {
            ImgbookmarkBtn.Source = "bookmark_empty_icon";
            IsBookmarkEnabled = false;
        }
        else
        {
            ImgbookmarkBtn.Source = property.Bookmark.Status ? "bookmark_fill_icon" : "bookmark_empty_icon";
            IsBookmarkEnabled = true;
            bookmarkId = property.Bookmark.Id;
        }
    }    

    private async void ImgbookmarkBtn_Clicked(object sender, EventArgs e)
    {
        if(IsBookmarkEnabled == false)
        {
            // add bookmark
            var addBookmark = new AddBookmark()
            {
                User_Id = Preferences.Get("userid", 0),
                PropertyId = propertyId
            };
            var response = await ApiService.AddBookmark(addBookmark);
            if (response)
            {
                ImgbookmarkBtn.Source = "bookmark_fill_icon";
                IsBookmarkEnabled = true;
            }
        }
        else
        {
            //delete bookmark
            var response = await ApiService.DeleteBookmark(bookmarkId);
            if (response)
            {
                ImgbookmarkBtn.Source = "bookmark_empty_icon";
                IsBookmarkEnabled = false;
            }
        }
    }

    private void TapCall_Tapped(object sender, EventArgs e)
    {

    }

    private void TapMessage_Tapped(object sender, EventArgs e)
    {

    }
}