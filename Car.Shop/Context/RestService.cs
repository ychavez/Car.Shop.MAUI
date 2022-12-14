using Car.Shop.Models;
using System.Text;
using System.Text.Json;

namespace Car.Shop.Context
{
    public class RestService
    {
        HttpClient httpClient;
        Uri urlBase;

        public RestService()
        {
            urlBase = new Uri("https://carshopwebapi.azurewebsites.net/api/");
            httpClient = new();
            httpClient.BaseAddress = urlBase;
        }

        public List<CarModel> GetCars() 
        {

            var response = httpClient.GetAsync("carsForSalesApi").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<List<CarModel>>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }

            throw new Exception("Error al tratar de obtener la informacion");
        }

        public void SetCar(CarModel car) 
        {
            var json = JsonSerializer.Serialize(car);

            var data = new StringContent(json, Encoding.UTF8 ,"application/json");

            var response = httpClient.PostAsync("carsForSalesApi", data).Result;


            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al tratar de enviar la informacion");

        }


    }
}
