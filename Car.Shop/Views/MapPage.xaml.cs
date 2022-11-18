using Car.Shop.Context;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace Car.Shop.Views;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		InitializeComponent();
      
        map.IsShowingUser = true;
    

	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();


        var location = await Geolocation.Default.GetLocationAsync();
        MapSpan mapSpan = MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(5));
        map.MoveToRegion(mapSpan);

        var carsForSale = new RestService().GetCars();

        foreach (var car in carsForSale)
        {
            if (car.Lat is null || car.Lon is null)
                continue;

            map.Pins.Add(new Pin { Label = car.Description, Location = new Location(car.Lat.Value, car.Lon.Value) });
        }

    }

}