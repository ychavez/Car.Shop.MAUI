using Car.Shop.Models;
using SQLite;

namespace Car.Shop.Context
{
    public class DataContext
    {
        SQLiteAsyncConnection db;

        async Task Init()
        {
            if (db is not null)
                return;

            db = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "CarChop.db3"), SQLiteOpenFlags.ReadWrite
                | SQLiteOpenFlags.Create
                | SQLiteOpenFlags.SharedCache);

            var result = await db.CreateTableAsync<CarModel>();
        }

        public async Task<List<CarModel>> GetFavourites()
        {
            await Init();
            return await db.Table<CarModel>().ToListAsync();

        }

        public async Task<CarModel> GetCarById(int id) 
        {
            await Init();
            return await db.Table<CarModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
        
        }


        public async Task<bool> SetasFavorite(CarModel carModel)
        {
            await Init();
            var _car = await GetCarById(carModel.Id);

            if (_car is not null)
                return false;

            await db.InsertAsync(carModel);

            return true;
        }

        public async Task<bool> RemoveFromFavorites(int id) 
        {
            await Init();

            var _car = await GetCarById(id);

            if (_car is  null)
                return false;

            return await db.DeleteAsync(_car) > 0;

        }

    }
}
