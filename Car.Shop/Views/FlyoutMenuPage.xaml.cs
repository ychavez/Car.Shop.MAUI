using Car.Shop.Views.Models;

namespace Car.Shop.Views;

public partial class FlyoutMenuPage : ContentPage
{
    public FlyoutMenuPage()
    {
        InitializeComponent();

        var menuList = new List<FlyoutPageItem> {
            new FlyoutPageItem { IconSource= "map.png", Title = "Mapa" },
            new FlyoutPageItem { IconSource = "favourite.png", Title = "Favoritos" },
             new FlyoutPageItem { IconSource = "clipboard.png", Title = "Lista" }
        };

        MenuCollection.ItemsSource = menuList;

    }
}