using Car.Shop.Context;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace Car.Shop.Views;

public partial class MapPage : ContentPage
{
    Microsoft.Maui.Controls.Maps.Map map;
    public MapPage()
	{
		InitializeComponent();


    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(5000);
        var location = await Geolocation.Default.GetLocationAsync();
        map = new(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(5)));
        map.IsShowingUser = true;
        var carsForSale = new RestService().GetCars();

        foreach (var car in carsForSale)
        {
            if (car.Lat is null || car.Lon is null)
                continue;

            map.Pins.Add(new Pin { Label = car.Description, Location = new Location(car.Lat.Value, car.Lon.Value) });
        }

        Content = map;
    }

}