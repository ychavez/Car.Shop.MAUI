using Car.Shop.Context;
using Car.Shop.Models;

namespace Car.Shop.Views;

public partial class FavouritePage : ContentPage
{
    public FavouritePage()
    {
        InitializeComponent();
    }

    private async Task LoadData()
    {
        CarsList.ItemsSource = await new DataContext().GetFavourites();
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
    }

    private async void btnFavourite_Clicked(object sender, EventArgs e)
    {

        var carId = ((CarModel)((ImageButton)sender).BindingContext).Id;

        var result = await new DataContext().RemoveFromFavorites(carId);


        await DisplayAlert("Auto favorito", result ? "El vehiculo se  borro de favoritos correctamente" :
                "Hubo un problema tratando de quitar de vavoritos el vehiculo", "Ok");

        await LoadData();

    }
}