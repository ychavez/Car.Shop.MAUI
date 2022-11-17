using SQLite;

namespace Car.Shop.Models;

public class CarModel
{
    [PrimaryKey]
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }
    public double? Lat { get; set; }
    public double? Lon { get; set; }
}



                                                   