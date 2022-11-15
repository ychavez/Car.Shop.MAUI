using Car.Shop.Views;

namespace Car.Shop;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainMenu();
	}
}
