using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Techem.Models;

namespace Techem.Data
{
    public class TechemDataBase
    {
        private readonly SQLiteAsyncConnection db;

        public TechemDataBase(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);
            db.CreateTableAsync<City>();
        }

        public async Task<int> SaveAsync(City city)
        {
            if(city.ID == 0)
            {
                //var ct = await db.FindAsync<City>(x => x.Name == city.Name);
                List<City> cities = await db.QueryAsync<City>("SELECT * FROM [City] WHERE [Name]=?", city.Name);
                if(cities.Count == 0)
                    return await db.InsertAsync(city);
                throw new Exception("L'élément existe déjà");
            }
            else
            {
                return await db.UpdateAsync(city);
            }
        }
    }
}
