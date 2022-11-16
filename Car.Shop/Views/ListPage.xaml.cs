using Car.Shop.Context;
using System.Diagnostics;

namespace Car.Shop.Views;

public partial class ListPage : ContentPage
{
    IDispatcherTimer timer;


    public ListPage()
    {
        InitializeComponent();
        CarsList.ItemsSource = new RestService().GetCars();


        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);

        timer.Start();

        timer.Tick += Timmer_Tick;

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
}