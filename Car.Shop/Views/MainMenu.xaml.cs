namespace Car.Shop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : FlyoutPage
    {
        public MainMenu()
        {
            //InitializeComponent();
            //FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuFlyoutMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

           // FlyoutPage.ListView.SelectedItem = null;
        }
    }
}