using Car.Shop.Views.Models;

namespace Car.Shop.Views;

public partial class FlyoutMenuPage : ContentPage
{
    public FlyoutMenuPage()
    {
        InitializeComponent();

        var menuList = new List<FlyoutPageItem> {
            new FlyoutPageItem { IconSource= "map.png", Title = "Mapa", Target = typeof(MapPage) },
            new FlyoutPageItem { IconSource = "favourite.png", Title = "Favoritos", Target = typeof(FavouritePage) },
            new FlyoutPageItem { IconSource = "clipboard.png", Title = "Lista", Target = typeof(ListPage) }
        };

        MenuCollection.ItemsSource = menuList;

    }

    private void MenuCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item is not null)
        {
            /// cambiar la pagina
        }

    }
}