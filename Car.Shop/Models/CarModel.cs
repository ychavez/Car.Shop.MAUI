using SQLite;

namespace Car.Shop.Models;

public class CarModel
{
    [PrimaryKey,AutoIncrement]
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


/*
 * 
 * Practica 1 de 2
 * agregar un boton al menu llamado mis lugares
 * esto nos va a llevar a una lista en donde tendremos
 * conectado a sqlite una tabla con Lugares que incluyen:
 * Titulo, Latitud y Longitud
 * y agregar otra vista para dar de alta nuevos lugares
 * nota la lista tiene que tener opcion para poder eliminar
 * 
 */
                                                   