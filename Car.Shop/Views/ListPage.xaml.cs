using Car.Shop.Context;
using Car.Shop.Models;
using CommunityToolkit.Mvvm.Messaging;

namespace Car.Shop.Views;

public partial class ListPage : ContentPage
{
    IDispatcherTimer timer;


    public ListPage()
    {
        InitializeComponent();
        LoadList();

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);

        timer.Start();

        timer.Tick += Timmer_Tick;

        if (!WeakReferenceMessenger.Default.IsRegistered<string>(""))
            WeakReferenceMessenger.Default.Register<string>("", (o, s) =>
            {

                LoadList();
            });



        void LoadList()
        {
            CarsList.ItemsSource = new RestService().GetCars();
        }
    }



    private void Timmer_Tick(object x, EventArgs y)
    {

        timer.Stop();
        if (textSearched == (srchVehiculo.Text ?? ""))
            return;

        textSearched = srchVehiculo.Text.ToUpper();

        var carSearched = new RestService().GetCars().Where(x =>
        (x.Model?.ToUpper().Contains(textSearched) ?? false) ||
               (x.Description?.ToUpper().Contains(textSearched) ?? false) ||
         (x.Brand?.ToUpper().Contains(textSearched) ?? false));


        CarsList.ItemsSource = carSearched;
    }



    string textSearched = string.Empty;

    private void srchVehiculo_TextChanged(object sender, TextChangedEventArgs e)
    {

        timer.Stop();
        timer.Start();

    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new AddCar());

    }

    private async void btnFavourite_Clicked(object sender, EventArgs e)
    {
        var favoriteResult = await new DataContext().SetasFavorite((CarModel)((ImageButton)sender).BindingContext);

        await DisplayAlert("Auto Favorito", favoriteResult ? "Auto agregado correctamente" : "El auto ya se encuentra en favoritos", "Ok");

    }
}