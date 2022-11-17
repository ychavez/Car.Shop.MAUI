using Car.Shop.Context;
using Car.Shop.Models;
using CommunityToolkit.Mvvm.Messaging;

namespace Car.Shop.Views;

public partial class AddCar : ContentPage
{
    public AddCar()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("Cual deberia tomar?", "Cancelar", "Ok", "Foto", "Galeria");


        var photo = action == "Galeria" ? await MediaPicker.Default.PickPhotoAsync()
            : await MediaPicker.Default.CapturePhotoAsync();

        img.Source = ImageSource.FromStream(async x => await photo.OpenReadAsync());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {

        var location = await Geolocation.Default.GetLocationAsync();

        new RestService().SetCar(new CarModel
        {
            Brand = txtMarca.Text,
            Description = txtDescripcion.Text,
            Model = txtModelo.Text,
            Price = double.Parse(txtPrecio.Text),
            PhotoUrl = "https://thumbs.dreamstime.com/b/carro-rojo-con-ojos-y-boca-caricatura-ilustraci%C3%B3n-vectorial-portadora-de-dibujos-animados-r%C3%A1pida-sonriente-amigable-167377186.jpg",
            Year = int.Parse(txtAnio.Text),
            Lat = location.Latitude,
            Lon = location.Longitude
        });

        await Navigation.PopAsync();

        WeakReferenceMessenger.Default.Send<String>("Hola");

    }
}

