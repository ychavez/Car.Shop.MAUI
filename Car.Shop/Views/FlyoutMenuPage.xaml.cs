using Car.Shop.Views.Models;

namespace Car.Shop.Views;

public partial class FlyoutMenuPage : ContentPage
{

    public CollectionView CollectionView;

    public FlyoutMenuPage()
    {
        InitializeComponent();

        var menuList = new List<FlyoutPageItem> {
            new FlyoutPageItem { IconSource= "map.png", Title = "Mapa", Target = typeof(MapPage) },
            new FlyoutPageItem { IconSource = "favourite.png", Title = "Favoritos", Target = typeof(FavouritePage) },
            new FlyoutPageItem { IconSource = "clipboard.png", Title = "Lista", Target = typeof(ListPage) }
        };

        MenuCollection.ItemsSource = menuList;

        CollectionView = MenuCollection;

    }

  
}