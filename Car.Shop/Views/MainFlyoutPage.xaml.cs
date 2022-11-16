using Car.Shop.Views.Models;

namespace Car.Shop.Views;

public partial class MainFlyoutPage : FlyoutPage
{
	public MainFlyoutPage()
	{
		InitializeComponent();
        flyoutPage.CollectionView.SelectionChanged += MenuCollection_SelectionChanged;
        Detail = new NavigationPage(new ListPage());
    }

    private void MenuCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item is not null)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.Target));
            IsPresented = false;
        }

    }
}


